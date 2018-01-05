using System.Web.ModelBinding;
using System.Web.Mvc;
using TL.Promotion.Web.Models;

namespace TL.Promotion.Web.Controllers
{
    public class TestUserController : BaseUserController
    {
        public TestUserController()
        {
            MerchantNo = "MER01";
            ApiKey = "6-6-6";
        }

        public override ActionResult SignUp(string refereeCode, [Form] UserSignUpViewModel value)
        {
            return base.SignUp(refereeCode, value);
        }

        public ActionResult SignUp2(string refereeCode, [Form] UserSignUpViewModel value)
        {
            return base.SignUp(refereeCode, value);
        }

        public override ActionResult SendVerifyCode(string cellphone)
        {
            return base.SendVerifyCode(cellphone);
        }

        public override ActionResult Agreement()
        {
            return base.Agreement();
        }
    }
}