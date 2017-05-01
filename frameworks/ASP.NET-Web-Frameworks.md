## WebMatrix.Data Namespace
1. The WebMatrix.Data namespace contains classes that simplify database interaction in ASP.NET Web Pages. This namespace includes classes that help you to open, query, and send commands to a database, and to work with database rows that are returned by SQL queries.
2. [Class]Database: Provides methods and properties that are used to access and manage data that is stored in a database.

## WebMatrix.Data Database Class
1. Provides methods and properties that are used to access and manage data that is stored in a database.
2. [Property]Connection: Gets the current connection to a database.
3. [Method]OpenConnectionString(String): Opens a connection to a database using the specified connection string.
3. [Method]OpenConnectionString(String, String): Opens a connection to a database using the specified connection string.
3. [Method]Query: Executes a SQL query that returns a list of rows as the result.
3. [Method]Execute: Executes a non-query SQL statement.
3. [Method]Close: Closes an open database.
3. [Method]Dispose(): Releases all resources used by a Database instance.
3. [Method]Dispose(Boolean): Releases the unmanaged resources used by a Database instance and optionally releases the managed resources.

