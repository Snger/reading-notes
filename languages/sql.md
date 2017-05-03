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