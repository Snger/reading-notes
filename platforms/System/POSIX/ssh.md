# ssh

## Can someone explain the 'PasswordAuthentication' in the /etc/ssh/sshd_config file?
> SSH support multiple ways to authenticate users, the most common one is by asking a login and a password but you can also authenticate user a login and a public key. If you set PasswordAuthentication to no, you will no longer be able to use a login and password to authenticate and must use a login and public key instead (if PubkeyAuthentication is set to yes)
