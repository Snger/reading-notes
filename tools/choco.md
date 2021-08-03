# Chocolatey - Software Management Automation

## Installing Chocolatey
> First, ensure that you are using an [administrative shell](http://www.howtogeek.com/194041/how-to-open-the-command-prompt-as-administrator-in-windows-8.1/) - you can also install as a non-admin, check out [Non-Administrative Installation](https://chocolatey.org/install#non-administrative-install).

### Install with cmd.exe
> Run the following command:
````bash
@"%SystemRoot%\System32\WindowsPowerShell\v1.0\powershell.exe" -NoProfile -InputFormat None -ExecutionPolicy Bypass -Command "iex ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1'))" && SET "PATH=%PATH%;%ALLUSERSPROFILE%\chocolatey\bin"
```` 

### Install with PowerShell.exe
> With PowerShell, there is an additional step. You must ensure Get-ExecutionPolicy is not Restricted. We suggest using Bypass to bypass the policy to get things installed or AllSigned for quite a bit more security.
> Run Get-ExecutionPolicy. If it returns Restricted, then run Set-ExecutionPolicy AllSigned or Set-ExecutionPolicy Bypass.
> Now run the following command:
````bash
Set-ExecutionPolicy Bypass; iex ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1'))
````

## Chocolatey and babun pact integeration
> the pact install the command line tools. Where are the choco installs GUI softwares. If we compare it with Mac's Home Brew
> pact is like just brew
> choco is like brew cask

## What is the difference between packages no suffix as compared to .install.portable?
> What is the difference between packages named `*.install` (i. e. autohotkey.install), `*.portable` (i. e. autohotkey.portable) and * (i. e. autohotkey)?
> Nearly 100% of the time, the package with no suffix (autohotkey in this example) is going to ensure the `*.install`. The package without the suffix is for both discoverability and for other packages to take a dependency on.
> Hey, good question! You are paying attention! Chocolatey has the concept of virtual packages (coming) and meta packages. Virtual packages are packages that represent other packages when used as a dependency. Metapackages are packages that only exist to provide a grouping of dependencies.
> A package with no suffix that is surrounded by packages with suffixes is to provide a virtual package. So in the case of git, git.install, and git.commandline (deprecated for .portable) – git is that virtual package (currently it is really just a metapackage until the virtual packages feature is complete). That means that other packages could depend on it and you could have either git.install or git.portable installed and you would meet the dependency of having git installed. That keeps Chocolatey from trying to install something that already meets the dependency requirement for a package.
> Talking specifically about the `*.install` package suffix – those are for the packages that have a native installer that they have bundled or they download and run.
> NOTE: the suffix `*.app` has been used previously to mean the same as `*.install`. But the `*.app` suffix is now deprecated and should not be used for new packages.
> The `*.portable` packages are the packages that will usually result in an executable on your path somewhere but do not get installed onto the system (Add/Remove Programs). Previously the suffixes `*.tool` and `*.commandline` have been used to refer to the same type of packages.
> NOTE: now `*.tool` and `*.commandline` are deprecated and should not be used for new packages.
