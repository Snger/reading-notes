## What is babun?
1. babun: a windows shell you will love.

<!-- MarkdownTOC -->

- Features in 3 minutes of babun
- How can I change the default fonts and size of Babun’s \(mintty\) window on startup.
- What is the difference between Cygwin and MinGW?
- [Cannon Start Plugin][cygdrive]

<!-- /MarkdownTOC -->

## Features in 3 minutes of babun
1. Cygwin : The core of Babun consists of a pre-configured Cygwin. Cygwin is a great tool, but there’s a lot of quirks and tricks that makes you lose a lot of time to make it actually 'usable'. Not only does babun solve most of these problems, but also contains a lot of vital packages, so that you can be productive from the very first minute.
2. Package manager : Babun provides a package manager called pact. It is similar to 'apt-get' or 'yum'. Pact enables installing/searching/upgrading and deinstalling cygwin packages with no hassle at all. Just invoke pact --help to check how to use it.
3. Shell : Babun’s shell is tweaked in order to provide the best possible user-experience. There are two shell types that are pre-configured and available right away - bash and zsh (zsh is the default one).

## How can I change the default fonts and size of Babun’s (mintty) window on startup.
1. Add / edit ~/.minttyrc
````
Font=YaHei & SourceCodePro.Medium
FontHeight=16
RowSpacing=2
Transparency=low
ColSpacing=4
````

## What is the difference between Cygwin and MinGW?
1. As a simplification, it's like this:
> Compile something in Cygwin and you are compiling it for Cygwin.
> Compile something in MinGW and you are compiling it for Windows.
2. About Cygwin
> The purpose of Cygwin is to make porting *nix-based applications to Windows much easier, by emulating many of the small details that Unix-based operating systems provide, and are documented by the POSIX standards. If your application assumes that it can use Unix feature such as pipes, Unix-style file and directory access, and so forth, then you can compile it in Cygwin and Cygwin itself will act as a compatibility layer around your application, so that many of these Unix-specific paradigms can continue to be used with little or no modification to your application.
> If you want to compile something for Cygwin and distribute that resulting application, you must also distribute the Cygwin run-time environment (provided by cygwin1.dll) along with it, and this has implications for what types of software license you may use.
3. About MinGW
> MinGW is a Windows port of the GNU compiler tools, such as GCC, Make, Bash, and so on. It does not attempt to emulate or provide comprehensive compatibility with Unix, but instead it provides the minimum necessary environment to use GCC (the GNU compiler) and a small number of other tools on Windows. It does not have a Unix emulation layer like Cygwin, but as a result your application needs to specifically be programmed to be able to run in Windows, which may mean significant alteration if it was created to rely on being run in a standard Unix environment and uses Unix-specific features such as those mentioned earlier. By default, code compiled in MinGW's GCC will compile to a native Windows X86 target, including .exe and .dll files, though you could also cross-compile with the right settings. MinGW is an open-source alternative to Microsoft Visual C++ compiler and its associated linking/make tools.
> Considerably sophisticated cross-platform frameworks exist which make the task of porting applications to various operating systems easily - for example the Qt framework is a popular framework for cross-platform applications. If you use such a framework from the start, you can not only reduce your headaches when it comes time to port to another platform but you can use the same graphical widgets - windows, menus and controls - across all platforms if you're writing a GUI app.
4. Short:
> Cygwin uses a DLL, cygwin.dll, (or maybe a set of DLLs) to provide a POSIX-like runtime on Windows.
> MinGW compiles to a native Win32 application.
> If you build something with Cygwin, any system you install it to will also need the Cygwin DLL(s). A MinGW application does not need any special runtime.

## Cannon Start Plugin [cygdrive]
> This error occurs when I attempt to start two babun sessions in split console under ConEmu. The first console opens correctly, but the second has the following error:
````bash
rm: cannot remove ‘/c’: No such file or directory
ln: failed to create symbolic link ‘/c/c’: File exists
Error on or near line 20, last command 'ln -s "$cygdrive_dir" "/$drive_name"';
Could not start plugin [cygdrive]
````
> - vim /etc/fstab
> - remove with vim the last line `none /cygdrive binary,posix=0,user,acl 0 0`
> - replace it with this line `none /cygdrive binary 0 0`
> - System Properties > Environment Variables... -> User Variable for [username] -> New...
> - Create a HOME variable (in all caps), and path to .babun/cygwin/home/[username].
> - Restart babun it will reinstall some configs if not, check if the HOME var is in uppercase.