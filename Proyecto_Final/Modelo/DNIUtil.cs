using System;
using System.Text.RegularExpressions;
using System.Windows;
using Proyecto_Final.Enumerados;

namespace Proyecto_Final.Modelo
{
    public class DNIUtil
    {
        LetraDNI[] letrasDni = (LetraDNI[])Enum.GetValues(typeof(LetraDNI));

        public String getDniSinLetra(String dniConLetra)
        {
            return dniConLetra.Substring(0, 8);
        }

        public char extraeLetraDni(String dniConLetra)
        {
            return Convert.ToChar(dniConLetra.Substring(8));
        }

        public char calculaLetraDni(String dniSinLetra)
        {
            if (int.TryParse(dniSinLetra, out int numDni))
            {
                Console.WriteLine("El número convertido es: " + numDni);

                int posicionLetraDniEnum = numDni % 23;

                LetraDNI letraDni = (LetraDNI)posicionLetraDniEnum;
                String stringLetra = letraDni.ToString();

                return stringLetra[0];
            }
            else
            {
                Console.WriteLine("La conversión no fue exitosa.");
                return Convert.ToChar("-");
            }
        }

        public bool dniFormatoCorrecto(String dniConLetra)
        {
            String pattern = @"^\d{8}[a-zA-Z]$";

            if (Regex.IsMatch(dniConLetra, pattern))
            {
                return true;
            }

            return false;
        }
        
        public bool letraDniCorrecta(string dniConLetra)
        {
            char letra = dniConLetra.ToUpper()[8];

            char letraEsperada = calculaLetraDni(getDniSinLetra(dniConLetra));

            return letra == letraEsperada;
        }

        public bool DNICorrecto(String dniConLetra)
        {
            if (dniConLetra.Length == 9)
            {
                if (dniFormatoCorrecto(dniConLetra))
                {
                    char letraDni = extraeLetraDni(dniConLetra);
                    String dniSinLetra = getDniSinLetra(dniConLetra);
                    if (letraDniCorrecta(dniConLetra))
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Asegúrese de que el DNI/NIF \"" + dniSinLetra + "\" y la letra \"" + letraDni + "\" son correspondientes", "Valores introducidos no válidos");
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("El campo \"DNI/NIF\" debe tener el formato 12345678A", "Valores introducidos no válidos");
                    return false;
                }
            } else
            {
                MessageBox.Show("El campo \"DNI/NIF\" debe tener una longitud de 9 caracteres", "Valores introducidos no válidos");
                return false;
            }
        }
    }
}
