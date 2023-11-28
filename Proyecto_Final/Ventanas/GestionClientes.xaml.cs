using Proyecto_Final.Enumerados;
using Proyecto_Final.Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Proyecto_Final
{
    public partial class GestionClientes : Window
    {
        public ObservableCollection<Cliente> ListaClientes { get; set; }

        public GestionClientes()
        {
            InitializeComponent();
            ListaClientes = new ObservableCollection<Cliente>(ObtenerClientes());
            lvClientes.ItemsSource = ListaClientes;
        }

        private List<Cliente> ObtenerClientes()
        {
            Cliente cliente1 = new Cliente("00000000A", "Juan", "Pérez", "Cuadrado", "email@mail.com", true);
            Cliente cliente2 = new Cliente("00000001B", "María", "Gómez", "Núñez", "email2@mail.com", true);
            Cliente cliente3 = new Cliente("00000002C", "Luis", "Martínez", "Hernández", "email3@mail.com", false);
            Cliente cliente4 = new Cliente("00000003D", "Laura", "Fernández", "García", "email4@mail.com", false);
            Cliente cliente5 = new Cliente("00000004E", "Carlos", "Gutiérrez", "Sánchez", "email5@mail.com", true);
            Cliente cliente6 = new Cliente("00000005F", "Ana", "Díaz", "López", "email6@mail.com", false);
            Cliente cliente7 = new Cliente("00000006G", "Pedro", "Ramírez", "Jiménez", "email7@mail.com", true);
            Cliente cliente8 = new Cliente("00000007H", "Elena", "Muñoz", "Rodríguez", "email8@mail.com", false);
            Cliente cliente9 = new Cliente("00000008I", "Miguel", "Serrano", "Vega", "email9@mail.com", true);
            Cliente cliente10 = new Cliente("00000009J", "Sofía", "Ortega", "Soto", "email10@mail.com", false);

            cliente1.Viajes.Add(new Viaje(Ciudades.Cracovia, Ciudades.Barcelona, DateTime.Now.AddDays(19), DateTime.Now.AddDays(25), TipoHotel.Lujoso, TipoTransporte.Combinado, EstadoViaje.Cancelado));
            cliente5.Viajes.Add(new Viaje(Ciudades.Cracovia, Ciudades.Viena, DateTime.Now.AddDays(14), DateTime.Now.AddDays(17), TipoHotel.Estandar, TipoTransporte.Avion, EstadoViaje.Cancelado));
            cliente9.Viajes.Add(new Viaje(Ciudades.Dublín, Ciudades.Zurich, DateTime.Now.AddDays(7), DateTime.Now.AddDays(25), TipoHotel.Lujoso, TipoTransporte.Tren, EstadoViaje.Cancelado));

            List<Cliente> clientes = new List<Cliente>
            {
                cliente1, cliente2, cliente3, cliente4, cliente5,
                cliente6, cliente7, cliente8, cliente9, cliente10
            };

            foreach (Cliente cliente in clientes)
            {
                cliente.Viajes.Add(new Viaje(Ciudades.Madrid, Ciudades.Roma, DateTime.Now.AddDays(4), DateTime.Now.AddDays(11), TipoHotel.Premium, TipoTransporte.Avion, EstadoViaje.Abierto));
                cliente.Viajes.Add(new Viaje(Ciudades.París, Ciudades.Atenas, DateTime.Now.AddDays(9), DateTime.Now.AddDays(15), TipoHotel.Estandar, TipoTransporte.Combinado, EstadoViaje.Cerrado));

                if (cliente.Viajes.ToList().Any(viaje => viaje.EstadoViaje == EstadoViaje.Cancelado))
                {
                    cliente.Descripcion = "Viaje cancelado";
                }
            }


            return clientes;
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
