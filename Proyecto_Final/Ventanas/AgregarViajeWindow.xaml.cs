﻿using Proyecto_Final.Enumerados;
using Proyecto_Final.Modelo;
using System;
using System.Windows;

namespace Proyecto_Final
{
    /// <summary>
    /// Lógica de interacción para AgregarCLienteWindow.xaml
    /// </summary>
    public partial class AgregarViajeWindow : Window
    {
        public Viaje NuevoViaje { get; private set; }

        public AgregarViajeWindow()
        {
            InitializeComponent();
            DatePickerIda.SelectedDate = DateTime.Now;
            DatePickerVuelta.SelectedDate = DateTime.Now.AddDays(7);
            CargarCBoxes();
        }

        private void CargarCBoxes()
        {
            CargarCBoxTipoHotel();
            CargarCBoxOrigen();
            CargarCBoxDestino();
            CargarCBoxTipoTransporte();
        }

        private void CargarCBoxTipoTransporte()
        {
            ComboBoxTipoTransporte.ItemsSource = Enum.GetValues(typeof(Enumerados.TipoTransporte));
            ComboBoxTipoTransporte.SelectedIndex = 0;
        }

        private void CargarCBoxTipoHotel()
        {
            ComboBoxTipoHotel.ItemsSource = Enum.GetValues(typeof(Enumerados.TipoHotel));
            ComboBoxTipoHotel.SelectedIndex = 0;
        }

        private void CargarCBoxOrigen()
        {
            ComboBoxOrigen.ItemsSource = Enum.GetValues(typeof(Enumerados.Ciudades));
            ComboBoxOrigen.SelectedIndex = 0;
        }

        private void CargarCBoxDestino()
        {
            ComboBoxDestino.ItemsSource = Enum.GetValues(typeof(Enumerados.Ciudades));
            ComboBoxDestino.SelectedIndex = 0;
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            if (camposRellenos())
            {
                if (ComboBoxOrigen.SelectedItem is Ciudades origen && ComboBoxDestino.SelectedItem is Ciudades destino)
                {
                    DateTime fechaActual = DateTime.Now;

                    if (DatePickerVuelta.SelectedDate >= fechaActual && DatePickerIda.SelectedDate >= fechaActual)
                    {
                        if (DatePickerVuelta.SelectedDate > DatePickerIda.SelectedDate)
                        {
                            NuevoViaje = new Viaje(
                                origen,
                                destino,
                                DatePickerIda.SelectedDate ?? fechaActual,
                                DatePickerVuelta.SelectedDate ?? fechaActual,
                                (Enumerados.TipoHotel)ComboBoxTipoHotel.SelectedItem,
                                (Enumerados.TipoTransporte)ComboBoxTipoTransporte.SelectedItem,
                                Enumerados.EstadoViaje.Abierto
                            );
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("La fecha de vuelta no puede ser anterior a la fecha de ida.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Las fechas no pueden ser anteriores al día actual.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione valores válidos para Origen y Destino", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Para añadir el viaje debe rellenar todos los campos", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private bool camposRellenos()
        {
            if (ComboBoxOrigen.SelectedItem == null || ComboBoxDestino.SelectedItem == null ||
                DatePickerIda.SelectedDate == null || DatePickerVuelta.SelectedDate == null ||
                ComboBoxTipoHotel.SelectedItem == null || ComboBoxTipoTransporte.SelectedItem == null)
            {
                return false;
            } else
            {
                return true;
            }
        }


        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("¿Está seguro de que desea cancelar la operación?", "Aviso", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Close();
            }
        }
    }
}
