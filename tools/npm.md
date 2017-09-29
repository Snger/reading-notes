## Error: Cannot find module 'webpack/lib/node/NodeTemplatePlugin'
1. Node requires you to install webpack to your project.
1. You have 2 options to solve the above:
1. Remove global webpack and install it locally
> npm uninstall -g webpack
> npm install --save-dev html-webpack-plugin webpack webpack-dev-server
1. You can link the global webpack pkg to your project's node modules. The downside of this is that your project will be forced to use most updated webpack. This will create a problem only when some updates are not backwards compatible.
> npm i webpack -g; npm link webpack --save-dev
1. You can omit the html-webpack-plugin depending on your requirement.
1. You can find more info here: https://github.com/webpack/webpack/issues/2131

## Short version of --save-dev and --save
1. Use -S instead of --save and -D instead of --save-dev.
1. [Shorthands and Other CLI Niceties](https://docs.npmjs.com/misc/config#shorthands-and-other-cli-niceties)

## npm-run-script
1. Run arbitrary package scripts
1. Synopsis:
> npm run-script <command> [--silent] [-- <args>...]
> alias: npm run
1. Description: This runs an arbitrary command from a package's "scripts" object. If no "command" is provided, it will list the available scripts. run[-script] is used by the test, start, restart, and stop commands, but can be called directly, as well. When the scripts in the package are printed out, they're separated into lifecycle (test, start, restart) and directly-run scripts.
1. As of npm@2.0.0, you can use custom arguments when executing scripts. The special option -- is used by getopt to delimit the end of the options. npm will pass all the arguments after the -- directly to your script.

## npm run env
1. The env script is a special built-in command that can be used to list environment variables that will be available to the script at runtime. If an "env" command is defined in your package it will take precedence over the built-in.

## npm run locally-installed dependencies
1. In addition to the shell's pre-existing PATH, npm run adds node_modules/.bin to the PATH provided to scripts. Any binaries provided by locally-installed dependencies can be used without the node_modules/.bin prefix.
> For example, if there is a devDependency on tap in your package, you should write:
> "scripts": {"test": "tap test/\*.js"}
> instead of "scripts": {"test": "node_modules/.bin/tap test/\*.js"} to run your tests.

