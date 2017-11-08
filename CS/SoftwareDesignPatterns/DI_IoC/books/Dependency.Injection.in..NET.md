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
            - 1.3.3. Volatile Dependencies
        - 1.4. DI scope
            - 1.4.1. Object Composition
            - 1.4.2. Object Lifetime
            - 1.4.3. Interception
            - 1.4.4. DI in three dimensions
        - 1.5. Summary
    - Chapter 2. A comprehensive example
        - 2.1. Doing it wrong
            - 2.1.3. Evaluation
            - 2.1.4. Analysis
        - 2.2. Doing it right
            - 2.2.1. Rebuilding the commerce application

<!-- /MarkdownTOC -->

# Part 1. Putting Dependency Injection on the map
> Dependency Injection (DI) is one of the most misunderstood concepts of object-oriented programming. The confusion is abundant and spans terminology, purpose, and mechanics. Should it be called Dependency Injection, Inversion of Control, or even Third-Party Connect? Is the purpose of DI only to support unit testing or is there a broader purpose? Is DI the same as Service Location? Is a DI CONTAINER required?
> There are plenty of blog posts, magazine articles, conference presentations, and so on that discuss DI, but, unfortunately, many of them use conflicting terminology or give bad advice. This is true across the board, and even big and influential actors like Microsoft add to the confusion.
> It doesn’t have to be this way. In this book I present and use a consistent terminology that I hope others will adopt. For the most part, I’ve adopted and clarified existing terminology defined by others, but occasionally I add a bit of terminology where none existed previously. This has helped me tremendously in evolving a specification of the scope or boundaries of DI.
> One of the underlying reasons behind all the inconsistency and bad advice is that the boundaries of DI are quite blurry. Where does DI end and other object-oriented concepts begin? I think that it’s impossible to draw a distinct line between DI and other aspects of writing good object-oriented code. To talk about DI we have to draw in other concepts such as SOLID and Clean Code. I don’t feel that I can credibly write about DI without also touching on some of these other topics.
> The first part of the book helps you understand the place of DI in relation to other facets of software engineering—putting it on the map, so to speak.

## Chapter 1. A Dependency Injection tasting menu
> - Dependency Injection is a set of software design principles and patterns that enable us to develop loosely coupled code.

### 1.1. Writing maintainable code
> - What purpose does DI serve?
> DI isn’t a goal in itself; rather, it’s a means to an end. Ultimately, the purpose of most programming techniques is to deliver working software as efficiently as possible. One aspect of that is to write maintainable code.

#### 1.1.1. Unlearning DI
> Like a Hollywood martial arts cliché, you must unlearn before you can learn. There are many misconceptions about DI, and if you carry those around, you’ll misinterpret what you read in this book. You must clear your mind to understand DI.
> There are at least four common myths about DI:
> DI is only relevant for late binding.
> DI is only relevant for unit testing.
> DI is a sort of Abstract Factory on steroids.
> DI requires a DI CONTAINER.
- Late binding
> In this context, late binding refers to the ability to replace parts of an application without recompiling the code. An application that enables third-party add-ins (such as Visual Studio) is one example.
> Another example is standard software that supports different runtime environments. You may have an application that can run on more than one database engine: for example, one that supports both Oracle and SQL Server. To support this feature, the rest of the application can talk to the database through an interface. The code base can provide different implementations of this interface to provide access to Oracle and SQL Server, respectively. A configuration option can be used to control which implementation should be used for a given installation.
> It’s a common misconception that DI is only relevant for this sort of scenario. That’s understandable, because DI does enable this scenario, but the fallacy is to think that the relationship is symmetric. Just because DI enables late binding doesn’t mean it’s only relevant in late binding scenarios. As figure 1.2 illustrates, late binding is only one of the many aspects of DI.
- Unit testing
> Even if you don’t write unit tests (if you don’t, you should start now), DI is still relevant because of all the other benefits it offers. Claiming that DI is only relevant to support unit testing is like claiming that it’s only relevant for supporting late binding.
- An Abstract Factory on steroids
> In the introduction to this chapter, I wrote that “collaborating classes...should rely on the infrastructure...to provide the necessary services.”
> What were your initial thoughts about this sentence? Did you think about the infrastructure as some sort of service you could query to get the DEPENDENCIES you need? If so, you aren’t alone. Many developers and architects think about DI as a service that can be used to locate other services; this is called a SERVICE LOCATOR, but it’s the exact opposite of DI.
> If you thought of DI as a SERVICE LOCATOR—that is, a general-purpose Factory—this is something you need to unlearn. DI is the opposite of a SERVICE LOCATOR; it’s a way to structure code so that we never have to imperatively ask for DEPENDENCIES. Rather, we force consumers to supply them.
- DI Containers
> A DI CONTAINER is an optional library that can make it easier for us to compose components when we wire up an application, but it’s in no way required. When we compose applications without a DI CONTAINER we call it POOR MAN’S DI; it takes a little more work, but other than that we don’t have to compromise on any DI principles.

