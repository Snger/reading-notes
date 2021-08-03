using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T.Common.Utils;
using T.Promotion.BO;

namespace T.Promotion.Service.Impl
{
    public class CookieAuthenticationService : IAuthenticationService
    {
        private const string COOKIENAME = "__COOKIECOOKIENAME__";

        private const string SOMEPROPERTY = "SomeProperty";
        private const string EXPIRES = "ExpiresTime";
        private const string TOKEN = "Token";
        private const string ENCRYPTKEY = "EncryptKey";

        private int _expires = 0;

        public bool IsAuthenticated
        {
            get
            {
                bool isAuthenticated = false;
                var values = SomeWebAppHelper.GetCookieDic(COOKIENAME);
                if (values.ContainsKey(ENCRYPTKEY))
                {
                    var sign = values[ENCRYPTKEY];
                    values.Remove(ENCRYPTKEY);
                    var reSign = Sign(values);
                    isAuthenticated = string.Equals(reSign, sign);
                }
                return isAuthenticated;
            }
        }

        public int Expires
        {
            get
            {
                return _expires == 0 ? 60 : _expires;
            }
            set { _expires = value; }
        }

        public string SomeProperty
        {
            get
            {
                return GetValue(SOMEPROPERTY);
            }
        }

        public string GetValue(string key)
        {
            return SomeWebAppHelper.GetCookie(COOKIENAME, key);
        }

        public void Save(object obj)
        {
            if (obj == null)
            {
                return;
            }

            var userSignInLog = obj as UserSignInLogBO;
            if (userSignInLog == null)
            {
                return;
            }

            var values = new SortedDictionary<string, string>
            {
                { SOMEPROPERTY, userSignInLog.PromoId },
                { EXPIRES, userSignInLog.Expires.ToString("yyyy-MM-dd HH:mm:ss") },
                { CELLPHONE, userSignInLog.Cellphone },
                { TOKEN, userSignInLog.Token ?? string.Empty },
            };
            values.Add(ENCRYPTKEY, Sign(values));

            SomeWebAppHelper.WriteCookie(COOKIENAME, values, Expires);
        }

        public void SignOut()
        {
            SomeWebAppHelper.DeleteCookie(COOKIENAME);
        }

        private string Sign(SortedDictionary<string, string> values)
        {
            return EncryptHelper.ToMD5(string.Join("&", values.Select(x => $"{x.Key}={x.Value}")));
        }
    }
}
