## How to manually fire validation of a textbox with angularJS?
> $scope.tradeForm[modelName].$setDirty();

## the `watchExpression` of angular.$watch(watchExpression, listener, [objectEquality]);
1. Registers a listener callback to be executed whenever the watchExpression changes.
2. The watchExpression is called on every call to $digest() and should return the value that will be watched. (watchExpression should not change its value when executed multiple times with the same input because it may be executed multiple times by $digest(). That is, watchExpression should be idempotent.)
3. Idempotence (UK: /ˌɪdɛmˈpoʊtns/; US: /ˌaɪdᵻmˈpoʊtəns/ eye-dəm-poh-təns) is the property of certain operations in mathematics and computer science, that can be applied multiple times without changing the result beyond the initial application. The concept of idempotence arises in a number of places in abstract algebra (in particular, in the theory of projectors and closure operators) and functional programming (in which it is connected to the property of referential transparency).

## $compile.directive.attributes.$observe(key, fn)
1. Observes an interpolated attribute.
2. The observer function will be invoked once during the next `$digest` following compilation. The observer is then invoked whenever the interpolated value changes.
3. Parameters:
> key	string	Normalized key. (ie ngAttribute) .
> fn	function(interpolatedValue)	Function that will be called whenever the interpolated value of the attribute changes. See the Interpolation guide for more info.

## Interpolation and data-binding
1. Interpolation markup with embedded expressions is used by Angular to provide data-binding to text nodes and attribute values.
2. How text and attribute bindings work:
> During the compilation process the compiler uses the $interpolate service to see if text nodes and element attributes contain interpolation markup with embedded expressions.
> If that is the case, the compiler adds an interpolateDirective to the node and registers watches on the computed interpolation function, which will update the corresponding text nodes or attribute values as part of the normal digest cycle.

## angular.isDefined
1. Determines if a reference is defined.
2. Usage: angular.isDefined(value);
> Arguments:	value	*	Reference to check.
3. Returns:	boolean	True if value is defined.

## How to reload or re-render the entire page using AngularJS?
1. $route.reload(); // $route is used for deep-linking URLs to controllers and views (HTML partials). Causes $route service to reload the current route even if $location hasn't changed. As a result of that, ngView creates new scope, reinstantiates the controller.
2. $route.reload() will reinitialise the controllers but not the services. If you want to reset the whole state of your application you can use: `$window.location.reload(forcedReload);` This is a standard DOM method which you can access injecting the $window  service.
3. The Location.reload() method reloads the resource from the current URL. Its optional unique parameter is a Boolean, which, when it is true, causes the page to always be reloaded from the server. If it is false or not specified, the browser may reload the page from its cache. Besides caching behaviour forcedReload flag also impacts how some browsers handle scroll position: ordinary reload happens to try to restore scroll position after reloading page DOM, while in forced mode (when parameter is set to true) the new DOM gets loaded with scrollTop == 0.

## Using $q.all() to Resolve Multiple Promises
1. If you have a lot of promises in Angular that need to be run sequentially, you can go about it in one of two ways. There is the classic way of chaining callback functions together to achieve the desired result. Or there is the better way, which uses $q.all().
2. `$q.all`: Combines multiple promises into a single promise that is resolved when all of the input promises are resolved.
3. [param] promises Array.<Promise>Object.<Promise> An array or hash of promises.
4. [Return] Promise: Returns a single promise that will be resolved with an array/hash of values, each value corresponding to the promise at the same index/key in the promises array/hash. If any of the promises is resolved with a rejection, this resulting promise will be rejected with the same rejection value.

## ngRoute.ngView.$viewContentLoaded
1. ngView is a directive that complements the $route service by including the rendered template of the current route into the main layout (index.html) file. Every time the current route changes, the included view changes with it according to the configuration of the $route service. Requires the ngRoute module to be installed.
2. [event] $viewContentLoaded: Emitted every time the ngView content is reloaded. [Type] emit [Target] the current ngView scope

## In angular, how to use cancel an $interval on user events, like page change?
1. When the DOM element is removed from the page, AngularJS will trigger the $destroy event on the scope. This gives us a chance to cancel any pending timer that we may have.
````javascript
$scope.$on(
    "$destroy",
    function( event ) {
        $timeout.cancel( timer );
    }
);
````