#### 1.1.2. Understanding the purpose of DI
> - Comparing electrical wiring to design patterns
> The ability to replace one end without changing the other is similar to a central software design principle called the LISKOV SUBSTITUTION PRINCIPLE. This principle states that we should be able to replace one implementation of an interface with another without breaking either client or implementation.
> When it comes to DI, the LISKOV SUBSTITUTION PRINCIPLE is one of the most important software design principles. It’s this principle that enables us to address requirements that occur in the future, even if we can’t foresee them today.
> In software design, this way of INTERCEPTING one implementation with another implementation of the same interface is known as the Decorator design pattern. It gives us the ability to incrementally introduce new features and CROSS-CUTTING CONCERNS without having to rewrite or change a lot of our existing code.
> Another way to add new functionality to an existing code base is to compose an existing implementation of an interface with a new implementation. When we aggregate several implementations into one, we use the Composite design pattern.
> The Adapter design pattern works like its physical namesake. It can be used to match two related, yet separate, interfaces to each other. This is particularly useful when you have an existing third-party API that you wish to expose as an instance of an interface your application consumes.

### 1.2. Hello DI
> The Salutation class depends on a custom interface called IMessageWriter, and it requests an instance of it through its constructor . This is called *CONSTRUCTOR INJECTION* and is described in detail in chapter 4, which also contains a more detailed walkthrough of a similar code example.
> The IMessageWriter instance is later used in the implementation of the Exclaim method , which writes the proper message to the *DEPENDENCY*.

#### 1.2.2. Benefits of DI
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
> To demarcate responsibilities, each team will develop one or more modules that will need to be integrated into the finished application. Unless the areas of each team are truly independent, some teams are likely to depend on the functionality developed by other teams.
> In the above example, because the SecureMessageWriter and ConsoleMessageWriter classes don’t depend directly on each other, they could’ve been developed by parallel teams. All they would’ve needed to agree upon was the shared interface IMessageWriter.
> - Maintainability
> As the responsibility of each class becomes clearly defined and constrained, maintenance of the overall application becomes easier. This is a known benefit of the SINGLE RESPONSIBILITY PRINCIPLE, which states that each class should have only a single responsibility.
> Adding new features to an application becomes simpler because it’s clear where changes should be applied. More often than not, we don’t even need to change existing code, but can instead add new classes and recompose the application. This is the OPEN/CLOSED PRINCIPLE in action again.
> - Testability
> An application is considered TESTABLE when it can be unit tested.
> Almost by accident, loose coupling enables unit testing because consumers follow the LISKOV SUBSTITUTION PRINCIPLE: they don’t care about the concrete types of their DEPENDENCIES. This means that we can inject Test Doubles into the System Under Test (SUT)
> - Test Doubles
> It’s a common technique to create implementations of DEPENDENCIES that act as stand-ins for the real or intended implementations. Such implementations are called Test Doubles, and they will never be used in the final application. Instead, they serve as placeholders for the real DEPENDENCIES, when these are unavailable or undesirable to use.
> There’s a complete pattern language around Test Doubles, and many subtypes, such as Stubs, Mocks, and Fakes.
> After exercising the System Under Test (SUT), you can use the Mock to verify that the Write method was invoked with the correct text.

