# tmux

<!-- MarkdownTOC -->

- 1. What is tmux?
- 2. tmux installation
- 3. tmux Configuration & Prefix key
- 4. tmux Session Management
- 5. tmux Windows \(tabs\) Management
- 6. tmux Panes Management
- Vi mode in tmux
- refresh config file
- Toggle pane zoom
- tmux version

<!-- /MarkdownTOC -->

## 1. What is tmux?
> According to the tmux authors:
tmux is a terminal multiplexer. What is a terminal multiplexer? It lets you switch easily between several programs in one terminal, detach them (they keep running in the background) and reattach them to a different terminal. And do a lot more.

## 2. tmux installation
> Installation is pretty straightforward if you have Ubuntu or any other Debian-based distribution you can install tmux with:
sudo apt-get install tmux
on CentOS/Fedora:
yum install tmux
and on MacOS:
brew install tmux
After installation, to start tmux run tmux in your terminal window.

## 3. tmux Configuration & Prefix key
> The global configuration file is located at /etc/tmux.conf and the user specific configuration file is located at ~/.tmux.conf. The default prefix is Ctrl-b but if you want to change it to Ctrl-a (GNU Screen’s default prefix), you need to add the following code to your ~/.tmux.conf file:
````conf
unbind C-b
set -g prefix C-a
bind C-a send-prefix
````

## 4. tmux Session Management
> tmux is developed on a client-server model which means that the session is stored on the server and persist beyond ssh logout.
The following command will create a new session called mysession:
tmux new-session -s mysession
To attach to a session run:
tmux attach -t mysession
To list all session run:
tmux ls
You can kill a session using the following command:
tmux kill-session -t mysession
Frequently used sessions commands
````bash
Ctrl-b d	  Detach from the current session 
Ctrl-b (          Go to previous session
Ctrl-b )          Go to next session
Ctrl-b L          Go to previously used session
Ctrl-b s          Choose a session from the sessions list
````

## 5. tmux Windows (tabs) Management
> Each session can have multiple windows. By default all windows are numbered starting from zero.
Frequently used windows (tabs) commands
````bash
Ctrl-b 1  Switch to window 1
Ctrl-b c  Create new window
Ctrl-b w  List all windows
Ctrl-b n  Go to next window
Ctrl-b p  Go to previous window
Ctrl-b f  Find window
Ctrl-b ,  Name window
Ctrl-b w  Choose a window from the windows list
Ctrl-b &  Kill the current window
````

## 6. tmux Panes Management
> With tmux, you can split windows into multiple panes.
Frequently used panes commands
````bash
Ctrl-b "		Split the pane vertically (top/bottom)
Ctrl-b %		Split the pane horizontally (left/right)
Ctrl-b q		Show pane numbers
Ctrl-b x		Kill the current pane
Ctrl-b +		Break pane into window
Ctrl-b -		Restore pane from window
Ctrl-b left		Go to the next pane on the left
Ctrl-b right            Go to the next pane on the right
Ctrl-b up		Go to the next pane on the top
Ctrl-b down		Go to the next pane on the bottom
Ctrl-b o                Cycle through all panes
Ctrl-b ;                Go to previously used pane
````

## Vi mode in tmux
> tmux offers a set of vi-like bindings for navigating a buffer in a window. These allow you to not only navigate through the buffer beyond what your screen is currently showing, but also to search all the output generated thus far, and to select and copy text that can be pasted in any other window in the tmux session.
You can enable this as a default setting in .tmux.conf with the following:
`set-window-option -g mode-keys vi`
You can confirm this is working by pressing Ctrl+B and then : in a tmux session to bring up the command line, and typing:
`list-keys -T copy-mode-vi`
In version 2.3 and below, the syntax is different:
`list-keys -t vi-copy`
This will bring up a complete list of the vi-like functionality available to you in this mode.

## refresh config file
`tmux source ~/.tmux.conf`

## Toggle pane zoom
> `< prefix> + z`
or
`resize-pane -Z`

## tmux version
> tmux -V
