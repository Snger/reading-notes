## What exactly is “sencha app watch” doing?
1. docs
	1. This command watches the current application's source code for changes and and rebuild the necessary outputs to support "dev mode".
	1. This will run an initial pass over the ant targets specified by the build.trigger.targets ant property. During this pass, the compiler will be instrumented to capture the files used as inputs for the build (JavaScript, Sass and page resources).
	1. A subset of Ant build targets will be re-triggered each time a file in one if the directories being monitored is created, deleted, or modified.
	1. A web server is automatically started and hosts the application at the default port of 1841.
	1. The high-level logic of the watch process is implemented in Ant. For details, see ".sencha/app/watch-impl.xml.".
	1. For information regarding the set of available Ant properties that control the the watch process, see ".sencha/app/defaults.properties".
2. stackoverflow
	1. It's doing the equivalent of sencha app build development. The reason it goes faster is that it keeps the JVM running and it doesn't re-run the initialisation tasks continually.
	2. If you want to take more control of this yourself, the relevant Ant tasks are in the Sencha CMD distribution - most (but not all) Sencha CMD commands are delegated down to the Ant tasks.
	3. It's a little smarter than doing a simple build - because it knows which files have been changed, it knows what steps it needs to do. As such, it won't run redundant steps (another speed win).
	4. One key difference is with CSS - using sencha app watch will create the CSS once, and then subsequent edits are processed using Fashion instead.
	5. I'm a bit curious. You said "won't run redundant steps". But according to the console output it runs a lot of things multiple times. Any idea why that is? It won't run (as many) redundant steps once it gets to the point where it's waiting for changes. While booting up, it will do a number of things repeatedly - most particularly, every time it goes through a call to Ant, it does start and stop the background server.