# Calibre

<!-- MarkdownTOC -->

- Adding your favorite news website
- convert book

<!-- /MarkdownTOC -->

## Adding your favorite news website
1. calibre has a powerful, flexible and easy-to-use framework for downloading news from the Internet and converting it into an ebook.
2. If your news source is simple enough, calibre may well be able to fetch it completely automatically, all you need to do is provide the URL. calibre gathers all the information needed to download a news source into a recipe. In order to tell calibre about a news source, you have to create a recipe for it.
3. To test your new recipe, click the Fetch news button and in the Custom news sources sub-menu click calibre Blog. After a couple of minutes, the newly downloaded ebook of blog posts will appear in the main library view (if you have your reader connected, it will be put onto the reader instead of into the library). Select it and hit the View button to read!
4. The best way to develop new recipes is to use the command line interface. Create the recipe using your favorite python editor and save it to a file say myrecipe.recipe. The .recipe extension is required. You can download content using this recipe with the command: `ebook-convert myrecipe.recipe .epub --test -vv --debug-pipeline debug`
5. The command ebook-convert will download all the webpages and save them to the EPUB file myrecipe.epub. The -vv option makes ebook-convert spit out a lot of information about what it is doing. The ebook-convert-recipe-input --test option makes it download only a couple of articles from at most two feeds. In addition, ebook-convert will put the downloaded HTML into the debug/input directory, where debug is the directory you specified in the ebook-convert --debug-pipeline option.
6. Once the download is complete, you can look at the downloaded HTML by opening the file debug/input/index.html in a browser. Once you’re satisfied that the download and preprocessing is happening correctly, you can generate ebooks in different formats as shown below: `ebook-convert myrecipe.recipe myrecipe.epub`

## convert book
> convert books - output format: mobi - mobi output - mobi file type: new(KF8 format)
