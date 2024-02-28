using Proyecto_Final.Modelo;
using System.Windows;

namespace Proyecto_Final.Ventanas
{
    /// <summary>
    /// Lógica de interacción para PagoViajeWindow.xaml
    /// </summary>
    public partial class PagoViajeWindow : Window
    {
        public Viaje Viaje { get; private set; }
        public bool PagoExitoso { get; set; }

        public PagoViajeWindow(Viaje NuevoViaje)
        {
            InitializeComponent();

            Viaje = NuevoViaje;
            LoadViaje();
        }

        private void LoadViaje()
        {
            LabelDestinoViaje.Content = Viaje.Destino;
            LabelOrigenViaje.Content = Viaje.Origen;
            DatePickerIda.SelectedDate = Viaje.FechaIda;
            DatePickerVuelta.SelectedDate = Viaje.FechaVuelta;
            LabelTipoHotel.Content = Viaje.TipoHotel;
            LabelTipoTransporte.Content = Viaje.TipoTransporte;

            // Calcular el precio del viaje
            int precioViaje = Viaje.PrecioViaje;
            // Mostrar el precio en el Label
            LabelPrecio.Content = precioViaje.ToString() + "€";
        }

        private void BtnAceptar_Click(object sender, RoutedEventArgs e)
        {
            if (RadioButtonBizum.IsChecked == true)
            {
                MessageBox.Show($"Ha seleccionado el método de pago Bizum, el precio es de {Viaje.PrecioViaje}€. Deberá de realizarse el Bizum al número +34 546 328 937", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                PagoExitoso = true;
            }
            else if (RadioButtonTransferencia.IsChecked == true)
            {
                MessageBox.Show($"Ha seleccionado el método de pago Transferencia, el precio es de {Viaje.PrecioViaje}€. Deberá de realizarse la transefernacia a la cuenta " +
                    $"con IBAN ES21 0181 0089 52 8976543810", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                PagoExitoso = true;
            }
            else if (RadioButtonTarjeta.IsChecked == true)
            {
                MessageBox.Show($"Ha seleccionado el método de pago Tarjeta, el precio es de {Viaje.PrecioViaje}€. El datáfono está listo para cobrar.", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                PagoExitoso = true;
            }
            else if (RadioButtonPlazos.IsChecked == true)
            {
                MessageBox.Show($"Ha seleccionado el método de pago A Plazos, el precio es de {Viaje.PrecioViaje}€. " +
                    $"Deberá pagarse {Viaje.PrecioViaje/12}€ mensuales durante 12 meses.", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                PagoExitoso = true;
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un método de pago.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                PagoExitoso = false;
            }

            if (PagoExitoso == true)
            {
                Close();
            }
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Está seguro de que desea cancelar el pago?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                Close();
            }
        }
    }
}
