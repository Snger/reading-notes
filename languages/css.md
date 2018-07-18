# css
<!-- MarkdownTOC -->

- transform: matrix\(1, 0, 0, 1, 317.4, -235\);
- flex
- Viewport Sized Typography
- How to force a line break in a loooooong word in a DIV?
- Stop word-wrap dividing words
- 100% width table overflowing div container
- Fixed 'thead' width doesn't match with the 'tbody' width
- Centering in the Unknown
- HTML position:fixed page header and in-page anchors
- rendering  as text not as a newline
- Gaussian blur all content

<!-- /MarkdownTOC -->

## transform: matrix(1, 0, 0, 1, 317.4, -235);
1. The origin, the (0, 0) is the top-left corner of the element.
2. The matrix() CSS function specifies a homogeneous 2D transformation matrix comprised of the specified six values. The constant values of such matrices are implied and not passed as parameters; the other parameters are described in the column-major order. matrix(a, b, c, d, tx, ty) is a shorthand for matrix3d(a, b, 0, 0, c, d, 0, 0, 0, 0, 1, 0, tx, ty, 0, 1).
3. (matrix count)[https://developer.mozilla.org/@api/deki/files/5799/=transform_functions_generic_transformation_cart.png], (matrix count2)[https://developer.mozilla.org/@api/deki/files/5800/=transform_functions_transform_composition_cart.png]
4. 3*3矩阵每一行的第1个值与后面1*3的第1个值相乘，第2个值与第2个相乘，第3个与第3个，然后相加，如下图同色标注

## flex
1. The flex CSS property is a shorthand property specifying the ability of a flex item to alter its dimensions to fill available space. Flex items can be stretched to use available space proportional to their flex grow factor or their flex shrink factor to prevent overflow.
2. Formal syntax: `none | [ <'flex-grow'> <'flex-shrink'>? || <'flex-basis'> ]`
3. `.container {display: flex; /* or inline-flex */} .children{flex: 1;}`

## Viewport Sized Typography
1. CSS3 has some new values for sizing things relative to the current viewport size: vw, vh, and vmin.
2. One unit on any of the three values is 1% of the viewport axis. "Viewport" == browser window size == window object. If the viewport is 40cm wide, 1vw == 0.4cm.
- 1vw = 1% of viewport width
- 1vh = 1% of viewport height
- 1vmin = 1vw or 1vh, whichever is smaller
- 1vmax = 1vw or 1vh, whichever is larger

## How to force a line break in a loooooong word in a DIV?
1. word-break: break-all;
2. <wbr> (word break) means: "The browser may insert a line break here, if it wishes." It the browser does not think a line break necessary nothing happens.

## Stop word-wrap dividing words
1. use white-space: nowrap;. If you have set width on the element on which you are setting this it should work.

## 100% width table overflowing div container
1. You can prevent tables from expanding beyond their parent div by using `width: 100%; table-layout:fixed`.
2. The 'table-layout' property controls the algorithm used to lay out the table cells, rows, and columns. Values have the following meaning:
- fixed: Use the fixed table layout algorithm
- auto: Use any automatic table layout algorithm
3. Fixed table layout: With this (fast) algorithm, the horizontal layout of the table does not depend on the contents of the cells; it only depends on the table's width, the width of the columns, and borders or cell spacing. The table's width may be specified explicitly with the 'width' property. A value of 'auto' (for both 'display: table' and 'display: inline-table') means use the automatic table layout algorithm. However, if the table is a block-level table ('display: table') in normal flow, a UA may (but does not have to) use the algorithm of 10.3.3 to compute a width and apply fixed table layout even if the specified width is 'auto'.

## Fixed 'thead' width doesn't match with the 'tbody' width
1. Adding table-layout:fixed to the table and display:table to the thead fixes your problem.
1. This is kind of a sloppy fix though, since the table-layout:fixed affects the entire layout and might not look how you want it to.
1. You could also set percentage widths on the columns instead of using table-layout:fixed for more control over the layout.

## Centering in the Unknown
1. Centering in the Unknown
> If you know the height and width of both the element to be centered and its parent element (and those measurements won't change, i.e. not fluid width environment) one foolproof way to center the element is just to absolute position it with pixel values so it looks perfectly centered.
> Let's say you know the exact width and height of the element you are centering, but the parent element can change in height and width.
> You absolutely position the element to be centered and set the top and left values to 50% and the margin top and left values to negative half of the elements height and width.
2. Harder: Unknown Child
> The grossest way to handle it is literally tables
> If you are worried about the semantics of that, you could attempt to match it to your content. And get the same result as the tables like.
> CSS tables might be fine for you. Or it might not. Tables do render a bit differently than just a regular block-level div does. For instance the 100% width thing. A table will only stretch to be as wide as it needs to for the content inside it whereas by default a block level element will expand to the width of its parent automatically. Also, god help you if you need other content inside that div that you want to position or otherwise not act as a table-cell.
> Michał Czernow wrote in to me with an alternate technique that is extremely clever and accomplishes the same thing. If we set up a "ghost" element inside the parent that is 100% height, then we vertical-align: middle both that and the element to be centered, we get the same effect.
> So does that ghost element need to be an un-semantic element? Nope, it can be a pseudo element.
> I'd like to tell you the ghost element technique is way better and should be the go-to centering technique for the ages. But in reality, it's just about the same as the table trick. The browser support for this is essentially everything and IE 8+. IE 7 doesn't support pseudo elements. But it doesn't support CSS tables either, so it's a horse apiece. If IE <= 7 support is needed, it's <table> time (or use an equally un-semantic <span> or something for the ghost element).

## HTML position:fixed page header and in-page anchors
> 
````css
.fix-header {
	height: 40px
}
.anchor {
    padding-top: 40px;
}
````

## rendering <br> as text not as a newline
> `white-space: pre-line;`

## Gaussian blur all content
````css
.signup_wall_prevent_scroll .SiteHeader, .signup_wall_prevent_scroll .LoggedOutFooter, .signup_wall_prevent_scroll .ContentWrapper {
    filter: blur(3px);
}
````
