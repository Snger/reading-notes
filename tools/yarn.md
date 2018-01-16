# yarn

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
