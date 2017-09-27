# Hibernate
<!-- MarkdownTOC -->

- Basic property and class mappings
- Interface Criteria
- Why use many-to-one to represent a one-to-one?

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

## Why use many-to-one to represent a one-to-one?
1. When?

> - There are several ways to implement a one-to-one association in a database: you can share a primary key but you can also use a foreign key relationship with a unique constraint (one table has a foreign key column that references the primary key of the associated table).
> - In the later case, the hibernate way to map this is to use a many-to-one association (that allows to specify the foreign key).
>> The reason is simple: You don’t care what’s on the target side of the association, so you can treat it like a to-one association without the many part. All you want is to express “This entity has a property that is a reference to an instance of another entity”and use a foreign key field to represent that relationship.
> - In other words, using a many-to-one is the way to map one-to-one foreign key associations (which are actually maybe more frequent than shared primary key one-to-one associations).

2. Why?

> - The biggest difference is, with a shared-key one-to-one mapping the 2 objects are bound to each other, they exists together.
> - f.e. if you create a Person and an Address class that are bound to tables with same name, each person will have exactly one address...
> - With many-to one relationship the table structure changes a bit, but the same effect can have multiple addresses: addressid (fk), shippingaddressid (fk). The two foreign keys (addressid and shippingaddressid) could point to a single DB entry...or a single address could belong to 2-3 persons. so whats a many-to-one from the person's side it's a one-to-many from the address side. and just guess what does a one-to-many association with only 1 item look like? Yeah, just like a one-to-one...

3. Object-Relational impedance mismatch

> I would say the problem is fundamentally related to the object-relational impedance mismatch. To be able to relate the two object representations in a database, you need to have some sort of relationship between their tables. However, the database knows only the 1:N relationship: all the others are derived from it.
> With relational databases and object languages, it's up to the developer to find the least unnatural representation of the concept he/she wants to represent (in this case, a 1:1 relationship).

4. About unique

> The unique = true doesn't mean anything when if you are not using Hibernate to generate out your SQL schema when your application starts. Hibernate does not enforce uniqueness of values, that is a pure database function.
> If you use Hibernate to generate your database schema then it places a Unique constraint on any property that you have set unique=true on, but if you are pointing Hibernate at a database that already exist, and only validating the schema of that database, Hibernate won't check that the unique constraint exists.
> The other properties this applies to are (from the top of my head) insertable, updateable and nullable