### 1.3. What to inject and what not to inject
> The .NET Base Class Library (BCL) consists of many assemblies. Every time you write code that uses a type from a BCL assembly, you add a dependency to your module. In the previous section, I discussed how loose coupling is important, and how programming to an interface is the cornerstone.
> Does this imply that you can’t reference any BCL assemblies and use their types directly in your application? What if you would like to use an XmlWriter, which is defined in the System.Xml assembly?

#### 1.3.1. Seams
> Everywhere we decide to program against an interface instead of a concrete type, we introduce a SEAM into the application. A SEAM is a place where an application is assembled from its constituent parts, similar to the way a piece of clothing is sewn together at its seams. It’s also a place where we can disassemble the application and work with the modules in isolation.
> The Salutation class doesn’t directly depend on the ConsoleMessageWriter class; rather, it uses the IMessageWriter interface to write messages. You can take the application apart at this SEAM and reassemble it with a different message writer.
> As you learn DI, it can be helpful to categorize your dependencies into STABLE DEPENDENCIES and VOLATILE DEPENDENCIES, but deciding where to put your SEAMS will soon become second nature to you.

#### 1.3.2. Stable Dependencies
> Many of the modules in the BCL and beyond pose no threat to an application’s degree of modularity. They contain reusable functionality that you can leverage to make your own code more succinct.
> The BCL modules are always available to your application, because it needs the .NET Framework to run. The concern about parallel development doesn’t apply to these modules because they already exist, and you can always reuse a BCL library in another application.
> By default, you can consider most (but not all) types defined in the BCL as safe, or STABLE DEPENDENCIES—I call them stable because they’re already there, tend to be backwards compatible, and invoking them has deterministic outcomes.
> The important criteria for STABLE DEPENDENCIES are
> - The class or module already exists.
> - You expect that new versions won’t contain breaking changes.
> - The types in question contain deterministic algorithms.
> - You never expect to have to replace the class or module with another.
> Ironically, DI CONTAINERS themselves will tend to be STABLE DEPENDENCIES, because they fit all the criteria. When you decide to base your application on a particular DI CONTAINER, you risk being stuck with this choice for the entire lifetime of the application; that’s yet another reason why you should limit the use of the container to the application’s COMPOSITION ROOT.

#### 1.3.3. Volatile Dependencies
> A DEPENDENCY should be considered Volatile if any of the following criteria is true:
> - The DEPENDENCY introduces a requirement to set up and configure a runtime environment for the application.
>> A relational database is the archetypical example: if we don’t hide the relational database behind a SEAM, we can never replace it by any other technology. It also makes it hard to set up and run automated unit tests.
> - The DEPENDENCY doesn’t yet exist, but is still in development. The obvious symptom of such dependencies is the inability to do parallel development.
> - The DEPENDENCY isn’t installed on all machines in the development organization. The most common symptom is disabled TESTABILITY.
> - The dependency contains nondeterministic behavior.
>> This is particularly important in unit tests, because all tests should be deterministic. Typical sources of nondeterminism are random numbers and algorithms that depend on the current date or time. Note that common sources of nondeterminism, such as System.Random, System.Security.Cryptography.RandomNumberGenerator, or System.DateTime.Now are defined in mscorlib, so you can’t avoid having a reference to the assembly in which they’re defined. Nevertheless, you should treat them as VOLATILE DEPENDENCIES, because they tend to destroy TESTABILITY.
> VOLATILE DEPENDENCIES are the focal point of DI. It’s for VOLATILE DEPENDENCIES, rather than STABLE DEPENDENCIES, that we introduce SEAMS into our application. Again, this obliges us to compose them using DI.
> Now that you understand the differences between STABLE and VOLATILE DEPENDENCIES, you may begin to see the contours of the scope of DI. Loose coupling is a pervasive design principle, so DI (as an enabler) should be everywhere in your code base.

