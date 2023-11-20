using Proyecto_Final.Enumerados;
using System;

namespace Proyecto_Final.Modelo
{
    public class Viaje
    {
        public string Origen { get; set; }
        public string Destino { get; set; }
        public DateTime FechaIda { get; set; }
        public DateTime FechaVuelta { get; set; }
        public TipoHotel TipoHotel { get; set; }
        public TipoTransporte TipoTransporte { get; set; }
        public EstadoViaje EstadoViaje { get; set; }

        public Viaje(string Origen, string Destino, DateTime FechaIda, 
            DateTime FechaVuelta, TipoHotel TipoHotel, TipoTransporte TipoTransporte, EstadoViaje EstadoViaje)
        {
            this.Origen = Origen;
            this.Destino = Destino;
            this.FechaIda = FechaIda;
            this.FechaVuelta = FechaVuelta;
            this.TipoHotel = TipoHotel;
            this.TipoTransporte = TipoTransporte;
            this.EstadoViaje = EstadoViaje;
        }
    }
}
