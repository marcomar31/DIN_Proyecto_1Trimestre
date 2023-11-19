using Proyecto_Final.Enumerados;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace Proyecto_Final
{
    public partial class GestionClientes : Window
    {
        public ObservableCollection<Cliente> ListaClientes { get; set; }

        public GestionClientes()
        {
            InitializeComponent();
            ListaClientes = new ObservableCollection<Cliente>(ObtenerListaClientes());
            lvClientes.ItemsSource = ListaClientes;
        }

        private List<Cliente> ObtenerListaClientes()
        {
            return new List<Cliente>
            {
                new Cliente("00000000A", "Juan", "Pérez", "Cuadrado", "email@mail.com", EstadoViaje.Abierto, true),
                new Cliente("00000000A", "María", "Gómez", "Núñez", "email2@mail.com", EstadoViaje.Cerrado, true),
            };
        }

        private void BtnAniadirCliente_Click(object sender, RoutedEventArgs e)
        {
            AgregarClienteWindow ventanaAgregarCliente = new AgregarClienteWindow();
            ventanaAgregarCliente.ShowDialog();

            Cliente nuevoCliente = ventanaAgregarCliente.NuevoCliente;
            if (nuevoCliente != null)
            {
                ListaClientes.Add(nuevoCliente);
            }
        }

        private void BtnEliminarCliente_Click(object sender, RoutedEventArgs e)
        {
            Cliente clienteSeleccionado = lvClientes.SelectedItem as Cliente;
            if (clienteSeleccionado != null)
            {
                ListaClientes.Remove(clienteSeleccionado);
            }
        }

        private void BtnEditarCliente_Click(object sender, RoutedEventArgs e)
        {
            Cliente clienteSeleccionado = lvClientes.SelectedItem as Cliente;

            if (clienteSeleccionado != null)
            {
                EditarClienteWindow ventanaEditarCliente = new EditarClienteWindow(clienteSeleccionado);
                ventanaEditarCliente.ShowDialog();
            }
        }

        private void btnDetallesCliente_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
