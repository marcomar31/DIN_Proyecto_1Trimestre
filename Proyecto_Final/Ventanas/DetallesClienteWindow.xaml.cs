using Proyecto_Final.Modelo;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Proyecto_Final
{
    public partial class DetallesClienteWindow : Window
    {
        public Cliente Cliente { get; private set; }
        public ObservableCollection<Viaje> ListaViajes { get; set; }
        private HashSet<Viaje> ConjuntoViajes;

        public DetallesClienteWindow(Cliente clienteSeleccionado)
        {
            InitializeComponent();
            Cliente = clienteSeleccionado;
            LoadCliente();

            ListaViajes = new ObservableCollection<Viaje>(ObtenerListaViajes());
            ListViewViajes.ItemsSource = ListaViajes;

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
                Viaje ViajeSeleccionado = ListViewViajes.SelectedItem as Viaje;
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
