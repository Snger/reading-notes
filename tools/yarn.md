# yarn

<!-- MarkdownTOC -->

- Yarn throws "stdout is not a tty" in Git Bash
- Migrating from npm - CLI commands comparison

<!-- /MarkdownTOC -->

## Yarn throws "stdout is not a tty" in Git Bash
> I just hit the same error in AppVeyor when trying to use Yarn within a shell script via Git Bash: https://ci.appveyor.com/project/kittens/yarn/build/1938/job/momtbo9wa2carunr. In my case, I could work around the issue by explicitly running yarn.cmd rather than yarn:
	# Workaround for https://github.com/yarnpkg/yarn/issues/2591
	case "$(uname -s)" in
	  *CYGWIN*|MSYS*|MINGW*) yarn=yarn.cmd;;
	  *) yarn=yarn;;
	esac
	eval $yarn run build
> - alias
> `alias yarn='yarn.cmd '`

## Migrating from npm - CLI commands comparison
````bash
npm (v5)                                Yarn
npm install                             yarn add
(N/A)                                   yarn add --flat
(N/A)                                   yarn add --har
npm install --no-package-lock           yarn add --no-lockfile
(N/A)                                   yarn add --pure-lockfile
npm install [package] --save            yarn add [package]
npm install [package] --save-dev        yarn add [package] --dev
(N/A)                                   yarn add [package] --peer
npm install [package] --save-optional   yarn add [package] --optional
npm install [package] --save-exact      yarn add [package] --exact
(N/A)                                   yarn add [package] --tilde
npm install [package] --global          yarn global add [package]
npm update --global                     yarn global upgrade
npm rebuild                             yarn add --force
npm uninstall [package]                 yarn remove [package]
npm cache clean                         yarn cache clean [package]
rm -rf node_modules && npm install      yarn upgrade
npm version major                       yarn version --major
npm version minor                       yarn version --minor
npm version patch                       yarn version --patch
Migrating from npm
````
