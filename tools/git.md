## Rewriting the most recent commit message
You can change the most recent commit message using the `git commit --amend` command.

## Amending older or multiple commit messages
If you have already pushed the commit to GitHub, you will have to force push a commit with an amended message. Use the `push --force` command to force push over the old commit.

## Amending the message of older or multiple commit messages
1. Use the `git rebase -i HEAD~n` command to display a list of the last n commits in your default text editor.
2. Replace pick with reword before each commit message you want to change.
3. Save and close the commit list file.
4. In each resulting commit file, type the new commit message, save the file, and close it.
5. Force-push the amended commits.

## Using a socks proxy with git for the http transport
1. $ ALL_PROXY=socks5://127.0.0.1:1080 git clone https://github.com/some/one.git
2. $ git clone https://github.com/xxxxx --config 'http.proxy=socks5://127.0.0.1:1080'

## error: RPC failed; curl transfer closed with outstanding read data remaining
1. because have error when clone by HTTP protocol (curl command). And, you should increment buffer size: `git config --global http.postBuffer 524288000`
2. use `ssh` git type

## min clone a big git repository
1. Create a shallow clone with a history truncated to the specified number of commits. `git clone --depth=1 https://github.com/some/one.git`
2. Clone only the history leading to the tip of a single branch, either specified by the --branch option or the primary branch remote’s HEAD points at. Further fetches into the resulting repository will only update the remote-tracking branch for the branch this option was used for the initial cloning. --[no-]single-branch
3. git clone --depth=1 --single-branch --branch=master https://github.com/some/one.git//
4. git fetch --unshallow

## Git Status Takes a Long Time to Complete
1. Have you tried git gc? This cleans cruft out of the git repo.
2. Have you tried repacking? git-repack.
3. On a similar issue I found that having a git repo in a directory below my existing git repo caused a massive slow down. I moved the secondary git repo somewhere else and now the speed is fast!
4. using git bash please.

## Trace the evolution of the line range of a file
1. git log -L <start>,<end>:<file>; git log -L :<funcname>:<file>
2. Trace the evolution of the line range given by "<start>,<end>" (or the function name regex <funcname>) within the <file>. You may not give any pathspec limiters. This is currently limited to a walk starting from a single revision, i.e., you may only give zero or one positive revision arguments. You can specify this option more than once.
3. <start> and <end> can take one of these forms: number, /regex/, +offset or -offset
4. If “:<funcname>” is given in place of <start> and <end>, it is a regular expression that denotes the range from the first funcname line that matches <funcname>, up to the next funcname line. “:<funcname>” searches from the end of the previous -L range, if any, otherwise from the start of file. “^:<funcname>” searches from the start of file.

## git diff between two different files
1. git diff [options] [--no-index] [--] <path> <path>
2. This form is to compare the given two paths on the filesystem. You can omit the --no-index option when running the command in a working tree controlled by Git and at least one of the paths points outside the working tree, or when running the command outside a working tree controlled by Git.
3. You don't need git for that, just use diff fileA.php fileB.php (or vimdiff if you want side by side comparison)

## List merge commits affecting a file. 
### For background, someone mis-resolved a conflict when merging, and it wasn't noticed by the team for a few days. At that point, a lot of other unrelated merges had been committed (some of us have been preferring to not use rebase, or things would be simpler). I need to locate the "bad" merge commit, so it can be checked to identify what else might have been reverted (and, of course, to identify and punish the guilty).
1. git log --follow /path/to/file , --follow : Continue listing the history of a file beyond renames (works only for a single file).
2. `git log -U -m --simplify-merges --merges -- a.txt` 
3. --simplify-merges : Additional option to --full-history to remove some needless merges from the resulting history, as there are no selected commits contributing to this merge.
4. -U<n>, --unified=<n> : Generate diffs with <n> lines of context instead of the usual three. Implies -p.
5. -m : This flag makes the merge commits show the full diff like regular commits; for each merge parent, a separate log entry and diff is generated. An exception is that only diff against the first parent is shown when --first-parent option is given; in that case, the output represents the changes the merge brought into the then-current branch.
6. --merges : Print only merge commits. This is exactly the same as --min-parents=2.
7. -- : Use '--' to separate paths from revisions
8. so, git log -p -m

## Get the Git Commit ID via Command Line
1. git rev-parse HEAD
2. change default pager to vim;

## How do I use vim as 'git log' editor?
1. The git log command pipes it's output by default into a pager, not an editor. This pager is usually less or more on most systems. You can change the default pager to vim with the command:
2. git config --global core.pager 'vim -' //'less -'
3. Now you can search using vim functionality with / as usual.
4. 'vim - ', what does '-' there do? It makes vim read from STDIN. Usually a good idea to add -R for read-only mode it that case as well.for many utilities, - as file name means stdin or stdout depending on context.

## What is HEAD in Git?
1. HEAD is actually a file whose contents determines where the HEAD variable refers:
````bash
$ cat .git/HEAD
ref: refs/heads/master
$ cat .git/refs/heads/master
35ede5c916f88d8ba5a9dd6afd69fcaf773f70ed
````
2. The HEAD in Git is the pointer to the current branch reference, which is in turn a pointer to the last commit you made or the last commit that was checked out into your working directory. That also means it will be the parent of the next commit you do. It's generally simplest to think of it as HEAD is the snapshot of your last commit.
3. HEAD means "current" everywhere in git, but it does not necessarily mean "current branch" (i.e. detached HEAD). But it almost always means the "current commit".

