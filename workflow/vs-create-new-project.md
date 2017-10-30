# vs create new (tm type) project

## Code Style
- JsonProperty 小驼峰式：(little camel-case)
- Service上独立的方法要带上Transaction注解或特性 [Transaction(ReadOnly = false)]
- 单个Dao或只查询可以直接在ApiService里调用，多个Dao或者非查询放在Service里
- 共用的userId写在基础类里，不需要Api接口都写
- 需要用户登录的接口继承AbstractSecurityApiService
- 需要参与签名的字段：敏感、数据不是复杂和太长的字段
- 用户输入的信息，除了密码最好都先trim()
- 需要签名的Api 字段使用扁平结构，不考虑签名的可以直接object[]或配合DTO使用

## 待处理问题
- 城市接口？ 银行接口？

## Create New Project (Demo)
- Target Framework: 4.5
- Tpye: Class Library(Framework)
- Name: Demo.Core
- Location: workspace
- Solution Name: Demo
- Demo.Core - right click - properties - Application - Default Namespace: Demo - Save
- Close project
-? in project dir, mkdir src, move project to src

## Add packages
> - Tools - Nuget Package Manager - Browse
> Common.Logging, (Common.Logging.Core), (Microsoft.CSharp), Spring.Aop, (Spring.Core), Spring.Data
> auto build app.config file, configuration > runtime > Common.Logging.Core, Common.Logging
>?(x) manual add runtime dependents: Iesi.Collections, NHibernate assemblyIdentity config to app.config

## Add framework (Solution)
> - Add New solution folder - framework
> Api, Configuration, Configuration.MySql, Core, Network, SH4

## Add Reference (Demo.Core)
> - Restore
> - Referens - right click - add reference - Projects
>> tm.Core, SH4
> ### Notes
> - Restore
>> right click of References - Manage NuGet Packages - Restore
>> ### Add PO (Demo)
> - Add new folder - PO
> - Add new item - Visual C# Items - General - Class Diagram
> - View - Toolbox(Ctrl+Alt+X)
> - Add Class - public UserPO - inherit SH4.PO<TId>
> ### Add Dao
>> public interface IUserSecurityInfoDao : IHibernateDao<IUserSecurityInfoDao, long>
>> mkdir Impl
>> public class UserSecurityInfoDao : HibernateDao<LoanUserSecurityInfoPO, long>, IUserSecurityInfoDao
>> Tools - Nuget Package Manager - Browse - Spring.Data.NHibernate4

## Add Demo.Core.MySql project
> Class Library

## Add Demo.Sdk project
> Class Library
> - Tools - Nuget Package Manager - Browse
> Newtonsoft.Json
> - Referens - right click - add reference - Projects
>> tm.API
> - Add class - public LoanApiData - inherit tm.API.AbstractApiData
>> using Newtonsoft.Json, System.Security.Cryptography
> - Add class - public LoanApiRespData : LoanApiData
>> using Newtonsoft.Json, tm.Api

## Add Demo.Core.Api project
> Class Library
> - Referens - right click - add reference - Projects
>> tm.API, Demo.Core, Demo.Sdk
> - add public interface class
>> IApiService.cs, AbstractApiService.cs
## Demo.Core.Api project change ApiService
> - Tools - Nuget Package Manager - Browse
> Common.Logging, (Common.Logging.Core), (Microsoft.CSharp), Spring.Aop, (Spring.Core), Spring.Data, Spring.Data.NHibernate4

## Add Demo.Web project
> type: Asp.Net Web Application (.NET Framework)
> Template: MVC API
> Template: Empty, Add folders and core references for: Web API
> Template: MVC, Add folders and core references for: Web API
> - clear unusing file
>> delete dir Content, fonts, Scripts; <del>delete Controllers/HomeController.cs, delete Views/Home, Views/Shared/, View\/\_ViewStart.cshtml, favicon.ico</dev>
>> - delete App_Start/BundleConfig.cs, FilterConfig.cs
>>> Global.cs - remove bundleConfig, filterConfig
>> - delete all about ApplicationInsights, 
>> - packages.config file
>>> add zh-Hans,like Microsoft.AspNet.Mvc.zh-Hans
>>> delete all unseing package: Antlr, bootstrap, jQuery, jQuery.Validation, Microsoft.ApplicationInsights ...
>> - /Web.config file
>>> under system.web > httpModules delete ApplicationInsightsWebTracking
>>> under system.webServer > modules, delete ApplicationInsightsWebTracking
>>> under system.web - add 
````xml
    <pages>
      <namespaces>
        <add namespace="System.Web.Helpers" />
        <add namespace="System.Web.Mvc" />
        <add namespace="System.Web.Mvc.Ajax" />
        <add namespace="System.Web.Mvc.Html" />
        <add namespace="System.Web.Routing" />
        <add namespace="System.Web.WebPages" />
      </namespaces>     
    </pages>
````

## Demo.Core add UserSecurityInfoDao
> - Tools - Nuget Package Manager - Browse
>> NHibernate
> - 

## Demo.Web - MVC
> - Tools - Nuget Package Manager - Browse
>> Microsoft.CodeDom.Providers.DotNetCompilerPlatform(update), MySql.Data
> - framework dir add framework
>> tm.Web.Mvc5
> - Referens - right click - add reference - Projects
>> tm.Web.Mvc5, Demo.Api
> - App_Stat/WebApiConfig.cs
````C#
using System.Web.Http.Dispatcher; using Timemicro.Web.Mvc5;

// Web API configuration and services
config.MapHttpAttributeRoutes();
config.Formatters.JsonFormatter.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc;

config.Services.Replace(typeof(IHttpControllerSelector), new NamespaceHttpControllerSelector(config));

config.Routes.MapHttpRoute(
    name: "v1_Api",
    routeTemplate: "api/v1/{controller}/{action}/{id}",
    defaults: new
    {
        action = "Get",
        id = RouteParameter.Optional,
    },
    namespaces: new string[] { "Timemicro.Loan.Web.Areas.v1.Controllers.Api" }
);
````
> - v1AreaRegistration
> mkdir Areas/v1
> public class v1AreaRegistration : AreaRegistration 
> mkdir Controllers, Models
> - ServiceController.cs
> mkdir Controllers/Api/, ServiceController.cs
````c#
    [HttpPost]
    [ActionName("do")]
    public HttpResponseMessage Do([FromUri] ServiceDoDTO dto)
    {
        logger.Info($"api service {dto.Name} start.");

        var json = string.Empty;
        var stream = Request.Content.ReadAsStreamAsync().Result;
        using (var reader = new System.IO.StreamReader(stream))
        {
            json = reader.ReadToEnd();
        }

        var apiService = ApiServices[dto.Name];
        var req = JsonConvert.DeserializeObject(json, apiService.ReqType);
        var resp = apiService.Execute(req);
        var msg = string.IsNullOrEmpty(dto.Callback) ? HttpResponseMessageUtility.Json(resp) : HttpResponseMessageUtility.Jsonp(resp, dto.Callback);

        logger.Info($"api service {dto.Name} end.");

        return msg;
    }
````

## Demo.Web 添加项目配置
> - Config 添加配置

## 发布
> - PublishProfiles
