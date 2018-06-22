# svn

## SVN Checkout 问题 The XML response contains invalid XML
> 原因：svn路径里面有“不可描述”的字符，我checkout的使用，用的是同事发来的地址，放到浏览器打开后，从浏览器地址栏复制的。这样是不行的。
> 正确的地址：
> https://svn.XXX.com:444/svn/xxx
> 输入浏览器后的坑爹地址：
> https://svn.XXX.com:444/!/%23xxx
> 解决：用正确的svn路径（废话）
