using Proyecto_Final.Enumerados;
using System;
using System.ComponentModel;

namespace Proyecto_Final.Modelo
{
    public class Viaje : INotifyPropertyChanged
    {
        private Ciudades _origen;
        public Ciudades Origen 
        {
            get { return _origen; }
            set
            {
                if (_origen != value)
                {
                    _origen = value;
                    OnPropertyChanged(nameof(Origen));
                }
            }
        }

        private Ciudades _destino;
        public Ciudades Destino
        {
            get { return _destino; }
            set
            {
                if (_destino != value)
                {
                    _destino = value;
                    OnPropertyChanged(nameof(Destino));
                }
            }
        }

        private DateTime _fechaIda;
        public DateTime FechaIda
        {
            get { return _fechaIda; }
            set
            {
                if (_fechaIda != value)
                {
                    _fechaIda = value;
                    OnPropertyChanged(nameof(FechaIda));
                }
            }
        }

        private DateTime _fechaVuelta;
        public DateTime FechaVuelta
        {
            get { return _fechaVuelta; }
            set
            {
                if (_fechaVuelta != value)
                {
                    _fechaVuelta = value;
                    OnPropertyChanged(nameof(FechaVuelta));
                }
            }
        }

        private TipoHotel _tipoHotel;
        public TipoHotel TipoHotel
        {
            get { return _tipoHotel; }
            set
            {
                if (_tipoHotel != value)
                {
                    _tipoHotel = value;
                    OnPropertyChanged(nameof(TipoHotel));
                }
            }
        }

        private TipoTransporte _tipoTransporte;
        public TipoTransporte TipoTransporte
        {
            get { return _tipoTransporte; }
            set
            {
                if (_tipoTransporte != value)
                {
                    _tipoTransporte = value;
                    OnPropertyChanged(nameof(TipoTransporte));
                }
            }
        }

        private EstadoViaje _estadoViaje;
        public EstadoViaje EstadoViaje
        {
            get { return _estadoViaje; }
            set
            {
                if (_estadoViaje != value)
                {
                    _estadoViaje = value;
                    OnPropertyChanged(nameof(EstadoViaje));
                }
            }
        }

        private int _precioViaje;
        public int PrecioViaje
        {
            get { return _precioViaje; }
            set
            {
                if (_precioViaje != value)
                {
                    _precioViaje = value;
                    OnPropertyChanged(nameof(PrecioViaje));
                }
            }
        }

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
            PrecioViaje = CalculaPrecio();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int CalculaPrecio()
        {
            int numeroNoches = CalcularNumeroNoches();

            int precioBase = 200;
            int precioFinal = precioBase;

            // Calcular el precio adicional según el tipo de hotel
            switch (_tipoHotel)
            {
                case TipoHotel.Economico:
                    precioFinal += (100 * numeroNoches); 
                    break;
                case TipoHotel.Estandar:
                    precioFinal += (200 * numeroNoches);
                    break;
                case TipoHotel.Premium:
                    precioFinal += (300 * numeroNoches);
                    break;
                case TipoHotel.Lujoso:
                    precioFinal += (400 * numeroNoches);
                    break;
            }

            // Calcular el precio adicional según el tipo de transporte
            switch (_tipoTransporte)
            {
                case TipoTransporte.Coche:
                    precioFinal += (100 * numeroNoches);
                    break;
                case TipoTransporte.Autobus:
                    precioFinal += 120;
                    break;
                case TipoTransporte.Tren:
                    precioFinal += 200;
                    break;
                case TipoTransporte.Avion:
                    precioFinal += 500;
                    break;
                case TipoTransporte.Combinado:
                    precioFinal += 200 + (80 * numeroNoches);
                    break;
            }

            return precioFinal;
        }

        private int CalcularNumeroNoches()
        {
            // Calcular la diferencia de días entre la fecha de vuelta y la fecha de ida
            TimeSpan diferencia = _fechaVuelta - _fechaIda;
            int numeroNoches = diferencia.Days;

            return numeroNoches;
        }

    }
}
