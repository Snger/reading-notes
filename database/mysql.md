## DROP TABLE IF EXISTS TABLENAME;
1. DROP TABLE removes one or more tables. You must have the DROP privilege for each table. All table data and the table definition are removed, so be careful with this statement! If any of the tables named in the argument list do not exist, MySQL returns an error indicating by name which nonexisting tables it was unable to drop, but it also drops all of the tables in the list that do exist.
2. Use IF EXISTS to prevent an error from occurring for tables that do not exist. A NOTE is generated for each nonexistent table when using IF EXISTS. 

## CREATE TABLE TABLENAME () ENGINE=InnoDB DEFAULT CHARSET=utf8;
1. CREATE TABLE creates a table with the given name. You must have the CREATE privilege for the table.
2. Rules for permissible table names are given in Section 10.2, “Schema Object Names”. By default, the table is created in the default database, using the InnoDB storage engine. An error occurs if the table exists, if there is no default database, or if the database does not exist.
3. The table name can be specified as db_name.tbl_name to create the table in a specific database. This works regardless of whether there is a default database, assuming that the database exists. If you use quoted identifiers, quote the database and table names separately. For example, write `mydb`.`mytbl`, not `mydb.mytbl`.

## ALTER TABLE TABLENAME ADD INDEX IX_TABLENAME_CREATETIME(CREATETIME);
1. ALTER TABLE changes the structure of a table. For example, you can add or delete columns, create or destroy indexes, change the type of existing columns, or rename columns or the table itself. You can also change characteristics such as the storage engine used for the table or the table comment.
2. Indexes are used to retrieve data from the database very fast. The users cannot see the indexes, they are just used to speed up searches/queries.(Note: Updating a table with indexes takes more time than updating a table without (because the indexes also need an update). So, only create indexes on columns that will be frequently searched against.)

## Definition of stored procedures
1. A stored procedure is a segment of declarative SQL statements stored inside the database catalog. A stored procedure can be invoked by triggers, other stored procedures, and applications such as Java, Python, PHP, etc.
2. MySQL is known as the most popular open source RDBMS which is widely used by both community and enterprise. However, during the first decade of its existence, it did not support stored procedures, stored functions, triggers, and events. Since MySQL version 5.0, those features were added to MySQL database engine to make it more flexible and powerful.
3. [advantages] Typically stored procedures help increase the performance of the applications. Once created, stored procedures are compiled and stored in the database. However, MySQL implements the stored procedures slightly different. MySQL stored procedures are compiled on demand. After compiling a stored procedure, MySQL puts it into a cache. And MySQL maintains its own stored procedure cache for every single connection. If an application uses a stored procedure multiple times in a single connection, the compiled version is used, otherwise, the stored procedure works like a query.
4. [advantages] Stored procedures help reduce the traffic between application and database server because instead of sending multiple lengthy SQL statements, the application has to send only name and parameters of the stored procedure.
5. Stored procedures are reusable and transparent to any applications. Stored procedures expose the database interface to all applications so that developers don’t have to develop functions that are already supported in stored procedures.
6. [advantages] Stored procedures are secure. The database administrator can grant appropriate permissions to applications that access stored procedures in the database without giving any permissions on the underlying database tables.
7. [disadvantages] If you use a lot of stored procedures, the memory usage of every connection that is using those stored procedures will increase substantially. In addition, if you overuse a large number of logical operations inside store procedures, the CPU usage will also increase because the database server is not well-designed for logical operations.
8. [disadvantages] Constructs of stored procedures make it more difficult to develop stored procedures that have complicated business logic.
9. [disadvantages] It is difficult to debug stored procedures. Only a few database management systems allow you to debug stored procedures. Unfortunately, MySQL does not provide facilities for debugging stored procedures.
10. [disadvantages] It is not easy to develop and maintain stored procedures. Developing and maintaining stored procedures are often required a specialized skill set that not all application developers possess. This may lead to problems in both application development and maintenance phases.

