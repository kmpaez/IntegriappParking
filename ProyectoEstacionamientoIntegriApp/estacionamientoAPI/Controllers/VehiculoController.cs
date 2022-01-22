using Microsoft.AspNetCore.Mvc;
using estacionamientoAPI.Models;
using System.Collections.Generic;
using System.Linq;
 
namespace estacionamientoAPI.Controllers;

[Route("api/[controller]")]
public class VehiculoController : Controller
{
    private readonly  ParkingLotDbContext _context;

    public VehiculoController(ParkingLotDbContext context)
    {
        _context=context;
    }
    //Devuelve tosos los tipos de vehículos
    [HttpGet]
    public List<Vehiculo> Get()
    {
        return _context.Vehiculos.ToList();
    }
    
    //retorna el tipo de vehículo que coincida con el id
    [HttpGet("{id:int}")]
    public IActionResult GetVehiculoById(int id)
    {
        var tvehiculo= this._context.Vehiculos.SingleOrDefault(ct=>ct.id==id);
        if(tvehiculo!=null)
        {
            return Ok(tvehiculo);
        } 
        else
        {
            return NotFound();
        }
    }

    //Agrega tipos de vehículo
    [HttpPost]
    public IActionResult AddVehiculo([FromBody] Vehiculo Vehiculo)
    {
        if(!this.ModelState.IsValid)
        {
            return BadRequest();
        }
        this._context.Vehiculos.Add(Vehiculo);
        this._context.SaveChanges();
        return Created($"Vehiculo/{Vehiculo.id}",Vehiculo);
    }

    //Actualiza tipos de vehículo
    [HttpPut("{id}")]
    public IActionResult PutVehiculo(int id, [FromBody] Vehiculo Vehiculo)
    {
        var target=_context.Vehiculos.FirstOrDefault(ct=> ct.id==id);
        if(target==null)
        {
            return NotFound();
        }
        else
        {
            target.id=Vehiculo.id;
            target.placa=Vehiculo.placa;
            target.marca=Vehiculo.marca;
            target.modelo=Vehiculo.modelo;
            target.idTipoVehiculo=Vehiculo.idTipoVehiculo;

            _context.Vehiculos.Update(target);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }

    //Elimina tipos de vehículos
    [HttpDelete("{id}")]
    public IActionResult DeleteVehiculos(int id)
    {
        var target = _context.Vehiculos.FirstOrDefault(ct=> ct.id==id);
        if(!this.ModelState.IsValid)
        {
            return BadRequest();
        }
        else
        {
            _context.Vehiculos.Remove(target);
            _context.SaveChanges();
            return Ok();
        }
    }


}