# ubuntu

<!-- MarkdownTOC -->

- How do I tell what is running on which ports in Ubuntu?
- Change the hostname on a running system
- 查看linux系统版本信息

<!-- /MarkdownTOC -->

## How do I tell what is running on which ports in Ubuntu?
1. Run sudo netstat -lp in your terminal; this will tell you what ports are open to receive connections, and what programs are listening on them. Try sudo netstat -p for the same thing, plus currently-active connections.

## Change the hostname on a running system
> On any Linux system you can change its hostname with the command `hostname`
    hostname --fqd
>> it will output the fully qualified domain name (or FQDN) of the system.
    hostname NEW_NAME
>> will set the hostname of the system to NEW_NAME.

## How to check which shell am I using?
>You can type the following command in your terminal to see which shell you are using:
`echo $0`
> To find the shell you have on the default environment you can check the value of the SHELL environment variable:
`echo $SHELL`
To find the current shell instance, look for the process (shell) having the PID of the current shell instance.
To find the PID of the current instance of shell:
`echo "$$"`
Now to find the process having the PID:
`ps -p <PID>`
Putting it together:
`ps -p "$$"`

## 查看linux系统版本信息
> Ubuntu查看版本命令
`cat /etc/issue`
> 查看Linux内核版本命令
`cat /proc/version`
`uname -a`
> 硬盘信息
`fdisk -l`
`lsblk`
`df` //缩略信息
> CPU信息
`lscpu`
`cat /proc/cpuinfo`
> 查看账号登录信息
`lslogins`
> 查看PCI信息，lspci 是读取 hwdata 数据库
`lspci -v` (相比cat/proc/pci更直观）

