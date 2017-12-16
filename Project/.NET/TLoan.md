# TimeLoan

<!-- MarkdownTOC -->

- 枚举转化为字符串
- 字符串转化为枚举
- 手机号去除特殊符号
- 联系人姓名包含中文
- 数据去重后转化为内存IList
- 创建线程处理大量数据
- 事务存储
- 在缓存中比较两个List
- 常见的两种Dao操作
- ApiService读取Json文件

<!-- /MarkdownTOC -->

## 枚举转化为字符串
````c#
resp.Relationship1 = contactsResp.ContactRelationship1.ToString();
````

## 字符串转化为枚举
````c#
ContactRelationship1 = (ContactRelationship)Enum.Parse(typeof(ContactRelationship), req.Relationship1),
````

## 手机号去除特殊符号
````c#
CellPhone1.Trim().Replace("-", "").Replace("+", "").Replace(" ", "");
````

## 联系人姓名包含中文
````c#
var onlyChineseRegex = new Regex(@"[^\u4e00-\u9fa5]");
var realName1 = req.RealName1.Trim();
var realName2 = req.RealName2.Trim();
var realName1Temp = onlyChineseRegex.Replace(realName1, "");
var realName2Temp = onlyChineseRegex.Replace(realName2, "");
if (string.IsNullOrEmpty(realName1Temp) || string.IsNullOrEmpty(realName2Temp))
{
    resp.ResultCode = "20001";
    resp.ResultMessage = "联系人姓名请使用中文";
    return resp;
}
````

## 数据去重后转化为内存IList
````
// 转化为List
IList<LoanUserSthPO> rawSths = new List<LoanUserSthPO>();
foreach (var contact in req.Contacts.Select(x => { x.CellPhone = x.CellPhone.Replace("-", "").Replace("+", "").Replace(" ", ""); return x; }).GroupBy(x => x.CellPhone).Select(x => x.First()))
{
    if (!string.IsNullOrEmpty(contact.NickName) && !string.IsNullOrEmpty(contact.CellPhone))
    {
        var Sth = new LoanUserSthPO
        {
            Merchant = user.Merchant,
            Owner = user,
            NickName = contact.NickName,
            CellPhone = contact.CellPhone
        };
        rawSths.Add(Sth);
    }
}
````

## 创建线程处理大量数据
````
Task.Run(() =>
{
    try
    {
    	// do sth here
    }
    catch (Exception ex)
    {
        logger.Error("Task出错，" + ex.Message);
    }
});
````

## 事务存储
````
// ApiService
using (new Spring.Data.NHibernate.Support.SessionScope())
{
    // 上传Sth
    UserInfoAuthService.UploadSth(needToUploadList.ToList());
    // 更新Sth
    UserInfoAuthService.UpdateSth(needToUpdateList.ToList());
}
// Service
[Transaction(ReadOnly = false)]
public void UploadSth(IList<LoanUserSthPO> list)
{
    LoanUserSthDao.UploadSth(list);
}
````

## 在缓存中比较两个List
````
IList<LoanUserSthPO> dbSths = LoanUserSthDao.FindByOwnerId(user.Id);
var exceptList = rawSths.Select(x => x.CellPhone)
                        .Except(dbSths.Select(x => x.CellPhone));
var intersectList = rawSths.Select(x => x.CellPhone)
                        .Intersect(dbSths.Select(x => x.CellPhone));
var needToUploadList = rawSths.Where(x => exceptList.Contains(x.CellPhone));
var needToUpdateList = rawSths.Where(x => intersectList.Contains(x.CellPhone));
````

## 常见的两种Dao操作
````
public LoanUserSthPO FindByCellPhone(string cellPhone)
{
    return HibernateTemplate.Execute((ISession session) =>
    {
        return session
            .CreateCriteria<LoanUserSthPO>("Sth")
            .Add(Restrictions.Eq("Sth.CellPhone", cellPhone))
            .List<LoanUserSthPO>()
            .FirstOrDefault();
    });
}
// 同一个Session操作类似数据，不为每个数据开新的Session
public void UploadSth(IList<LoanUserSthPO> list)
{
    HibernateTemplate.Execute<int>((ISession session) =>
    {
        foreach (var po in list)
        {
            session.Save(po);
        }
        return 0;
    });
}
````

## ApiService读取Json文件
````
public UserInfoBaseAuthApiService()
{
    var assembly = Assembly.GetExecutingAssembly();
    var stream = assembly.GetManifestResourceStream("Tm.Loan.Api.pca-code.json");
    pca = JToken.ReadFrom(new Newtonsoft.Json.JsonTextReader(new System.IO.StreamReader(stream, System.Text.Encoding.UTF8))) as JArray;
}
````
