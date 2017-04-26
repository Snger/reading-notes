## What's NHibernate?
1. NHibernate not only takes care of the mapping from .NET classes to database tables (and from .NET data types to SQL data types), but also provides data query and retrieval facilities and can significantly reduce development time otherwise spent with manual data handling in SQL and ADO.NET.

## set up the database connection information for NHibernate
1. We now set up the database connection information for NHibernate. To do this, open the file Web.config automatically generated for your project and add configuration elements according to the listing.
2. The <configSections> element contains definitions of sections that follow and handlers to use to process their content. We declare the handler for the configuration section here. NHibernate will take care of the differences and comes bundled with dialects for several major commercial and open source databases.
3. An ISessionFactory is NHibernate's concept of a single datastore, multiple databases can be used by creating multiple XML configuration files and creating multiple Configuration and ISessionFactory objects in your application.
4. The last element of the <hibernate-configuration> (or <databaseSettings>) section declares Web project as the name of an assembly containing class declarations and mapping files. The mapping files contain the metadata for the mapping of the POCO class to a database table (or multiple tables). 

## First persistent class
1. NHibernate works best with the Plain Old CLR Objects (POCOs, sometimes called Plain Ordinary CLR Objects) programming model for persistent classes. A POCO has its data accessible through the standard .NET property mechanisms, shielding the internal representation from the publicly visible interface.
2. NHibernate is not restricted in its usage of property types, all .NET types and primitives (like string, char and DateTime) can be mapped, including classes from the System.Collections namespace. You can map them as values, collections of values, or associations to other entities. The Id is a special property that represents the database identifier (primary key) of that class, it is highly recommended for entities. NHibernate can use identifiers only internally, without having to declare them on the class, but we would lose some of the flexibility in our application architecture.
3. 