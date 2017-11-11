# Dependency Injection in .NET
> Author: Mark Seemann
> ©2012 by Manning Publications Co.
> ISBN-13: 978-1935182504
> ISBN-10: 1935182501
<!-- MarkdownTOC -->

- Part 1. Putting Dependency Injection on the map
    - Chapter 1. A Dependency Injection tasting menu
        - 1.1. Writing maintainable code
        - 1.1.1. Unlearning DI
        - 1.1.2. Understanding the purpose of DI
        - 1.2. Hello DI
        - 1.2.2. Benefits of DI
        - 1.3. What to inject and what not to inject
        - 1.3.1. Seams
        - 1.3.2. Stable Dependencies

<!-- /MarkdownTOC -->

# Part 1. Putting Dependency Injection on the map
> Dependency Injection (DI) is one of the most misunderstood concepts of object-oriented programming. The confusion is abundant and spans terminology, purpose, and mechanics. Should it be called Dependency Injection, Inversion of Control, or even Third-Party Connect? Is the purpose of DI only to support unit testing or is there a broader purpose? Is DI the same as Service Location? Is a DI CONTAINER required?
There are plenty of blog posts, magazine articles, conference presentations, and so on that discuss DI, but, unfortunately, many of them use conflicting terminology or give bad advice. This is true across the board, and even big and influential actors like Microsoft add to the confusion.
It doesn’t have to be this way. In this book I present and use a consistent terminology that I hope others will adopt. For the most part, I’ve adopted and clarified existing terminology defined by others, but occasionally I add a bit of terminology where none existed previously. This has helped me tremendously in evolving a specification of the scope or boundaries of DI.
One of the underlying reasons behind all the inconsistency and bad advice is that the boundaries of DI are quite blurry. Where does DI end and other object-oriented concepts begin? I think that it’s impossible to draw a distinct line between DI and other aspects of writing good object-oriented code. To talk about DI we have to draw in other concepts such as SOLID and Clean Code. I don’t feel that I can credibly write about DI without also touching on some of these other topics.
The first part of the book helps you understand the place of DI in relation to other facets of software engineering—putting it on the map, so to speak.

## Chapter 1. A Dependency Injection tasting menu
> - Dependency Injection is a set of software design principles and patterns that enable us to develop loosely coupled code.

### 1.1. Writing maintainable code
> - What purpose does DI serve?
> DI isn’t a goal in itself; rather, it’s a means to an end. Ultimately, the purpose of most programming techniques is to deliver working software as efficiently as possible. One aspect of that is to write maintainable code.

### 1.1.1. Unlearning DI
> Like a Hollywood martial arts cliché, you must unlearn before you can learn. There are many misconceptions about DI, and if you carry those around, you’ll misinterpret what you read in this book. You must clear your mind to understand DI.
There are at least four common myths about DI:
DI is only relevant for late binding.
DI is only relevant for unit testing.
DI is a sort of Abstract Factory on steroids.
DI requires a DI CONTAINER.
- Late binding
> In this context, late binding refers to the ability to replace parts of an application without recompiling the code. An application that enables third-party add-ins (such as Visual Studio) is one example.
Another example is standard software that supports different runtime environments. You may have an application that can run on more than one database engine: for example, one that supports both Oracle and SQL Server. To support this feature, the rest of the application can talk to the database through an interface. The code base can provide different implementations of this interface to provide access to Oracle and SQL Server, respectively. A configuration option can be used to control which implementation should be used for a given installation.
It’s a common misconception that DI is only relevant for this sort of scenario. That’s understandable, because DI does enable this scenario, but the fallacy is to think that the relationship is symmetric. Just because DI enables late binding doesn’t mean it’s only relevant in late binding scenarios. As figure 1.2 illustrates, late binding is only one of the many aspects of DI.
- Unit testing
> Even if you don’t write unit tests (if you don’t, you should start now), DI is still relevant because of all the other benefits it offers. Claiming that DI is only relevant to support unit testing is like claiming that it’s only relevant for supporting late binding.
- An Abstract Factory on steroids
> In the introduction to this chapter, I wrote that “collaborating classes...should rely on the infrastructure...to provide the necessary services.”
What were your initial thoughts about this sentence? Did you think about the infrastructure as some sort of service you could query to get the DEPENDENCIES you need? If so, you aren’t alone. Many developers and architects think about DI as a service that can be used to locate other services; this is called a SERVICE LOCATOR, but it’s the exact opposite of DI.
If you thought of DI as a SERVICE LOCATOR—that is, a general-purpose Factory—this is something you need to unlearn. DI is the opposite of a SERVICE LOCATOR; it’s a way to structure code so that we never have to imperatively ask for DEPENDENCIES. Rather, we force consumers to supply them.
- DI Containers
> A DI CONTAINER is an optional library that can make it easier for us to compose components when we wire up an application, but it’s in no way required. When we compose applications without a DI CONTAINER we call it POOR MAN’S DI; it takes a little more work, but other than that we don’t have to compromise on any DI principles.

### 1.1.2. Understanding the purpose of DI
> - Comparing electrical wiring to design patterns
> The ability to replace one end without changing the other is similar to a central software design principle called the LISKOV SUBSTITUTION PRINCIPLE. This principle states that we should be able to replace one implementation of an interface with another without breaking either client or implementation.
> When it comes to DI, the LISKOV SUBSTITUTION PRINCIPLE is one of the most important software design principles. It’s this principle that enables us to address requirements that occur in the future, even if we can’t foresee them today.
> In software design, this way of INTERCEPTING one implementation with another implementation of the same interface is known as the Decorator design pattern. It gives us the ability to incrementally introduce new features and CROSS-CUTTING CONCERNS without having to rewrite or change a lot of our existing code.
> Another way to add new functionality to an existing code base is to compose an existing implementation of an interface with a new implementation. When we aggregate several implementations into one, we use the Composite design pattern.
> The Adapter design pattern works like its physical namesake. It can be used to match two related, yet separate, interfaces to each other. This is particularly useful when you have an existing third-party API that you wish to expose as an instance of an interface your application consumes.