### 1.4. DI scope
> an important element of DI is to break up various responsibilities into separate classes. One responsibility that we take away from classes is the task of creating instances of DEPENDENCIES.
> As a class relinquishes control of DEPENDENCIES, it gives up more than the decision to select particular implementations. However, as developers, we gain some advantages.
> As developers, we gain control by removing that control from the classes that consume DEPENDENCIES. This is an application of the SINGLE RESPONSIBILITY PRINCIPLE: these classes should only deal with their given area of responsibility, without concerning themselves with how DEPENDENCIES are created.
> DI gives us an opportunity to manage DEPENDENCIES in a uniform way. When consumers directly create and set up instances of DEPENDENCIES, each may do so in its own way, which may be inconsistent with how other consumers do it. We have no way to centrally manage DEPENDENCIES, and no easy way to address CROSS-CUTTING CONCERNS. With DI, we gain the ability to intercept each DEPENDENCY instance and act upon it before it’s passed to the consumer.
> With DI, we can compose applications while intercepting dependencies and controlling their lifetimes. OBJECT COMPOSITION, INTERCEPTION, and LIFETIME MANAGEMENT are three dimensions of DI.

#### 1.4.1. Object Composition
> To harvest the benefits of extensibility, late binding, and parallel development, we must be able to compose classes into applications. Such OBJECT COMPOSITION is often the foremost motivation for introducing DI into an application. Initially, DI was synonymous with OBJECT COMPOSITION;
> There are several ways we can compose classes into an application. When I discussed late binding I used a configuration file and a bit of dynamic object instantiation to manually compose the application from the available modules, but I could also have used CODE AS CONFIGURATION or a DI CONTAINER.

#### 1.4.2. Object Lifetime
> A class that has surrendered control of its DEPENDENCIES gives up more than the power to select particular implementations of an ABSTRACTION. It also gives up the power to control when instances are created, and when they go out of scope.
> In .NET, the garbage collector takes care of a lot of these things for us. A consumer can have its DEPENDENCIES injected into it and use them for as long as it wants. When it’s done, the DEPENDENCIES go out of scope. If no other classes reference them, they’re eligible for garbage collection.
> Because DEPENDENCIES may be shared, a single consumer can’t possibly control its lifetime. As long as a managed object can go out of scope and be garbage collected, this isn’t much of an issue, but when DEPENDENCIES implement the IDisposable interface, things become much more complicated.
> Giving up control of a DEPENDENCY also means giving up control of its lifetime; something else higher up in the call stack must manage the lifetime of the DEPENDENCY.

#### 1.4.3. Interception
> When we delegate control over DEPENDENCIES to a third party, as figure 1.16 shows, we also gain the power to modify them before we pass them on to the classes consuming them.
> Such abilities of INTERCEPTION move us along the path towards Aspect-Oriented Programming—a closely related topic that, nonetheless, is outside the scope of this book. With INTERCEPTION, we can apply CROSS-CUTTING CONCERNS such as logging, auditing, access control, validation, and so forth in a well-structured manner that lets us maintain Separation of Concerns.

#### 1.4.4. DI in three dimensions
> Although DI started out as a series of patterns aimed at solving the problem of OBJECT COMPOSITION, the term has subsequently expanded to also cover OBJECT LIFETIME and INTERCEPTION. Today, I think of DI as encompassing all three in a consistent way.
> OBJECT COMPOSITION tends to dominate the picture because, without flexible OBJECT COMPOSITION, there would be no INTERCEPTION and no need to manage OBJECT LIFETIME. OBJECT COMPOSITION has dominated most of this chapter, and will continue to dominate the book, but we shouldn’t forget the other aspects. OBJECT COMPOSITION provides the foundation and LIFETIME MANAGEMENT addresses some important side effects, but it’s mainly when it comes to INTERCEPTION that we start to reap the benefits.

### 1.5. Summary

## Chapter 2. A comprehensive example
> Telling you that a sauce béarnaise is “an emulsified sauce made from egg yolk and butter” doesn’t magically instill in you the ability to make one. The best way to learn is to practice; an example can often bridge the gap between theory and practice. Watching a professional cook making a sauce béarnaise is helpful before you try it out yourself.

### 2.1. Doing it wrong

