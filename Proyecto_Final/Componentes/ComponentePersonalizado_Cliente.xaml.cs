using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Proyecto_Final.Componentes
{
    /// <summary>
    /// Lógica de interacción para ComponentePersonalizado_Cliente.xaml
    /// </summary>
    public partial class ComponentePersonalizado_Cliente : UserControl
    {
        public static readonly DependencyProperty TituloProperty =
        DependencyProperty.Register("Titulo", typeof(string), typeof(ComponentePersonalizado_Cliente), new PropertyMetadata("NUEVO CLIENTE"));

        public event RoutedEventHandler AceptarClick;
        public event RoutedEventHandler CancelarClick;

        public string Titulo
        {
            get { return (string)GetValue(TituloProperty); }
            set { SetValue(TituloProperty, value); }
        }

        public ComponentePersonalizado_Cliente()
        {
            InitializeComponent();
        }

        // Manejadores de eventos internos para los botones
        private void OnAceptarClicked(object sender, RoutedEventArgs e)
        {
            // Propaga el evento al exterior a través del evento personalizado
            AceptarClick?.Invoke(sender, e);
        }

        private void OnCancelarClicked(object sender, RoutedEventArgs e)
        {
            // Propaga el evento al exterior a través del evento personalizado
            CancelarClick?.Invoke(sender, e);
        }
    }
}
