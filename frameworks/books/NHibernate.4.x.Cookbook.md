# NHibernate 4.x Cookbook Second Edition
> Authors: Gunnar Liljas, Alexander Zaytsev, Jason Dentler
> Copyright © 2017 Packt Publishing
> ISBN 978-1-78439-642-8

<!-- MarkdownTOC -->

- Chapter 1. The Configuration and Schema
    - NHibernate architecture
        - diagram
        - several key components to an NHibernate application

<!-- /MarkdownTOC -->

# Chapter 1. The Configuration and Schema
## NHibernate architecture
### diagram
````
|--------------------------------------------------|
|                 Your Application                 |
|--------------------------------------------------|
| Configuration -> Session Factory -> Session      |
|--------------------------------------------------|
| Dialect + Connection Provider + Driver + Batcher |
|--------------------------------------------------|
|                     ADO.NET                      |
|--------------------------------------------------|
````
### several key components to an NHibernate application
>
- Configuration: Builds session factory
> On startup, an NHibernate application builds a Configuration object. In
this recipe, we build the configuration from settings in the
hibernate.cfg.xml file. The Configuration object is responsible for
loading mappings, investigating the object model for additional
information, building the mapping metadata, and finally building a session
factory.
- Session Factory: Builds sessions
>  Building the session factory is a rather resource intensive
operation, and is normally only done once, when the application starts up.
- Session: Unit of Work
> A session represents a Unit of Work in the application. An NHibernate
session tracks changes to entities and writes those changes back to the
database all at once. In NHibernate, this process of waiting to write to the
database is called transactional write-behind. In addition, the session is
the entry point to much of the NHibernate API.
- Dialect: Builds SQL syntax
> A dialect is used to build correct SQL syntax for a specific RDBMS. For
example, in some versions of Microsoft SQL Server, we begin a select
statement with SELECT TOP 20 to specify a maximum result set size. Only
20 rows will be returned. Similarly, to perform this operation in SQLite, we
append LIMIT 20 to the end of the select statement. Each dialect provides
the necessary SQL syntax string fragments and other information to build
correct SQL strings for the chosen RDBMS.
- Connection Provider: Opens and closes connections
> A connection provider is simply responsible for opening and closing
database connections.
- Driver: Creates ADO.NET objects
> A driver is responsible for building a Batcher, creating IDbConnection
and IDbCommand objects, and preparing those commands.
- Batcher: Batcher SQL statements
> A batcher manages the batch of commands to be sent to the database and
the resulting data readers. Currently, only the SqlClientDriver ,
OracleDataDriver , and MySqlDataDriver support batching. The drivers
that don't support batching provide a NonBatchingBatcher to manage
IDbCommands and IDataReaders and simulate the existence of a single
logical batch of commands.
