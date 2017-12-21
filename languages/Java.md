# Java

## What Version Of JAVA JRE do I have?
> you can get the precise version string from your installed JRE by opening a command window, cding to your JRE's binaries folder, and doing java -version. For example, on my laptop I do
````bash
C:\Program Files (x86)\Java\jre7\bin>java -version
java version "1.7.0_51"
Java(TM) SE Runtime Environment (build 1.7.0_51-b13)
Java HotSpot(TM) Client VM (build 24.51-b03, mixed mode, sharing)
This is JRE 1.7.0 update 51, or just 'Java 7 update 51'.
````

## in Java syntax, Class<? extends Something>
> Basically, Java has no concept of templates (C++ has). This is called generics. And this defines a generic class Class<> with the generics' attribute being any subclass of Something.
> I suggest reading up "[What are the differences between “generic” types in C++ and Java?](https://stackoverflow.com/questions/36347/what-are-the-differences-between-generic-types-in-c-and-java)" if you want to get the difference between templates and generics.
> In Java generics, the ? operator means "any class". The extends keyword may be used to qualify that to "any class which extends/implements Something (or is Something).
> Thus you have "the Class of some class, but that class must be or extend/implement Something".

## What is SuppressWarnings (“unchecked”) in Java?
> It is an annotation to suppress compile warnings about unchecked generic operations (not exceptions), such as casts. It essentially implies that the programmer did not wish to be notified about these which he is already aware of when compiling a particular bit of code.
> You can read more on this specific annotation here: [SuppressWarnings](https://docs.oracle.com/javase/8/docs/api/java/lang/SuppressWarnings.html)
Additionally, Oracle provides some tutorial documentation on the usage of annotations here: [Annotations](https://docs.oracle.com/javase/tutorial/java/annotations/predefined.html)
> As they put it,
> "The 'unchecked' warning can occur when interfacing with legacy code written before the advent of generics (discussed in the lesson titled Generics)."

