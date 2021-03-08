using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amanda
{
    class Calculadora
    {
        public static string Calcule(string entrada)
        {
            string[] parts = entrada.Split(' ');
            double n1 = Gramaticas.DicNumeros[parts[2]];
            double n2;
            double result = 0;
            try
            {
                n2 = Gramaticas.DicNumeros[parts[4]];
            }
            catch (KeyNotFoundException)
            {
                n2 = Gramaticas.DicNumeros[parts[5]];
            }

            try
            {
                switch (parts[3])
                {
                    case "mais":
                        result = n1 + n2;
                        break;
                    case "menos":
                        result = n1 - n2;
                        break;
                    case "vezes":
                        result = n1 * n2;
                        break;
                    case "dividido":
                        result = n1 / n2;
                        break;
                    case "elevado":
                        result = Math.Pow(n1, n2);
                        break;
                    case "raiz":
                        result = Math.Pow(n2, 1 / n1);
                        break;

                }
            }
            catch (Exception)
            {
                return "Calculo inválido";
            }

            return Math.Round(result, 2).ToString();
        }
    }
}
