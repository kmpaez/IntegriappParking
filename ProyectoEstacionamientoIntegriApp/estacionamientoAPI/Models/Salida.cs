namespace estacionamientoAPI.Models
{
    public class Salida
    {
        public int id {get; set;}
        public int idEntrada {get; set;}
        public int idVehiculo {get; set;}
        public DateTime fecha {get; set;}
        public DateTime hora {get; set;}
    }
}