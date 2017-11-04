# VS for Mac
<!-- MarkdownTOC -->

- roslyn compiler not copied to AspnetCompileMerge folder using msbuild
- spring-net not support mono now
- vim
- How can I launch multiple instances of MonoDevelop on the Mac?

<!-- /MarkdownTOC -->

## roslyn compiler not copied to AspnetCompileMerge folder using msbuild
> <kill process processname= "Vbcscompiler" imagepath= "$ webprojectoutputdir" />.
> It turns out that *Microsoft.CodeDom.Providers.DotNetCompilerPlatform 1.0.6 (and 1.0.7) is broken. Downgrade to 1.0.5*.
I was getting the same errors as everyone else here, but I'm using VS 2017, and both local WebDeploy as well as AzureDeploy were broken (no csc.exe found). I tried all the suggestions that I could find on the internet (most of them redirect back to this SO post) but nothing worked until I downgraded to 1.0.5.
> See: [https://github.com/aspnet/RoslynCodeDomProvider/issues/13](https://github.com/aspnet/RoslynCodeDomProvider/issues/13) and [https://github.com/dotnet/roslyn/issues/21340](https://github.com/dotnet/roslyn/issues/21340)

## spring-net not support mono now
> [2 Mar 2014](https://github.com/spring-projects/spring-net/issues/60) Unfortunately, MONO support was deprecated some time ago as a lower-tier focus for the project and the MONO-IFDEFs in the code base are no longer ensured to produce code with expected/supported behavior. If you (or any others) are interested in offering pull requests to re-energize SPRNET support for MONO and to bring its behavior under MONO into line with the MSFT CLR compilation, the project team would be happy to accept them.
> [Is the project still alive?](https://github.com/spring-projects/spring-net/issues/141)

## vim
> Visual Studio -> Extensions -> Gallery -> IDE Extensions -> "VIM" -> Install
> restart Visual Studio

## How can I launch multiple instances of MonoDevelop on the Mac?
> `open -n /Applications/Visual\ Studio.app`


