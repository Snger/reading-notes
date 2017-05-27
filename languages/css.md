## transform: matrix(1, 0, 0, 1, 317.4, -235);
1. The origin, the (0, 0) is the top-left corner of the element.
2. The matrix() CSS function specifies a homogeneous 2D transformation matrix comprised of the specified six values. The constant values of such matrices are implied and not passed as parameters; the other parameters are described in the column-major order. matrix(a, b, c, d, tx, ty) is a shorthand for matrix3d(a, b, 0, 0, c, d, 0, 0, 0, 0, 1, 0, tx, ty, 0, 1).
3. (matrix count)[https://developer.mozilla.org/@api/deki/files/5799/=transform_functions_generic_transformation_cart.png], (matrix count2)[https://developer.mozilla.org/@api/deki/files/5800/=transform_functions_transform_composition_cart.png]
4. 3*3矩阵每一行的第1个值与后面1*3的第1个值相乘，第2个值与第2个相乘，第3个与第3个，然后相加，如下图同色标注

## flex
1. The flex CSS property is a shorthand property specifying the ability of a flex item to alter its dimensions to fill available space. Flex items can be stretched to use available space proportional to their flex grow factor or their flex shrink factor to prevent overflow.
2. Formal syntax: `none | [ <'flex-grow'> <'flex-shrink'>? || <'flex-basis'> ]`
3. `.container {display: flex; /* or inline-flex */} .children{flex: 1;}`

