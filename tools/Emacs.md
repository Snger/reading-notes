## install
1. https://emacsformacosx.com/
2. `alias emacs="/Applications/Emacs.app/Contents/MacOS/Emacs -nw"`
3. `alias emacsclient="/Applications/Emacs.app/Contents/MacOS/bin/emacsclient"`

## useful link
1. [ 一年成为Emacs高手(像神一样使用编辑器)](http://blog.csdn.net/redguardtoo/article/details/7222501)
2. [emacs.d](https://github.com/Snger/emacs.d)

## work
1. M-x counsel-recentf
2. M-x neotree-find (current dir file, or ido-find-file) 
3. M-x evil-mode
4. M-x neotree-toggle
5. switch to buffer: M-x b
6. create new file: Just press C-x C-f. This will prompt for a filename, using the current directory of the current buffer as the directory to put it in. For a dired buffer, its current directory is simply the directory you are looking at.
7. change other window: C-x o
8. last input: M p
9. next input: M p

## basic
1. Press `C-h t` in Emacs (“C” means Ctrl key, “M” means Alt key) to read bundled tutorial.
2. read help by pressing `C-h v` and `C-h f`.
3. Evil-mode: `~/.emacs.d/site-lisp/evil/doc/evil.pdf`, 
	1. Disable Vim key bindings: Comment out line containing (require 'init-evil) in init.el to unload it.
	2. Evil setup: It’s defined in `~/.emacs.d/lisp/init-evil.el`. Press `C-z` to switch between Emacs and Vim key bindings.
4. Key bindings are defined in `~/.emacs.d/lisp/init-evil.el`.
5. ParEdit (paredit.el) is a minor mode for performing structured editing of S-expression data. The typical example of this would be Lisp or Scheme source code.
6. Press M-x org-version, then read corresponding online manual to setup.
7. Open file with Ido: If you press C-x C-f to open a file, Ido will show the suggestions. Keep pressing C-f to ignore suggestions.
8. You could `M-x package-refresh-content` and restart Emacs.
9. Chinese Input Method Editor: `M-x toggle-input-method to toggle input method chinese-pyim.`

## daemon
1. emacs --daemon
2. emacsclient -t or emacsclient -c (add ` -a ""` without step 1)
3. emacsclient --eval "(kill-emacs)"
4. emacsclient -e '(client-save-kill-emacs)'

## Why emacsclient can't find socket after executing 'emacs --daemon'
1. Finding the server socket file is the tricky bit, you can use lsof to find it, and then a bit of grep-ing to extract the socket path/filename.
2. lsof -c Emacs | grep server | tr -s " " | cut -d' ' -f8

## 【C-x】 Prefix
C-x C-b		list-buffers
C-x C-c		save-buffers-kill-terminal
C-x C-d		list-directory
C-x C-f		find-file
C-x C-s		save-buffer
C-x C-z		suspend-frame (To resume Emacs, use the appropriate command in the parent shell—most likely fg.)
C-x TAB   	indent-rigidly
C-x 0		delete-window
C-x 1		delete-other-windows
C-x 2		split-window-vertically
C-x 3		split-window-horizontally
C-x <		scroll-left
C-x =		what-cursor-position
C-x >		scroll-right
C-x [		backward-page
C-x ]		forward-page
C-x d		dired
C-x i		insert-file
C-x k		kill-buffer
C-x u		undo
C-x z		repeat
C-x 4 0		kill-buffer-and-window
C-x 4 d		dired-other-window
C-x 4 f		find-file-other-window
C-x 5 0		delete-frame
C-x 5 1		delete-other-frames
C-x 6 2		2C-two-columns
C-x 6 b		2C-associate-buffer
C-x 6 s		2C-split