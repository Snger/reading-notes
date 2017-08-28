## What's NHibernate?
1. NHibernate not only takes care of the mapping from .NET classes to database tables (and from .NET data types to SQL data types), but also provides data query and retrieval facilities and can significantly reduce development time otherwise spent with manual data handling in SQL and ADO.NET.

## (NHibernate.Criterion.Expression)Creates a new Criteria for the entity class with a specific alias
> session.CreateCriteria<TransactionGoodsPO>("goods");

## (NHibernate.Criterion.Expression)Set a limit upon the number of objects to be retrieved
> session.CreateCriteria<TransactionGoodsPO>("goods").SetMaxResults(limit).List<TransactionGoodsPO>();

## (NHibernate.Criterion.Expression)Apply a "like" constraint to the project
> session.CreateCriteria<TransactionGoodsPO>("goods").Add(Restrictions.Like("goods.GoodsCode", goodsCode, MatchMode.Anywhere)).List<TransactionGoodsPO>();

## How do I make NHibernate Linq provider to use the paging features of MsSql2012Dialect
1. You can still get the updated dialect from https://github.com/nhibernate/nhibernate-core/blob/master/src/NHibernate/Dialect/MsSql2012Dialect.cs, include it in your project and reference it (adding the correct assembly name).

## How to auto generate IDs in NHibernate?
- increment: generates identifiers of any integral type that are unique only when no other process is inserting data into the same table. Do not use in a cluster.
- identity: supports identity columns in DB2, MySQL, MS SQL Server and Sybase. The identifier returned by the database is converted to the property type using Convert.ChangeType. Any integral property type is thus supported.
- sequence: uses a sequence in DB2, PostgreSQL, Oracle or a generator in Firebird. The identifier returned by the database is converted to the property type using Convert.ChangeType. Any integral property type is thus supported.
- hilo: uses a hi/lo algorithm to efficiently generate identifiers of any integral type, given a table and column (by default hibernate_unique_key and next_hi respectively) as a source of hi values. The hi/lo algorithm generates identifiers that are unique only for a particular database. Do not use this generator with a user-supplied connection. You can use the "where" parameter to specify the row to use in a table. This is useful if you want to use a single tabel for your identifiers, with different rows for each table.
- seqhilo: uses a hi/lo algorithm to efficiently generate identifiers of any integral type, given a named database sequence.
- uuid.hex: uses System.Guid and its ToString(string format) method to generate identifiers of type string. The length of the string returned depends on the configured format.
- uuid.string: uses a new System.Guid to create a byte[] that is converted to a string.
- guid: uses a new System.Guid as the identifier.
- guid.comb: uses the algorithm to generate a new System.Guid described by Jimmy Nilsson in the article http://www.informit.com/articles/article.asp?p=25862
- native: picks identity, sequence or hilo depending upon the capabilities of the underlying database
- assigned: lets the application to assign an identifier to the object before Save() is called
- foreign: uses the identifier of another associated object. Usually used in conjunction with a <one-to-one> primary key association

## download NHibernate to project
1. Download NHibernate, either from SourceForge (http://sourceforge.net/projects/nhibernate/) or NuGet ( Install-Package NHibernate ). In the project, add a reference to NHibernate.dll (NuGet already does this). Visual Studio will automatically copy the library and its dependencies to the project output directory. If you are using a database other than SQL Server, add a reference to its driver assembly to your project.

## set up the database connection information for NHibernate
1. We now set up the database connection information for NHibernate. To do this, open the file Web.config automatically generated for your project and add configuration elements according to the listing.
2. The <configSections> element contains definitions of sections that follow and handlers to use to process their content. We declare the handler for the configuration section here. NHibernate will take care of the differences and comes bundled with dialects for several major commercial and open source databases.
3. An ISessionFactory is NHibernate's concept of a single datastore, multiple databases can be used by creating multiple XML configuration files and creating multiple Configuration and ISessionFactory objects in your application.
4. The last element of the <hibernate-configuration> (or <databaseSettings>) section declares Web project as the name of an assembly containing class declarations and mapping files. The mapping files contain the metadata for the mapping of the POCO class to a database table (or multiple tables). 

## First persistent class
1. NHibernate works best with the Plain Old CLR Objects (POCOs, sometimes called Plain Ordinary CLR Objects) programming model for persistent classes. A POCO has its data accessible through the standard .NET property mechanisms, shielding the internal representation from the publicly visible interface.
2. NHibernate is not restricted in its usage of property types, all .NET types and primitives (like string, char and DateTime) can be mapped, including classes from the System.Collections namespace. You can map them as values, collections of values, or associations to other entities. The Id is a special property that represents the database identifier (primary key) of that class, it is highly recommended for entities. NHibernate can use identifiers only internally, without having to declare them on the class, but we would lose some of the flexibility in our application architecture.
3. No special interface has to be implemented for persistent classes nor do we have to subclass from a special root persistent class. NHibernate also doesn't use any build time processing, such as IL manipulation, it relies solely on .NET reflection and runtime class enhancement. So, without any dependency in the POCO class on NHibernate, we can map it to a database table. For the above mentioned runtime class enhancement to work, NHibernate requires that all public properties of an entity class are declared as virtual.
4. For the above mentioned runtime class enhancement to work, NHibernate requires that all public properties of an entity class are declared as virtual .
5. The Cat.hbm.xml mapping file contains the metadata required for the object/relational mapping. The metadata includes declaration of persistent classes and the mapping of properties (to columns and foreign key relationships to other entities) to database tables. Please note that the Cat.hbm.xml should be set to an embedded resource.
6. Every persistent class should have an identifer attribute (actually, only classes representing entities, not dependent value objects, which are mapped as components of an entity). This property is used to distinguish persistent objects: Two cats are equal if catA.Id.Equals(catB.Id) is true, this concept is called database identity.
7. An ISessionFactory is responsible for one database and may only use one XML configuration file (Web.config or hibernate.cfg.xml). You can set other properties (and even change the mapping metadata) by accessing the Configuration before you build the ISessionFactory (it is immutable). 
8. An ISessionFactory is threadsafe, many threads can access it concurrently and request ISessions. An ISession is a non-threadsafe object that represents a single unit-of-work with the database. ISessions are opened by an ISessionFactory and are closed when all work is completed.
9. In an ISession, every database operation occurs inside a transaction that isolates the database operations (even read-only operations). We use NHibernate's ITransaction API to abstract from the underlying transaction strategy (in our case, ADO.NET transactions). 

## nhibernate-core does not contain Remotion.Linq namespace
1. NHibernate embeds the compiled Remotion.Linq. But Remotion.Linq is a separate project with their own project pages: https://relinq.codeplex.com/ https://github.com/re-motion/Relinq
2. With re-linq, it's now easier than ever to create full-featured LINQ providers.

## Criteria vs. Criterion: What's the Difference?
1. Criteria is the plural form of criterion. It is used when referring to more than one criterion. Criterion is singular and is used to refer to a single thing.
