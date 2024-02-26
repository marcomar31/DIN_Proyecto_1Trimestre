using Proyecto_Final.Modelo;
using System.Windows;

namespace Proyecto_Final
{
    public partial class AgregarClienteWindow : Window
    {
        private readonly DNIUtil DNIUtil;
        public Cliente NuevoCliente { get; private set; }

        public AgregarClienteWindow()
        {
            InitializeComponent();
            DNIUtil = new DNIUtil();

            componenteCliente.AceptarClick += OnAceptarClicked;
            componenteCliente.CancelarClick += OnCancelarClicked;
        }

        private bool camposRellenos()
        {
            if (string.IsNullOrWhiteSpace(componenteCliente.tbDni.Text) ||
                string.IsNullOrWhiteSpace(componenteCliente.tbNombre.Text) ||
                string.IsNullOrWhiteSpace(componenteCliente.tbApellido1.Text) ||
                string.IsNullOrWhiteSpace(componenteCliente.tbApellido2.Text) ||
                string.IsNullOrWhiteSpace(componenteCliente.tbEmail.Text))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void OnAceptarClicked(object sender, RoutedEventArgs e)
        {
            if (camposRellenos())
            {
                if (DNIUtil.DNICorrecto(componenteCliente.tbDni.Text))
                {
                    if (componenteCliente.tbEmail.Text.Contains("@"))
                    {
                        NuevoCliente = new Cliente(
                            componenteCliente.tbDni.Text,
                            componenteCliente.tbNombre.Text,
                            componenteCliente.tbApellido1.Text,
                            componenteCliente.tbApellido2.Text,
                            componenteCliente.tbEmail.Text,
                            componenteCliente.checkbxDadoAlta.IsChecked ?? false
                        );
                        MessageBox.Show("Se ha creado el nuevo cliente exitosamente", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("El campo \"Email\" debe contener el caracter \"@\"", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("Para añadir el cliente deberá rellenar todos los campos", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
        }

        private void OnCancelarClicked(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("¿Está seguro de que desea cancelar la operación?", "Aviso", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Close();
            }
        }
    }
}
