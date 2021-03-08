using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Amanda
{
    class ClimaTempo
    {
        private const string KEY = "f7d0f5cdd2ce4fdf681b28eaf5e1e942";
        public static List<string> GetInfoCity(string city)
        {
            List<string> infos = new List<string>();

            try
            {
                using (WebClient web = new WebClient())
                {
                    string url = String.Format("http://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}&units=metric&lang=pt", city, KEY);

                    var json = web.DownloadString(url);
                    var result = JsonConvert.DeserializeObject<ClimaTempoApp.root>(json);

                    ClimaTempoApp.root outPut = result;

                    infos.Add(outPut.name); // [0] Nome da Cidade
                    infos.Add(outPut.coord.lon.ToString()); // [1] Longitude
                    infos.Add(outPut.coord.lat.ToString()); // [2] Latitude
                    infos.Add(outPut.weather[0].main.ToString()); // [3] Situação (tipo, nublado)
                    infos.Add(outPut.weather[0].description.ToString()); // [4] Descrição (tipo, poucas nuvens)
                    infos.Add(outPut.main.temp.ToString()); // [5] Temperatura
                    infos.Add(outPut.main.temp_min.ToString()); // [6] Temperatura Mínima
                    infos.Add(outPut.main.temp_max.ToString()); // [7] Temperatura Máxima
                    infos.Add(outPut.main.feels_like.ToString()); // [8] Sensação Térmica
                    infos.Add(Math.Round((outPut.main.pressure / 1013), 2).ToString()); // [9] Pressão do Ar
                    infos.Add(outPut.main.humidity.ToString()); // [10] Humidade, porcentagem
                    infos.Add(outPut.wind.speed.ToString()); // [11] Velocidade do Vento
                    infos.Add(outPut.wind.deg.ToString()); // [12] Direção em Graus

                    return infos;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ocorreu um erro ao buscar informações sobre o tempo" +
                    "\n Verifique sua conexão com a rede. " +
                    "\n\n\n" + e.Message, "Erro ao buscar informações");

                infos.Clear();
                infos.Add("Erro");
            }
            return infos;
        }

    }
}
