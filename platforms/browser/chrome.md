## How to reset Chrome DevTools sort requests?
1. By default, the resources in the Requests Table are sorted by the start time of each request, starting with the earliest requests at the top.
2. Click on the header of a column to sort the table by each resource's value for that header. Click the same header again to change the sort order to ascending or descending.
3. The Timeline column is unique from the others. When clicked, it displays a menu of sort fields:
4. Timeline. Sorts by the start time of each network request. This is the default sort, and is the same as sorting by the Start Time option.
Start Time. Sorts by the start time of each network request (same as sorting by the Timeline option).

## Chrome for iOS gets an offline Read Later feature
1. Google has officially brought a Pocket-like Read Later feature to the latest version of Chrome for iOS, as rumored by 9to5Mac last week. The feature works a lot like Apple’s Reading List feature in Safari — there’s a new “Read Later” icon that appears on the share sheet in Chrome, which saves articles locally on the device to read later, even without an internet connection.

## Chrome DevTools converts all HEX Colors to RGB
1. In Chrome DevTools window: Click "3 dots" icon at the far right corner, select "Settings", in the "Preferences" panel find "Elements" > "Color format", select the option you wish to have, "As authored" is the default option.

## How Source Maps Work
1. A source map provides a way of mapping code within a compressed file back to it’s original position in a source file. This means that – with the help of a bit of software – you can easily debug your applications even after your assets have been optimized. The Chrome and Firefox developer tools both ship with built-in support for source maps.
2. Note: Support for source maps is enabled by default in Firefox’s developer tools. You may need to enable support manually in Chrome. To do this, launch the Chrome dev tools and open the Settings pane (cog in the bottom right corner). In the General tab make sure that Enable JS source maps and Enable CSS source maps are both ticked.
3. You indicate to the browser that a source map is available by adding a special comment to the bottom of your optimised file. `//# sourceMappingURL=/path/to/script.js.map` This comment will usually be added by the program that was used to generate the source map. The developer tools will only load this file if support for source maps is enabled and the developer tools are open.
4. You can also specify a source map is available by sending the X-SourceMap  HTTP header in the response for the compressed JavaScript file. `X-SourceMap: /path/to/script.js.map`
5. The source map file contains a JSON object with information about the map itself and the original JavaScript files. 
> version – This property indicates which version of the source map spec the file adheres to.
> file – The name of the source map file.
> sources – An array of URLs for the original source files.
> sourceRoot – (optional) The URL which all of the files in the sources  array will be resolved from.
> names – An array containing all of the variable and function names from your source files.
> mappings – A string of Base64 VLQs containing the actual code mappings. (This is where the magic happens.)
