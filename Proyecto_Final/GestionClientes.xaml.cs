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
        public List<Cliente> ListaClientes { get; set; }

        public GestionClientes()
        {
            InitializeComponent();
            ListaClientes = ObtenerListaClientes();
            lvClientes.ItemsSource = ListaClientes;
        }

        private List<Cliente> ObtenerListaClientes()
        {
            return new List<Cliente>
        {
            new Cliente("Juan", "Pérez", "Cuadrado", EstadoViaje.Abierto, true),
            new Cliente("María", "Gómez", "Núñez", EstadoViaje.Cerrado, true),
        };
        }
    }
}