#### 2.1.3. Evaluation
> Did Mary succeed in developing a proper, layered application? No, she did not—although she certainly had the best of intentions. She created three Visual Studio projects that correspond to the three layers in the planned architecture, as shown in figure 2.9. To the casual observer, this looks like the coveted layered architecture, but, as you’ll see, the code is tightly coupled.
> Visual Studio makes it easy and natural to work with solutions and projects in this way. If we need functionality from a different library, we can easily add a reference to it and write code that creates new instances of the types defined in these other libraries. Every time we add a reference, we take on a DEPENDENCY.
> - Dependency graph
> When working with solutions in Visual Studio, it’s easy to lose track of the important DEPENDENCIES, because Visual Studio displays them together with all the other project references that may point to assemblies in the .NET Base Class Library (BCL).
> - Evaluating composability
> To evaluate Mary’s implementation, we can ask a simple question:
> *Is it possible to use each module in isolation?*
> In theory, we should be able to compose modules in any way we like. We may need to write new modules to bind existing modules together in new and unanticipated ways, but, ideally, we should be able to do so without having to modify the existing modules.
> The following analysis discusses whether modules can be replaced, but be aware that this is a technique we use to evaluate composability. Even if we never want to swap modules, this sort of analysis uncovers potential issues regarding coupling. If we find that the code is tightly coupled, all the benefits of loose coupling are lost.

#### 2.1.4. Analysis
> - Dependency graph analysis
> Why is the User Interface dependent on the Data Access library? The culprit is this Domain Model method signature:
`public IEnumerable<Product> GetFeaturedProducts(bool isCustomerPreferred)`
> The GetFeaturedProducts method returns a sequence of products, but the Product class is defined in the Data Access library. Any client consuming the GetFeaturedProducts method must reference the Data Access library to be able to compile.
> It’s possible to change the signature of the method to return a sequence of a type defined within the Domain Model. It would also be more correct, but it doesn’t solve the problem.
- Data Access interface analysis
> The Domain Model depends on the Data Access library because the entire data model is defined there. The Product class was generated when Mary ran the LINQ to Entities wizard.
> The offending code can be found spread out in the ProductService class. The constructor creates a new instance of the CommerceObjectContext class and assigns it to a private member variable:
`this.objectContext = new CommerceObjectContext();`
> This tightly couples the ProductService class to the Data Access library. There’s no reasonable way we can intercept this piece of code and replace it with something else. The reference to the Data Access library is hard-coded into the ProductService class.
> This tightly couples the ProductService class to the Data Access library. There’s no reasonable way we can intercept this piece of code and replace it with something else. The reference to the Data Access library is hard-coded into the ProductService class.
> The implementation of the GetFeaturedProducts method uses the CommerceObjectContext to pull Product objects from the database:
````c#
var products = (from p in this.objectContext.Products
                where p.IsFeatured
                select p).AsEnumerable();
````
> This only reinforces the hard-coded dependency, but, at this point, the damage is already done. What we need is a better way to compose modules without such tight coupling.
> - Miscellaneous other issues
> Most of the Domain Model seems to be implemented in the Data Access library. Whereas it’s a technical problem that the Domain Model library references the Data Access library, it’s a conceptual problem that the Data Access library defines such a class as the Product class. A public Product class belongs in the Domain Model.
> Under the influence of Jens, Mary decided to implement the code that determines whether or not a user is a preferred customer in the User Interface. However, how a customer is identified as a preferred customer is a piece of Business Logic, so it ought to be implemented in the Domain Model. Jens’ argument about separations of concern and the SINGLE RESPONSIBILITY PRINCIPLE is no excuse for putting code in the wrong place. Following the SINGLE RESPONSIBILITY PRINCIPLE within a single library is entirely possible—that’s the expected approach.
> The ProductService class relies on XML configuration. As you saw when we followed Mary’s efforts, she forgot that she had to put a particular piece of configuration code in her web.config file. Although the ability to configure a compiled application is important, only the finished application should rely on configuration files. It’s much more flexible for reusable libraries to be imperatively configurable by their callers. In the end, the ultimate caller is the application itself. At that point, all relevant configuration data can be read from a .config file and fed to the underlying libraries, as needed.
> The View (as shown in listing 2.3) seems to contain too much functionality. It performs casts and specific string formatting. Such functionality should be moved to the underlying model.

