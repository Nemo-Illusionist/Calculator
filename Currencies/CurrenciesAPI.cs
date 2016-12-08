using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace Currencies
{
    public struct Cur
    {
        public string CurName;
        public double Count;

        public static Cur operator +(Cur a1, Cur a2)
        {
            return Oper(a1, a2, (x, y) => x + y, (x, y, hx, hy) => x * hx + y * hy);
        }
        public static Cur operator -(Cur a1, Cur a2)
        {
            return Oper(a1, a2, (x, y) => x - y, (x, y, hx, hy) => x * hx - y * hy);
        }
        public static Cur operator *(Cur a1, Cur a2)
        {
            return Oper(a1, a2, (x, y) => x * y, (x, y, hx, hy) => x * hx * y * hy);
        }
        public static Cur operator /(Cur a1, Cur a2)
        {
            return Oper(a1, a2, (x, y) => x / y, (x, y, hx, hy) => x * hx / y * hy);
        }
        private static Cur Oper(Cur a1, Cur a2, Func<double, double, double> f1,
            Func<double, double, double, double, double> f2)
        {
            if (a1.CurName == a2.CurName || a1.CurName == "NNN" || a2.CurName == "NNN")
            {
                return new Cur { Count = f1(a1.Count, a2.Count), CurName = a1.CurName == "NNN" ? a1.CurName : a2.CurName };
            }
            else
            {
                return new Cur
                {
                    CurName = "USD",
                    Count =
                        f2(a1.Count, CurrenciesAPI.Coefficient(a1.CurName), a2.Count,
                            CurrenciesAPI.Coefficient(a2.CurName))
                };
            }

        }

        public Cur(string str)
        {
            CurName = str.Substring(str.Length - 4, 3);
            Count = Double.Parse(str.Remove(str.Length - 4, 3));
        }
        public Cur(double d)
        {
            CurName = "NNN";
            Count = d;
        }
        public string ToString()
        {
            return Count + CurName == "NNN" ? "" : CurName.ToUpper();
        }
        public void Convert(string newCur)
        {
            
        }
    }

    public class CurrenciesAPI
    {
        public static DateTime SelectedDate;
        public static double RupValue;
        public static double Coefficient(string key)
        {
            key = key.ToUpper();
            return key == "RUP"
                ? RupValue
                : JObject.Parse(File.ReadAllText(Environment.CurrentDirectory + "\\CurrenciesHistory\\" +
                        SelectedDate.ToString("yyyy-MM-dd") + ".json"))["rates"][key].Value<double>();
        }
        public static string DownloadJson(DateTime date)
        {
            string histdate = date.ToString("yyyy-MM-dd");
            string apikey = "d1d5d3d9d88849e9b6de14852bd2e262";
            string json;
            json = new System.Net.WebClient().DownloadString(String.Format(
                "https://openexchangerates.org/api/historical/{0}.json?app_id={1}", histdate, apikey));
            File.WriteAllText(Environment.CurrentDirectory + "\\CurrenciesHistory\\" + histdate + ".json", json);
            return json;

        }
    }
}
