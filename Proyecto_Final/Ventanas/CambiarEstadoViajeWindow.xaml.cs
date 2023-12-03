using Proyecto_Final.Enumerados;
using Proyecto_Final.Modelo;
using System;
using System.Windows;

namespace Proyecto_Final.Ventanas
{
    /// <summary>
    /// Lógica de interacción para CambiarEstadoViajeWindow.xaml
    /// </summary>
    public partial class CambiarEstadoViajeWindow : Window
    {
        public EstadoViaje EstadoSeleccionado { get; private set; }
        public CambiarEstadoViajeWindow(Viaje Viaje)
        {
            InitializeComponent();
            ComboBoxEstados.ItemsSource = Enum.GetValues(typeof(EstadoViaje));
            EstadoSeleccionado = Viaje.EstadoViaje;
            ComboBoxEstados.SelectedValue = EstadoSeleccionado;
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            EstadoSeleccionado = (EstadoViaje)ComboBoxEstados.SelectedValue;
            MessageBox.Show("Se ha cambiado el estado del viaje exitosamente", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("¿Está seguro de que desea cancelar la operación?", "Aviso", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Close();
            }
        }
    }
}
