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
                new Cliente("00000000A", "Juan", "Pérez", "Cuadrado", "email@mail.com", true),
                new Cliente("00000000A", "María", "Gómez", "Núñez", "email2@mail.com", true),
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
            } else
            {
                MessageBox.Show("Para eliminar un cliente, deberá seleccionar el cliente en la tabla", "Warning");
            }
        }

        private void BtnEditarCliente_Click(object sender, RoutedEventArgs e)
        {
            Cliente clienteSeleccionado = lvClientes.SelectedItem as Cliente;

            if (clienteSeleccionado != null)
            {
                EditarClienteWindow ventanaEditarCliente = new EditarClienteWindow(clienteSeleccionado);
                ventanaEditarCliente.ShowDialog();
            } else
            {
                MessageBox.Show("Para editar un cliente, deberá seleccionar el cliente en la tabla", "Warning");
            }
        }

        private void btnDetallesCliente_Click(object sender, RoutedEventArgs e)
        {
            Cliente clienteSeleccionado = lvClientes.SelectedItem as Cliente;

            if (clienteSeleccionado != null)
            {
                DetallesClienteWindow ventanaEditarCliente = new DetallesClienteWindow(clienteSeleccionado);
                ventanaEditarCliente.ShowDialog();
            } else
            {
                MessageBox.Show("Para ver los detalles de un cliente, deberá seleccionar el cliente en la tabla", "Warning");
            }
        }
    }
}
