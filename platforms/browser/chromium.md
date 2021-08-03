# chromium

## clone
> git clone https://github.com/chromium/chromium.git --config 'http.proxy=socks5://127.0.0.1:1080' --depth=1
> For me the git:// just doesn't work through the proxy although the https:// does. This caused some bit of headache because I was running scripts that all used git:// so I couldn't just easily change them all. However I found this GEM
````conf
git config --global url."https://github.com/".insteadOf git://github.com/
````
> Try reconfiguring the pack creation parameters on the serving repo, especially git's ~no limit~ default for  pack.windowmemory.
I'd start with
````conf
git config pack.windowmemory 1g
````
because it'll use that much per core by default.
> The best method that I know of is to combine [shallow clone](https://git-scm.com/docs/git-clone#git-clone---depthltdepthgt) (`--depth 1`) feature with [sparse checkout](https://git-scm.com/docs/git-read-tree#_sparse_checkout), that is checking out only the subfolders or files that you need. (Shallow cloning also implies `--single-branch`, which is also useful.) See [udondan's answer](https://stackoverflow.com/a/28039894/5407270) for an example. 
Additionally, if pulling still keeps failing, I use a bash loop to keep retrying until finished successfully. Like this:

    #!/bin/bash

    git init <repo>
    cd <repo>
    git remote add origin <repo_url>
    git config core.sparsecheckout true                     # <-- enable sparse checkout
    echo "subdirectory/*" >> .git/info/sparse-checkout      # <-- specify files you need

    # Keep pulling until successful
    until $( git pull --depth=1 origin master ); do         # <-- shallow clone
        echo "Pulling git repository failed; retrying..."
    done

> In this way I can eventually pull the needed files even with slow VPN behind the Great Chinese Firewall (usually overnight).
Importantly, by pulling this way you will still be able to push. 
