using System;
using System.Collections.Generic;
using System.Text;

namespace YektamakDesktop
{
    internal static class IbanWorks
    {
        /// <summary>
        /// iban doğru sayıda rakamdan oluşuyorsa formatlı şekilde döner. Uymuyorsa boş string döner.
        /// </summary>
        /// <param name="iban"></param>
        /// <param name="prefix"></param>
        /// <returns></returns>
        internal static string GetFormattedIbanWithCheck(string iban, IbanPrefix prefix)
        {
            if (IbanCheck(iban, prefix) == 0)
            {
                switch (prefix)
                {
                    case IbanPrefix.TR: //2+4+4+4+4+4+2 formatında boşluklu olarak dön
                        string cleanIban = iban.Replace(" ", "").Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        string result = cleanIban.Substring(0, 2) + " " + cleanIban.Substring(2, 4) + " " + cleanIban.Substring(6, 4) + " " +
                            cleanIban.Substring(10, 4) + " " + cleanIban.Substring(14, 4) + " " + cleanIban.Substring(18, 4) + " " +
                            cleanIban.Substring(22, 2);
                        return result;
                    default:
                        return "";
                }
            }
            else
                return "";
        }
        /// <summary>
        /// Nümerik olmayan her şeyi siler ve nümerik olanları sıralı olarak verir. Karakter sayısı aşılırsa aşan kısmı siler.
        /// </summary>
        /// <param name="iban"></param>
        /// <param name="prefix"></param>
        /// <returns></returns>
        internal static string GetFormattedIbanWithoutCheck(string iban, IbanPrefix prefix)
        {
            switch (prefix)
            {
                case IbanPrefix.TR: //2+4+4+4+4+4+2 formatında boşluklu olarak dön
                    string cleanIban = CleanNonNumeric(iban);
                    string result = "";
                    for (int i = 0; i < cleanIban.Length && i < 24; i++)
                    {
                        if (i == 2 || i == 6 || i == 10 || i == 14 || i == 18 || i == 22)
                        {
                            result += " ";
                        }
                        result += cleanIban[i];
                    }
                    return result;
                default:
                    return iban;
            }
        }

        /// <summary>
        /// iban formatında hata varsa hata kodunu döner. Hata yoksa 0 döner.
        /// </summary>
        /// <param name="iban"></param>
        /// <param name="prefix"></param>
        /// <returns></returns>
        internal static int IbanCheck(string iban, IbanPrefix prefix)
        {
            switch (prefix)
            {
                case IbanPrefix.TR:
                    string cleanIban = iban.Replace(" ", "").Replace("\r", "").Replace("\n", "").Replace("\t", "");
                    //Nümerik olmayan ifade var mı kontrol et
                    if (!IsOnlyNumeric(cleanIban))
                    {
                        return 1;
                    }
                    //Karakter sayısını kontrol et. TR için ön ek hariç 24 hane
                    if (cleanIban.Length != 24)
                    {
                        return 2;
                    }
                    return 0;
                default:
                    return 0;
            }
        }
        internal static bool IsOnlyNumeric(string str)
        {
            foreach (char c in str)
            {
                if (!char.IsDigit(c))
                {
                    //Non-numeric karakter
                    return false;
                }
            }
            return true;
        }
        internal static string CleanNonNumeric(string input)
        {
            string temp = input.Replace(" ", "").Replace("\r", "").Replace("\n", "").Replace("\t", "");
            string output = "";
            foreach (char c in temp)
            {
                if (char.IsDigit(c))
                {
                    output += c;//Sadece sayısal değerler kalıyor
                }
            }
            return output;
        }
        internal static string CleanWhiteSpaces(string input)
        {
            string temp = input.Replace(" ", "").Replace("\r", "").Replace("\n", "").Replace("\t", "");
            return temp;
        }
    }
}
