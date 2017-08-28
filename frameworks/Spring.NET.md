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

