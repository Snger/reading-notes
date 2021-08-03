using System.Web.Mvc;
using System.Web.ModelBinding;
using TL.Promotion.Web.Models;

namespace TL.Promotion.Web.Controllers
{
    public interface IBaseUserController
    {
        string HostUrl { get; set; }

        string MerchantNo { get; set; }

        string ApiKey { get; set; }

        ActionResult SignUp(string refereeCode, [Form] UserSignUpViewModel value);

        ActionResult SendVerifyCode(string cellphone);

        ActionResult Agreement();
    }
}