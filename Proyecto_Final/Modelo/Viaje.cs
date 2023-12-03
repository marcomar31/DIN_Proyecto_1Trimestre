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

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
