namespace estacionamientoAPI.Models
{
    public class CobroPorDia
    {
        public int id {get; set;}
        public int idSalida {get; set;}
        public int idVehiculo {get; set;}
        public DateTime fecha {get; set;}
        public float tiempoTotal {get; set;}
        public float totalPagar {get; set;}
    }
}