# zeal
> Zeal is a simple offline documentation browser inspired by Dash.

## Add maven docsets to zeal
1. Zeal has a (Tools -> Docsets -> Add feed) option to add external docsets but I was unable to find the feeds for the maven.org docsets.
1. That being said, you can add feeds for user-contributed docsets - perhaps that will have the docs you're looking for? I found two options for getting the user-contributed docset feed URLs:
> Search via https://zealusercontributions.herokuapp.com/
> Get the URL to the raw XML on github at https://github.com/zsoltika/feeds
1. These are not officially supported by the zeal/dash maintainers so use at your own risk! I found these solutions in the "Show Dash user contrib docsets in Zeal" github issue.
1. You might be able to generate the docsets yourself but, in looking around the app UI, I found no intuitive way to get that into zeal either.