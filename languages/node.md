## How do I debug Node.js applications?
1. node-inspector could save the day! Use it from any browser supporting WebSocket. Breakpoints, profiler, livecoding, etc... It is really awesome.
> Install it with:
> npm install -g node-inspector
> Then run:
> node-debug app.js
2. Node has its own built in GUI debugger as of version 6.3 (using Chrome's DevTools), Simply pass the inspector flag and you'll be provided with a URL to the inspector:
> node --inspect server.js
> You can also break on the first line by passing --inspect-brk instead.
> To open a Chrome window automatically, use the inspect-process module.
````command line
# install inspect-process globally
npm install -g inspect-process
# start the debugger with inspect
inspect script.js
````
3. Node.js version 0.3.4+ has built-in debugging support.
> node debug script.js
> Manual: http://nodejs.org/api/debugger.html
