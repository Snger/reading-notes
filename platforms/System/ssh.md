# ssh

<!-- MarkdownTOC -->

- Multiple SSH keys for different accounts on Github or Gitlab \(Example\)
    - config
    - delete cached
    - check agent
    - Add your SSH private key to the ssh-agent
        - add in mac
    - check fingerprint
    - test connection
    - .ssh/config 文件的解释算法及配置原则

<!-- /MarkdownTOC -->


[Source](https://coderwall.com/p/7smjkq/multiple-ssh-keys-for-different-accounts-on-github-or-gitlab "Permalink to Multiple SSH keys for different accounts on Github or Gitlab (Example)")

# Multiple SSH keys for different accounts on Github or Gitlab (Example)

Sometimes you need more accounts than one for access to Github or Gitlab and similar tools. For example you can have one account for your projects at home and second account for your company.

Create SSH keys with different names


    $ ssh-keygen -t rsa -C "your_name@home_email.com"
    $ ssh-keygen -t rsa -C "sjs.stef@gmail.com"

When you see this message


    Generating public/private rsa key pair.
    Enter file in which to save the key (/home/user_name/.ssh/id_rsa):

Enter unique name, for example:


    id_rsa_home

Next, you'll be asked to enter a passphrase.

So, you'll have created SSH key for your home account, now you can generate SSH key for your company account.

Call SSH key generator again with second mail.


    $ ssh-keygen -t rsa -C "your_name@company_email.com"

Enter name for file


    id_rsa_company

After all steps you can check that all keys were created.


    $ ls ~/.ssh

You should see a similar files list:


    id_rsa_home  id_rsa_company  id_rsa_home.pub  id_rsa_company.pub


## config
Now you need a config file for organise these keys.


    $ cd ~/.ssh/
    $ touch config
    $ nano config

Add into config file:


    # Home account
    Host home.github.com
      HostName github.com
      PreferredAuthentications publickey
      IdentityFile ~/.ssh/id_rsa_home

    # Company account
    Host company.github.com
      HostName github.com
      PreferredAuthentications publickey
      IdentityFile ~/.ssh/id_rsa_company


## delete cached
Next you'll delete cached keys


    $ ssh-add -D

If you see a message


    Could not open a connection to your authentication agent.

## check agent
Then enter:


    eval `ssh-agent -s`

and try again previous command.

## Add your SSH private key to the ssh-agent
Next, you can check that your keys were added:


    $ ssh-add -l
    2048 d4:e0:39:e1:bf:6f:e3:26:14:6b:26:73:4e:b4:53:83 /home/user/.ssh/id_rsa_home (RSA)
    2048 7a:32:06:3f:3d:6c:f4:a1:d4:65:13:64:a4:ed:1d:63 /home/mateusz/.ssh/id_rsa_company (RSA)

### add in mac
    $ ssh-add -K ~/.ssh/id_demo
> Note: The -K option is Apple's standard version of ssh-add, which stores the passphrase in your keychain for you when you add an ssh key to the ssh-agent. If you chose not to add a passphrase to your key, run the command without the -K option.
> If you don't have Apple's standard version installed, you may receive an error. For more information on resolving this error, see "Error: ssh-add: illegal option -- K."

## check fingerprint
[error-permission-denied-publickey](https://docs.github.com/en/github/authenticating-to-github/error-permission-denied-publickey)
Find and take a note of your public key fingerprint. Compare the list of github SSH keys with the output from the ssh-add command.

If you haven't any entries then you should add your keys


    ssh-add ~/.ssh/id_rsa_company
    ssh-add ~/.ssh/id_rsa_home

Now you can check connection


    $ ssh -T git@home.github.com
    Hi home_user! You've successfully authenticated, but GitHub does not provide shell access.

    $ ssh -T git@work.github.com
    Hi company_user! You've successfully authenticated, but GitHub does not provide shell access.

**Note! Check the last paragraph of this tip.**

This is very similar case to the previous. I won't describe it step by step, because all steps are the same. I'll add only example config file.

For example you have own account for home works and company account on gitlab.


    # GITLAB
    Host gitlab.company_url.com
       HostName gitlab.company_url.com
       PreferredAuthentications publickey
       IdentityFile ~/.ssh/id_rsa_company

    # GITHUB
    Host github.com
       HostName github.com
       PreferredAuthentications publickey
       IdentityFile ~/.ssh/id_rsa_home

## test connection
The test connections


    $ ssh -T git@gitlab.company_url.com
    Welcome to GitLab, CompanyUser!

    $ ssh -T git@github.com
    Hi home_user! You've successfully authenticated, but GitHub does not provide shell access.

As you probably have seen, prefix on hostname isn't required.

It's required to distinguish your accounts.


    $ cd ~/home_project
    $ git config user.name "home_user"
    $ git config user.email "your_name@home_email.com"

## .ssh/config 文件的解释算法及配置原则
[.ssh/config 文件的解释算法及配置原则](https://www.cnblogs.com/xjshi/p/9146296.html)

