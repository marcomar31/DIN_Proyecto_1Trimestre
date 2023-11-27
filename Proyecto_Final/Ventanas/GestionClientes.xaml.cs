using Proyecto_Final.Enumerados;
using Proyecto_Final.Modelo;
using System;
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
            foreach (Cliente Cliente in ListaClientes)
            {
                Cliente.Viajes.Add(new Viaje(Ciudades.Madrid, Ciudades.Roma, DateTime.Now.AddDays(4), DateTime.Now.AddDays(11), TipoHotel.Premium, TipoTransporte.Avion, EstadoViaje.Abierto));
            }
        }

        private List<Cliente> ObtenerListaClientes()
        {
            return new List<Cliente>
            {
                new Cliente("00000000A", "Juan", "Pérez", "Cuadrado", "email@mail.com", true),
                new Cliente("00000001B", "María", "Gómez", "Núñez", "email2@mail.com", true),
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
            Cliente clienteSeleccionado = (Cliente)lvClientes.SelectedItem;
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
            Cliente clienteSeleccionado = (Cliente)lvClientes.SelectedItem;

            if (clienteSeleccionado != null)
            {
                EditarClienteWindow ventanaEditarCliente = new EditarClienteWindow(clienteSeleccionado);
                ventanaEditarCliente.ShowDialog();
            } else
            {
                MessageBox.Show("Para editar un cliente, deberá seleccionar el cliente en la tabla", "Warning");
            }
        }

        private void BtnDetallesCliente_Click(object sender, RoutedEventArgs e)
        {
            Cliente clienteSeleccionado = (Cliente)lvClientes.SelectedItem;

            if (clienteSeleccionado != null)
            {
                ViajesClienteWindow ventanaEditarCliente = new ViajesClienteWindow(clienteSeleccionado);
                ventanaEditarCliente.ShowDialog();
            } else
            {
                MessageBox.Show("Para ver los viajes de un cliente, deberá seleccionar el cliente en la tabla", "Warning");
            }
        }
    }
}
