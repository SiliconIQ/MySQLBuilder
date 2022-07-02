using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace MySQLBuilder
{
    public partial class Form1 : Form
    {
        public string[] fileContents;
        public List<string> outputData = new List<string>();
        public List<SQLColumn> columns = new List<SQLColumn>();
        public List<Thread> processingThreads = new List<Thread>();
        public List<int> idxColsRemove = new List<int>();
        public Form1()
        {
            InitializeComponent();
            cbOperation.SelectedIndex = 0;
        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {

            openFileDialog1.Filter = "JSON files (*.json)|*.json|CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                #region empty_old_data
                writeToConsole("Status", "Clearing Form");
                //Get the path of specified file
                tbInputFilePath.Text = openFileDialog1.FileName;
                // Clear any rows from table
                dgvMapping.Rows.Clear();
                #endregion
                #region load_file
                writeToConsole("Status", "Loading File Contents");
                //Read the contents of the file into a stream
                var fileStream = openFileDialog1.OpenFile();
                List<List<string>> csvContents = new List<List<string>>();
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    fileContents = reader.ReadToEnd().Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    reader.Close();
                }
                writeToConsole("Status", "File loaded");
                #endregion
                #region load_headers
                writeToConsole("Status", "Loading headers");
                if (openFileDialog1.FileName.Contains(".csv"))
                {
                    tbTableName.Text = openFileDialog1.FileName.Replace(".csv", "").Split('\\').Last();
                    // Headers
                    string[] headers = fileContents[0].Split(',');
                    foreach (string header in headers)
                    {
                        dgvMapping.Rows.Add(new string[] { header.Replace("\"", "").Replace("'", "\'"), "" });
                    }
                    writeToConsole("Status", "Headers loaded");
                }
                else if (openFileDialog1.FileName.Contains(".json"))
                {
                    MessageBox.Show("JSON file reading is not yet implemented");
                    //using (StreamReader reader = new StreamReader(fileStream))
                    //{
                    //    JObject json = JObject.Parse(reader.ReadToEnd());

                    //}
                }
                else
                {
                    MessageBox.Show("Unsupported file");
                }
                #endregion
                #region clean_data
                writeToConsole("Status", "Cleaning input data to fit SQL format");
                processingThreads = new Thread[fileContents.Length].ToList();
                cleanValues();
                #endregion
                rtbConsole.Text += "[Status] File ready. Please fill in table." + Environment.NewLine;
                GC.Collect();
                
            }
        }

        private void dgvMapping_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            string operation = cbOperation.Text;
            string previewText = "";
            List<string> columns = new List<string>();
            foreach (DataGridViewRow row in dgvMapping.Rows)
            {
                if (row.Cells["OutputCol"].Value != null)
                {
                    columns.Add("`" + row.Cells["OutputCol"].Value + "`");
                }
            }
            if (operation == "INSERT")
            {
                previewText = "INSERT INTO `" + tbTableName.Text + "` (" + String.Join(",", columns) + ") VALUES (" + String.Join(",", fileContents[1])  + ");";

                rtbConsole.Text += "[Request] Preview Generated" + Environment.NewLine;
            }
            else if (operation == "UPDATE")
            {

            }
            rtbPreview.Text = previewText;
        }

        private void btnSaveConfig_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Configuration saving not implemented yet");
        }

        private void btnSelectDest_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "MySQL files (*.sql)|*.sql|All files (*.*)|*.*";
            saveFileDialog1.FileName = tbTableName.Text;
            saveFileDialog1.FilterIndex = 0;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                tbOutputFile.Text = saveFileDialog1.FileName;

                rtbConsole.Text += "[Request] Output destination selected" + Environment.NewLine;
            }

        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            string operation = cbOperation.Text;
            string previewText = "";
            columns.Clear();

            rtbConsole.Text += "[Request] Collecting column data" + Environment.NewLine;
            foreach (DataGridViewRow row in dgvMapping.Rows)
            {
                if (row.Cells["OutputCol"].Value != null)
                {
                    // This line throws a null exception on the branded foods file
                    int len = 0;
                    if(row.Cells["LengthCol"].Value == null) { len = 0; }
                    else { len = int.Parse(row.Cells["LengthCol"].Value.ToString()); }
                    columns.Add(new SQLColumn() { inputName = row.Cells["InputCol"].Value + "", outputName = "`" + row.Cells["OutputCol"].Value + "`", dataType = row.Cells["DTCol"].Value + "", length = len, isNull = Convert.ToBoolean(row.Cells["colNull"].Value), isPrimary = Convert.ToBoolean(row.Cells["colPrimary"].Value), ignore = Convert.ToBoolean(row.Cells["colIgnore"].Value) });
                }
            }

            rtbConsole.Text += "[Request] Collecting SQL data" + Environment.NewLine;
            // Populate the list of cols to remove
            idxColsRemove = columns.Where(x => x.ignore == true).Select(y => columns.IndexOf(y)).ToList();
            float progress = 0;
            // Safety checks
            if (checkValidity() == true)
            {
                // If "Create Table if Not Exists" is checked
                if (cbCTIfNotExists.Checked == true)
                {
                    outputData.Add("CREATE TABLE IF NOT EXISTS `" + tbTableName.Text + "` (" + String.Join(",", columns.Where(x => x.ignore == false).Select(x => x.outputName + " " + x.dataType + "(" + x.length + ") " + extractProperties(x)).ToList()) + ");");
                    
                }
                if (operation == "INSERT")
                {
                    // If there aren't any columns to remove, don't waste time processing each line as if their could be
                    if(idxColsRemove.Count == 0)
                    {
                        for (var idx0 = 1; idx0 < fileContents.Length; idx0++)
                        {
                            outputData.Add("INSERT INTO `" + tbTableName.Text + "' (" + String.Join(",", columns.Select(x => x.outputName).ToList()) + ") VALUES (" + fileContents[0] + ");");

                            progress += (((idx0 + 1)/(fileContents.Length+1))/2)*1000;
                            while(pbOutput.Value < MathF.Round(progress)) { pbOutput.PerformStep(); };
                        }
                    }
                    // Otherwise, walk through each line and remove the data not wanted
                    else
                    {
                        for (var idx0 = 1; idx0 < fileContents.Length; idx0++)
                        {
                            string line = sortedRowInsertEntry(fileContents[idx0]);
                            if (line != "")
                            {
                                outputData.Add(line);
                                progress += (((idx0 + 1) / (fileContents.Length + 1)) / 2) * 1000;
                                while (pbOutput.Value < MathF.Round(progress)) { pbOutput.PerformStep(); };
                            }
                        }
                    }
                    

                }
                else if (operation == "UPDATE")
                {

                }
                progress = 500f;
                pbOutput.Value = (int)MathF.Round(progress);
                if(nudVolSize.Value == 0)
                {
                    using (StreamWriter sw = new StreamWriter(tbOutputFile.Text))
                    {
                        int idx0 = 0;
                        outputData.ForEach(line => {
                            sw.WriteLine(line);
                            progress += (((idx0 + 1) / (fileContents.Length + 1)) / 2) * 1000;
                            while (pbOutput.Value < MathF.Round(progress)) { pbOutput.PerformStep(); };
                            idx0++;
                        });

                        sw.Close();
                    }
                    resetForm();
                }
                else
                {
                    int vols = (int)Math.Ceiling((float)(outputData.Count / nudVolSize.Value));

                    for(var i = 0; i < vols; i++)
                    {
                        bool quit = false;
                        using (StreamWriter sw = new StreamWriter(tbOutputFile.Text.Replace("." + tbOutputFile.Text.Split('.').Last(), "") + i + "." + tbOutputFile.Text.Split('.').Last()))
                        {
                            for(var j = 0; j < nudVolSize.Value; j++)
                            {
                                int idx = (int)(i * nudVolSize.Value) + j;
                                if(idx == outputData.Count)
                                {
                                    quit = true;
                                    break;
                                }
                                else
                                {
                                    sw.WriteLine(outputData[idx]);
                                }
                                
                            }
                            sw.Close();
                        }
                        if (quit)
                        {
                            break;
                            
                        }
                    }
                    resetForm();
                }
            }
            
        }
        private string sortedRowInsertEntry(string input)
        {
            string dat = "";
            if(idxColsRemove.Count > 0)
            {
                List<string> cur = System.Text.RegularExpressions.Regex.Split(input, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)").ToList();
                //List<string> cur = System.Text.RegularExpressions.Regex.Split(input.Substring(1, input.Length - 2), @"""\s*,\s*""").ToList();
                dat = string.Join(",", cur.Where(x => idxColsRemove.Contains(cur.IndexOf(x)) == false));
            }
            else
            {
                dat= input;
            }

            if(dat != "")
            {
                return "INSERT INTO `" + tbTableName.Text + "' (" + String.Join(",", columns.Where(x => x.ignore == false).Select(x => x.outputName).ToList()) + ") VALUES (" + dat + ");";
            }
            else
            {
                return "";
            }
        }
        private void cleanString(int i)
        {
            List<string> cleanedList = new List<string>();
            // Values that contain commas cannot be split from the file properly
            TextFieldParser parser = new TextFieldParser(new StringReader(fileContents[i]));
            parser.HasFieldsEnclosedInQuotes = true;
            parser.SetDelimiters(",");
            List<string> rawFields = parser.ReadFields().ToList();
            cleanedList.Add(string.Join(",", rawFields.Select(f => "'" + f.Replace("'", "\\'") + "'").ToArray()));
            fileContents[i] = string.Join(",", cleanedList);
            
        }
        private void cleanValues()
        {
            writeToConsole("Status", "Preparing Threads for data cleaning");
            processingThreads.ForEach(t => t = new Thread(new ThreadStart(() =>
            {
                cleanString(processingThreads.IndexOf(t));
                t.Start();
            })));
            writeToConsole("Status", "Commencing all threads for data cleaning");
            //int i = 0;
            //fileContents.ToList().ForEach(line =>
            //{
            //    Parallel.Invoke(() => cleanString(i));
            //    i++;
            //});
        }
        private string extractProperties(SQLColumn x)
        {
            string res = "";
            if(x.isPrimary == true)
            {
                return "AUTO_INCREMENT PRIMARY KEY";
            }
            else if(x.isNull == false)
            {
                return "NOT NULL";
            }
            else
            {
                return "";
            }
        }
        private bool checkValidity()
        {
            if(columns.Where(x => x.isPrimary == true).ToList().Count > 1)
            {
                MessageBox.Show("You cannot have more than one primary column selected");
                return false;
            }
            else if (columns.Where(x => x.outputName.Length == 0).ToList().Count > 0)
            {
                MessageBox.Show("You must specify a name for all columns");
                return false;
            }
            else if (columns.Where(x => x.length < 1).ToList().Count > 0)
            {
                MessageBox.Show("You must specify a length for all columns");
                return false;
            }
            
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvMapping.Rows)
            {
                row.Cells["OutputCol"].Value = row.Cells["InputCol"].Value;
                
            }
        }
        private void writeToConsole(string type, string message)
        {
            rtbConsole.Text += "[" + type + "] " + message + Environment.NewLine;
            rtbConsole.ScrollToCaret();
        }
        private void resetForm()
        {
            #region clearFormData
            // Clear any rows from table
            dgvMapping.Rows.Clear();
            // Remote table name
            tbTableName.Text = "";
            // Remove input path
            tbInputFilePath.Text = "";
            // Remove output path
            tbOutputFile.Text = "";
            // remove preview
            rtbPreview.Text = "";
            #endregion

            #region freeMemory
            // Remove column list
            columns = new List<SQLColumn>();
            // Empty file contents from memory
            Array.Clear(fileContents);
            // Clear memory of output data 
            outputData = new List<string>();
            #endregion
            // Notify of completion
            MessageBox.Show("Operation Complete!");
        }

        private void cbDeleteInputOnCompletion_CheckedChanged(object sender, EventArgs e)
        {
            MessageBox.Show("This feature has not been implemented yet");
        }
    }
}