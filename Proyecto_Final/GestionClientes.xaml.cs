using System.Collections.Generic;
using System.Windows;
using Proyecto_Final.Modelo;

namespace Proyecto_Final
{
    /// <summary>
    /// Lógica de interacción para GestionClientes.xaml
    /// </summary>
    public partial class GestionClientes : Window
    {
        public List<Cliente> listaClientes { get; set; }

        public GestionClientes()
        {
            InitializeComponent();
            listaClientes = ObtenerListaClientes();
            lvClientes.ItemsSource = listaClientes;
        }

        private List<Cliente> ObtenerListaClientes()
        {
            return new List<Cliente>
        {
            new Cliente("Juan", "Pérez", "Cuadrado", EstadoViaje.Abierto, true),
            new Cliente("María", "Gómez", "Núñez", EstadoViaje.Cerrado, true),
        };
        }

        private void btnAniadirCliente_Click(object sender, RoutedEventArgs e)
        {
            AgregarClienteWindow ventanaAgregarCliente = new AgregarClienteWindow();
            ventanaAgregarCliente.ShowDialog();
            Cliente nuevoCliente = ventanaAgregarCliente.nevoCliente;
            if (nuevoCliente != null)
            {
                listaClientes.Add(nuevoCliente);
            }
        }
    }
}
