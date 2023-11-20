using Proyecto_Final.Modelo;
using System;
using System.ComponentModel;

namespace Proyecto_Final
{
    public class Cliente : INotifyPropertyChanged
    {
        private string _dni;
        public string Dni
        {
            get { return _dni; }
            set
            {
                if (_dni != value)
                {
                    _dni = value;
                    OnPropertyChanged(nameof(Dni));
                }
            }
        }

        private string _nombre;
        public string Nombre
        {
            get { return _nombre; }
            set
            {
                if (_nombre != value)
                {
                    _nombre = value;
                    OnPropertyChanged(nameof(Nombre));
                }
            }
        }

        private string _apellido1;
        public string Apellido1
        {
            get { return _apellido1; }
            set
            {
                if (_apellido1 != value)
                {
                    _apellido1 = value;
                    OnPropertyChanged(nameof(Apellido1));
                }
            }
        }

        private string _apellido2;
        public string Apellido2
        {
            get { return _apellido2; }
            set
            {
                if (_apellido2 != value)
                {
                    _apellido2 = value;
                    OnPropertyChanged(nameof(Apellido2));
                }
            }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
        }

        private Viaje[] _viajes;
        public Viaje[] Viajes
        {
            get { return _viajes; }
            set
            {
                if (_viajes != value)
                {
                    _viajes = value;
                    OnPropertyChanged(nameof(Viajes));
                }
            }
        }

        private bool _dadoAlta;
        public bool DadoAlta
        {
            get { return _dadoAlta; }
            set
            {
                if (_dadoAlta != value)
                {
                    _dadoAlta = value;
                    OnPropertyChanged(nameof(DadoAlta));
                }
            }
        }

        public Cliente(string dni, string nombre, string apellido1, string apellido2, string email, bool dadoAlta)
        {
            Dni = dni;
            Nombre = nombre;
            Apellido1 = apellido1;
            Apellido2 = apellido2;
            Email = email;
            Viajes = new Viaje[99];
            DadoAlta = dadoAlta;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
