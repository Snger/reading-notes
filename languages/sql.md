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