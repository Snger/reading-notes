# git

<!-- MarkdownTOC -->

- Windows GIT 解決中文顯示亂碼問題
- Rewriting the most recent commit message
- Amending older or multiple commit messages
- Amend your last commit
- Amending the message of older or multiple commit messages
- git rebase commands
- Change the author and committer name and e-mail of multiple commits in Git
- Remove refs/original/heads/master from git repo after filter-branch --tree-filter?
- Completely cancel a rebase
- How do I move forward and backward between commits in git?
- Using a socks proxy with git for the http transport
- error: RPC failed; curl transfer closed with outstanding read data remaining
- min clone a big git repository
- Git Status Takes a Long Time to Complete
- Trace the evolution of the line range of a file
- git diff between two different files
- How to compare files from two different branches?
- How to view file diff in git before commit \(committed\)
- git-diff ignore changes in whitespace
- git-diff to ignore ^M
- man git-merge-base
- List merge commits affecting a file.
- Get the Git Commit ID via Command Line
- How do I use vim as 'git log' editor?
- What is HEAD in Git?
- Using git log to display files changed during merge
- git: a quick command to go to root of the working tree
- git rev-parse \[ --option \] ...
- Want to exclude file from “git diff”
- How to delete .orig files after merge from git repository?
- how to remove untracked files in Git?
- Is there a way to skip password typing when using https:// on GitHub?
- .gitignore manual
- Best practice for using multiple .gitignore files
- Are multiple `.gitignore`s frowned on?
- git check-ignore
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
- Git Bash \(by babun\) git pull command crashed and created git.exe.stackdump file
- Git Diff with Beyond Compare
- git merge with vimdiff
- Create Git branch with current changes
- A previous backup already exists in refs/original/
- fetch/pull/push from multiple remote locations
- How to clone all remote branches in Git?
- Differences between git remote update and fetch?
- Why am I getting the message, “fatal: This operation must be run in a work tree?”
- How can I add an empty directory to a Git repository?
- How To Change Git Remote Origin - devconnected
- Replace Remote Repositories
- Adding Remote Repositories
- Delete a branch \(local or remote\)
- git stuck on Unpacking Objects phase
- git clone issue: repo too large?
- git tag
- git-revert - Revert some existing commits
- 解决Git Revert操作后再次Merge代码被冲掉的问题
- Force merge after reverting merge commit init git
- git cherry-pick Apply the changes introduced by some existing commits
- 对代码进行 revert 后，应该如何避免代码不能合并到主干？
- 冲突时直接把冲突文件进行reset操作，导致记录丢失
- git log - History Simplification

<!-- /MarkdownTOC -->

