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

        public DetallesClienteWindow(Cliente clienteSeleccionado)
        {
            InitializeComponent();
            Cliente = clienteSeleccionado;
            LoadCliente();

            ListaViajes = new ObservableCollection<Viaje>(ObtenerListaViajes());

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
            Viaje[] arrayDeViajes = Cliente.Viajes;

            List<Viaje> listaDeViajes = new List<Viaje>(arrayDeViajes);

            return listaDeViajes;
        }

        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnAniadirViaje_Click(object sender, RoutedEventArgs e)
        {
            AgregarViajeWindow ventanaAgregarViaje = new AgregarViajeWindow();
            ventanaAgregarViaje.ShowDialog();

            Viaje nuevoViaje = ventanaAgregarViaje.NuevoViaje;
            if (nuevoViaje != null)
            {
                ListaViajes.Add(nuevoViaje);
            }
        }
    }
}
