using System.Collections.Generic;
using System.Runtime.Serialization;


namespace Proyecto_Final.Enumerados
{
    public static class Descripcion
    {
        public static List<string> GetDescripcionesList()
        {
            return new List<string>
            {
                "Sin descripción",
                "Gestión pendiente",
                "Viaje cancelado",    
                "Viaje cerrado"
            };
            
        }
    }
}