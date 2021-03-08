using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amanda
{
    class Executer
    {
        //Metodos basicos de fala
        #region Sistema
        public static void GetHoras()
        {
            SaidaSom.Speak(DateTime.Now.ToShortTimeString());
        }
        public static void GetData()
        {
            SaidaSom.Speak(DateTime.Now.ToShortDateString());
        }
        public static void Modosilencioso()
        {
            SaidaSom.Speak("Modo silencioso ativado");
        }
        public static void Voltando()
        {
            SaidaSom.Speak("Olá, como posso te ajudar");
        }
        #endregion
        #region Saudações
        public static void Oi()
        {
            SaidaSom.Speak("Olá, Tudo bem?");
        }
        public static void Tudobem()
        {
            SaidaSom.Speak("Eu estou ótima");
        }
        public static void bomdia()
        {
            SaidaSom.Speak("Bom dia", "belo dia", "Lindo dia");
        }

        public static void boatarde()
        {
            SaidaSom.Speak("Boa tarde", "bela tarde");
        }
        public static void boanoite()
        {
            SaidaSom.Speak("Boa noite", "Otima noite");
        }
        public static void despedida()
        {
            SaidaSom.Speak("Tchauzinho");
        }
        public static void prazer()
        {
            SaidaSom.Speak("O prazer é todo meu", "Igualmente");
        }
        public static void nome()
        {
            SaidaSom.Speak("Oi", "Olá");
        }
        #endregion
        #region Clima e tempo
        public static void GetTemperatura(string city)
        {
            List<string> infos = ClimaTempo.GetInfoCity(city);

            if (infos[0] == "Erro")
                return;

            SaidaSom.Speak("Hoje a temperatura é: " + infos[5] + "graus");
        }
        public static void GetMainInfos(string city)
        {
            List<string> infos = ClimaTempo.GetInfoCity(city);

            if (infos[0] == "Erro")
                return;

            string msg = String.Format(
                "Temperatura: {0} graus, " +
                "Sensação Térmica: {1} graus, " +
                "Temperaturas previstas: " +
                "Mínima de {2} graus, " +
                "Máxima de {3} graus, " +
                "Humidade do Ar: {4}%",
                infos[5],
                infos[8],
                infos[6],
                infos[7],
                infos[10]
                );

            SaidaSom.Speak(msg);
        }
        public static void GetAllMainInfos(string city)
        {
            List<string> infos = ClimaTempo.GetInfoCity(city);

            if (infos[0] == "Erro")
                return;

            string msg = String.Format(
                "Temperatura: {0} graus, " +
                "Tempo: {1} " +
                "Com: {2} " +
                "Sensação Térmica: {3} graus, " +
                "Temperaturas previstas: " +
                "Mínima de {4} graus, " +
                "Máxima de {5} graus, " +
                "Humidade do Ar: {6}%" +
                "Velocidade do Vento de: {7} kilometros por hora, ",
                infos[5],
                infos[3],
                infos[4],
                infos[8],
                infos[6],
                infos[7],
                infos[10],
                infos[11]
                );

            SaidaSom.Speak(msg);
        }
        #endregion
        #region Localização
        public static string GetIp()
        {
            return new WebClient().DownloadString("https://api.ipify.org/");
        }
        public static string GetLocation(string ip)
        {
            return Localização.GetCityName(ip);
        }
        #endregion
    }
}