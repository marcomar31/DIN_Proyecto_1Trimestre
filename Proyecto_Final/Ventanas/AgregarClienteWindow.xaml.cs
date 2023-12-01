﻿using Proyecto_Final.Enumerados;
using Proyecto_Final.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Proyecto_Final
{
    /// <summary>
    /// Lógica de interacción para AgregarCLienteWindow.xaml
    /// </summary>
    public partial class AgregarClienteWindow : Window
    {
        private readonly DNIUtil DNIUtil;
        public Cliente NuevoCliente { get; private set; }

        public AgregarClienteWindow()
        {
            InitializeComponent();
            DNIUtil = new DNIUtil();
        }

        private bool camposRellenos()
        {
            if (string.IsNullOrWhiteSpace(tbDni.Text) ||
                string.IsNullOrWhiteSpace(tbNombre.Text) ||
                string.IsNullOrWhiteSpace(tbApellido1.Text) ||
                string.IsNullOrWhiteSpace(tbApellido2.Text) || 
                string.IsNullOrWhiteSpace(tbEmail.Text)) 
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            if (camposRellenos())
            {
                if (DNIUtil.DNICorrecto(tbDni.Text))
                {
                    if (tbEmail.Text.Contains("@"))
                    {
                        NuevoCliente = new Cliente(
                            tbDni.Text,
                            tbNombre.Text,
                            tbApellido1.Text,
                            tbApellido2.Text,
                            tbEmail.Text,
                            checkbxDadoAlta.IsChecked ?? false
                        );
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("El campo \"Email\" debe contener el caracter \"@\"", "Warning");

                    }
                }
            }
            else
            {
                MessageBox.Show("Para añadir el cliente deberá rellenar todos los campos", "Warning");
                return;
            }
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }

}
