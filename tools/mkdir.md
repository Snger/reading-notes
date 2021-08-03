# mkdir or md


## basic
> [Mkdir: Create directory from command line](https://www.windows-commandline.com/create-directory-command-line/)
> In Windows, we can create directories from command line using the command mkdir(or md). Syntax of this command is explained below.
1. Create a folder from command line:
mkdir foldername
2. For example, to create a folder named ‘newfolder‘ the command is:
mkdir newfolder

## Create directory hierarchy
> We can create multiple directories hierarchy(creating folder and sub folders with a single command) using mkdir command.
For example, the below command would create a new folder called ‘folder1’ and a sub folder ‘folder2’ and a sub sub folder ‘folder3’.
 mkdir folder1\folder2\folder3.
 md folder1\folder2\folder3.

## Handling whitespaces
> If the name needs to have space within, you should enclose it in double quotes.
For example, to create a folder with the name ‘My data’, the command would be
c:\>mkdir "my data"

## Creating multiple folders
> mkdir command can handle creating multiple folders in one go. So you can specify all the folders you wanted to create like below
C:\>mkdir folder1 folder2  subfolder1/folder3 subfolder2/subfolder21/folder4
> The syntax of the command is incorrect.
> If you get this error, make sure you are using the directory paths in Windows format and not in Linux format. On Linux, the directory paths are separated with ‘/’, but in Windows it’s ‘\’.
c:\>mkdir  folder1/folder2
> The syntax of the command is incorrect.
The right command is
c:\>mkdir  folder1\folder2

## mkdir Command Options and Syntax Summary
> Option / Syntax	Description
`mkdir directory_name`	Creates a directory in the current location
`mkdir {dir1,dir2,dir3,dir4}`	Creates multiple directories in the current location. Do not use spaces inside {}
`mkdir –p directory/path/newdir`	Creates a directory structure with the missing parent directories (if any)
`mkdir –m777 directory_name`	Creates a directory and sets full read, write, execute permissions for all users
`mkdir –v directory_name(s)`	Creates a directory in the current location
> Use ls -R to show the recursive directory tree.
> Without the -p option, the terminal returns an error if one of the directories in the string does not exist.
