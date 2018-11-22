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

