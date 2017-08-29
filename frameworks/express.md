## Express Static nodejs
1. $ curl http://localhost:8080/README

## Cannot GET / error running hello world in webpack
1. Turns out I had index.html in the wrong place. From the webpack docs:
> To load your bundled files, you will need to create an index.html file in the build folder from which static files are served (--content-base option).
1. I made a copy of index.html in a new folder I called deployment to match what I specified in the output.path
