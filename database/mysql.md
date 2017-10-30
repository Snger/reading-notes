# mydql
<!-- MarkdownTOC -->

- DROP TABLE IF EXISTS TABLENAME;
- CREATE TABLE TABLENAME \(\) ENGINE=InnoDB DEFAULT CHARSET=utf8;
- ALTER TABLE TABLENAME ADD INDEX IX_TABLENAME_CREATETIME\(CREATETIME\);
- Definition of stored procedures
- How to add new stored procedures to mysql in DataGrip?
- CREATE PROCEDURE Syntax
- INSERT ... SELECT Syntax
- SELECT Syntax
- Case operator -- Control Flow Functions
- UPDATE Syntax
- CURDATE\(\)
- mysql Workbench
- 14.2.9.3 UNION Syntax
- MySQL外键使用详解
- Set value to NULL in MySQL

<!-- /MarkdownTOC -->

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
1. Syntax
````
SELECT
    [ALL | DISTINCT | DISTINCTROW ]
      [HIGH_PRIORITY]
      [MAX_STATEMENT_TIME = N]
      [STRAIGHT_JOIN]
      [SQL_SMALL_RESULT] [SQL_BIG_RESULT] [SQL_BUFFER_RESULT]
      [SQL_CACHE | SQL_NO_CACHE] [SQL_CALC_FOUND_ROWS]
    select_expr [, select_expr ...]
    [FROM table_references
      [PARTITION partition_list]
    [WHERE where_condition]
    [GROUP BY {col_name | expr | position}
      [ASC | DESC], ... [WITH ROLLUP]]
    [HAVING where_condition]
    [ORDER BY {col_name | expr | position}
      [ASC | DESC], ...]
    [LIMIT {[offset,] row_count | row_count OFFSET offset}]
    [PROCEDURE procedure_name(argument_list)]
    [INTO OUTFILE 'file_name'
        [CHARACTER SET charset_name]
        export_options
      | INTO DUMPFILE 'file_name'
      | INTO var_name [, var_name]]
    [FOR UPDATE | LOCK IN SHARE MODE]]
````
2. A select_expr can be given an alias using AS alias_name. The alias is used as the expression's column name and can be used in GROUP BY, ORDER BY, or HAVING clauses.
3. The AS keyword is optional when aliasing a select_expr with an identifier.
4. However, because the AS is optional, a subtle problem can occur if you forget the comma between two select_expr expressions: MySQL interprets the second as an alias name. For this reason, it is good practice to be in the habit of using AS explicitly when specifying column aliases.
5. The FROM table_references clause indicates the table or tables from which to retrieve rows. If you name more than one table, you are performing a join. For each table specified, you can optionally specify an alias.
6. tbl_name [[AS] alias] [index_hint] -- You can refer to a table within the default database as tbl_name, or as db_name.tbl_name to specify a database explicitly. You can refer to a column as col_name, tbl_name.col_name, or db_name.tbl_name.col_name. You need not specify a tbl_name or db_name.tbl_name prefix for a column reference unless the reference would be ambiguous.
7.  The ALL and DISTINCT options specify whether duplicate rows should be returned. ALL (the default) specifies that all matching rows should be returned, including duplicates. DISTINCT specifies removal of duplicate rows from the result set. It is an error to specify both options. DISTINCTROW is a synonym for DISTINCT.

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

## mysql Workbench
1. 服务（桌面应用）-MySQL 手动启动
2. mysql Workbench -> mysql connections -> server status: running
3. open sql script ; or run sql script (need python)
4. schemas -> set as default schemas
5. VS -> 视图 -> 服务器资源管理器 -> 连接到数据库

## 14.2.9.3 UNION Syntax
1. Syntax
````
SELECT ...
UNION [ALL | DISTINCT] SELECT ...
[UNION [ALL | DISTINCT] SELECT ...]
````
1. UNION is used to combine the result from multiple SELECT statements into a single result set.
1. The column names from the first SELECT statement are used as the column names for the results returned. Selected columns listed in corresponding positions of each SELECT statement should have the same data type. (For example, the first column selected by the first statement should have the same type as the first column selected by the other statements.)
1. If the data types of corresponding SELECT columns do not match, the types and lengths of the columns in the UNION result take into account the values retrieved by all of the SELECT statements.
1. The default behavior for UNION is that duplicate rows are removed from the result. The optional DISTINCT keyword has no effect other than the default because it also specifies duplicate-row removal. With the optional ALL keyword, duplicate-row removal does not occur and the result includes all matching rows from all the SELECT statements.
1. You can mix UNION ALL and UNION DISTINCT in the same query. Mixed UNION types are treated such that a DISTINCT union overrides any ALL union to its left. A DISTINCT union can be produced explicitly by using UNION DISTINCT or implicitly by using UNION with no following DISTINCT or ALL keyword.

## MySQL外键使用详解
1. 只有InnoDB类型的表才可以使用外键，mysql默认是MyISAM，这种类型不支持外键约束
2. 外键的好处：可以使得两张表关联，保证数据的一致性和实现一些级联操作；
3. 外键的作用：

> 保持数据一致性，完整性，主要目的是控制存储在外键表中的数据。
> 使两张表形成关联，外键只能引用外表中的列的值！

4. 建立外键的前提：

> 两个表必须是InnoDB表类型。
> 使用在外键关系的域必须为索引型(Index)。
> 使用在外键关系的域必须与数据类型相似

5. 创建的步骤

> 指定主键关键字： foreign key(列名)
> 引用外键关键字： references <外键表名>(外键列名)

6. 事件触发限制:on delete和on update , 可设参数cascade(跟随外键改动), restrict(限制外表中的外键改动),set Null(设空值）,set Default（设默认值）,[默认]no action
7. 举例
````mysql
# 创建含有外键的表
create table temp (
    id int,
    name char(20),
    foreign key(id) references outTable(id)
        on delete cascade on update cascade
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
-- 把id列 设为外键 参照外表outTable的id列 当外键的值删除 本表中对应的列筛除 当外键的值改变 本表中对应的列值改变。
````
8. 缺点：在对MySQL做优化的时候类似查询缓存，索引缓存之类的优化对InnoDB类型的表是不起作用的，还有在数据库整体架构中用得同步复制也是对InnoDB类型的表不生效的，像数据库中核心的表类似商品表请大家尽量不要是使用外键，如果同步肯定要同步商品库的，加上了外键也就没法通不了，优化也对它没作用，岂不得不偿失，做外键的目的在于保证数据完整性，请大家通过程序来实现这个目的而不是外键，切记！

## Set value to NULL in MySQL
> ````
UPDATE MyTable
SET MyField = NULL
WHERE MyField = ''
