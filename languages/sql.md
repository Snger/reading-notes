# SQL

<!-- MarkdownTOC -->

- Pronouncing SQL: S-Q-L or Sequel?
- The SQL LIKE Operator
- WHERE CustomerName LIKE `a%`
- WHERE CustomerName LIKE `%a`
- WHERE CustomerName LIKE `%or%`
- WHERE CustomerName LIKE `_r%`
- WHERE CustomerName LIKE `a_%_%`
- WHERE ContactName LIKE `a%o`
- SQL LIKE Examples
- SQL JOIN
- COUNT\(expr\)
- CASE WHEN IFNULL\(ftg.ID, 0\) > 0 THEN 1 ELSE 0 END AS Followed
- INSERT INTO ARTICLES \(CATEGORY, TITLE, CREATETIME\) VALUES \(`Help`,`帮助`, now(\))
- INSERT ... SELECT Syntax
- ROW_COUNT\(\)
- FOUND_ROWS\(\)

<!-- /MarkdownTOC -->

## Pronouncing SQL: S-Q-L or Sequel?
> SQL was initially developed at IBM by Donald Chamberlin and Raymond Boyce. It was initially called “Structured English Query Language” (SEQUEL) and pronounced “sequel”, though it later had to have it’s name shortened to “Structured Query Language” (SQL) due to trademark issues. 
> If you look at Oracle’s official documentation on SQL, it says it’s still pronounced “sequel” [2]. However, if you look at MySQL’s official documentation, it says “MySQL” is officially pronounced “‘My Ess Que Ell’ (not ‘my sequel’)” [3], and Wikipedia says SQL is officially pronounced “S-Q-L” and references an O’Reilly book on the subject [4]. So this is no help, the major sources aren’t agreeing on the way it’s “officially” pronounced.
> Since the language was originally named SEQUEL, many people continued to pronounce the name that way after it was shortened to SQL. Both pronunciations are widely used and recognized. As to which is more “official”, I guess the authority would be the ISO Standard, which is spelled (and presumably pronounced) S-Q-L.

## The SQL LIKE Operator
> The LIKE operator is used in a WHERE clause to search for a specified pattern in a column.
> There are two wildcards used in conjunction with the LIKE operator:
> % - The percent sign represents zero, one, or multiple characters
> _ - The underscore represents a single character

## WHERE CustomerName LIKE `a%`
> Finds any values that starts with "a"

## WHERE CustomerName LIKE `%a`
> Finds any values that ends with "a"

## WHERE CustomerName LIKE `%or%`
> Finds any values that have "or" in any position

## WHERE CustomerName LIKE `_r%`
> Finds any values that have "r" in the second position

## WHERE CustomerName LIKE `a_%_%`
> Finds any values that starts with "a" and are at least 3 characters in length

## WHERE ContactName LIKE `a%o`
> Finds any values that starts with "a" and ends with "o"

## SQL LIKE Examples
> SELECT * FROM Customers WHERE CustomerName LIKE `a%`;
> SELECT * FROM Customers WHERE CustomerName LIKE `%a`;
> SELECT * FROM Customers WHERE CustomerName LIKE `%or%`;

## SQL JOIN
> A JOIN clause is used to combine rows from two or more tables, based on a related column between them.
> (INNER) JOIN: Returns records that have matching values in both tables
> LEFT (OUTER) JOIN: Return all records from the left table, and the matched records from the right table
> RIGHT (OUTER) JOIN: Return all records from the right table, and the matched records from the left table
> FULL (OUTER) JOIN: Return all records when there is a match in either left or right table

## COUNT(expr)
> Returns a count of the number of non-NULL values of expr in the rows retrieved by a SELECT statement. The result is a BIGINT value. COUNT() returns 0 if there were no matching rows.
> `COUNT(*)` is somewhat different in that it returns a count of the number of rows retrieved, whether or not they contain NULL values.
> `COUNT(*)` is optimized to return very quickly if the SELECT retrieves from one table, no other columns are retrieved, and there is no WHERE clause. 
> if you put `count(*)`, count(1) or count("test") it will give you the same result because mysql will count the number of rows

## CASE WHEN IFNULL(ftg.ID, 0) > 0 THEN 1 ELSE 0 END AS Followed
> [syntax] 
> `CASE value WHEN [compare_value] THEN result [WHEN [compare_value] THEN result ...] [ELSE result] END `
> `CASE WHEN [condition] THEN result [WHEN [condition] THEN result ...] [ELSE result] END`
> The first version returns the result where value=compare_value. The second version returns the result for the first condition that is true. If there was no matching result value, the result after ELSE is returned, or NULL if there is no ELSE part.
> The return type of a CASE expression is the compatible aggregated type of all return values, but also depends on the context in which it is used. If used in a string context, the result is returned as a string. If used in a numeric context, the result is returned as a decimal, real, or integer value.
> `IFNULL(expr1,expr2)` : If expr1 is not NULL, IFNULL() returns expr1; otherwise it returns expr2. IFNULL() returns a numeric or string value, depending on the context in which it is used.
> The default result value of IFNULL(expr1,expr2) is the more “general” of the two expressions, in the order STRING, REAL, or INTEGER. Consider the case of a table based on expressions or where MySQL must internally store a value returned by IFNULL() in a temporary table.

