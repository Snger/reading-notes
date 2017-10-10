# Mastering React Native
> Authors: Eric Masiello, Jacob Friedmann
> Copyright © 2017 Packt Publishing
> ISBN 978-1-78588-578-5

<!-- MarkdownTOC -->

- Chapter 1. Building a Foundation in React
    - Motivation for React
    - Describing components in JSX
    - The component
    - Component composition
    - Props and PropTypes
        - Passing props
        - Default props
        - Props.children
    - Event handlers

<!-- /MarkdownTOC -->

# Chapter 1. Building a Foundation in React
## Motivation for React
> The foundational building block in a React application is the component, which is a declarative description of some visual feature on the page, such as a form or a menu. The declarative nature of components promotes predictability: given some set of external inputs (properties), the output is well defined and deterministic.
> React also aims to combat one of the hurdles to writing efficient applications: the Document Object Model (DOM) is notoriously slow. If changes to the DOM are relatively infrequent, this may not be a problem, but in a complex application the time it takes to alter and redraw the DOM can add up. This is especially true for applications that take a declarative approach as React does, which necessitates re-rendering whenever the application's state changes.
> The solution proposed by the React framework is to keep a representation of the DOM in memory, called a virtual DOM, and make all alterations there. Once the alterations have been made in memory, React can apply the minimum number of changes necessary to reconcile the real DOM with the virtual DOM. This also can allow quickly successive changes to be batched for greater efficiency. Taking this approach can lead to great gains in performance that can be noticed by end users.
> In addition to solving some of the common problems faced when creating JavaScript applications, React components are modular and emphasize composition over inheritance, which makes code immensely reusable and testable. Additionally, a React component often has rendering logic, markup declaration, and even styles in the same file, which promotes the portability of code and the ability to write shared libraries of components.

## Describing components in JSX
> Using JSX is not an absolute requirement for writing React, but without it, React becomes verbose and cumbersome. Furthermore, since most developers will be using tools such as Babel already to convert their ES2015 code into JavaScript, writing in JSX does not add much burden because most of those tools come with support for JSX built in.
> It differs from HTML5 only slightly. HTML and JSX have a common ancestor language called XML (Extensible Markup Language). HTML has since diverged in some ways from strict XML that JSX has not. For instance, in the case of a tag such as the image tag (that is, <img>) HTML and JSX differ. The <img> tag is called self-closing in that there is no standalone closing tag like we might see with a <div> or a <p>.
> There are other differences between JSX and HTML that arise from JSX being written in the context of JavaScript. The first is that class is a keyword in JavaScript, whereas that word is used as an attribute of HTML elements to allow elements to be targeted by CSS for styling. So, when we would use class in HTML, we instead have to use className in JSX
> A consolation prize for this small inconvenience is we get the benefit of being able to interleave JavaScript into places in our markup where we typically wouldn't in normal HTML. For instance, defining inline styles can use a JavaScript object, rather than cramming all properties into a string.
> Not only can attribute values be written in JavaScript, but so too can the content contained between JSX tags. This way, we can use dynamic properties to render text content.

## The component
>In React, we build applications using composable, modular components. These components represent parts of our visual interface and are rendered as such. In their most simple form, they are simply a description of how to render. We create a component by using ES2015 class syntax
> Since the only requirement is that a render() method is defined, this is now a valid and complete (albeit not especially useful) React component.
> In a typical React application project, a component will be self-contained within a file. Files that contain JSX, such as a component file, sometimes have a .jsx extension in web projects; however, this practice is less common in React Native projects. This extension helps tools such as Babel know how to transform them into browser-compatible JavaScript.

## Component composition
> As was mentioned earlier in this chapter, React favors composition over inheritance. What does this mean? In essence, it means to build complex or derivative components, instead of using something akin to object-oriented inheritance, we use composition to build up complexity from simple building blocks.
> Composition has other uses besides making increasingly more complex components from smaller, simpler building blocks. Composition can also be used to make derivative components, a task that in an object-oriented programming world we might use inheritance to achieve.

## Props and PropTypes
> React provides a mechanism for making components dynamic by using properties, or props.
> Defining PropTypes in a component is how we formally tell other developers what properties a component accepts and what value types those properties should be. PropTypes are the same across instances of a component and are thus statically attached to the class
> Adding PropTypes to a component does not change anything functionally, but it will cause annoying warning messages to be logged to the JavaScript console when they are disobeyed (only when React is in development mode, mind you).
> To use PropTypes, we'll need to add it to the React import
> The PropTypes module comes with functions for validating different value types, such as string, number, and func.
> One thing to note with the preceding example is that CSS properties that have a dash in them when written in traditional CSS use camel case in React inline style. This is because keys in JavaScript objects cannot contain dashes.
> React PropType specifications can also be used to validate more complex properties. For instance, we could have a property that is either a string or a number using the oneOfType function, which is as follows.
> Likewise, we can specify a set of specific values that a property is allowed to take by using the oneOf method.
> We can of course specify more complex data types, such as arrays and objects, but we can also be more specific and describe the types of values in an array property or the shape that an object property takes.
> Alternatively, PropTypes can be added to a React component as a static property using the static keyword

### Passing props
> With a component defined that accepts props, the next step is for props to be passed into this component.
> Strings are the only value types that can be passed in as a prop directly, For other JavaScript data types, such as numbers, Booleans, and arrays, we must surround the values in curly braces so that they are interpreted correctly as JavaScript, For Boolean props, we can shorten their input to where the property name's presence is interpreted as true and its absence is interpreted as false, much like in HTML.

### Default props
> `defaultProps` must be a JavaScript object where keys are property names and the values are the default values to use in the case that no values were passed in for that particular property.

### Props.children
> Every component has an optional special property that is called *children*. Normal properties, as we have seen, are passed in using something similar to the HTML attribute syntax
> When validating the children prop, we can use a special PropTypes called node, which means anything that can be rendered by React

## Event handlers
> In JavaScript development, we often think of our application as reacting to user events on the page. For instance, we may listen for a submit button on the page to be clicked, and when it is, validate a form. Functions that respond to these user events are sometimes dubbed event handlers or event listeners.
> In React, the way we do event handling is more like the inline JavaScript of yesteryear. Elements in React can optionally take event handler properties in order to respond to user inputs. A React element is the portion of a component that is returned from the render function. In other words, it is a description of what we want rendered on the screen, generally written in JSX. Our form from the previous example written in JSX would only have a couple of subtle differences.
> Take note that we are binding the render method's this context to the onClick method when adding it as a click handler, We need to do this in order to ensure this has the same meaning in the onClick method as it does in other component methods. This way, we can still access props and call other component methods. However, the better way to bind the this context to the event handler method is to do so within the component's constructor.
> Event listeners in React, much as they do without React, receive an optional argument that is an object representing the user event. We can access this event object in order to suppress default behavior, for instance, in a form submission, by using event.preventDefault(). We can also use the event object to, for example, see what document element was targeted by the action or, in the case of a key press event, see which specific key was pressed by the user. To get access to the event, we just need to add it as a parameter to our event listener method.
