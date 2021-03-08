using Microsoft.Speech.Recognition;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Amanda
{
    public partial class Form1 : Form
    {
        private SpeechRecognitionEngine engine;
        private CultureInfo ci;
        private bool EstaOuvindo = true;
        public static string NOME_ASSISTENTE = "Amanda";
        private string city;

        public Form1()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            try
            {
                ci = new CultureInfo("pt_BR");
                engine = new SpeechRecognitionEngine(ci);
                city = Localização.GetCityName(Executer.GetIp()).ToLower();
                SpeechRec();
                SaidaSom.Speak("Sistema Carregando");
                SaidaSom.Speak("Sistema Carregado");
                SaidaSom.Speak("Olá, Me chamo Amanda. Como posso te ajudar");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro em Init()");
            }
        }

        private void setText(string text)
        {
            this.labelText.Text = text;
        }
        private void setColor(string cor)
        {
            switch (cor)
            {
                case "green":
                    this.labelStatus.BackColor = Color.Green;
                    break;
                case "red":
                    this.labelStatus.BackColor = Color.Red;
                    break;
                case "orange":
                    this.labelStatus.BackColor = Color.Orange;
                    break;
                default:
                    this.labelStatus.BackColor = Color.Black;
                    break;
            }
        }

        private List<Grammar> Load_Grammar()
        {
            List<Grammar> GramaticasParaFala = new List<Grammar>();

            #region Choices
            // Sistema
            Choices comandosDoSistema = new Choices();
            comandosDoSistema.Add(Gramaticas.QueHorasSao.ToArray());
            comandosDoSistema.Add(Gramaticas.Quediae.ToArray());
            comandosDoSistema.Add(Gramaticas.PareDeOuvir.ToArray());
            comandosDoSistema.Add(Gramaticas.VolteAOuvir.ToArray());
            comandosDoSistema.Add(Gramaticas.Oi.ToArray());
            comandosDoSistema.Add(Gramaticas.TudoBem.ToArray());
            comandosDoSistema.Add(Gramaticas.BomDia.ToArray());
            comandosDoSistema.Add(Gramaticas.BoaTarde.ToArray());
            comandosDoSistema.Add(Gramaticas.BoaNoite.ToArray());
            comandosDoSistema.Add(Gramaticas.despedida.ToArray());
            comandosDoSistema.Add(Gramaticas.nome.ToArray());
            comandosDoSistema.Add(Gramaticas.prazer.ToArray());
            comandosDoSistema.Add(Gramaticas.QualATemperatura.ToArray());
            comandosDoSistema.Add(Gramaticas.InfoCity.ToArray());
            comandosDoSistema.Add(Gramaticas.AllInfos.ToArray());

            // Calculos
            Choices QuantoE = new Choices();
            QuantoE.Add("Quanto é");

            Choices Nvalues = new Choices();
            Nvalues.Add(Gramaticas.Numeros.ToArray());

            Choices Operadores = new Choices();
            Operadores.Add(Gramaticas.Operadores.ToArray());
            


            #endregion
            #region GrammarBuilder
            GrammarBuilder comandosDoSistema_gb = new GrammarBuilder();
            comandosDoSistema_gb.Append(comandosDoSistema);

            GrammarBuilder calculus = new GrammarBuilder();
            calculus.Append(QuantoE);
            calculus.Append(Nvalues);
            calculus.Append(Operadores);
            calculus.Append(Nvalues);

            #endregion
            #region Grammar
            
            
            Grammar gramaticaSistema = new Grammar(comandosDoSistema);
            gramaticaSistema.Name = "System";

            Grammar gramaticaCalculos = new Grammar(calculus);
            gramaticaCalculos.Name = "calc";

            #endregion 

            GramaticasParaFala.Add(gramaticaSistema);
            GramaticasParaFala.Add(gramaticaCalculos);

            return GramaticasParaFala;
        }

        private void SpeechRec()
        {
            try
            {
                List<Grammar> g = Load_Grammar();

                #region SpeechRecognition (Eventos)
                engine.SetInputToDefaultAudioDevice();

                foreach (Grammar gr in g)
                {
                    engine.LoadGrammar(gr);
                }

                engine.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(Rec);
                engine.AudioLevelUpdated += new EventHandler<AudioLevelUpdatedEventArgs>(AudioLevel);
                engine.SpeechRecognitionRejected += new EventHandler<SpeechRecognitionRejectedEventArgs>(Rejected);

                #endregion

                engine.RecognizeAsync(RecognizeMode.Multiple); // Inicia o reconhecimento


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro em SpeechRec()");
            }
        }

      
        #region Eventos do reconhecimento
        private void Rec(object s, SpeechRecognizedEventArgs e) // Aqui entra se for reconhecido
        {
            string fala = e.Result.Text;

            if (EstaOuvindo)
            {
                setColor("green");

                switch (e.Result.Grammar.Name)
                {
                    case "System":
                        //Tudo aqui dentro corresponde a gramatica do sistema

                        if (Gramaticas.QueHorasSao.Any(f => f == fala))
                        {
                            Executer.GetHoras();
                        }
                        else if (Gramaticas.Quediae.Any(f => f == fala))
                        {
                            Executer.GetData();
                        }
                        else if (Gramaticas.PareDeOuvir.Any(f => f == fala))
                        {
                            EstaOuvindo = false;
                            setColor("orange");
                            Executer.Modosilencioso();
                        }
                        else if (Gramaticas.Oi.Any(f => f == fala))
                        {
                            Executer.Oi();
                        }
                        else if (Gramaticas.TudoBem.Any(f => f == fala))
                        {
                            Executer.Tudobem();
                        }
                        else if (Gramaticas.BomDia.Any(f => f == fala))
                        {
                            Executer.bomdia();
                        }
                        else if (Gramaticas.BoaTarde.Any(f => f == fala))
                        {
                            Executer.boatarde();
                        }
                        else if (Gramaticas.BoaNoite.Any(f => f == fala))
                        {
                            Executer.boanoite();
                        }
                        else if (Gramaticas.despedida.Any(f => f == fala))
                        {
                            Executer.despedida();
                        }
                        else if (Gramaticas.nome.Any(f => f == fala))
                        {
                            Executer.nome();
                        }
                        else if (Gramaticas.prazer.Any(f => f == fala))
                        {
                            Executer.prazer();
                        }
                        else if (Gramaticas.QualATemperatura.Any(f => f == fala))
                        {
                            Executer.GetTemperatura(city);
                        }
                        else if (Gramaticas.InfoCity.Any(f => f == fala))
                        {
                            Executer.GetMainInfos(city);
                        }
                        else if (Gramaticas.AllInfos.Any(f => f == fala))
                        {
                            Executer.GetAllMainInfos(city);
                        }
                        break;
                    case "calc":
                        SaidaSom.Speak(Calculadora.Calcule(fala));
                        break;
                }
            }
            else
            {
                if (Gramaticas.VolteAOuvir.Any(f => f == fala))
                {
                    EstaOuvindo = true;
                    setColor("green");
                    Executer.Voltando();
                }
            }

        }
        private void AudioLevel(object s, AudioLevelUpdatedEventArgs e)
        {
            if (e.AudioLevel > BarraDeAudio.Maximum)
            {
                BarraDeAudio.Value = BarraDeAudio.Maximum;
            }
            else if (e.AudioLevel < BarraDeAudio.Minimum)
            {
                BarraDeAudio.Value = BarraDeAudio.Minimum;
            }
            else
            {
                BarraDeAudio.Value = e.AudioLevel;
            }

        }
        private void Rejected(object s, SpeechRecognitionRejectedEventArgs e)  // Aqui fica o que ela não entender
        {
            setColor("red");
        }
        #endregion


    }
}
