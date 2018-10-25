# npm
<!-- MarkdownTOC -->

- cnpm
- Error: Cannot find module 'webpack/lib/node/NodeTemplatePlugin'
- Short version of --save-dev and --save
- npm-run-script
- npm run env
- npm run locally-installed dependencies
- npm outdated
- npm update
- npm ls
- Use dependencies from a private GitLab with NPM

<!-- /MarkdownTOC -->

## cnpm
> npm install cnpm -g

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

## npm outdated
> This command will check the registry to see if any (or, specific) installed packages are currently outdated.

## npm update
> This command will update all the packages listed to the latest version (specified by the tag config), respecting semver.
>It will also install missing packages. As with all commands that install packages, the --dev flag will cause devDependencies to be processed as well.
>If the -g flag is specified, this command will update globally installed packages. >If no package name is specified, all packages in the specified location (global or local) will be updated.

## npm ls
> aliases: list, la, ll
> This command will print to stdout all the versions of packages that are installed, as well as their dependencies, in a tree-structure.
> Positional arguments are name@version-range identifiers, which will limit the results to only the paths to the packages named. Note that nested packages will also show the paths to the specified packages.
> The tree shown is the logical dependency tree, based on package dependencies, not the physical layout of your node_modules folder.
> When run as ll or la, it shows extended information by default.
> `npm list -g --depth=0` get a list of all globally installed modules
> ls `npm root -g`

## Use dependencies from a private GitLab with NPM
> In package.json try to replace `https://` by `git+https://`
> doc : https://docs.npmjs.com/files/package.json#git-urls-as-dependencies
````json
// package.json
"raw-html-loader": "https://gitlab.leke.cn/lekeweb/frontend/raw-html-loader.git",
// replace
"raw-html-loader": "git+https://git@gitlab.leke.cn:lekeweb/frontend/raw-html-loader.git",
// yarn.lock
"leke-jscore@git+https://git@gitlab.leke.cn/lekeweb/frontend/leke-jscore.git":
  version "1.0.0"
  resolved "git+https://git@gitlab.leke.cn/lekeweb/frontend/leke-jscore.git#b7e883b2da1a68aa90a30988a7d94065128e3c0d"
"p-repo-filters@git+https://git@gitlab.leke.cn/leke-common/p-repo-filters.git":
  version "1.0.0"
  resolved "git+https://git@gitlab.leke.cn/leke-common/p-repo-filters.git#d636d3acab16c6f2b52841ac4040e7246ea22b32"
  dependencies:
    leke-jscore "git+https://git@gitlab.leke.cn/lekeweb/frontend/leke-jscore.git"
"raw-html-loader@git+https://git@gitlab.leke.cn:lekeweb/frontend/raw-html-loader.git":
  version "1.0.0"
  resolved "git+https://git@gitlab.leke.cn:lekeweb/frontend/raw-html-loader.git#bae8b878420bceca415af2ea8c23db94a7089ccb"
````

