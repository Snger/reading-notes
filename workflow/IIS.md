# IIS

## Host ASP.NET Core on Windows with IIS
> [Host ASP.NET Core on Windows with IIS](https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/iis/?tabs=aspnetcore2x)

## HTTP Error 503, the service is unavailable
> It could be that the user identity is outdated, especially if you've tried starting a stopped app pool and the next request again fails.
> In IIS, go to the Application Pools under the Server, then find the correct Application Pool for your web site, and click on it. On the Advanced Settings menu to the right, select Identity and change it and enter new user and password. Click on your Application Pool again, and select Recycle to restart it.

## IIS服务器手机端测试流程/Testing your site with IIS express on a mobile device
- 运行 inetmgr 看看是否安装，
- IIS管理器中，添加一个网站，设置端口，浏览
- ipconfig 查看本地ip，修改打开的url中的 localhost 为本地ip
- 打开本地防火墙，添加入站规则——测试的端口；
- 复制测试url，在 cli.im 中生成二维码
- 扫描二维码
