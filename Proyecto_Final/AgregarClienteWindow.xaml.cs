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
        public Cliente nevoCliente { get; private set; }

        public AgregarClienteWindow()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            /*
            nevoCliente = new Cliente(
                txtNombre.Text,
                txtApellido1.Text,
                txtApellido2.Text,
                cbEstadoViaje,
                // Agrega más propiedades según tus necesidades
            );*/
            Close();
        }
    }

}
