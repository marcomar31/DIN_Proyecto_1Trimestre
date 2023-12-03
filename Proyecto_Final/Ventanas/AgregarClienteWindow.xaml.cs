using Proyecto_Final.Modelo;
using System.Windows;

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
                        MessageBox.Show("Se ha creado el nuevo cliente exitosamente", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                        Close();
                    } else
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
