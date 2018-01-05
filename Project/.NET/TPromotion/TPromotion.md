# TB

<!-- MarkdownTOC -->

- Unable to find manifest signing certificate in the certificate store.
- using ViewBag

<!-- /MarkdownTOC -->

## Unable to find manifest signing certificate in the certificate store.
> Unable to find code signing certificate in the current user’s Windows certificate store. To correct this, either disable signing of the ClickOnce manifest or install the certificate into the certificate store.	Timemicro.B.WindowsService			
> 


## using ViewBag
````c#
public ActionResult Promo(string bId)
{
    PromoPageRespBO allInfo = ...
    try
    {
        var aInfo = allInfo.AInfo;
        var bInfo = allInfo.BInfo;
        var cInfo = allInfo.CInfo;
        var rgxHidePhone = new Regex(@"(\d{3})\d{4}(\d*)");
        var wts = new List<WT>();
        foreach(var item in aInfo)
        {
            var wt = new WT
            {
                TNumber = item.TNumber,
                CellPhone = rgxHidePhone.Replace(item.CellPhone, "$1****$2")
            };
            wts.Add(wt);
        }
        ViewBag.AInfo = wts;
        ViewBag.STime = bInfo.STime.Substring(0, 5); //string
        ViewBag.STimeTAmount = bInfo.STimeTAmount;
        var lNum = cInfo.LNumber;
        ViewBag.LNumber1 = lNum[0];
        ViewBag.SI = cInfo.SI?.ToString("0.00"); //decimal
    }
    catch(Exception ex)
    {
        logger.Error("Error:", ex);
    }
    return View();
}
````
````html
<ul>
@{
    foreach(var item in ViewBag.AInfo)
    {
        <li><span class="code-span">@item.TNumber</span>  <span class="float-right">@item.CellPhone</span></li>
    };
}
</ul>
````