### 1.2. Hello DI
> The Salutation class depends on a custom interface called IMessageWriter, and it requests an instance of it through its constructor . This is called *CONSTRUCTOR INJECTION* and is described in detail in chapter 4, which also contains a more detailed walkthrough of a similar code example.
> The IMessageWriter instance is later used in the implementation of the Exclaim method , which writes the proper message to the *DEPENDENCY*.

### 1.2.2. Benefits of DI
>
|----------------------|--------------------------|-----------------------------------|
|       Benefit        |       Description        |        When is it valuable?       |
|----------------------|--------------------------|-----------------------------------|
| Late binding         | Services can be swapped  | Valuable in standard software,    |
|                      | with other services.     | but perhaps less so in            |
|                      |                          | enterprise applications where     |
|                      |                          | the runtime environment tends     |
|                      |                          | to be well-defined                |
|----------------------|--------------------------|-----------------------------------|
| Extensibility        | Code can be extended and | Always valuable                   |
|                      | reused in ways not       |                                   |
|                      | explicitly planned for.  |                                   |
|----------------------|--------------------------|-----------------------------------|
| Parallel development | Code can be developed    | Valuable in large, complex        |
|                      | in parallel.             | applications; not so much in      |
|                      |                          | small, simple applications        |
|----------------------|--------------------------|-----------------------------------|
| Maintainability      | Classes with clearly     | Always valuable                   |
|                      | defined responsibilities |                                   |
|                      | are easier to maintain.  |                                   |
|----------------------|--------------------------|-----------------------------------|
| TESTABILITY          | Classes can be unit      | Only valuable if you unit test    |
|                      | tested.                  | (which you really, really should) |
|----------------------|--------------------------|-----------------------------------|
> - Late binding
> XML files never seemed like a convincing alternative in highly scalable enterprise scenarios. This has changed significantly in the last couple of years.
> By pulling the type name from the application configuration file and creating a Type instance from it, you can use Reflection to create an instance of IMessageWriter without knowing the concrete type at compile time.
> - Extensibility
> Loose coupling enables you to write code which is open for extensibility, but closed for modification. This is called the OPEN/CLOSED PRINCIPLE. The only place where you need to modify the code is at the application’s entry point; we call this the COMPOSITION ROOT.
> - Parallel development
> Separation of concerns makes it possible to develop code in parallel teams. When a software development project grows to a certain size, it becomes necessary to separate the development team into multiple teams of manageable sizes. Each team is assigned responsibility for an area of the overall application.
To demarcate responsibilities, each team will develop one or more modules that will need to be integrated into the finished application. Unless the areas of each team are truly independent, some teams are likely to depend on the functionality developed by other teams.
In the above example, because the SecureMessageWriter and ConsoleMessageWriter classes don’t depend directly on each other, they could’ve been developed by parallel teams. All they would’ve needed to agree upon was the shared interface IMessageWriter.
> - Maintainability
> As the responsibility of each class becomes clearly defined and constrained, maintenance of the overall application becomes easier. This is a known benefit of the SINGLE RESPONSIBILITY PRINCIPLE, which states that each class should have only a single responsibility.
Adding new features to an application becomes simpler because it’s clear where changes should be applied. More often than not, we don’t even need to change existing code, but can instead add new classes and recompose the application. This is the OPEN/CLOSED PRINCIPLE in action again.
> - Testability
> An application is considered TESTABLE when it can be unit tested.
> Almost by accident, loose coupling enables unit testing because consumers follow the LISKOV SUBSTITUTION PRINCIPLE: they don’t care about the concrete types of their DEPENDENCIES. This means that we can inject Test Doubles into the System Under Test (SUT)
> - Test Doubles
> It’s a common technique to create implementations of DEPENDENCIES that act as stand-ins for the real or intended implementations. Such implementations are called Test Doubles, and they will never be used in the final application. Instead, they serve as placeholders for the real DEPENDENCIES, when these are unavailable or undesirable to use.
> There’s a complete pattern language around Test Doubles, and many subtypes, such as Stubs, Mocks, and Fakes.
> After exercising the System Under Test (SUT), you can use the Mock to verify that the Write method was invoked with the correct text.

### 1.3. What to inject and what not to inject
> The .NET Base Class Library (BCL) consists of many assemblies. Every time you write code that uses a type from a BCL assembly, you add a dependency to your module. In the previous section, I discussed how loose coupling is important, and how programming to an interface is the cornerstone.
Does this imply that you can’t reference any BCL assemblies and use their types directly in your application? What if you would like to use an XmlWriter, which is defined in the System.Xml assembly?

### 1.3.1. Seams
> Everywhere we decide to program against an interface instead of a concrete type, we introduce a SEAM into the application. A SEAM is a place where an application is assembled from its constituent parts, similar to the way a piece of clothing is sewn together at its seams. It’s also a place where we can disassemble the application and work with the modules in isolation.
> The Salutation class doesn’t directly depend on the ConsoleMessageWriter class; rather, it uses the IMessageWriter interface to write messages. You can take the application apart at this SEAM and reassemble it with a different message writer.
> As you learn DI, it can be helpful to categorize your dependencies into STABLE DEPENDENCIES and VOLATILE DEPENDENCIES, but deciding where to put your SEAMS will soon become second nature to you.

### 1.3.2. Stable Dependencies
>