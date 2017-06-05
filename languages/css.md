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
1. use white-space: wrap;. If you have set width on the element on which you are setting this it should work.

## 100% width table overflowing div container
1. You can prevent tables from expanding beyond their parent div by using `width: 100%; table-layout:fixed`.
2. The 'table-layout' property controls the algorithm used to lay out the table cells, rows, and columns. Values have the following meaning:
- fixed: Use the fixed table layout algorithm
- auto: Use any automatic table layout algorithm
3. Fixed table layout: With this (fast) algorithm, the horizontal layout of the table does not depend on the contents of the cells; it only depends on the table's width, the width of the columns, and borders or cell spacing. The table's width may be specified explicitly with the 'width' property. A value of 'auto' (for both 'display: table' and 'display: inline-table') means use the automatic table layout algorithm. However, if the table is a block-level table ('display: table') in normal flow, a UA may (but does not have to) use the algorithm of 10.3.3 to compute a width and apply fixed table layout even if the specified width is 'auto'.