## Using git log to display files changed during merge
1. git log -p
2. -p, -u, --patch : Generate patch (see section on generating patches).
3. Normally, to show you what changed in a commit, Git runs a simple git diff parent self, where parent and self are the commit's parent, and the commit itself, respectively. Both git log and git show do this, in slightly different ways and under slightly different circumstances. The most obvious is that git show defaults to showing a diff every time, but git log only does a diff when given -p or one of the various diff control options such as --name-only.

4. Instead of typing "HEAD", you can say "@" instead, e.g. "git log @".

## git: a quick command to go to root of the working tree
1. cd $(git rev-parse --show-toplevel) or cd $(git rev-parse --show-cdup)
2. alias git-root='cd $(git rev-parse --show-cdup)'
3. --show-toplevel: Show the absolute path of the top-level directory.
4. --show-cdup: When the command is invoked from a subdirectory, show the path of the top-level directory relative to the current directory (typically a sequence of "../", or an empty string).

## git rev-parse [ --option ] <args>...
1. git-rev-parse - Pick out and massage parameters
2. Many Git porcelainish commands take mixture of flags (i.e. parameters that begin with a dash -) and parameters meant for the underlying git rev-list command they use internally and flags and parameters for the other commands they use downstream of git rev-list. This command is used to distinguish between them.

## Want to exclude file from “git diff”
1. It is implemented now (git 1.9/2.0, Q1 2014) with the introduction pathspec magic :(exclude) and its short form :! .
2. You now can log everything except a sub-folder content: `git log -- . ":(exclude)sub"`, `git log -- . ":!sub"`
3. You can make that exclusion case insensitive! : `git log -- . ":(exclude,icase)SUB"`
4. pathspec magic: add '^' as alias for '!': The choice of '!' for a negative pathspec ends up not only not matching what we do for revisions, it's also a horrible character for shell expansion since it needs quoting.

## How to delete .orig files after merge from git repository?
1. git clean -i is really nice. it will give you a list of files that will be deleted and give you options on how to deal with the list (filter the list, being able to delete everything on the list, and some other options).
2. `git rm -r *.orig`

## Is there a way to skip password typing when using https:// on GitHub?
1. With Git version 1.7.9 and later
> Since Git 1.7.9 (released in late January 2012), there is a neat mechanism in Git to avoid having to type your password all the time for HTTP / HTTPS, called [credential helpers](http://www.kernel.org/pub/software/scm/git/docs/v1.7.9/gitcredentials.html). (Thanks to [dazonic](http://stackoverflow.com/users/109707/dazonic) for pointing out this new feature in the comments below.)
> With Git 1.7.9 or later, you can just use one of the following credential helpers:
>    git config --global credential.helper cache
> ... which tells Git to keep your password cached in memory for (by default) 15 minutes. You can [set a longer timeout](http://www.kernel.org/pub/software/scm/git/docs/v1.7.9/git-credential-cache.html#_examples) with:
>    git config --global credential.helper "cache --timeout=3600"
> (That example was suggested in the [GitHub help page for Linux](https://help.github.com/articles/caching-your-github-password-in-git/).) You can also store your credentials permanently if so desired, see the other answers below.
> GitHub's help [also suggests](https://help.github.com/articles/set-up-git#platform-mac) that if you're on Mac OS X and used [Homebrew] to install Git, you can use the native Mac OS X keystore with:
>     git config --global credential.helper osxkeychain
> For Windows, there is a helper called [Git Credential Manager for Windows](https://github.com/Microsoft/Git-Credential-Manager-for-Windows)(存储在 凭据管理器-控制面板) or [wincred in msysgit].
>     git config --global credential.helper wincred # obsolete
> With [Git for Windows 2.7.3+] (March 2016):
>     git config --global credential.helper manager
> For Linux, you can [use `gnome-keyring`](http://stackoverflow.com/questions/13385690/how-to-use-git-with-gnome-keyring-integration)(or other keyring implementation such as KWallet).
2. With Git versions before 1.7.9
> With versions of Git before 1.7.9, this more secure option is not available, and you'll need to change the URL that your `origin` remote uses to include the password in this fashion:
>     https://you:password@github.com/you/example.git
> ... in other words with `:password` after the username and before the `@`.
> You can set a new URL for your `origin` remote with:
>     git config remote.origin.url https://you:password@github.com/you/example.git
> Make sure that you use `https` and you should be aware that if you do this, your GitHub password will be stored in plaintext in your `.git` directory, which is obviously undesirable.
3. With any Git version (well, since version 0.99)
> An alternative approach is to put your username and password in your `~/.netrc` file, although, as with keeping the password in the remote URL, this means that your password will be stored on the disk in plain text and is thus less secure and not recommended. However, if you want to take this approach, add the following line to your `~/.netrc`:
>     machine <hostname> login <username> password <password>
> ... replacing `<hostname>` with the server's hostname, and `<username>` and `<password>` with your username and password. Also remember to set restrictive file system permissions on that file:
>     chmod 600 ~/.netrc
> Note that on Windows, this file should be called `_netrc`, and you may need to define the %HOME% environment variable - for more details see:

