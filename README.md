# MySQLBuilder
A software for converting between CSV or JSON into MySQL by allowing mapping of fields to target names, and exporting the data in proper format

This was developed to save programmers time when it comes to data mining tasks. I was working on an app that required me to have an extensive database of foods, and the data I found was all CSV or JSON; Which is obviously commonplace when importing data. This inspired me to write a tool (which I hope to expand on in the future to other output types) to do the heavy-lifting for me.

# Known Problems
* For large files, this program is memory intensive. For example, if you run a 2.6gb CSV file through this it may take as much as 24gb of memory. 
* The program does not factor in whether the SQL definition of a certain type will actually require a length
* Many features are incomplete or not implemented like JSON reading
* Many configuration related settings are unavailable as they are not implemented

# Roadmap
* Save configurations and load them for files with similar layouts
* JSON implementation
* Customizable output format (MySQL, NoSQL, SQLite, etc)
