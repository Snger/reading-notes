# Sprint.Net
<!-- MarkdownTOC -->

- ContextRegistry Class
- Spring.Objects.Factory.IObjectFactory
- Spring.Objects.Factory.IObjectFactory.GetObject\(\)
- Spring cron expression for every after 30 minutes
- Class CronSequenceGenerator - org.springframework.scheduling.support

<!-- /MarkdownTOC -->

## ContextRegistry Class
1. Provides access to a central registry of IApplicationContexts.
1. [Remarks] Simplifies access to to one or more application contexts.
1. Inheritance Hierarchy: System.Object > Spring.Context.Support.ContextRegistry
1. [Public Methods] GetContext Method
 - GetContext(String)   Returns context based on specified name.  
 - GetContext()    Returns the root application context.  [Remarks] :The first call to GetContext will create the context as specified in the .NET application configuration file under the location spring/context.

## Spring.Objects.Factory.IObjectFactory
1. The root interface for accessing a Spring.NET IoC container.
1. This is the root interface to be implemented by objects that can hold a number of object definitions, each uniquely identified by a <see cref="T:System.String" /> name. An independent instance of any of these objects can be obtained (the Prototype design pattern), or a single shared instance can be obtained (a superior alternative to the Singleton design pattern, in which the instance is a singleton in the scope of the factory). Which type of instance will be returned depends on the object factory configuration - the API is the same. The Singleton approach is more useful and hence more common in practice.
1. The point of this approach is that the IObjectFactory is a central registry of application components, and centralizes the configuring of application components (no more do individual objects need to read properties files, for example).
1. Normally an IObjectFactory will load object definitions stored in a configuration source (such as an XML document), and use the <see cref="N:Spring.Objects" /> namespace to configure the objects. However, an implementation could simply return .NET objects it creates as necessary directly in .NET code. There are no constraints on how the definitions could be stored: LDAP, RDBMS, XML, properties file etc. Implementations are encouraged to support references amongst objects, to either Singletons or Prototypes.

## Spring.Objects.Factory.IObjectFactory.GetObject<T>()
1. Return an instance (possibly shared or independent) of the given object name.
1. This method allows an object factory to be used as a replacement for the Singleton or Prototype design pattern.
1. Note that callers should retain references to returned objects. There is no guarantee that this method will be implemented to be efficient. For example, it may be synchronized, or may need to run an RDBMS query.
1. Will ask the parent factory if the object cannot be found in this factory instance.

## Spring cron expression for every after 30 minutes
> [Quartz Tutorials](http://www.quartz-scheduler.org/documentation/quartz-2.x/tutorials/)
> <property name="cronExpression" value="0 0/30 * * * ?" />
````
+-------------------- second (0 - 59)
|  +----------------- minute (0 - 59)
|  |  +-------------- hour (0 - 23)
|  |  |  +----------- day of month (1 - 31)
|  |  |  |  +-------- month (1 - 12)
|  |  |  |  |  +----- day of week (0 - 6) (Sunday=0 or 7)
|  |  |  |  |  |  +-- year [optional]
|  |  |  |  |  |  |
*  *  *  *  *  *  * command to be executed 
````

## Class CronSequenceGenerator - org.springframework.scheduling.support
> Date sequence generator for a Crontab pattern, allowing clients to specify a pattern that the sequence matches.
> The pattern is a list of six single space-separated fields: representing second, minute, hour, day, month, weekday. Month and weekday names can be given as the first three letters of the English names.
````
// Example patterns:
"0 0 * * * *" = the top of every hour of every day.
"*/10 * * * * *" = every ten seconds.
"0 0 8-10 * * *" = 8, 9 and 10 o'clock of every day.
"0 0 6,19 * * *" = 6:00 AM and 7:00 PM every day.
"0 0/30 8-10 * * *" = 8:00, 8:30, 9:00, 9:30, 10:00 and 10:30 every day.
"0 0 9-17 * * MON-FRI" = on the hour nine-to-five weekdays
"0 0 0 25 12 ?" = every Christmas Day at midnight
````
