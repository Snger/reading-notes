# Dependency Injection in .NET
> Author: Mark Seemann
> ©2012 by Manning Publications Co.
> ISBN-13: 978-1935182504
> ISBN-10: 1935182501
<!-- MarkdownTOC -->

- Part 1. Putting Dependency Injection on the map
	- Chapter 1. A Dependency Injection tasting menu

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
