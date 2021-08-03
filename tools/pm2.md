# pm2

## How to use babel-node with pm2
> 1. Install babel-cli in your project with yarn add babel-cli and then you can run `pm2 start ./server.js --interpreter ./node_modules/babel-cli/bin/babel-node.js`
> 2. You have your npm script to run es6 js, something like
````package.json
{
  ...
  "scripts": {
    "server": "babel-node ./src/server.js"
  },
  ...
}
````
> Then to run that with pm2 you use `pm2 start npm -- run server` Make sure you have babel-cli installed globally.
> 3. index.js
````shell
pm2 start index.js
// index.js 中使用 node 的 child_process
require('child_process').exec( `babel-node src/index.js` );
````

## Start App With PM2 JSON Config File
> Besides the pm2 command line utility, you can use an [advanced JSON configuration](https://futurestud.io/tutorials/pm2-advanced-app-configuration-with-json-file#availableoptions) to have a static configuration file that is reusable or even provides multiple app definitions. The following snippet contains only a single app with the name futurestudio-homepage which gets kicked off using NPM.
````app.json
{
  "apps": [
    {
      "name": "futurestudio-homepage",
      "script": "npm",
      "args": "start"
    }
  ]
}
````
> To simulate the npm start command within a PM2 JSON configuration, you need to pass npm as a value for the script entry point and pass the start command as the value for args. You can even further customize your JSON file with allowed [options and advanced features](https://futurestud.io/tutorials/pm2-advanced-app-configuration-with-json-file#availableoptions).
