using Proyecto_Final.Enumerados;
using Proyecto_Final.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Proyecto_Final
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DNIUtil dniUtil;

        public MainWindow()
        {
            InitializeComponent();
            dniUtil = new DNIUtil();
        }

        private void btnAcceder_Click(object sender, RoutedEventArgs e)
        {
            if (tbDni.Text.Length > 0 && passwdboxContrasenia.Password.Length > 0)
            {
                String dniConLetra = tbDni.Text;
                if (dniUtil.dniFormatoCorrecto(dniConLetra))
                {
                    char letraDni = dniUtil.extraeLetraDni(dniConLetra);
                    String dniSinLetra = dniUtil.getDniSinLetra(dniConLetra);
                    if (dniUtil.letraDniCorrecta(dniConLetra))
                    {
                        iniciaSesion();
                    }
                    else
                    {
                        MessageBox.Show("Asegúrese de que el DNI \"" + dniSinLetra + "\" y la letra \"" + letraDni + "\" son correspondientes", "Valores introducidos no válidos");
                    }
                } else
                {
                    MessageBox.Show("El campo \"DNI\" debe tener el formato 12345678A", "Valores introducidos no válidos");
                }
            } else
            {
                if (tbDni.Text.Length <= 0 && passwdboxContrasenia.Password.Length <= 0)
                {
                    MessageBox.Show("Los campos \"DNI\" y \"Contraseña\" no puede estar en blanco", "Valores introducidos no válidos");
                } else
                {
                    if (tbDni.Text.Length <= 0)
                    {
                        MessageBox.Show("El campo \"DNI\" no puede estar en blanco", "Valores introducidos no válidos");
                    }
                    else 
                    {
                        MessageBox.Show("El campo \"Contraseña\" no puede estar en blanco", "Valores introducidos no válidos");
                    }
                }
            }
        }

        private void iniciaSesion()
        {
            if (dniUtil.dniFormatoCorrecto(tbDni.Text))
            {
                if (passwdboxContrasenia.Password.Equals("1234"))
                {
                    GestionClientes subWindow = new GestionClientes();
                    subWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("La contraseña es incorrecta. Inténtelo de nuevo", "Credenciales incorrectas");
                }
            }
            else
            {
                MessageBox.Show("El campo \"DNI\" debe tener el formato 12345678A", "Credenciales incorrectas");
            }
        }

    }
}