# go


## Install Golang with Homebrew
> https://sourabhbajaj.com/mac-setup/Go/README.html
````shell
$ brew update
$ brew install golang
````
> When installed, try to run go version to see the installed version of Go.

## Setup the workspace:
### Add Environment variables:
> Go has a different approach of managing code, you'll need to create a single Workspace for all your Go projects. For more information consult : How to write Go Code
> First, you'll need to tell Go the location of your workspace.
> We'll add some environment variables into shell config. One of does files located at your home directory bash_profile, bashrc or .zshrc (for Oh My Zsh Army)
````shell
$ vi .bashrc
````
Then add those lines to export the required variables
#### This is actually your .bashrc file
````shell
export GOPATH=$HOME/go-workspace # don't forget to change your path correctly!
export GOROOT=/usr/local/opt/go/libexec
export PATH=$PATH:$GOPATH/bin
export PATH=$PATH:$GOROOT/bin
````
### Create your workspace:
Create the workspace directories tree:
````shell
$ mkdir -p $GOPATH $GOPATH/src $GOPATH/pkg $GOPATH/bin
$GOPATH/src : Where your Go projects / programs are located
$GOPATH/pkg : contains every package objects
$GOPATH/bin : The compiled binaries home
````
Hello world time!
Create a file in your $GOPATH/src, in my case hello.go Hello world program :
````shell
package main
import "fmt"

func main() {
    fmt.Printf("hello, world\n")
}
````
Run your first Go program by executing:
````shell
$ go run hello.go
````
You'll see a sweet hello, world stdout
If you wish to compile it and move it to $GOPATH/bin, then run:
````shell
 $ go install hello.go
````
Since we have $GOPATH/bin added to our $PATH, you can run your program from placement :
````shell
$ hello
````
Prints : hello, world

