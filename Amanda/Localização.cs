using System;
using System.Net;
using Newtonsoft.Json;

namespace Amanda
{
    class Localização
    {
        public static string GetCityName(string ip)
        {
            string city;

            try
            {
                using(WebClient webC = new WebClient())
                {
                    string url = String.Format("http://ip-api.com/json/{0}", ip);

                    var json = webC.DownloadString(url);
                    var result = JsonConvert.DeserializeObject<LocalizaçãoApp.root>(json);

                    LocalizaçãoApp.root saída = result;
                    city = saída.city;
                }
            }
            catch (Exception)
            {
                city = "Erro";
            }

            return city;
        }
    }
}