## Windows GIT 解決中文顯示亂碼問題
> [link](https://jerry2yang.wordpress.com/2011/08/12/windows-git-%E8%A7%A3%E6%B1%BA%E4%B8%AD%E6%96%87%E9%A1%AF%E7%A4%BA%E4%BA%82%E7%A2%BC%E5%95%8F%E9%A1%8C/)
> - 終端機內無法輸入中文：
修改「C:\Program Files\Git\etc\inputrc」
````config
#disable/enable 8bit input
set meta-flag on
set input-meta on
set output-meta on
set convert-meta off
````
- ls 無法顯示中文目錄：
修改「C:\Program Files\Git\etc\profile」
````config
#修正 ls 無法顯示中文目錄，新增下面這行
alias ls='ls --show-control-chars --color=auto'
#如果安裝的msysGit此設定已成預設值(bash_profile設定檔裏)
````
- git log 無法顯示中文註解：
修改「C:\Program Files\Git\etc\profile」
````config
#修正 git log 無法顯示中文註解
export LESSCHARSET=utf-8
````
修改「C:\Program Files\Git\mingw64\etc\gitconfig」
````config
#加入以下設定值
[gui]
    encoding = utf-8
[i18n]
    commitencoding = utf-8
    logoutputencoding = utf-8
````
此三項是 Windows GIT 常見的中文問題。
補充說明：
如果在msys裏無法正確顯示日文、韓文或是簡體中文，請在windows作業系統上安裝「unicode補完計畫」重新開機後，就可以正常於msys上顯示。

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

## git rebase commands
````vi
# Commands:
# p, pick = use commit
# r, reword = use commit, but edit the commit message
# e, edit = use commit, but stop for amending
# s, squash = use commit, but meld into previous commit
# f, fixup = like "squash", but discard this commit's log message
# x, exec = run command (the rest of the line) using shell
# d, drop = remove commit
````

## Change the author and committer name and e-mail of multiple commits in Git
1. git commit --amend --reset-author --no-edit

> git config --global user.name "Your Name"
> git config --global user.email "youremail@yourdomain.com"
> That works really well on the last commit. Nice and simple. Doesn't have to be a global change, using --local works too
> git commit -C <commit> --reset-author
>> --reuse-message=<commit> Take an existing commit object, and reuse the log message and the authorship information (including the timestamp) when creating the commit.
2. In the case where just the top few commits have bad authors, you can do this all inside git rebase -i using the exec command and the --amend commit, as follows:
> [Git-rebase 小筆記](https://blog.yorkxin.org/2011/07/29/git-rebase.html)
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
3. [Changing the Git history of your repository using a script](https://help.github.com/articles/changing-author-info/)
````bash
git_change_author() {
    git filter-branch --env-filter '
    OLD_EMAIL="your-old-email@example.com"
    CORRECT_NAME="Your Correct Name"
    CORRECT_EMAIL="your-correct-email@example.com"
    if [ "$GIT_COMMITTER_EMAIL" = "$OLD_EMAIL" ]
    then
        export GIT_COMMITTER_NAME="$CORRECT_NAME"
        export GIT_COMMITTER_EMAIL="$CORRECT_EMAIL"
    fi
    if [ "$GIT_AUTHOR_EMAIL" = "$OLD_EMAIL" ]
    then
        export GIT_AUTHOR_NAME="$CORRECT_NAME"
        export GIT_AUTHOR_EMAIL="$CORRECT_EMAIL"
    fi
    ' --tag-name-filter cat -- --branches --tags
}
````

## Remove refs/original/heads/master from git repo after filter-branch --tree-filter?
> Here's the thing to know, from which all else flows: except when doing `git gc` (well, and things `git gc` does as well), git *never removes anything*, it only ever *adds new things*.
> `refs/original/*` is there as a backup, in case you mess up your filter-branch. Believe me, it's a *really* good idea.
> Once you've inspected the results, and you're very confident that you have what you want, you can remove the backed up ref:
    git update-ref -d refs/original/refs/heads/master
> or if you did this to many refs, and you want to wipe it all out:
    git for-each-ref --format="%(refname)" refs/original/ | xargs -n 1 git update-ref -d
> (That's taken directly from the filter-branch manpage.)
> This doesn't apply to you, but to others who may find this: If you do a filter-branch which *removes* content taking up significant disk space, you might also want to run `git reflog expire --expire=now --all` and `git gc --prune=now` to expire your reflogs and delete the now-unused objects. (Warning: completely, totally irreversible. Be very sure before you do it.)

## Completely cancel a rebase
> `git rebase --abort`.
> In the case of a past rebase that you did not properly aborted, you now (Git 2.12, Q1 2017) have `git rebase --quit`

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
ALL_PROXY=socks5://127.0.0.1:1090 git fetch --depth=5

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

## How to compare files from two different branches?
> `git diff mybranch master -- myfile.cs`
> Or, equivalently:
> `git diff mybranch..master -- myfile.cs`
> Using the latter syntax, if either side is HEAD it may be omitted (e.g. master.. compares master to HEAD).
> You may also be interested in `mybranch...master` (from git diff docs):
> This form is to view the changes on the branch containing and up to the second <commit>, starting at a common ancestor of both <commit>. `git diff A...B` is equivalent to `git diff $(git-merge-base A B) B`.
In other words, this will give a diff of changes in master since it diverged from mybranch (but without new changes since then in mybranch).

## How to view file diff in git before commit (committed)
> If you want to see what you haven't git added yet:
`git diff myfile.txt`
or if you want to see already added changes
`git diff --cached myfile.txt`

## git-diff ignore changes in whitespace
````bash
--ignore-cr-at-eol
   Ignore carrige-return at the end of line when doing a comparison.

--ignore-space-at-eol
   Ignore changes in whitespace at EOL.

-b, --ignore-space-change
   Ignore changes in amount of whitespace. This ignores whitespace at line end, and considers all other sequences of
   one or more whitespace characters to be equivalent.

-w, --ignore-all-space
   Ignore whitespace when comparing lines. This ignores differences even if one line has whitespace where the other
   line has none.

--ignore-blank-lines
   Ignore changes whose lines are all blank.
````

## git-diff to ignore ^M
> 1. GitHub suggests that you should make sure to only use \n as a newline character in git-handled repos. There's an option to auto-convert:
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

## man git-merge-base
> git-merge-base - Find as good common ancestors as possible for a merge
> git merge-base finds best common ancestor(s) between two commits to use in a three-way merge. One common ancestor is better than another common ancestor if the latter is an ancestor of the former. A common ancestor that does not have any better common ancestor is a best common ancestor, i.e. a merge base. Note that there can be more than one merge base for a pair of commits.
> Given two commits A and B, git merge-base A B will output a commit which is reachable from both A and B through the parent relationship.
> For example, with this topology:
            o---o---o---B
           /
    ---o---1---o---o---o---A
> the merge base between A and B is 1.

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

## how to remove untracked files in Git?
> - User interactive approach:
git clean -i -fd
-i for interactive
-f for force
-d for directory
-x for ignored files(add if required)
Note: Add -n or --dry-run to just check what it will do.
> - To remove untracked files / directories do:
git clean -fdx
-f - force
-d - directories too
-x - remove ignored files too ( don't use this if you don't want to remove ignored files)

## Is there a way to skip password typing when using https:// on GitHub?
> 1. With Git version 1.7.9 and later
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

## .gitignore manual
> - NAME
gitignore - Specifies intentionally untracked files to ignore
> - SYNOPSIS
$HOME/.config/git/ignore, $GIT_DIR/info/exclude, .gitignore
> - DESCRIPTION
A gitignore file specifies intentionally untracked files that Git should ignore. Files already tracked by Git are not affected; see the NOTES below for details.
Each line in a gitignore file specifies a pattern. When deciding whether to ignore a path, Git normally checks gitignore patterns from multiple sources, with the following order of precedence, from highest to lowest (within one level of precedence, the last matching pattern decides the outcome):
>> - Patterns read from the command line for those commands that support them.
>> - Patterns read from a .gitignore file in the same directory as the path, or in any parent directory, with patterns in the higher level files (up to the toplevel of the work tree) being overridden by those in lower level files down to the directory containing the file. These patterns match relative to the location of the .gitignore file. A project normally includes such .gitignore files in its repository, containing patterns for files generated as part of the project build.
>> - Patterns read from $GIT_DIR/info/exclude.
>> - Patterns read from the file specified by the configuration variable core.excludesFile.
>> Which file to place a pattern in depends on how the pattern is meant to be used.
>> - Patterns which should be version-controlled and distributed to other repositories via clone (i.e., files that all developers will want to ignore) should go into a .gitignore file.
>> - Patterns which are specific to a particular repository but which do not need to be shared with other related repositories (e.g., auxiliary files that live inside the repository but are specific to one user’s workflow) should go into the $GIT_DIR/info/exclude file.
>> - Patterns which a user wants Git to ignore in all situations (e.g., backup or temporary files generated by the user’s editor of choice) generally go into a file specified by core.excludesFile in the user’s ~/.gitconfig. Its default value is $XDG_CONFIG_HOME/git/ignore. If $XDG_CONFIG_HOME is either not set or empty, $HOME/.config/git/ignore is used instead.
>> The underlying Git plumbing tools, such as git ls-files and git read-tree, read gitignore patterns specified by command-line options, or from files specified by command-line options. Higher-level Git tools, such as git status and git add, use patterns from the sources specified above.
> - PATTERN FORMAT
>> - A blank line matches no files, so it can serve as a separator for readability.
>> - A line starting with # serves as a comment. Put a backslash ("\") in front of the first hash for patterns that begin with a hash.
>> - Trailing spaces are ignored unless they are quoted with backslash ("\").
>> - An optional prefix "!" which negates the pattern; any matching file excluded by a previous pattern will become included again. It is not possible to re-include a file if a parent directory of that file is excluded. Git doesn’t list excluded directories for performance reasons, so any patterns on contained files have no effect, no matter where they are defined. Put a backslash ("\") in front of the first "!" for patterns that begin with a literal "!", for example, `\!important!.txt`.
>> - If the pattern ends with a slash, it is removed for the purpose of the following description, but it would only find a match with a directory. In other words, foo/ will match a directory foo and paths underneath it, but will not match a regular file or a symbolic link foo (this is consistent with the way how pathspec works in general in Git).
>> - If the pattern does not contain a slash /, Git treats it as a shell glob pattern and checks for a match against the pathname relative to the location of the .gitignore file (relative to the toplevel of the work tree if not from a .gitignore file).
>> - Otherwise, Git treats the pattern as a shell glob suitable for consumption by fnmatch(3) with the FNM_PATHNAME flag: wildcards in the pattern will not match a / in the pathname. For example, `Documentation/*.html` matches `Documentation/git.html` but not `Documentation/ppc/ppc.html` or `tools/perf/Documentation/perf.html`.
>> - A leading slash matches the beginning of the pathname. For example, `/*.c` matches `cat-file.c` but not `mozilla-sha1/sha1.c`.
>> Two consecutive asterisks (`**`) in patterns matched against full pathname may have special meaning:
>> - A leading `**` followed by a slash means match in all directories. For example, `**/foo` matches file or directory `foo` anywhere, the same as pattern `foo`. `**/foo/bar` matches file or directory `bar` anywhere that is directly under directory `foo`.
>> - A trailing `/**` matches everything inside. For example, `abc/**` matches all files inside directory `abc`, relative to the location of the .gitignore file, with infinite depth.
>> - A slash followed by two consecutive asterisks then a slash matches zero or more directories. For example, `a/**/b` matches `a/b`, `a/x/b`, `a/x/y/b` and so on.
>> - Other consecutive asterisks are considered invalid.
> - NOTES
The purpose of gitignore files is to ensure that certain files not tracked by Git remain untracked.
To stop tracking a file that is currently tracked, use git rm --cached.

## Best practice for using multiple .gitignore files
> [Background] A .gitignore refers to the directory that it's in, which is either the top level or descendent of a directory with a .git repository, i.e. a ".git/" directory.
> There can be multiple .gitignore files in any sub directories but *the Best Practice is to have one .gitignore in a given projects root and have that file reference sub-directories as necessary*, e.g. images/yearly/recent Otherwise it is be tricky to know "which" .gitignore file to look at to find something that's being ignored. Given that you can use patterns as file names that could be pretty tricky!
> I also recommend avoiding using a global .gitignore file which applies to all projects on your machine, although you might keep a template around for using with new projects. The main consideration here is that your .gitignore will be different from other developers (which may or may not exist) and so the result is undetermined. One example of an exception to this is using a global .gitignore file for IDE files that I don't want in any project that I open on my machine so I use a global .gitigore with an entry for .idea/ files (rubyMine).
> The intent of the templates you see listed is that normally you are writing the code for a given file in a specific language. Given this, a template that is based on the language is frequently sufficient.
> If there are multiple languages in the code base, then used you will need to combine multiple .gitignore's for those languages, which can be done in a multitude of ways such as:
````bash
cat .gitignore1 .gitignore2 > .gitignore # if .gitignore doesn't exist yet
cat .gitignore1 >> .gitignore # Add to it if it already exists
paste .gitignore1 .gitignore # Add to it if it already exists
````

## Are multiple `.gitignore`s frowned on?
> I can think of at least two situations where you would want to have multiple .gitignore files in different (sub)directories.
> - Different directories have different types of file to ignore. For example the .gitignore in the top directory of your project ignores generated programs, while Documentation/.gitignore ignores generated documentation.
> - Ignore given files only in given (sub)directory (you can use /sub/foo in .gitignore, though).
> Please remember that patterns in .gitignore file apply recursively to the (sub)directory the file is in and all its subdirectories, unless pattern contains '/' (so e.g. pattern name applies to any file named name in given directory and all its subdirectories, while /name appliest to file with this name only in given directory).
> - As a tangential note, one case where the ability to have multiple .gitignore files is very useful is if you want an extra directory in your working copy that you never intend to commit. Just put a 1-byte .gitignore (containing just a single asterisk) in that directory and it will never show up in git status etc.
> - You can have multiple .gitignore, each one of course in its own directory.
> To check which gitignore rule is responsible for ignoring a file, use `git check-ignore`: `git check-ignore -v -- afile`.
> And you can have different version of a .gitignore file per branch: I have already seen that kind of configuration for ensuring one branch ignores a file while the other branch does not: see this question for instance.
> If your repo includes several independent projects, it would be best to reference them as submodules though.
> That would be the actual best practices, allowing each of those projects to be cloned independently (with their respective .gitignore files), while being referenced by a specific revision in a global parent project.

## git check-ignore
> git check-ignore - Debug gitignore / exclude files
> "git check-ignore" follows the same rule as "git add" and "git status" in that the ignore/exclude mechanism does not take effect on paths that are already tracked.
> With "--no-index" option, it can be used to diagnose which paths that should have been ignored have been mistakenly added to the index.
> `check-ignore` currently shows how .gitignore rules would treat untracked paths. Tracked paths do not generate useful output.
> This prevents debugging of why a path became tracked unexpectedly unless that path is first removed from the index with `git rm --cached <path>`.
> *The option `--no-index` tells the command to bypass the check for the path being in the index and hence allows tracked paths to be checked too.*
> Whilst this behaviour deviates from the characteristics of `git add` and `git status` its use case is unlikely to cause any user confusion.
> Test scripts are augmented to check this option against the standard ignores to ensure correct behaviour.
> - `--no-index`
> Don't look in the index when undertaking the checks. This can be used:
> - to debug why a path became tracked by e.g. git add . and was not ignored by the rules as expected by the user or
> - when developing patterns including negation to match a path previously added with git add -f.

## How to .gitignore files recursively
1. git treats the pattern as a shell glob suitable for consumption by fnmatch(3) with the FNM_PATHNAME flag: wildcards in the pattern will not match a / in the pathname.
2. 可以在前面添加正斜杠/来避免递归, /TODO -- 仅在当前目录下忽略 TODO 文件， 但不包括子目录下的 subdir/TODO
3. 可以在后面添加正斜杠/来忽略文件夹，例如build/即忽略build文件夹。
4. 可以使用!来否定忽略，即比如在前面用了`*.apk`，然后使用`!a.apk`，则这个a.apk不会被忽略。
5. `*`用来匹配零个或多个字符，如\*.[oa]忽略所有以".o"或".a"结尾，`*~`忽略所有以~结尾的文件（这种文件通常被许多编辑器标记为临时文件）；[]用来匹配括号内的任一字符，如[abc]，也可以在括号内加连接符，如[0-9]匹配0至9的数；?用来匹配单个字符。

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
> 为了能从打了 tag 的版本中也删除你所指定的文件或文件夹， 您可以使用这样的命令来强制推送您的 Git tags
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
## Git Bash (by babun) git pull command crashed and created git.exe.stackdump file
> [error msg] Your configuration specifies to merge with the ref 'refs/heads/dev' from the remote, but no such ref was fetched.
> [git.exe.stackdump content] Exception: STATUS_ACCESS_VIOLATION at eip=...
> [git bash shell extensions use system32/cmd and wscript #8](https://github.com/msysgit/git/issues/8)
> [Fails with Exception: STATUS_ACCESS_VIOLATION #25](https://github.com/msysgit/msysgit/issues/25)

## Git Diff with Beyond Compare
> `git difftool -t bc3`
> `git difftool -t vimdiff`

## git merge with vimdiff
> `git mergetool -t vimdiff`


## Create Git branch with current changes
````bash
git checkout -b <new-branch>
git add <files>
git commit -m "<Brief description of this commit>"
````

## A previous backup already exists in refs/original/
> log: Cannot create a new backup. A previous backup already exists in refs/original/
> `refs/original/*` is there as a backup, in case you mess up your filter-branch. Believe me, it's a *really* good idea.
> Once you've inspected the results, and you're very confident that you have what you want, you can remove the backed up ref:
    git update-ref -d refs/original/refs/heads/master
> or if you did this to many refs, and you want to wipe it all out:
    git for-each-ref --format="%(refname)" refs/original/ | xargs -n 1 git update-ref -d
> (That's taken directly from the filter-branch manpage.)
> This doesn't apply to you, but to others who may find this: If you do a filter-branch which *removes* content taking up significant disk space, you might also want to run `git reflog expire --expire=now --all` and `git gc --prune=now` to expire your reflogs and delete the now-unused objects. (Warning: completely, totally irreversible. Be very sure before you do it.)

## fetch/pull/push from multiple remote locations
> You can configure multiple remote repositories with the `git remote` command:
    git remote add lab lab-machine:/path/to/repo
> To fetch from all the configured remotes and update tracking branches, but not merge into HEAD, do:
    git remote update
> If it's not currently connected to one of the remotes, it will take time out or throw an error, and go on to the next. You'll have to manually merge from the fetched repositories, or cherry-pick, depending on how you want to organize collecting changes.
> To fetch the master branch from alt and pull it into your current head, do:
    git fetch origin --all
    //-u, --set-upstream    set upstream for git pull/status
    git push -u lab --all
    git push lab --all
    git pull lab master
    git push lab master
> So in fact `git pull` is almost shorthand for `git pull origin HEAD` (actually it looks in the config file to determine this, but you get the idea).
> For pushing updates, you have to do that to each repo manually. A push was, I think, designed with the central-repository workflow in mind.

## How to clone all remote branches in Git?
> 1. mirror and core.bare
> Using the --mirror option seems to copy the remote tracking branches properly. However, it sets up the repository as a bare repository, so you have to turn it back into a normal repository afterwards.
````bash
git clone --mirror path/to/original path/to/dest/.git
cd path/to/dest
git config --bool core.bare false
git checkout anybranch
````
> Reference: Git FAQ: How do I clone a repository with all remotely tracked branches?
> 3. checkout by xargs
> Here is another short one-liner command which creates local branches for all remote branches:
````bash
(git branch -r | sed -n '/->/!s#^  origin/##p' && echo master) | xargs -L1 git checkout
````
> It works also properly if tracking local branches are already created. You can call it after the first git clone or any time later.
> If you do not need to have master branch checked out after cloning, use
````bash
git branch -r | sed -n '/->/!s#^  origin/##p'| xargs -L1 git checkout
````
> 2. bash alias
> Use aliases. Though there aren't any native Git one-liners, you can define your own as
````bash
git config --global alias.clone-branches '! git branch -a | sed -n "/\/HEAD /d; /\/master$/d; /remotes/p;" | xargs -L1 git checkout -t'
````
> and then use it as
````bash
git clone-branches
````

## Differences between git remote update and fetch?
> git remote update fetches from all remotes, not just one.
> You can configure which remotes to fetch when running git remote update, see git-remote manpage.

## Why am I getting the message, “fatal: This operation must be run in a work tree?”
> I had this issue, because .git/config contained worktree = D:/git-repositories/OldName. I just changed it into worktree = D:/git-repositories/NewName
> I discovered that, because I used git gui, which showed a more detailed error message

## How can I add an empty directory to a Git repository?
> Create an empty file called `.gitkeep` in the directory, and add that.
> `.gitkeep` has not been prescribed by Git and is going to make people second guess its meaning, which will lead them to google searches, which will lead them here. The .git prefix convention should be reserved for files and directories that Git itself uses.
````gitkeep
# add empty directory of mock and give a explanation
# https://stackoverflow.com/questions/115983/how-can-i-add-an-empty-directory-to-a-git-repository#8418403
````

## How To Change Git Remote Origin - devconnected
````shell
$ git remote -v
> origin  https://github.com/USERNAME/REPOSITORY.git (fetch)
> origin  https://github.com/USERNAME/REPOSITORY.git (push)
$ git remote set-url origin git@github.com:USERNAME/REPOSITORY.git
$ git remote -v
# Verify new remote URL
> origin  git@github.com:USERNAME/REPOSITORY.git (fetch)
> origin  git@github.com:USERNAME/REPOSITORY.git (push)
````
## Replace Remote Repositories
> git remote set-url [--push] <name> <newurl> [<oldurl>]

## Adding Remote Repositories
> git remote add upstream [git link]
> git pull upstream master

## Delete a branch (local or remote)
> To delete a local branch
`git branch -d the_local_branch`
> To remove a remote branch (if you know what you are doing!)
`git push origin :the_remote_branch`
or simply use the new syntax (v1.7.0)
`git push origin --delete the_remote_branch`
- Note
If you get the error error: unable to push to unqualified destination: the_remote_branch The destination refspec neither matches an existing ref on the remote nor begins with refs/, and we are unable to guess a prefix based on the source ref. error: failed to push some refs to 'git@repository_name'
perhaps someone else has already deleted the branch. Try to synchronize your branch list with
`git fetch -p`
The git manual says -p, --prune After fetching, remove any remote-tracking branches which no longer exist on the remote.

## git stuck on Unpacking Objects phase
> I had the same problem when I git pull a repository on github.com. I found there were some large files and the connection to github was slow. So maybe you just have to wait patiently before git pulls the whole repository.
> For me the solution was to change protocol specifier from https to git, e.g.:
git clone https://github.com/some/repository
to
git clone git://github.com/some/repository
Edit:
Here's something about the protocols used in Git.
Some highlights:
The downside of the Git protocol is the lack of authentication.
It also requires firewall access to port 9418, which isn’t a standard port that corporate firewalls always allow
> I find that large binary objects (like Adobe Illustrator files, etc.) tend to bog the whole pull/push process down as well.
Which is why I like to use two repositories now for design vs. code.

## git clone issue: repo too large?
> Basically, initialize an empty repository
`cd repo_name && git init`
Add the original repo as a remote in this repo
`git remote add origin url/to/repo`
And now do a `git fetch`.
This way, even if your clone breaks in the middle, fetch will take care to bring in unfetched objects only in next run.
Alternatively, you can check the solutions [here](https://stackoverflow.com/questions/21277806/fatal-early-eof-fatal-index-pack-failed/22317479#22317479) and [here](https://stackoverflow.com/questions/2505644/git-checking-out-problem-fatal-early-eofs/2505821#2505821).

## git tag
> 1. 创建tag
git tag -a V1.2 -m 'release 1.2'
上面的命令我们成功创建了本地一个版本 V1.2 ,并且添加了附注信息 'release 1.2'
> 2. 查看tag
git tag
要显示附注信息,我们需要用 show 指令来查看
git show V1.2
但是目前这个标签仅仅是提交到了本地git仓库.如何同步到远程代码库
git push origin --tags
如果刚刚同步上去,你缺发现一个致命bug ,需要重新打版本,现在还为时不晚.
git tag -d V1.2
到这一步我们只是删除了本地 V1.2的版本,可是线上V1.2的版本还是存在,如何办?这时我们可以推送的空的同名版本到线下,达到删除线上版本的目标:
git push origin :refs/tags/V1.2
如何获取远程版本?
git fetch origin tag V1.2
这样我们可以精准拉取指定的某一个版本.适用于运维同学部署指定版本.

## git-revert - Revert some existing commits
> Given one or more existing commits, revert the changes that the relatedpatches introduce, and record some new commits that record them. Thisrequires your working tree to be clean (no modifications from the HEADcommit).
> Note: git revert is used to record some new commits to reverse the effectof some earlier commits (often only a faulty one). If you want to throwaway all uncommitted changes in your working directory, you should see git-reset(1), particularly the --hard option. If you want to extract specificfiles as they were in another commit, you should see git-checkout(1),specifically the git checkout <commit> -- <filename> syntax. Take care withthese alternatives as both will discard uncommitted changes in your workingdirectory.

## 解决Git Revert操作后再次Merge代码被冲掉的问题
> [link](https://www.cnblogs.com/zhaokunbokeyuan256/p/9597263.html)
> 要解决这个问题，需要把revert产生的提交再revert一次
> 因为git revert是用新提交覆盖旧提交，因此，被覆盖的提交等于不会被采用了。如果两个分支（假设是master和A分支）先合并再用revert回滚，之后又合并（A合并到master），就会发现在master分支上，A分支第一次合并之前的修改大部分不见了。这是因为从时间的发生顺序来看，A分支第一次合并之前的修改发生在revert之前，revert 发生在后，而 revert 抛弃了A第一合并之前的修改，那么再合并 Git 就认为你永远抛弃了A第一次之前的修改。
> [link](https://blog.csdn.net/cxn945/article/details/48372327)
> 使用revert，把错误的合并反向删除掉。把master合并到dev_cxn时，发现dev_cxn上最后一次提交的代码丢失。经过检查，发现这次合并是fast-forward，而master上的revert操作不会改变合并历史，只是反向删除，所以版本节点是向前更新的，于是想到把dev_cxn合到master，结果发现Already-up-to-date，失败。。
> 再想到如果不用快进合并的方式，也许能够解决问题，于是执行git merge master --no-ff
````man
--no-ff
Create a merge commit even when the merge resolves as a fast-forward. This is the default behaviour when merging an annotated (and possibly signed) tag.
````
> 结果发现，即使不用快进的方式，revert那次操作还是会实实在在的执行进dev_cxn分支，失败。。。

## Force merge after reverting merge commit init git
> There is no way to force a merge; indeed, reverting the revert is the correct way to do it (see https://github.com/git/git/blob/master/Documentation/howto/revert-a-faulty-merge.txt where Linus discusses this). Note that if there are commits on the branch after the (reverted) merge that you want in master, you will need to of course merge in the branch as well.

## git cherry-pick Apply the changes introduced by some existing commits
> Given one or more existing commits, apply the change each one introduces, recording a new commit for each. This requires your working tree to be clean (no modifications from the HEAD commit). When it is not obvious how to apply a change, the following happens:
1. The current branch and HEAD pointer stay at the last commit successfully made.
2. The CHERRY_PICK_HEAD ref is set to point at the commit that introduced the change that is difficult to apply.
3. Paths in which the change applied cleanly are updated both in the index file and in your working tree.
4. For conflicting paths, the index file records up to three versions, as described in the "TRUE MERGE" section of git-merge(1). The working tree files will include a description of the conflict bracketed by the usual conflict markers <<<<<<< and >>>>>>>.
5. No other modifications are made.

## 对代码进行 revert 后，应该如何避免代码不能合并到主干？
> - 推荐方案：
当主干代码对分支代码进行 revert 以后
需要把主干代码拉到分支中；（这时候分支部分代码也会被 revert，造成代码丢失）
在分支中，对上一次 revert 的记录进行 revert，才能保证代码完整；
具体的操作记录，可以参考 test-git-revert 仓库
> - 其他方案：
手动提交丢失代码；
手动修改本地的仓库提交记录（把不需要的提交记录删除）后，强制提交分支；（不推荐，一般也没有这个权限）
> - 对 revert 进入进行 revert 的讨论
可以选择对“合并记录” （以Merge 开头），进行 revert；
也可以选择对 “revert 记录” （以 Revert 开头），进行 revert；
从语义上推荐第二种，这样明确是对 revert 记录进行 revert；
从 gitlab 操作来说，第一种比较好找（直接看 merged list），目前不做强制限制；

## 冲突时直接把冲突文件进行reset操作，导致记录丢失
> 现象描述：对代码冲突进行合并的时候，如果觉得某些文件是保留本地的，也需要对这个文件的冲突中选择自己的那部分，而不是直接忽略，（特别是使用各种 IDE 的情况，要明确知道各按钮或选项的意义），忽略文件对应的 git 命令行是 git reset -- file，结果是保留了自己本地文件内容，但是在提交记录中体现不出来，并导致后续各种代码丢失的情况；
````bash
# 只显示正常提交的记录
git log
# --follow
# Continue listing the history of a file beyond renames
# (works only for a single file).
git log --follow
# --full-history
# Same as the default mode, but does not prune some
# history.
git log --full-history
# 显示完整记录并直接展示修改内容（包括merge）
git log --full-history -p -m readme.md
````

## git log - History Simplification
> Sometimes you are only interested in parts of the history,
for example the commits modifying a particular <path>. But
there are two parts of History Simplification, one part is
selecting the commits and the other is how to do it, as
there are various strategies to simplify the history.
> The following options select the commits to be shown:
<paths>
   Commits modifying the given <paths> are selected.
--simplify-by-decoration
   Commits that are referred by some branch or tag are
   selected.
Note that extra commits can be shown to give a meaningful
history.
The following options affect the way the simplification is
performed:
Default mode
   Simplifies the history to the simplest history
   explaining the final state of the tree. Simplest because
   it prunes some side branches if the end result is the
   same (i.e. merging branches with the same content)
--full-history
   Same as the default mode, but does not prune some
   history.
--dense
   Only the selected commits are shown, plus some to have a
   meaningful history.
--sparse
   All commits in the simplified history are shown.
--simplify-merges
   Additional option to --full-history to remove some
   needless merges from the resulting history, as there are
   no selected commits contributing to this merge.
--ancestry-path
   When given a range of commits to display (e.g.
   commit1..commit2 or commit2 ^commit1), only display
   commits that exist directly on the ancestry chain
   between the commit1 and commit2, i.e. commits that are
   both descendants of commit1, and ancestors of commit2.
