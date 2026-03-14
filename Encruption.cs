using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace passwordManager
{
    internal class Encruption
    {
        private static readonly string _allChar = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        private static readonly string _altchar = "abcdefghijklmABCDEFGHIJKLMNOP0123456789nopqrstuvwxyzQRSTUVWXYZ";
        public static string Encrypt(string password)
        {
            var sb = new StringBuilder();
            foreach (char c in password)
            {
                var cIndex = _allChar.IndexOf(c);

                // 2. هنا بقى اللعبة: لو لقينا الحرف (يعني الـ index مش -1)
                if (cIndex != -1)
                {
                    sb.Append(_altchar[cIndex]);
                }
                else
                {
                    // 3. لو ملحقناش الحرف (زي مسافة أو رمز) نزله زي ما هو عشان البرنامج ميضربش
                    sb.Append(c);
                }
            }
            return sb.ToString();

        }
        public static string Decrypt(string password)
        {
            var sb = new StringBuilder();
            foreach (char c in password)
            {
                // 1. بندور على مكان الحرف في لستة التشفير
                var cIndex = _altchar.IndexOf(c);

                // 2. هنا بقى اللعبة: لو لقينا الحرف (يعني الـ index مش -1)
                if (cIndex != -1)
                {
                    sb.Append(_allChar[cIndex]);
                }
                else
                {
                    // 3. لو ملحقناش الحرف (زي مسافة أو رمز) نزله زي ما هو عشان البرنامج ميضربش
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

    }
}
