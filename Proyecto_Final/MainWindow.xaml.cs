using Proyecto_Final.Modelo;
using System;
using System.Windows;

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
                        MessageBox.Show("Asegúrese de que el DNI \"" + dniSinLetra + "\" y la letra \"" + letraDni + "\" son correspondientes", "Valores introducidos no válidos", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                } else
                {
                    MessageBox.Show("El campo \"DNI\" debe tener el formato 12345678A", "Valores introducidos no válidos", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            } else
            {
                if (tbDni.Text.Length <= 0 && passwdboxContrasenia.Password.Length <= 0)
                {
                    MessageBox.Show("Los campos \"DNI\" y \"Contraseña\" no puede estar en blanco", "Valores introducidos no válidos", MessageBoxButton.OK, MessageBoxImage.Warning);
                } else
                {
                    if (tbDni.Text.Length <= 0)
                    {
                        MessageBox.Show("El campo \"DNI\" no puede estar en blanco", "Valores introducidos no válidos", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else 
                    {
                        MessageBox.Show("El campo \"Contraseña\" no puede estar en blanco", "Valores introducidos no válidos", MessageBoxButton.OK, MessageBoxImage.Warning);
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
                    GestionarClientesWindow subWindow = new GestionarClientesWindow();
                    subWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("La contraseña es incorrecta. Inténtelo de nuevo", "Error al intentar acceder", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("El campo \"DNI\" debe tener el formato 12345678A", "Credenciales incorrectas", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

    }
}