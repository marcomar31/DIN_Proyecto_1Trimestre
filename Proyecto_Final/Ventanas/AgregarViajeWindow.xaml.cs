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
            CargarCBoxTipoHotel();
            CargarCBoxOrigen();
            CargarCBoxDestino();
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
            
            Close();
        }
    }
}
