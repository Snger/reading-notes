## SQL Server 2014 Express LocalDB
1. Microsoft SQL Server 2014 Express LocalDB is an execution mode of SQL Server Express targeted to program developers. 
2.  LocalDB installation copies a minimal set of files necessary to start the SQL Server Database Engine. Once LocalDB is installed, developers initiate a connection by using a special connection string. When connecting, the necessary SQL Server infrastructure is automatically created and started, enabling the application to use the database without complex or time consuming configuration tasks. Developer Tools can provide developers with a SQL Server Database Engine that lets them write and test Transact-SQL code without having to manage a full server instance of SQL Server. An instance of SQL Server ExpressLocalDB is managed by using the SqlLocalDB.exe utility. SQL Server ExpressLocalDB should be used in place of the SQL Server Express user instance feature which is deprecated.

## Automatic and Named Instances
1. LocalDB supports two kinds of instances: Automatic instances and named instances.
> 1. Automatic instances of LocalDB are public. They are created and managed automatically for the user and can be used by any application. One automatic instance of LocalDB exists for every version of LocalDB installed on the user’s computer. Automatic instances of LocalDB provide seamless instance management. There is no need to create the instance; it just works. This allows for easy application installation and migration to a different computer. If the target machine has the specified version of LocalDB installed, the automatic instance of LocalDB for that version is available on the target machine as well. Automatic instances of LocalDB have a special pattern for the instance name that belongs to a reserved namespace. This prevents name conflicts with named instances of LocalDB. The name for the automatic instance is MSSQLLocalDB.
> 2. Named instances of LocalDB are private. They are owned by a single application that is responsible for creating and managing the instance. Named instances provide isolation from other instances and can improve performance by reducing resource contention with other database users. Named instances must be created explicitly by the user through the LocalDB management API or implicitly via the app.config file for a managed application (although managed application may also use the API, if desired). Each named instance of LocalDB has an associated LocalDB version that points to the respective set of LocalDB binaries. The instance name of a LocalDB is sysname data type and can have up to 128 characters. (This differs from regular named instances of SQL Server, which limits names to regular NetBIOS names of 16 ASCII chars.) The name of an instance of LocalDB can contain any Unicode characters that are legal within a filename. A named instance that uses an automatic instance name becomes an automatic instance.
2. Different users of a computer can have instances with the same name. Each instance is a different processes running as a different user.

## Shared Instances of LocalDB
1. To support scenarios where multiple users of the computer need to connect to a single instance of LocalDB, LocalDB supports instance sharing. An instance owner can choose to allow the other users on the computer to connect to his instance. Both automatic and named instances of LocalDB can be shared. To share an instance of LocalDB a user selects a shared name (alias) for it. Because the shared name is visible to all users of the computer, this shared name must be unique on the computer. The shared name for an instance of LocalDB has the same format as the named instance of LocalDB.
2. Only an administrator on the computer can create a shared instance of LocalDB. A shared instance of LocalDB can be unshared by an administrator or by the owner of the shared instance of LocalDB. To share and unshared an instance of LocalDB, use the LocalDBShareInstance and LocalDBUnShareInstance methods of the LocalDB API, or the share and unshared options of the SqlLocalDb utility.

## Connecting to the Automatic Instance
1. The easiest way to use LocalDB is to connect to the automatic instance owned by the current user by using the connection string "Server=(localdb)\MSSQLLocalDB;Integrated Security=true". To connect to a specific database by using the file name, connect using a connection string similar to "Server=(LocalDB)\MSSQLLocalDB; Integrated Security=true ;AttachDbFileName=D:\Data\MyDB1.mdf".

## Creating and Connecting to a Named Instances
1. In addition to the automatic instance, LocalDB also supports named instances. Use the SqlLocalDB.exe program to create, start, and stop an named instance of LocalDB. For more information about SqlLocalDB.exe, see SqlLocalDB Utility.

## Connecting to a Shared Instance of LocalDB
1. To connect to a shared instance of LocalDB add .\ (dot + backslash) to the connection string to reference the namespace reserved for shared instances. For example, to connect to a shared instance of LocalDB named AppData use a connection string such as (localdb)\.\AppData as part of the connection string. A user connecting to a shared instance of LocalDB that they do not own must have a Windows Authentication or SQL Server Authentication login.
