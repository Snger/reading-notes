# Hibernate
<!-- MarkdownTOC -->

- Basic property and class mappings
- Interface Criteria
- Types of associations

<!-- /MarkdownTOC -->

## Basic property and class mappings
1. A typical Hibernate property mapping defines a JavaBeans property name, a data- base column name, and the name of a Hibernate type. It maps a JavaBean style property to a table column. The basic declaration provides many variations and optional settings. It’s often possible to omit the type name. So, if description is a property of (Java) type java.lang.String, Hibernate will use the Hibernate type string by default (we discuss the Hibernate type system in chapter 6).
2. Hibernate uses reflection to determine the Java type of the property.
3. You can even omit the column name if it’s the same as the property name, ignor- ing case. (This is one of the sensible defaults we mentioned earlier.)

## Interface Criteria
1. Criteria is a simplified API for retrieving entities by composing Criterion objects. This is a very convenient approach for functionality like "search" screens where there is a variable number of conditions to be placed upon the result set.
2. The Session is a factory for Criteria. Criterion instances are usually obtained via the factory methods on Restrictions.
3. You may navigate associations using createAlias() or createCriteria().
4. You may specify projection and aggregation using Projection instances obtained via the factory methods on Projections.

## Types of associations
````
|----------------|----------------------------|----------------------------|
|  Association   |         Definition         |          Example           |
|----------------|----------------------------|----------------------------|
| One-to-one     | Each record in one table   | A car has only one engine. |
|                | is related to exactly one  |                            |
|                | record in the second table |                            |
|                | and vice versa. The other  |                            |
|                | side could also            |                            |
|                | be a zero record.          |                            |
|----------------|----------------------------|----------------------------|
| One-to-many or | Each record in one table   | A movie has many actors    |
| many-to-one    | is related to zero or      | (one-to-many); an actor    |
|                | more recordsin the         | can act in many movies     |
|                | second table.              | (many-to-one).             |
|----------------|----------------------------|----------------------------|
| Many-to-many   | Each record in either of   | Each student can enroll in |
|                | the tables is related to   | multiple courses, and      |
|                | zero or more records       | each course can have many  |
|                | in the other table.        | students registered.       |
|----------------|----------------------------|----------------------------|
````
