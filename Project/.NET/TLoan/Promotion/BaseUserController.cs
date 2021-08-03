using Newtonsoft.Json;
using System;
using System.Web.Mvc;
using T.Loan.Sdk;
using T.Network;
using System.Web.ModelBinding;
using System.Text.RegularExpressions;
using TL.Promotion.Web.Models;

namespace TL.Promotion.Web.Controllers
{
    public class BaseUserController : Controller, IBaseUserController
    {
        private static string _hosturl = "http://api.url/api/v1/service/do?name=";
        private static string _merchantNO = "";
        private static string _apikey = "";

        public BaseUserController(){}

        BaseUserController (string merchantNo, string apiKey)
        {
            MerchantNo = merchantNo;
            ApiKey = apiKey;
        }

        public string HostUrl
        {
            get
            {
                return _hosturl;
            }
            set { _hosturl = value; }
        }

        public string MerchantNo
        {
            get
            {
                return _merchantNO;
            }
            set { _merchantNO = value; }
        }

        public string ApiKey
        {
            get
            {
                return _apikey;
            }
            set { _apikey = value; }
        }

        public virtual ActionResult SignUp(string refereeCode, [Form] UserSignUpViewModel value)
        {
            if (this.Request.HttpMethod == "POST")
            {
                var userAgent = this.Request.UserAgent;
                // !this.Request.Browser.IsMobileDevice
                if (userAgent.Contains("Windows NT") || userAgent.Contains("Macintosh"))
                {
                    value.ErrorMsg = "Some Err";
                    return View(value);
                }
                if (!string.Equals(value.AgreeCheckbox, "on"))
                {
                    value.ErrorMsg = "Some Err";
                    return View(value);
                }
                if (string.IsNullOrEmpty(value.Cellphone))
                {
                    value.ErrorMsg = "Some Err";
                    return View(value);
                }
                var phoneRegex = @"^1[3|4|5|7|8|9]\d{9}$";
                if (!Regex.IsMatch(value.Cellphone, phoneRegex))
                {
                    value.ErrorMsg = "Some Err";
                    return View(value);
                }

                var regex = new Regex("(?=^.{6,12}$)(?=(?:.*?\\d){1})(?=(?:.*?[a-zA-Z]){1})");

                if (string.IsNullOrEmpty(value.Password) || !regex.IsMatch(value.Password))
                {
                    value.ErrorMsg = "Some Err";
                    return View(value);
                }
                if (string.IsNullOrEmpty(value.VerCode))
                {
                    value.ErrorMsg = "Some Err";
                    return View(value);
                }

                var req = new SignUpReq()
                {
                    Service = "signup",
                    MerchantNo = MerchantNo,
                    Timestamp = DateTime.Now.ToString("yyyyMMddHHmmss"),
                    Cellphone = value.Cellphone,
                    VerCode = value.VerCode,
                    Password = value.Password,
                    RefCode = value.RefereeCode,
                    DeviceType = "Web",
                };
                req.Signature = req.Sign(ApiKey);

                var http = System.Net.WebRequest.CreateHttp(HostUrl + "signup");

                var responseText = http.PostJson(JsonConvert.SerializeObject(req));
     
                var resp = JsonConvert.DeserializeObject<SignUpResp>(responseText);

                if(resp.ResultCode == "0")
                {
                    value.SuccessMsg = "success";
                }
                else
                {
                    value.ErrorMsg = resp.ResultMessage;
                }

            }

            if (value == null)
            {
                value = new UserSignUpViewModel() { RefereeCode = refereeCode };
            }

            return View(value);
        }

        public virtual ActionResult SendVerifyCode(string cellphone)
        {
            if (string.IsNullOrEmpty(cellphone))
            {
                return Content("fail");
            }

            var req = new SMSAuthReq
            {
                Service = "smsauth",
                MerchantNo = MerchantNo,
                Timestamp = DateTime.Now.ToString("yyyyMMddHHmmss"),
                Cellphone = cellphone,
                Type = "Register",
            };
            req.Signature = req.Sign(ApiKey);

            var http = System.Net.WebRequest.CreateHttp(HostUrl + "smsauth");

            var responseText = http.PostJson(JsonConvert.SerializeObject(req));
 
            var resp = JsonConvert.DeserializeObject<SignUpResp>(responseText);

            if(resp.ResultCode == "0")
            {
                return Content("success");
            }
            else
            {
                return Content("fail");
            }

        }

        public virtual ActionResult Agreement()
        {
            return View();
        }
    }
}