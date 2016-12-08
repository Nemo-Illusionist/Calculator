using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace Currencies
{
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
