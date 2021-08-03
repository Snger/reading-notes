# jQuery

## Remove All classes From Div
> You can use removeClass without using any class as a parameter.
> Description: Remove a single class, multiple classes, or all classes from each element in the set of matched elements.

## Button click not firing in modal window (Bootstrap)
> 
````js
$('#submit_btn').click(function(event){
    event.preventDefault();
    alert( "GO" ); 
});
// Try this
$(document).on("click", "#submit_btn", function(event){
    alert( "GO" ); 
});
// Or this -
$(document).delegate("#submit_btn", "click", function(event){
    alert( "GO" ); 
});
````