## INSERT INTO ARTICLES (CATEGORY, TITLE, CREATETIME) VALUES (`Help`,`帮助`, now())
> syntax
````mysql
INSERT [LOW_PRIORITY | DELAYED | HIGH_PRIORITY] [IGNORE]
    [INTO] tbl_name
    [PARTITION (partition_name,...)]
    [(col_name,...)]
    {VALUES | VALUE} ({expr | DEFAULT},...),(...),...
    [ ON DUPLICATE KEY UPDATE
      col_name=expr
        [, col_name=expr] ... ]
````
> INSERT inserts new rows into an existing table. The INSERT ... VALUES and INSERT ... SET forms of the statement insert rows based on explicitly specified values. The INSERT ... SELECT form inserts rows selected from another table or tables. 
> When inserting into a partitioned table, you can control which partitions and subpartitions accept new rows. The PARTITION option takes a comma-separated list of the names of one or more partitions or subpartitions (or both) of the table. If any of the rows to be inserted by a given INSERT statement do not match one of the partitions listed, the INSERT statement fails with the error Found a row not matching the given partition set. 
> You can use REPLACE instead of INSERT to overwrite old rows. REPLACE is the counterpart to INSERT IGNORE in the treatment of new rows that contain unique key values that duplicate old rows: The new rows are used to replace the old rows rather than being discarded.
> tbl_name is the table into which rows should be inserted. The columns for which the statement provides values can be specified...
> INSERT statements that use VALUES syntax can insert multiple rows. To do this, include multiple lists of column values, each enclosed within parentheses and separated by commas.

## INSERT ... SELECT Syntax
> syntax
````mysql
INSERT [LOW_PRIORITY | HIGH_PRIORITY] [IGNORE]
    [INTO] tbl_name
    [PARTITION (partition_name,...)]
    [(col_name,...)]
    SELECT ...
    [ ON DUPLICATE KEY UPDATE col_name=expr, ... ]
````
> With INSERT ... SELECT, you can quickly insert many rows into a table from one or many tables.
> The following conditions hold for a INSERT ... SELECT statements:
> The target table of the INSERT statement may appear in the FROM clause of the SELECT part of the query. (This was not possible in some older versions of MySQL.) However, you cannot insert into a table and select from the same table in a subquery.
> When selecting from and inserting into a table at the same time, MySQL creates a temporary table to hold the rows from the SELECT and then inserts those rows into the target table. However, it remains true that you cannot use INSERT INTO t ... SELECT ... FROM t when t is a TEMPORARY table, because TEMPORARY tables cannot be referred to twice in the same statement.

##  ROW_COUNT()
> ROW_COUNT() returns a value as follows:
> DDL statements: 0. This applies to statements such as CREATE TABLE or DROP TABLE.
> DML statements other than SELECT: The number of affected rows. This applies to statements such as UPDATE, INSERT, or DELETE (as before), but now also to statements such as ALTER TABLE and LOAD DATA INFILE.
> SELECT: -1 if the statement returns a result set, or the number of rows “affected” if it does not. For example, for SELECT * FROM t1, ROW_COUNT() returns -1. For SELECT * FROM t1 INTO OUTFILE `file_name`, ROW_COUNT() returns the number of rows written to the file.
> SIGNAL statements: 0.
> For UPDATE statements, the affected-rows value by default is the number of rows actually changed. If you specify the CLIENT_FOUND_ROWS flag to mysql_real_connect() when connecting to mysqld, the affected-rows value is the number of rows “found”; that is, matched by the WHERE clause.
> For REPLACE statements, the affected-rows value is 2 if the new row replaced an old row, because in this case, one row was inserted after the duplicate was deleted.
> For INSERT ... ON DUPLICATE KEY UPDATE statements, the affected-rows value per row is 1 if the row is inserted as a new row, 2 if an existing row is updated, and 0 if an existing row is set to its current values. If you specify the CLIENT_FOUND_ROWS flag, the affected-rows value is 1 (not 0) if an existing row is set to its current values.
> The ROW_COUNT() value is similar to the value from the mysql_affected_rows() C API function and the row count that the mysql client displays following statement execution.
> [Important] ROW_COUNT() is not replicated reliably using statement-based replication. This function is automatically replicated using row-based replication.

##  FOUND_ROWS()
> A SELECT statement may include a LIMIT clause to restrict the number of rows the server returns to the client. In some cases, it is desirable to know how many rows the statement would have returned without the LIMIT, but without running the statement again. To obtain this row count, include a SQL_CALC_FOUND_ROWS option in the SELECT statement, and then invoke FOUND_ROWS() afterward:
````mysql
mysql> SELECT SQL_CALC_FOUND_ROWS * FROM tbl_name
    -> WHERE id > 100 LIMIT 10;
mysql> SELECT FOUND_ROWS();
````
> The second SELECT returns a number indicating how many rows the first SELECT would have returned had it been written without the LIMIT clause.
> In the absence of the SQL_CALC_FOUND_ROWS option in the most recent successful SELECT statement, FOUND_ROWS() returns the number of rows in the result set returned by that statement. If the statement includes a LIMIT clause, FOUND_ROWS() returns the number of rows up to the limit. For example, FOUND_ROWS() returns 10 or 60, respectively, if the statement includes LIMIT 10 or LIMIT 50, 10.

