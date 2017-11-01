# html
<!-- MarkdownTOC -->

- How to prevent favicon.ico requests?
- Can we have multiple tbody in same table?
- IconFont和FontAwesome的区别？

<!-- /MarkdownTOC -->

## How to prevent favicon.ico requests?
1. <link rel="icon" href="data:;base64,="> I left out the "shortcut" name from the "rel" attribute value since that's only for older IE and versions of IE < 8 doesn't like dataURIs either. Not tested on IE8.
2. <link rel="icon" href="data:;base64,iVBORw0KGgo="> If you need your document to validate against HTML5 use this instead
3. Your UPDATE 2 had issues on Android – 5.0 Lollipop...adding <link rel="icon" type="image/png" href="data:image/png;base64,iVBORw0KGgo="> seems to solve the issue.
4. If this is just about creating an data URL that describes an empty file, use: <link rel="icon" href="data:,">

## Can we have multiple tbody in same table?
1. Yes. From the [DTD](http://www.w3.org/TR/xhtml1/dtds.html)
````
<!ELEMENT table
     (caption?, (col*|colgroup*), thead?, tfoot?, (tbody+|tr+))>
````
> So it expects one or more. It then goes on to say
> Use multiple tbody sections when [rules](http://www.w3.org/TR/html401/struct/tables.html#h-11.3.1) are needed between groups of table rows.

## IconFont和FontAwesome的区别？
> - Iconfont
Iconfont支持所有低版本浏览器；
Iconfont的图标库更大；
Iconfont可以用自己上传的svg，但是要花费大量时间和耐心去设计AI图标；
Iconfont的使用更灵活，可以自由搭配组合，按需索取。如果网站只需用5个图标，那么仅下载这5个图标的字体文件和相关css即可。如果使用Iconfont的CDN服务，你都不用下载文件，直接将这几个图标添加到自己的项目中，然后在你的网站里面引用一个css文件即可。
访问网址： [http://iconfont.cn/](http://iconfont.cn/), [http://iconfont.com](http://iconfont.com)
> - Font awesome
Bootstrap包含font awesome；
Fontawesome只支持IE7+的高版本浏览器；
Fontawesome只能用别人的字体文件；
Fontawesome，即便只用到2个图标，你都得把所有文件下载下来，才能使用。而且svg和其他字体文件加起来，大小总共有400+KB。
访问网址是： [http://fontawesome.dashgame.com/](http://fontawesome.dashgame.com/)
