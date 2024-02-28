using Proyecto_Final.Modelo;
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

            componenteCliente.AceptarClick += OnAceptarClicked;
            componenteCliente.CancelarClick += OnCancelarClicked;
        }

        private void LoadCliente()
        {
            componenteCliente.tbDni.Text = Cliente.Dni;
            componenteCliente.tbNombre.Text = Cliente.Nombre;
            componenteCliente.tbApellido1.Text = Cliente.Apellido1;
            componenteCliente.tbApellido2.Text = Cliente.Apellido2;
            componenteCliente.tbEmail.Text = Cliente.Email;
            componenteCliente.checkbxDadoAlta.IsChecked = Cliente.DadoAlta;
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
                        Cliente.Dni = componenteCliente.tbDni.Text;
                        Cliente.Nombre = componenteCliente.tbNombre.Text;
                        Cliente.Apellido1 = componenteCliente.tbApellido1.Text;
                        Cliente.Apellido2 = componenteCliente.tbApellido2.Text;
                        Cliente.Email = componenteCliente.tbEmail.Text;
                        Cliente.DadoAlta = componenteCliente.checkbxDadoAlta.IsChecked ?? false;
                        Cliente.DadoAltaString = Cliente.SetDadoAltaString();

                        MessageBox.Show("Se ha editado el cliente exitosamente", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                        Close();
                    } else
                    {
                        MessageBox.Show("El campo \"Email\" debe contener el caracter \"@\"", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("Para guardar los cambios del cliente deberá rellenar todos los campos", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
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
