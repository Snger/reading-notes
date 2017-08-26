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

