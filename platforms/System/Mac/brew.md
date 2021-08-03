# brew

<!-- MarkdownTOC -->

- brew update - Error: homebrew-core is a shallow clone.
- Homebrew: Cask 'java' definition is invalid
- Error: Cask 'java' is unreadable: undefined method 'undent' for
- Error: Unknown command: cask || despite the use of multiple instance trials

<!-- /MarkdownTOC -->

## brew update - Error: homebrew-core is a shallow clone.
> To `brew update`, first run:
    git -C /usr/local/Homebrew/Library/Taps/homebrew/homebrew-core fetch --unshallow
    error: RPC failed; result=18, HTTP code = 200 MiB | 16.00 KiB/s
    fatal: The remote end hung up unexpectedly
    fatal: early EOF
    fatal: index-pack failed
> cd /usr/local/Homebrew/Library/Taps/homebrew/homebrew-core
    ALL_PROXY=socks5://127.0.0.1:1090 git fetch --unshallow
    ALL_PROXY=socks5://127.0.0.1:1090 git fetch --depth=5

## Homebrew: Cask 'java' definition is invalid
Solved by doing the following:
1. Edited the java cask:

```
vim /usr/local/Caskroom/java/.metadata/1.8.0_51-b16/20150725210402.758/Casks/java.rb
```
2. Changed the first line from:
`cask :v1 => 'java' do`
to
`cask 'java' do`
3. Removed the `undent` comments at the end of the cask, which were giving me problems.
4. Ran `brew cask uninstall java`
Problem solved 💥

## Error: Cask 'java' is unreadable: undefined method 'undent' for
> You currently installed version of java is from an old version of the Cask file -- please run
    brew uninstall --force java
then
    rm -r "$(brew --prefix)/Caskroom/java"
then
    brew install java
and this may fix your issue.

## Error: Unknown command: cask || despite the use of multiple instance trials
> I was having a similar issue running brew cask install [...]. I am running macOS Catalina v10.15.7. I used brew install --cask [...] and it worked for me. In your case:
    brew install --cask cscreen
> cask is [no longer a brew command](https://github.com/Homebrew/discussions/discussions/902#discussioncomment-398348).

