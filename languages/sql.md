## Pronouncing SQL: S-Q-L or Sequel?
1. SQL was initially developed at IBM by Donald Chamberlin and Raymond Boyce. It was initially called “Structured English Query Language” (SEQUEL) and pronounced “sequel”, though it later had to have it’s name shortened to “Structured Query Language” (SQL) due to trademark issues. 
2. If you look at Oracle’s official documentation on SQL, it says it’s still pronounced “sequel” [2]. However, if you look at MySQL’s official documentation, it says “MySQL” is officially pronounced “‘My Ess Que Ell’ (not ‘my sequel’)” [3], and Wikipedia says SQL is officially pronounced “S-Q-L” and references an O’Reilly book on the subject [4]. So this is no help, the major sources aren’t agreeing on the way it’s “officially” pronounced.
3. Since the language was originally named SEQUEL, many people continued to pronounce the name that way after it was shortened to SQL. Both pronunciations are widely used and recognized. As to which is more “official”, I guess the authority would be the ISO Standard, which is spelled (and presumably pronounced) S-Q-L.

## The SQL LIKE Operator
1. The LIKE operator is used in a WHERE clause to search for a specified pattern in a column.
2. There are two wildcards used in conjunction with the LIKE operator:
> % - The percent sign represents zero, one, or multiple characters
> _ - The underscore represents a single character

## WHERE CustomerName LIKE 'a%'
> Finds any values that starts with "a"

## WHERE CustomerName LIKE '%a'
> Finds any values that ends with "a"

## WHERE CustomerName LIKE '%or%'
> Finds any values that have "or" in any position

## WHERE CustomerName LIKE '_r%'
> Finds any values that have "r" in the second position

## WHERE CustomerName LIKE 'a_%_%'
> Finds any values that starts with "a" and are at least 3 characters in length

## WHERE ContactName LIKE 'a%o'
> Finds any values that starts with "a" and ends with "o"

## SQL LIKE Examples
> SELECT * FROM Customers WHERE CustomerName LIKE 'a%';
> SELECT * FROM Customers WHERE CustomerName LIKE '%a';
> SELECT * FROM Customers WHERE CustomerName LIKE '%or%';

## SQL JOIN
> A JOIN clause is used to combine rows from two or more tables, based on a related column between them.
> (INNER) JOIN: Returns records that have matching values in both tables
> LEFT (OUTER) JOIN: Return all records from the left table, and the matched records from the right table
> RIGHT (OUTER) JOIN: Return all records from the right table, and the matched records from the left table
> FULL (OUTER) JOIN: Return all records when there is a match in either left or right table

## COUNT(expr)
1. Returns a count of the number of non-NULL values of expr in the rows retrieved by a SELECT statement. The result is a BIGINT value. COUNT() returns 0 if there were no matching rows.
2. COUNT(*) is somewhat different in that it returns a count of the number of rows retrieved, whether or not they contain NULL values.
3. COUNT(*) is optimized to return very quickly if the SELECT retrieves from one table, no other columns are retrieved, and there is no WHERE clause. 
4. if you put count(*), count(1) or count("test") it will give you the same result because mysql will count the number of rows

## CASE WHEN IFNULL(ftg.ID, 0) > 0 THEN 1 ELSE 0 END AS Followed
1. [syntax] 
> ` CASE value WHEN [compare_value] THEN result [WHEN [compare_value] THEN result ...] [ELSE result] END `
> `CASE WHEN [condition] THEN result [WHEN [condition] THEN result ...] [ELSE result] END`
2. The first version returns the result where value=compare_value. The second version returns the result for the first condition that is true. If there was no matching result value, the result after ELSE is returned, or NULL if there is no ELSE part.
3. The return type of a CASE expression is the compatible aggregated type of all return values, but also depends on the context in which it is used. If used in a string context, the result is returned as a string. If used in a numeric context, the result is returned as a decimal, real, or integer value.
4. `IFNULL(expr1,expr2)` : If expr1 is not NULL, IFNULL() returns expr1; otherwise it returns expr2. IFNULL() returns a numeric or string value, depending on the context in which it is used.
5. The default result value of IFNULL(expr1,expr2) is the more “general” of the two expressions, in the order STRING, REAL, or INTEGER. Consider the case of a table based on expressions or where MySQL must internally store a value returned by IFNULL() in a temporary table.

## INSERT INTO ARTICLES (CATEGORY, TITLE, CREATETIME) VALUES ('Help','帮助', now())
1. 

````sql
INSERT [LOW_PRIORITY | DELAYED | HIGH_PRIORITY] [IGNORE]
    [INTO] tbl_name
    [PARTITION (partition_name,...)]
    [(col_name,...)]
    {VALUES | VALUE} ({expr | DEFAULT},...),(...),...
    [ ON DUPLICATE KEY UPDATE
      col_name=expr
        [, col_name=expr] ... ]
````

2. INSERT inserts new rows into an existing table. The INSERT ... VALUES and INSERT ... SET forms of the statement insert rows based on explicitly specified values. The INSERT ... SELECT form inserts rows selected from another table or tables. 
3. When inserting into a partitioned table, you can control which partitions and subpartitions accept new rows. The PARTITION option takes a comma-separated list of the names of one or more partitions or subpartitions (or both) of the table. If any of the rows to be inserted by a given INSERT statement do not match one of the partitions listed, the INSERT statement fails with the error Found a row not matching the given partition set. 
4. You can use REPLACE instead of INSERT to overwrite old rows. REPLACE is the counterpart to INSERT IGNORE in the treatment of new rows that contain unique key values that duplicate old rows: The new rows are used to replace the old rows rather than being discarded.
5. tbl_name is the table into which rows should be inserted. The columns for which the statement provides values can be specified...
6. INSERT statements that use VALUES syntax can insert multiple rows. To do this, include multiple lists of column values, each enclosed within parentheses and separated by commas.

