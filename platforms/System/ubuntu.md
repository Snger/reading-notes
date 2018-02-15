# ubuntu

## How do I tell what is running on which ports in Ubuntu?
1. Run sudo netstat -lp in your terminal; this will tell you what ports are open to receive connections, and what programs are listening on them. Try sudo netstat -p for the same thing, plus currently-active connections.

## Change the hostname on a running system
> On any Linux system you can change its hostname with the command `hostname`
    hostname --fqd
>> it will output the fully qualified domain name (or FQDN) of the system.
    hostname NEW_NAME
>> will set the hostname of the system to NEW_NAME.
