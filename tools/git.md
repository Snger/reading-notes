# git

<!-- MarkdownTOC -->

- Rewriting the most recent commit message
- Amending older or multiple commit messages
- Amend your last commit
- Amending the message of older or multiple commit messages
- Change the author and committer name and e-mail of multiple commits in Git
- How do I move forward and backward between commits in git?
- Using a socks proxy with git for the http transport
- error: RPC failed; curl transfer closed with outstanding read data remaining
- min clone a big git repository
- Git Status Takes a Long Time to Complete
- Trace the evolution of the line range of a file
- git diff between two different files
- List merge commits affecting a file.
- Get the Git Commit ID via Command Line
- How do I use vim as 'git log' editor?
- What is HEAD in Git?
- Using git log to display files changed during merge
- git: a quick command to go to root of the working tree
- git rev-parse \[ --option \] ...
- Want to exclude file from “git diff”
- How to delete .orig files after merge from git repository?
- Is there a way to skip password typing when using https:// on GitHub?
- git-diff to ignore ^M
- How to .gitignore files recursively
- Refreshing a repository after changing line endings
- git rebase without changing commit timestamps
- 寻找并删除Git记录中的大文件 & Git如何永久删除文件\(包括历史记录\)
    - 寻找大文件的ID
    - 查看大文件
    - 删除大文件或者目录
    - 强制覆盖分支
    - 清理和回收空间
- git relog
- git rev-list
- git pack-objects
- git verify-pack
- git gc
- Remove all node_module folders recursively

<!-- /MarkdownTOC -->

## Rewriting the most recent commit message
You can change the most recent commit message using the `git commit --amend` command.

## Amending older or multiple commit messages
If you have already pushed the commit to GitHub, you will have to force push a commit with an amended message. Use the `push --force` command to force push over the old commit.

## Amend your last commit
1. And then just commit with the --amend argument.
2. `git commit --amend`

## Amending the message of older or multiple commit messages
1. Use the `git rebase -i HEAD~n` command to display a list of the last n commits in your default text editor.
2. Replace pick with reword before each commit message you want to change.
3. Save and close the commit list file.
4. In each resulting commit file, type the new commit message, save the file, and close it.
5. Force-push the amended commits.

