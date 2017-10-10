# Learning NHibernate 4
> Author: Suhas Chatekar
> Copyright © 2015 Packt Publishing
> ISBN 978-1-78439-356-4
> release of NHibernate 4.0.3.400
<!-- MarkdownTOC -->

- Chapter 1: Introduction to NHibernate
    - What is ORM?
    - What is NHibernate?
    - What is new in NHibernate 4.0?
    - NHibernate for users of Entity Framework
    - Is using ORM a bad idea?
    - Non-functional features required by the data access layer
    - Building blocks of NHibernate

<!-- /MarkdownTOC -->

# Chapter 1: Introduction to NHibernate
## What is ORM?
> ORM stands for Object Relational Mapping. It is a technique that lets you map objects to relational databases and vice versa. Here, the term "object" mostly means an instance of a class. Tools that make use of ORM techniques are also referred to as ORM, which stands for Object Relational Mapper. NHibernate is one such tool.
> ORM will handle all your database CRUD operations for you without you having to write a single line of SQL script. However, the most important principle to understand around an ORM is that it tries to bridge the gap between the OO world and the relational world. Programs written using the object-oriented principles adhere to a set of rules and support a particular set of data types. On the other hand, most RDBMSs follow rules derived from the set theory and support a set of data types that may not all be compatible with the corresponding data type on the OO side of the world. Besides this, there are differences in how new objects are constructed, how they associate with each other, what kind of operations are permitted on them, and so on.
> All these differences make working with databases difficult when viewed from the perspective of the OO program. These differences are also called impedance mismatch, a term taken from electrical engineering. Impedance gives a measure of how easily the current can flow through an electrical circuit. For two electrical circuits to work in coherence with each other when connected, their impedances should match. In the same way, for a program written in OOP to work with an RDBMS in coherence, the impedance between them has to be matched. An ORM does this job.

## What is NHibernate?
> NHibernate is a mature, open source object-relational mapper for the .NET framework. It's actively developed, fully featured and used in thousands of successful projects.
> NHibernate is a .NET port of a very famous ORM from the Java land called Hibernate. NHibernate has not only inherited most of the good features from its Java ancestor but has also been enriched with features from .NET, such as LINQ queries.
> ... As you can see, all you wrote was a simple C# LINQ expression against a C# class. You did not have to think about what the database table name is and how to form the correct SQL query; NHibernate has handled all of that for you.

## What is new in NHibernate 4.0?
> The General Availability release of NHibernate 4.0.3.400 was released on August 17 2014. This is the latest release of NHibernate as of the time of writing of this book.
- NH 4.0 is built for .NET 4.0. This may not mean much for the users of NHibernate 4.0 as you can still use older versions of NHibernate on a project that is built on .NET 4.0. However, this is a major move for NHibernate since it now gives NHibernate developers the ability to utilize new features of .NET 4.0. An immediate consequence of this was that NHibernate 4.0 now does not depend on the Iesi.Collection library to support sets ( Iesi. Collections.Generic.ISet<T> ) because .NET 4.0 has native support for sets, in the form of ISet<T> , and implementations such as HashSet<T> .
> Closed - [NH-3580 - Remove explicit dependency on Iesi.Collections](https://github.com/nhibernate/nhibernate-core/pull/604)
> @fredericDelaporte: I do not get the point of why we should do that change. Iesi was an annoyance when we had to deal concurrently with the Iesi ISet and the (late) native ISet. But since NHibernate v4, it is just supporting a feature as transparently as do Relinq for our Linq provider: it works, and users do not need to deal with it directly.
> @ngbrown: I'm not a fan of adding more reflection when we have NuGet's dependency management. Reflection makes it harder to reason about what is needed for an application before run-time.
- We all love LINQ and we all hated the fact that NH's LINQ support never matched that of Criteria or QueryOver. There has been great community contribution in this area with over 140 issues fixed. LINQ support in NHibernate 4.0 has matched that of other query providers in a lot of respects.

## NHibernate for users of Entity Framework
> In spite of the recent popularity of EF, a natural question to ask is why you should be taking a look at NHibernate?
- NHibernate has a stable and sophisticated support for second-level cache.
- NHibernate has native support for mapping dictionaries.
- In situations where you need to update a large number of database records as part of batch jobs, the usual session object of NHibernate may be too slow as it tracks every change made to the entities and enforces all the database relations/constraints before the changes are saved to the database. However, ... However, in my opinion, both of these options are not as intuitive as the stateless sessions of NHibernate.
- NH, in general, supports more number of databases than EF does.
- Identity generation is one of the important features offered by an ORM. ... NHibernate comes bundled with several identity generation strategies, while EF is still catching up.
- NHibernate's support for managing concurrency is far better.
- NHibernate supports global filters.
- NHibernate supports four different mechanisms for querying data. (LINQ, HQL, Criteria, and QueryOver)

## Is using ORM a bad idea?
> Still, some minds in the industry feel that using an ORM is not a good idea. Of all the reasons presented against using ORMs, the two most commonly given are as follows:
- ORMs abstract away databases, and hence, the important database concepts that are essential for any developer to master usually get ignored
- The use of ORMs results in a performance degradation of the application
> If you master APIs offered by the ORM, you will do just good to interact with a moderately complex database through the most commonly used queries. Further, since this almost always works, you never need to figure out what the ORM is doing under the hood for you. So, you indeed miss out on learning how to work with databases. If you are using your ORM to generate a database schema, then chances are that you are missing out on important database building blocks such as keys, associations, relations, and indexes. So, there is an element of truth in the first reasoning. If you do fall into this category of developers, then this lack of database knowledge will hit you the hardest when least expected.

## Non-functional features required by the data access layer
- Logging: Logging probably is one of the most important non-functional requirements. You would need to log not only the errors and exceptions but also important information such as details of the SQL query sent to the database and the data returned from the database.
- Caching: Caching may sound a simple thing to implement but as your domain grows complex so do the data querying patterns. Such complex data query patterns have very different caching requirements, which are not trivial to implement.
- Connection management: You might think that ADO.NET offers connection management and connection pooling. Indeed, it does. But there are more features around connection management that we need. In real-life applications, you need the ability to reuse connections across multiple queries, be able to make new connections, disconnect the existing connections at the right time, and so on.
- Transaction management
- Concurrency management
- Lazy loading
- Security
- Batching of queries

## Building blocks of NHibernate
> NHibernate stands on three important building blocks. To understand these building blocks is essential to understand and use NHibernate effectively.
- Mappings
> NHibernate uses mappings to find out which class maps to which database table and which property on the class maps to which column on the table. Every time your application tries to interact with the database, NHibernate refers to the mappings in order to generate the appropriate SQL to be sent to the database for execution.
- Configuration
>
