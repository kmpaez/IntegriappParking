namespace estacionamientoAPI.Models
{
    public class DatosResidente
    {
        public int id {get; set;}
        public int idVehiculo {get; set;}
        public string nombrePropietario {get; set;}
        public string direccion {get; set;}
        public string telefono {get; set;}
        public string correo {get; set;}
        public string observaciones {get; set;}
    }
}