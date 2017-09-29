## How to prevent favicon.ico requests?
1. <link rel="icon" href="data:;base64,="> I left out the "shortcut" name from the "rel" attribute value since that's only for older IE and versions of IE < 8 doesn't like dataURIs either. Not tested on IE8.
2. <link rel="icon" href="data:;base64,iVBORw0KGgo="> If you need your document to validate against HTML5 use this instead
3. Your UPDATE 2 had issues on Android – 5.0 Lollipop...adding <link rel="icon" type="image/png" href="data:image/png;base64,iVBORw0KGgo="> seems to solve the issue.
4. If this is just about creating an data URL that describes an empty file, use: <link rel="icon" href="data:,">

## Can we have multiple <tbody> in same <table>?
1. Yes. From the [DTD](http://www.w3.org/TR/xhtml1/dtds.html)
````
<!ELEMENT table
     (caption?, (col*|colgroup*), thead?, tfoot?, (tbody+|tr+))>
````
> So it expects one or more. It then goes on to say
> Use multiple tbody sections when [rules](http://www.w3.org/TR/html401/struct/tables.html#h-11.3.1) are needed between groups of table rows.
