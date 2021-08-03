# grunt

## install
> npm install -g grunt-cli
> npm install grunt --save-dev

## Fatal error: Unable to find local grunt
> - Install Grunt in node_modules rather than globally
`Unable to find local Grunt` likely means that you have installed Grunt globally.
The Grunt CLI insists that you install grunt in your local node_modules directory, so Grunt is local to your project.
This will fail:
    npm install -g grunt
Do this instead:
    npm install grunt --save-dev
