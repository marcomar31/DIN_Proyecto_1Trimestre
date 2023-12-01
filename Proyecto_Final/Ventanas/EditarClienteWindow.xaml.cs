﻿using Proyecto_Final.Modelo;
using System.Windows;

namespace Proyecto_Final
{
    public partial class EditarClienteWindow : Window
    {
        // Propiedad pública para almacenar el cliente
        private readonly DNIUtil DNIUtil;
        public Cliente Cliente { get; private set; }

        public EditarClienteWindow(Cliente clienteSeleccionado)
        {
            InitializeComponent();
            DNIUtil = new DNIUtil();
            Cliente = clienteSeleccionado;
            LoadCliente();
        }

        private void LoadCliente()
        {
            tbDni.Text = Cliente.Dni;
            tbNombre.Text = Cliente.Nombre;
            tbApellido1.Text = Cliente.Apellido1;
            tbApellido2.Text = Cliente.Apellido2;
            tbEmail.Text = Cliente.Email;
            checkbxDadoAlta.IsChecked = Cliente.DadoAlta;
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

        private void BtnAceptar_Click(object sender, RoutedEventArgs e)
        {
            if (camposRellenos())
            {
                if (DNIUtil.DNICorrecto(tbDni.Text))
                {
                    if (tbEmail.Text.Contains("@"))
                    {
                        Cliente.Dni = tbDni.Text;
                        Cliente.Nombre = tbNombre.Text;
                        Cliente.Apellido1 = tbApellido1.Text;
                        Cliente.Apellido2 = tbApellido2.Text;
                        Cliente.Email = tbEmail.Text;
                        Cliente.DadoAlta = checkbxDadoAlta.IsChecked ?? false;
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

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