## How to add new stored procedures to mysql in DataGrip?
1. If you haven't configured connection, please see howto
2. Then open new console for that data source.
3. In console press Alt+Insert that will suggest you to generate code for different objects.
4. After filling template, press Ctrl + Enter to execute

## CREATE PROCEDURE Syntax
1. CREATE PROCEDURE sp_name ([proc_parameter[,...]]) routine_body
2. These statements(CREATE PROCEDURE and CREATE FUNCTION) create stored routines. By default, a routine is associated with the default database. To associate the routine explicitly with a given database, specify the name as db_name.sp_name when you create it.

## INSERT ... SELECT Syntax
1. INSERT [INTO] tbl_name [(col_name,...)] SELECT ...
2. INSERT inserts new rows into an existing table. The INSERT ... VALUES and INSERT ... SET forms of the statement insert rows based on explicitly specified values. The INSERT ... SELECT form inserts rows selected from another table or tables.

## SELECT Syntax
1. SELECT select_expr [, select_expr ...] [FROM table_references] [WHERE where_condition] [ORDER BY {col_name | expr | position} [ASC | DESC], ...] [LIMIT {[offset,] row_count | row_count OFFSET offset}] [PROCEDURE procedure_name(argument_list)]
2. A select_expr can be given an alias using AS alias_name. The alias is used as the expression's column name and can be used in GROUP BY, ORDER BY, or HAVING clauses.
3. The AS keyword is optional when aliasing a select_expr with an identifier. 
4. However, because the AS is optional, a subtle problem can occur if you forget the comma between two select_expr expressions: MySQL interprets the second as an alias name. For this reason, it is good practice to be in the habit of using AS explicitly when specifying column aliases.
5. The FROM table_references clause indicates the table or tables from which to retrieve rows. If you name more than one table, you are performing a join. For each table specified, you can optionally specify an alias. 
6. tbl_name [[AS] alias] [index_hint] -- You can refer to a table within the default database as tbl_name, or as db_name.tbl_name to specify a database explicitly. You can refer to a column as col_name, tbl_name.col_name, or db_name.tbl_name.col_name. You need not specify a tbl_name or db_name.tbl_name prefix for a column reference unless the reference would be ambiguous.

## Case operator -- Control Flow Functions
1. Syntax: CASE value WHEN [compare_value] THEN result [WHEN [compare_value] THEN result ...] [ELSE result] END
2. Syntax: CASE WHEN [condition] THEN result [WHEN [condition] THEN result ...] [ELSE result] END
3. The first version returns the result where value=compare_value. The second version returns the result for the first condition that is true. If there was no matching result value, the result after ELSE is returned, or NULL if there is no ELSE part.
4. The return type of a CASE expression is the compatible aggregated type of all return values, but also depends on the context in which it is used. If used in a string context, the result is returned as a string. If used in a numeric context, the result is returned as a decimal, real, or integer value.

## UPDATE Syntax
1. UPDATE [LOW_PRIORITY] [IGNORE] table_reference SET col_name1={expr1|DEFAULT} [, col_name2={expr2|DEFAULT}] ... [WHERE where_condition] [ORDER BY ...] [LIMIT row_count]
2. For the single-table syntax, the UPDATE statement updates columns of existing rows in the named table with new values. The SET clause indicates which columns to modify and the values they should be given. Each value can be given as an expression, or the keyword DEFAULT to set a column explicitly to its default value. The WHERE clause, if given, specifies the conditions that identify which rows to update. With no WHERE clause, all rows are updated. If the ORDER BY clause is specified, the rows are updated in the order that is specified. The LIMIT clause places a limit on the number of rows that can be updated.

## CURDATE()
1. Returns the current date as a value in 'YYYY-MM-DD' or YYYYMMDD format, depending on whether the function is used in a string or numeric context.
2. mysql> SELECT CURDATE(); -> '2008-06-13'
3. mysql> SELECT CURDATE() + 0; -> 20080613
