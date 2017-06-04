## What's RVM
1. Ruby Version Manager (RVM): RVM is a command-line tool which allows you to easily install, manage, and work with multiple ruby environments from interpreters to sets of gems.
2. RVM lets you deploy each project with its own completely self-contained and dedicated environment, from the specific version of ruby, all the way down to the precise set of required gems to run your application. Having a precise set of gems also avoids the issue of version conflicts between projects, which can cause difficult-to-trace errors and hours of hair loss. With RVM, NO OTHER GEMS than those required are installed. This makes working with multiple complex applications, where each has a long list of gem dependencies, much more efficient. RVM lets you easily test gem upgrades, by switching to a new clean set of gems to test with, while leaving your original set intact. It is flexible enough to even let you maintain a set of gems per environment, or per development branch, or even per individual developer's taste!
3. RVM has an extremely flexible gem management system called Named Gem Sets. RVM's 'gemsets' make managing gems across multiple versions of Ruby a non-issue. RVM lets you add a small text file to your application's repository, instead of checking in tons of gems which would needlessly inflate your repository size. Additionally, RVM's gemset management uses a common cache directory, so only one downloaded version of each gem resides on disk rather than several copies.
4. RVM helps ensure that all aspects of Ruby are completely contained within user space, strongly encouraging safer, non-root use. Use of RVM rubies thus provides a higher level of system security, and therefore reduces risk and cuts overall system downtime. Additionally, since all processes run at the user level, a compromised ruby process cannot compromise the entire system.

## Typical RVM Project Workflow
1. RVM supports multiple types of files to allow configuring a project for automated ruby switching. In any case make sure to add those files to your version control systems as it is part of the project configuration.
2. Listed in order of precedence (Supported files):
- .rvmrc - shell script allowing full customization of the environment,
- .versions.conf - key=value configuration file
- .ruby-version - single line ruby-version only
- Gemfile - comment: #ruby=1.9.3 and directive:  ruby "1.9.3"
- [notes] only .rvmrc will work in all RVM versions; the other files were introduced in RVM 1.11.0, environment switching is supported since RVM 1.22.0.

## Project file .ruby-version
1. This file is also supported by chruby and rbenv.  .ruby-version is just a ruby name so it does not require trusting and is simpler to use than .rvmrc.