## Change the author and committer name and e-mail of multiple commits in Git
1. In the case where just the top few commits have bad authors, you can do this all inside git rebase -i using the exec command and the --amend commit, as follows:
````
git rebase -i HEAD~6 # not at master branch
git rebase -i HEAD~~~~ # at master branch
````
> which presents you with the editable list of commits:
````
pick abcd Someone else's commit
pick defg my bad commit 1
pick 1234 my bad commit 2
````
> Then add exec ... --author="..." lines after all lines with bad authors:
````
pick abcd Someone else's commit
pick defg my bad commit 1
exec git commit --amend --author="New Author Name <email@address.com>" -C HEAD
pick 1234 my bad commit 2
exec git commit --amend --reset-author -C HEAD
````
> save and exit editor (to run).
2. git commit --amend --reset-author --no-edit
> That works really well on the last commit. Nice and simple. Doesn't have to be a global change, using --local works too
> git commit -C <commit> --reset-author
>> --reuse-message=<commit> Take an existing commit object, and reuse the log message and the authorship information (including the timestamp) when creating the commit.
3. [Changing the Git history of your repository using a script](https://help.github.com/articles/changing-author-info/)

## How do I move forward and backward between commits in git?
1. I've experimented a bit and this seems to do the trick to navigate forwards:
````
git checkout $(git rev-list --topo-order HEAD..towards | tail -1)
````
> Explanation:
>> where towards is a SHA1 of the commit or a tag.
>> the command inside $() means: get all the commits between current HEAD and towards commit (excluding HEAD), and sort them in the precedence order (like in git log by default -- instead of the chronological order which is weirdly the default for rev-list), and then take the last one (tail), i.e. the one we want to go to.
>> this is evaluated in the subshell, and passed to git checkout to perform a checkout.
2. Add these two functions to your ~/.bashrc:
````
# checkout prev (older) revision
git_prev() {
    git checkout HEAD~
}
# checkout next (newer) commit
git_next() {
    BRANCH=`git show-ref | grep $(git show-ref -s -- HEAD) | sed 's|.*/\(.*\)|\1|' | grep -v HEAD | sort | uniq`
    HASH=`git rev-parse $BRANCH`
    PREV=`git rev-list --topo-order HEAD..$HASH | tail -1`
    git checkout $PREV
}
````
3. Once you are done looking around, you can go back to your original state just by checking out to that branch. In my example: git checkout master
4. If you don't want to go to original state, and want so keep one of the commits as your head and continue from there, then you need to branch out from there. for example after "git checkout HEAD@{4}" , git checkout -b MyNewBranch

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
> For background, someone mis-resolved a conflict when merging, and it wasn't noticed by the team for a few days. At that point, a lot of other unrelated merges had been committed (some of us have been preferring to not use rebase, or things would be simpler). I need to locate the "bad" merge commit, so it can be checked to identify what else might have been reverted (and, of course, to identify and punish the guilty).
1. git log --follow /path/to/file , --follow : Continue listing the history of a file beyond renames (works only for a single file).
2. `git log -U -m --simplify-merges --merges -- a.txt`
3. --simplify-merges : Additional option to --full-history to remove some needless merges from the resulting history, as there are no selected commits contributing to this merge.
4. -U<n>, --unified=<n> : Generate diffs with <n> lines of context instead of the usual three. Implies -p.
5. -m : This flag makes the merge commits show the full diff like regular commits; for each merge parent, a separate log entry and diff is generated. An exception is that only diff against the first parent is shown when --first-parent option is given; in that case, the output represents the changes the merge brought into the then-current branch.
6. --merges : Print only merge commits. This is exactly the same as --min-parents=2.
7. -- : Use '--' to separate paths from revisions
8. so, git log -p -m, or git log -U5 -m

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

## git-diff to ignore ^M
1. GitHub suggests that you should make sure to only use \n as a newline character in git-handled repos. There's an option to auto-convert:
2. `$ git config --global core.autocrlf true`
3. Of course, this is said to convert crlf to lf, while you want to convert cr to lf.
4. code
    ````bash
    # Remove everything from the index
    $ git rm --cached -r .
    # Re-add all the deleted files to the index
    # You should get lots of messages like: "warning: CRLF will be replaced by LF in <file>."
    $ git diff --cached --name-only -z | xargs -0 git add
    # Commit
    $ git commit -m "Fix CRLF"
    ````
5. core.autocrlf: Setting this variable to "true" is almost the same as setting the text attribute to "auto" on all files except that text files are not guaranteed to be normalized: files that contain CRLF in the repository will not be touched. Use this setting if you want to have CRLF line endings in your working directory even though the repository does not have normalized line endings. This variable can be set to input, in which case no output conversion is performed.

## How to .gitignore files recursively
1. git treats the pattern as a shell glob suitable for consumption by fnmatch(3) with the FNM_PATHNAME flag: wildcards in the pattern will not match a / in the pathname.
2. 可以在前面添加正斜杠/来避免递归, /TODO -- 仅在当前目录下忽略 TODO 文件， 但不包括子目录下的 subdir/TODO
3. 可以在后面添加正斜杠/来忽略文件夹，例如build/即忽略build文件夹。
4. 可以使用!来否定忽略，即比如在前面用了*.apk，然后使用!a.apk，则这个a.apk不会被忽略。
5. *用来匹配零个或多个字符，如*.[oa]忽略所有以".o"或".a"结尾，*~忽略所有以~结尾的文件（这种文件通常被许多编辑器标记为临时文件）；[]用来匹配括号内的任一字符，如[abc]，也可以在括号内加连接符，如[0-9]匹配0至9的数；?用来匹配单个字符。

## Refreshing a repository after changing line endings
1. After you've set the core.autocrlf option and committed a .gitattributes file, you may find that Git wants to commit files that you have not modified. At this point, Git is eager to change the line endings of every file for you.
1. The best way to automatically configure your repository's line endings is to first backup your files with Git, delete every file in your repository (except the .git directory), and then restore the files all at once.
> Save your current files in Git, so that none of your work is lost.
    > git add . -u
    > git commit -m "Saving files before refreshing line endings"
> Remove the index and force Git to rescan the working directory.
    > rm .git/index
> Rewrite the Git index to pick up all the new line endings.
    > git reset
> Show the rewritten, normalized files.
    > git status
> Add all your changed files back, and prepare them for a commit. This is your chance to inspect which files, if any, were unchanged.
    > git add -u
    > # It is perfectly safe to see a lot of messages here that read
    > # "warning: CRLF will be replaced by LF in file."
> Rewrite the .gitattributes file.
    > git add .gitattributes
> Commit the changes to your repository.
    > git commit -m "Normalize all the line endings"

## git rebase without changing commit timestamps
1. A crucial question of Von C helped me understand what is going on: when your rebase, the committer's timestamp changes, but not the author's timestamp, which suddenly all makes sense. So my question was actually not precise enough.
1. The answer is that rebase actually doesn't change the author's timestamps (you don't need to do anything for that), which suits me perfectly.

## 寻找并删除Git记录中的大文件 & Git如何永久删除文件(包括历史记录)
### 寻找大文件的ID
> `git verify-pack -v .git/objects/pack/*.idx`
### 查看大文件
> `git rev-list --objects --all | grep "$(git verify-pack -v .git/objects/pack/*.idx | sort -k 3 -n | tail -5 | awk '{print$1}')"`
### 删除大文件或者目录
> `git filter-branch --force --index-filter 'git rm --cached --ignore-unmatch path-to-your-remove-file' --prune-empty --tag-name-filter cat -- --all`
> 其中, path-to-your-remove-file 就是你要删除的文件的相对路径(相对于git仓库的跟目录), 替换成你要删除的文件即可. 注意一点，这里的文件或文件夹，都不能以 '/' 开头，否则文件或文件夹会被认为是从 git 的安装目录开始。
> 如果你要删除的目标不是文件，而是文件夹，那么请在 `git rm --cached` 命令后面添加 -r 命令，表示递归的删除（子）文件夹和文件夹下的文件，类似于 `rm -rf` 命令。
### 强制覆盖分支
> `git push origin master --force --tags`
> 为了能从打了 tag 的版本中也删除你所指定的文件或文件夹，您可以使用这样的命令来强制推送您的 Git tags
### 清理和回收空间
````bash
$ rm -rf .git/refs/original/
$ git reflog expire --expire=now --all
$ git gc --prune=now
$ git gc --aggressive --prune=now
````

## git relog
> `git-reflog` - Manage reflog information
> Reference logs, or "reflogs", record when the tips of branches and other references were updated in the local repository. Reflogs are useful in various Git commands, to specify the old value of a reference. For example, HEAD@{2} means "where HEAD used to be two moves ago", master@{one.week.ago} means "where master used to point to one week ago in this local repository", and so on. See gitrevisions(7) for more details.
> This command manages the information recorded in the reflogs.
> The `show` subcommand (which is also the default, in the absence of any subcommands) shows the log of the reference provided in the command-line (or HEAD, by default). The reflog covers all recent actions, and in addition the HEAD reflog records branch switching. `git reflog` show is an alias for `git log -g --abbrev-commit --pretty=oneline`; see git-log(1) for more information.
> The `expire` subcommand prunes older reflog entries. Entries older than expire time, or entries older than expire-unreachable time and not reachable from the current tip, are removed from the reflog. This is typically not used directly by end users — instead, see `git-gc`(1).
> The `delete` subcommand deletes single entries from the reflog. Its argument must be an exact entry (e.g. `git reflog delete master@{2}`). This subcommand is also typically not used directly by end users.
> The `exists` subcommand checks whether a ref has a reflog. It exits with zero status if the reflog exists, and non-zero status if it does not.

## git rev-list
> `git rev-list` - Lists commit objects in reverse chronological order
> `$ git rev-list foo bar ^baz` means "list all the commits which are reachable from foo or bar, but not from baz".
> List commits that are reachable by following the parent links from the given commit(s), but exclude commits that are reachable from the one(s) given with a ^ in front of them. The output is given in reverse chronological order by default.
> You can think of this as a set operation. Commits given on the command line form a set of commits that are reachable from any of them, and then commits reachable from any of the ones given with ^ in front are subtracted from that set. The remaining commits are what comes out in the command’s output. Various other options and paths parameters can be used to further limit the result.
> `rev-list` is a very essential Git command, since it provides the ability to build and traverse commit ancestry graphs. For this reason, it has a lot of different options that enables it to be used by commands as different as `git bisect` and `git repack`.

## git pack-objects
> `git pack-objects` - Create a packed archive of objects
> Reads list of objects from the standard input, and writes a packed archive with specified base-name, or to the standard output.
> A packed archive is an efficient way to transfer a set of objects between two repositories as well as an access efficient archival format. In a packed archive, an object is either stored as a compressed whole or as a difference from some other object. The latter is often called a delta.
> The packed archive format (.pack) is designed to be self-contained so that it can be unpacked without any further information. Therefore, each object that a delta depends upon must be present within the pack.
> A pack index file (.idx) is generated for fast, random access to the objects in the pack. Placing both the index file (.idx) and the packed archive (.pack) in the pack/ subdirectory of $GIT_OBJECT_DIRECTORY (or any of the directories on $GIT_ALTERNATE_OBJECT_DIRECTORIES) enables Git to read from the pack archive.
> The `git unpack-objects` command can read the packed archive and expand the objects contained in the pack into "one-file one-object" format; this is typically done by the smart-pull commands when a pack is created on-the-fly for efficient network transport by their peers.

## git verify-pack
> `git verify-pack` - Validate packed Git archive files
> Reads given idx file for packed Git archive created with the git pack-objects command and verifies idx file and the corresponding pack file.

## git gc
> `git gc` - Cleanup unnecessary files and optimize the local repository
> Runs a number of housekeeping tasks within the current repository, such as compressing file revisions (to reduce disk space and increase performance) and removing unreachable objects which may have been created from prior invocations of git add.
> Users are encouraged to run this task on a regular basis within each repository to maintain good disk space utilization and good operating performance.

## Remove all node_module folders recursively
> Remove all node_module folders (or any type of folder/file): `find . -name "node_modules" -exec rm -rf '{}' +` That will delete the folder and files even if there is a space in the name.
> Don't you think adding -type d to the find command might improve it a little, so it would be `find . -name "node_modules" -type d -exec rm -rf '{}' +`
> Include the "prune" argument to not go over children nodemodules.
```
find . -name "nodemodules" -type d -prune -exec rm -rf '{}' +
```
