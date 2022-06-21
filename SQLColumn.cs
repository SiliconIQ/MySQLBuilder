using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQLBuilder
{
    public class SQLColumn
    {
        public string inputName {get;set;}
        public string outputName {get;set;}
        public string dataType { get; set; }
        public int length { get; set; }
        public bool isNull { get; set; }
        public bool isPrimary { get; set; }

    }
}
