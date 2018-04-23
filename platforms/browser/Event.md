# Event

<!-- MarkdownTOC -->

- Inspect attached event handlers for any DOM element

<!-- /MarkdownTOC -->

## Inspect attached event handlers for any DOM element
> - chrome
> Chrome Dev Tools recently announced some new tools for Monitoring JavaScript Events.
>> Listen to events of a certain type using monitorEvents().
>> Use unmonitorEvents() to stop listening.
>> Get listeners of a DOM element using getEventListeners().
>> Use the Event Listeners Inspector panel to get information on event listeners.
- Finding Custom Events
> For my need, discovering custom JS events in 3rd party code, the following two versions of the getEventListeners() were amazingly helpful;
	getEventListeners(window)
	getEventListeners(document)
> If you know what DOM Node the event listener was attached to you'd pass that instead of window or  document.
- Known Event
If you know what event you wish to monitor e.g. click on the document body you could use the following: monitorEvents(document.body, 'click');.
You should now start seeing all the click events on the document.body being logged in the console.
> - Visual Event
> You can use Visual Event by Allan Jardine to inspect all the currently attached event handlers from several major JavaScript libraries on your page. It works with jQuery, YUI and several others.
> Visual Event is a JavaScript bookmarklet so is compatible with all major browsers.
