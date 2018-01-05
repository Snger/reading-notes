# feedly

## How to add Feedly to the Chrome RSS Subscription Extension (by Google)
>  I already use the [Chrome RSS Subscription Extension (by Google)](https://chrome.google.com/webstore/detail/rss-subscription-extensio/nlbjncdgjeocebhnmkbbbdekmmmcbfjd) which gives me a handy icon in my address bar when a feed is detected.
- Unfortunately though it doesn’t have Feedly as a service …
- Clicking on ‘Manage…’ gives the rather daunting
- A quick search for a Feedly specific url turned up Add Feedly to Firefox’s Feed Handlers List and I recognised that the browser.contentHandlers.types.#.uri would do the trick. So using the following in the Edit feed reader dialog:
Description: Feedly
URL: http://cloud.feedly.com/#subscription/feed/%s
