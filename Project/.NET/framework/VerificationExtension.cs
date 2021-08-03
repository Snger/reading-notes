using System;
using System.Text.RegularExpressions;

namespace Tm
{
    public static class VerificationExtension
    {
        /// <summary>
        /// 验证手机号码
        /// </summary>
        /// <param name="value"></param>
        /// <returns>true 手机号码</returns>
        public static bool IsPhoneNumber(this string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                string pattern = @"^1[3|4|5|7|8]\d{9}$";
                return Regex.IsMatch(value, pattern);
            }
            return false;
        }

        /// <summary>
        /// 身份证号码验证，支持15位与18位
        /// </summary>
        /// <param name="value">身份证号码字符串</param>
        /// <returns></returns>
        public static bool IsIdCard(this string value)
        {
            if (value.Length == 18)
            {
                return CheckIDCard18(value);
            }
            else if (value.Length == 15)
            {
                return CheckIDCard15(value);
            }
            return false;
        }

        /// <summary>
        /// 获取身份证出生日期
        /// </summary>
        /// <param name="value"></param>
        /// <param name="birthday"></param>
        /// <returns></returns>
        public static bool TryParseIDCardBirthday(this string value, out DateTime birthday)
        {
            if (CheckIDCard15(value))
            {
                return DateTime.TryParse(("19" + value.Substring(6, 6)).Insert(4, "-").Insert(7, "-"), out birthday);
            }
            else if (CheckIDCard18(value))
            {
                return DateTime.TryParse(value.Substring(6, 8).Insert(4, "-").Insert(7, "-"), out birthday);
            }
            else
            {
                birthday = default(DateTime);
                return false;
            }
        }

        /// <summary>
        /// 获取身份证性别
        /// </summary>
        /// <param name="value"></param>
        /// <param name="isMale"></param>
        /// <returns></returns>
        public static bool TryParseIDCardSex(this string value, out bool isMale)
        {
            if (CheckIDCard15(value))
            {
                isMale = Convert.ToInt16(value.Substring(14, 1)) % 2 == 1;
                return true;
            }
            else if (CheckIDCard18(value))
            {
                isMale = Convert.ToInt16(value.Substring(16, 1)) % 2 == 1;
                return true;
            }
            else
            {
                isMale = default(bool);
                return false;
            }
        }

        /// <summary>
        /// 获取身份证区域代码
        /// </summary>
        /// <param name="value"></param>
        /// <param name="areaCode"></param>
        /// <returns></returns>
        public static bool TryParseIDCardAreaCode(this string value, out string areaCode)
        {
            if (IsIdCard(value))
            {
                areaCode = value.Substring(0, 6);
                return true;
            }
            else
            {
                areaCode = default(string);
                return false;
            }
        }

        /// <summary>  
        /// 18位身份证号码验证  
        /// </summary>  
        private static bool CheckIDCard18(string idNumber)
        {
            long n = 0;
            if (long.TryParse(idNumber.Remove(17), out n) == false || n < Math.Pow(10, 16)
                || long.TryParse(idNumber.Replace('x', '0').Replace('X', '0'), out n) == false)
            {
                return false; //数字验证  
            }
            string address =
                "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(idNumber.Remove(2)) == -1)
            {
                return false; //省份验证  
            }
            string birth = idNumber.Substring(6, 8).Insert(6, "-").Insert(4, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false; //生日验证  
            }
            string[] arrVarifyCode = ("1,0,x,9,8,7,6,5,4,3,2").Split(',');
            string[] Wi = ("7,9,10,5,8,4,2,1,6,3,7,9,10,5,8,4,2").Split(',');
            char[] Ai = idNumber.Remove(17).ToCharArray();
            int sum = 0;
            for (int i = 0; i < 17; i++)
            {
                sum += int.Parse(Wi[i]) * int.Parse(Ai[i].ToString());
            }
            int y = -1;
            Math.DivRem(sum, 11, out y);
            if (arrVarifyCode[y] != idNumber.Substring(17, 1).ToLower())
            {
                return false; //校验码验证  
            }
            return true; //符合GB11643-1999标准  
        }

        /// <summary>  
        /// 15位身份证号码验证  
        /// </summary>  
        private static bool CheckIDCard15(string idNumber)
        {
            long n = 0;
            if (long.TryParse(idNumber, out n) == false || n < Math.Pow(10, 14))
            {
                return false; //数字验证  
            }
            string address =
                "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(idNumber.Remove(2)) == -1)
            {
                return false; //省份验证  
            }
            string birth = idNumber.Substring(6, 6).Insert(4, "-").Insert(2, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false; //生日验证  
            }
            return true;
        }

        /// <summary>
        /// 验证邮箱
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsEmail(this string value)
        {
            string pattern = @"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$";
            return Regex.IsMatch(value, pattern);
        }
    }
}
