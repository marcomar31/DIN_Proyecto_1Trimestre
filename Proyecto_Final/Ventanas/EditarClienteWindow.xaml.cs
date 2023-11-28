using System.Windows;

namespace Proyecto_Final
{
    public partial class EditarClienteWindow : Window
    {
        // Propiedad pública para almacenar el cliente
        public Cliente Cliente { get; private set; }

        public EditarClienteWindow(Cliente clienteSeleccionado)
        {
            InitializeComponent();
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

        private void BtnAceptar_Click(object sender, RoutedEventArgs e)
        {
            Cliente.Dni = tbDni.Text;
            Cliente.Nombre = tbNombre.Text;
            Cliente.Apellido1 = tbApellido1.Text;
            Cliente.Apellido2 = tbApellido2.Text;
            Cliente.Email = tbEmail.Text;
            Cliente.DadoAlta = checkbxDadoAlta.IsChecked ?? false;

            Close();
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
