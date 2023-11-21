using Proyecto_Final.Enumerados;
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
    public partial class AgregarViajeWindow : Window
    {
        public Viaje NuevoViaje { get; private set; }

        public AgregarViajeWindow()
        {
            InitializeComponent();
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
                    NuevoViaje = new Viaje(
                        origen,
                        destino,
                        DatePickerIda.SelectedDate ?? DateTime.Now,
                        DatePickerVuelta.SelectedDate ?? DateTime.Now,
                        (Enumerados.TipoHotel)ComboBoxTipoHotel.SelectedItem,
                        (Enumerados.TipoTransporte)ComboBoxTipoTransporte.SelectedItem,
                        Enumerados.EstadoViaje.Abierto
                    );
                    Close();
                }
                else
                {
                    MessageBox.Show("Seleccione valores válidos para Origen y Destino", "Warning");
                }
            }
            else
            {
                MessageBox.Show("Para añadir el viaje debe rellenar todos los campos", "Warning");
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
            Close();
        }
    }
}
