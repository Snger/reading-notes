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
