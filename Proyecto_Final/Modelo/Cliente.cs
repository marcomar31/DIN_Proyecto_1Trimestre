using System;
using Proyecto_Final.Modelo;

namespace Proyecto_Final
{
    public class Cliente
    {
        public String nombre { get; set; }
        public String apellido1 { get; set; }
        public String apellido2 { get; set; }
        public EstadoViaje estadoViaje { get; set; }
        public bool dadoAlta { get; set; }
        public Cliente(string nombre, string apellido1, string apellido2, EstadoViaje estadoViaje, bool dadoAlta)
        {
            this.nombre = nombre;
            this.apellido1 = apellido1;
            this.apellido2 = apellido2;
            this.estadoViaje = estadoViaje;
            this.dadoAlta = dadoAlta;
        }
    }
}
