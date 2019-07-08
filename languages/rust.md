# rust

<!-- MarkdownTOC -->

- crates 国内镜像源配置

<!-- /MarkdownTOC -->

## crates 国内镜像源配置
> 编辑~/.cargo/config写入 USTC-中科大镜像；
````config
[source.crates-io]
registry = "https://github.com/rust-lang/crates.io-index"
replace-with = 'ustc'
[source.ustc]
registry = "git://mirrors.ustc.edu.cn/crates.io-index"
````
