using Microsoft.EntityFrameworkCore;
namespace estacionamientoAPI.Models
{
    public class ParkingLotDbContext:DbContext
    {
     
        public ParkingLotDbContext(DbContextOptions<ParkingLotDbContext> data):base (data){}

        public DbSet<TipoVehiculo> TiposVehiculo{get; set;}
        public DbSet<Vehiculo> Vehiculos{get; set;}
        public DbSet<DatosResidente> DatosResidentes{get; set;}
        public DbSet<Entrada> Entradas{get; set;}
        public DbSet<Salida> Salidas{get; set;}
        public DbSet<CobroPorDia> CobrosPorDia{get; set;}

    }


}