### 2.2. Doing it right
> Dependency Injection (DI) can be used to solve the issues that we discovered. Because DI is a radical departure from the way Mary created her application, I’m not going to modify it. Rather, I’m going to re-create it from scratch.
> Many people refer to DI as INVERSION OF CONTROL (IoC). These two terms are sometimes used interchangeably, but DI is a subset of IoC.
> Before DI had a name, people started to refer to frameworks that manage DEPENDENCIES as Inversion of Control Containers, and soon, the meaning of IoC gradually drifted towards that particular meaning: Inversion of Control over DEPENDENCIES. Always the taxonomist, Martin Fowler introduced the term Dependency Injection to specifically refer to IoC in the context of dependency management.[5](http://martinfowler.com/articles/injection.html)Dependency Injection has since been widely accepted as the most correct terminology.
> In short, IoC is a much broader term that includes, but isn’t limited to, DI.
> In the context of managing dependencies, INVERSION OF CONTROL accurately describes what we’re trying to accomplish. In Mary’s application, the code directly controls its dependencies: when the ProductService needs a new instance of the CommerceObjectContext class, it simply creates an instance using the new keyword. When the HomeController needs a new instance of the ProductService class, it, too, news up an instance. The application is in total control. That may sound powerful, but it’s actually limiting. I call this the CONTROL FREAK anti-pattern. INVERSION OF CONTROL instructs us to let go of that control and let something else manage the dependencies.

#### 2.2.1. Rebuilding the commerce application
> *When I write software, I prefer to start in the most significant place. This is often the user interface.* From there, I work my way in, adding more functionality until the feature is done and I can move on to the next. This outside-in technique helps me to focus on the requested functionality without over-engineering the solution.
> The outside-in technique is closely related to the YAGNI principle (“You Aren’t Gonna Need It”). This principle emphasizes that only required features should be implemented, and that the implementation should be as simple as possible.
> Because I always practice Test-Driven Development (TDD), I start by writing unit tests as soon as my outside-in approach prompts me to create a new class. Although I wrote a lot of unit tests to create this example, TDD isn’t required to implement and use DI, so I’m not going to show these tests in the book.
- User interface
> The specification for the list of featured products is to write an application that extracts the featured products from the database and displays them in a list, as shown in figure 2.3. Because I know that the project’s stakeholders will mainly be interested in the visual result, the User Interface sounds like a good place to start.
> The first thing I do after opening Visual Studio is to add a new ASP.NET MVC application to my solution. Because the list of featured products needs to go on the front page, I start by modifying the Index.aspx to include the markup shown in the following listing.
> The entire product display string is pulled directly from the SummaryText property of the product.
> Both improvements are related to the introduction of View-specific Models that encapsulate the behavior of the View. These Models are Plain Old CLR[6](Common Language Runtime) Objects (POCOs).
> The HomeController must return a View with an instance of FeaturedProductsViewModel for the code in listing 2.4 to work.
> Although a user interface exists, it doesn’t do much of interest. The list of featured products is always empty, so I need to implement some Domain Logic that can supply a proper list of products.
- Domain Model
> The Domain Model is a plain vanilla C# library that I add to the solution. This library will contain POCOs and abstract types. The POCOs will model the Domain while the abstract types provide abstractions that will serve as my main external entry point into the Domain Model.
> The principle of programming to interfaces instead of concrete classes is a cornerstone of DI. It’s this principle that allows us to replace one concrete implementation with another.
- Interfaces or abstract classes?
> Many guides to object-oriented design focus on interfaces as the main abstraction mechanism, whereas the .NET Framework Design Guidelines endorse abstract classes over interfaces.[7] Should you use interfaces or abstract classes?
> With relation to DI, the reassuring answer is that it doesn’t matter. The important part is that you program against some sort of abstraction.
> Choosing between interfaces and abstract classes is important in other contexts, but not here. You’ll notice that I use the words interchangeably; I often use the term ABSTRACTION to encompass both interfaces and abstract classes.

