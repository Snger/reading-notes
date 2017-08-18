## How to verify the authenticity of a download?
1. download: pact install gnupg (gpg), pact install gnupg2 (gpg2)
1. Creating Your Key
> Before you can encrypt or sign files with GPG you must have a key.
> $ gpg --gen-key
1. Import another person’s public key:
> When you import a public key, you are placing it into what is commonly referred to as your GPG “keyring.”
> gpg --import laanwj-releases.asc
> gpg --fingerprint 90C8019E36C2E964
> gpg --edit 90C8019E36C2E964
> trust
> 4 -- I trust fully
> sign
> save
1. List the public keys in your keyring:
> You can now view a list of public keys in your keyring, as well as the name and email address associated with each key.
> gpg --list-keys
1. verify
> gpg --verify SHA256SUMS.asc
1. get the shasum
> shasum -a 256 bitcoin-0.14.2-win64-setup.exe
> sha256sum bitcoin-0.14.2-win64-setup.exe
> grep bitcoin-0.14.2-win64-setup.exe SHA256SUMS.asc
1. Check the hash sum file signature:
> gpg --verify-files SHA256SUMS.asc laanwj-releases.asc
1. Finally, check the file of interest:
> gpg --verify-files bitcoin-0.14.2-win64-setup.exe SHA256SUMS.asc
1. Check that the hash sum matches:
> sha256sum --ignore-missing -c SHA256SUMS.asc
1. Check by .sig file 
> gpg --verify v2ray.exe.sig v2ray.exe

