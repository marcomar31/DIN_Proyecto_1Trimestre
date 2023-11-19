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
    public partial class AgregarClienteWindow : Window
    {
        // Propiedad pública para almacenar el cliente
        public Cliente NuevoCliente { get; private set; }

        public AgregarClienteWindow()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            NuevoCliente = new Cliente(
                tbDni.Text,
                tbNombre.Text,
                tbApellido1.Text,
                tbApellido2.Text,
                tbEmail.Text,
                Enumerados.EstadoViaje.Abierto,
                checkbxDadoAlta.IsChecked ?? false
            );
            Close();
        }
    }

}
