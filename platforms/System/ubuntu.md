## How do I tell what is running on which ports in Ubuntu?
1. Run sudo netstat -lp in your terminal; this will tell you what ports are open to receive connections, and what programs are listening on them. Try sudo netstat -p for the same thing, plus currently-active connections.
