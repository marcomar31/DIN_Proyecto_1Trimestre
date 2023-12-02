using Proyecto_Final.Enumerados;
using Proyecto_Final.Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Proyecto_Final
{
    public partial class ViajesClienteWindow : Window
    {
        public Cliente Cliente { get; private set; }
        public ObservableCollection<Viaje> ListaViajes { get; set; }
        private HashSet<Viaje> ConjuntoViajes;

        public ViajesClienteWindow(Cliente clienteSeleccionado)
        {
            InitializeComponent();
            Cliente = clienteSeleccionado;
            LoadCliente();
            LoadListaViajes();
            LoadFiltros();
        }

        private void LoadFiltros()
        {
            ComboBoxEstado.ItemsSource = ObtenerOpcionesFiltro();
            ComboBoxEstado.SelectedIndex = 0;
        }

        private void LoadListaViajes()
        {
            ListaViajes = new ObservableCollection<Viaje>(ObtenerListaViajes());
            ListViewViajes.ItemsSource = ListaViajes;
        }

        private List<string> ObtenerOpcionesFiltro()
        {
            var opciones = new List<string>();
            opciones.Add("SIN FILTRO");
            opciones.AddRange(Enum.GetNames(typeof(EstadoViaje)));


            return opciones;
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

        private List<Viaje> ObtenerListaViajes()
        {
            ConjuntoViajes = Cliente.Viajes;

            List<Viaje> listaDeViajes = new List<Viaje>(ConjuntoViajes);

            return listaDeViajes;
        }

        private void ComboBoxEstado_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FiltrarViajes();
        }

        private void FiltrarViajes()
        {
            string estadoFiltro = ComboBoxEstado.SelectedItem as string;

            if (estadoFiltro == "SIN FILTRO")
            {
                // Si es "SIN FILTRO", muestra todos los viajes
                ListaViajes.Clear();
                foreach (var viaje in ConjuntoViajes)
                {
                    ListaViajes.Add(viaje);
                }
            }
            else
            {
                // Filtra por estado seleccionado
                EstadoViaje estadoSeleccionado = (EstadoViaje)Enum.Parse(typeof(EstadoViaje), estadoFiltro);
                List<Viaje> viajesFiltrados = ConjuntoViajes.Where(v => v.EstadoViaje == estadoSeleccionado).ToList();

                ListaViajes.Clear();
                foreach (var viaje in viajesFiltrados)
                {
                    ListaViajes.Add(viaje);
                }
            }
        }


        private void BtnAniadirViaje_Click(object sender, RoutedEventArgs e)
        {
            AgregarViajeWindow ventanaAgregarViaje = new AgregarViajeWindow();
            ventanaAgregarViaje.ShowDialog();

            Viaje nuevoViaje = ventanaAgregarViaje.NuevoViaje;
            if (nuevoViaje != null)
            {
                ConjuntoViajes.Add(nuevoViaje);
                ListaViajes.Add(nuevoViaje);
            }
        }
        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnEliminarViaje_Click(object sender, RoutedEventArgs e)
        {
            if (ListViewViajes.Items.Count > 0)
            {
                Viaje ViajeSeleccionado = (Viaje)ListViewViajes.SelectedItem;
                if (ViajeSeleccionado != null)
                {
                    ListaViajes.Remove(ViajeSeleccionado);
                }
                else
                {
                    MessageBox.Show("Para eliminar un viaje, deberá seleccionar el viaje en la tabla", "Warning");
                }
            } else
            {
                MessageBox.Show("Error al intentar eliminar el viaje. No hay viajes asociados a este usuario", "Error");
            }
        }
    }
}
