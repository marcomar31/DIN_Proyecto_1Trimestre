using Proyecto_Final.Enumerados;
using Proyecto_Final.Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Proyecto_Final
{
    public partial class GestionarClientesWindow : Window
    {
        public ObservableCollection<Cliente> ListaClientes { get; set; }

        public GestionarClientesWindow()
        {
            InitializeComponent();
            ListaClientes = new ObservableCollection<Cliente>(ObtenerClientes());
            lvClientes.ItemsSource = ListaClientes;
        }

        private List<Cliente> ObtenerClientes()
        {
            Cliente cliente1 = new Cliente("24252342S", "Juan", "Pérez", "Cuadrado", "email@mail.com", true);
            Cliente cliente2 = new Cliente("24572342Q", "María", "Gómez", "Núñez", "email2@mail.com", true);
            Cliente cliente3 = new Cliente("01236546C", "Luis", "Martínez", "Hernández", "email3@mail.com", false);
            Cliente cliente4 = new Cliente("04567645Y", "Laura", "Fernández", "García", "email4@mail.com", false);
            Cliente cliente5 = new Cliente("00043785Q", "Carlos", "Gutiérrez", "Sánchez", "email5@mail.com", true);
            Cliente cliente6 = new Cliente("03124645A", "Ana", "Díaz", "López", "email6@mail.com", false);
            Cliente cliente7 = new Cliente("45364532E", "Pedro", "Ramírez", "Jiménez", "email7@mail.com", true);
            Cliente cliente8 = new Cliente("00235456M", "Elena", "Muñoz", "Rodríguez", "email8@mail.com", false);
            Cliente cliente9 = new Cliente("02346546V", "Miguel", "Serrano", "Vega", "email9@mail.com", true);
            Cliente cliente10 = new Cliente("24675854M", "Sofía", "Ortega", "Soto", "email10@mail.com", false);

            cliente1.Viajes.Add(new Viaje(Ciudades.Cracovia, Ciudades.Barcelona, DateTime.Now.AddDays(19), DateTime.Now.AddDays(25), TipoHotel.Lujoso, TipoTransporte.Combinado, EstadoViaje.Cancelado));
            cliente4.Viajes.Add(new Viaje(Ciudades.Atenas, Ciudades.Viena, DateTime.Now.AddDays(14), DateTime.Now.AddDays(17), TipoHotel.Estandar, TipoTransporte.Avion, EstadoViaje.Cerrado));
            cliente7.Viajes.Add(new Viaje(Ciudades.Dubrovnik, Ciudades.Edimburgo, DateTime.Now, DateTime.Now.AddDays(5), TipoHotel.Estandar, TipoTransporte.Avion, EstadoViaje.Cerrado));
            cliente9.Viajes.Add(new Viaje(Ciudades.Dublín, Ciudades.Zurich, DateTime.Now.AddDays(17), DateTime.Now.AddDays(25), TipoHotel.Lujoso, TipoTransporte.Tren, EstadoViaje.Cancelado));

            List<Cliente> clientes = new List<Cliente>
            {
                cliente1, cliente2, cliente3, cliente4, cliente5,
                cliente6, cliente7, cliente8, cliente9, cliente10
            };

            foreach (Cliente cliente in clientes)
            {
                cliente.Viajes.Add(new Viaje(Ciudades.Madrid, Ciudades.Roma, DateTime.Now.AddDays(4), DateTime.Now.AddDays(11), TipoHotel.Premium, TipoTransporte.Avion, EstadoViaje.Abierto));
                cliente.Viajes.Add(new Viaje(Ciudades.París, Ciudades.Atenas, DateTime.Now.AddDays(9), DateTime.Now.AddDays(15), TipoHotel.Estandar, TipoTransporte.Combinado, EstadoViaje.Abierto));

                if (cliente.Viajes.ToList().Any(viaje => viaje.EstadoViaje == EstadoViaje.Cancelado))
                {
                    cliente.Descripcion = "Viaje cancelado";
                } else if (cliente.Viajes.ToList().Any(viaje => viaje.EstadoViaje == EstadoViaje.Cerrado))
                {
                    cliente.Descripcion = "Viaje cerrado";
                } else
                {
                    cliente.Descripcion = "Gestión pendiente";
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
                MessageBoxResult result = MessageBox.Show("¿Está seguro de que desea eliminar el cliente seleccionado?", "Aviso", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    ListaClientes.Remove(clienteSeleccionado);
                    MessageBox.Show("Se ha eliminado el cliente exitosamente", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                } else
                {
                    MessageBox.Show("Se ha cancelado la eliminación del cliente", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                }
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
                MessageBox.Show("Para editar un cliente, deberá seleccionar el cliente en la tabla", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
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
                MessageBox.Show("Para ver los viajes de un cliente, deberá seleccionar el cliente en la tabla", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BtnCerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("¿Está seguro de que desea cerrar sesión?", "Aviso", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                MainWindow subWindow = new MainWindow();
                subWindow.Show();
                this.Close();
                MessageBox.Show("Se ha cerrado la sesión exitosamente", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
