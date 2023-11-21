using Proyecto_Final.Enumerados;
using System;

namespace Proyecto_Final.Modelo
{
    public class Viaje
    {
        public Ciudades Origen { get; set; }
        public Ciudades Destino { get; set; }
        public DateTime FechaIda { get; set; }
        public DateTime FechaVuelta { get; set; }
        public TipoHotel TipoHotel { get; set; }
        public TipoTransporte TipoTransporte { get; set; }
        public EstadoViaje EstadoViaje { get; set; }

        public Viaje(Ciudades Origen, Ciudades Destino, DateTime FechaIda, 
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
