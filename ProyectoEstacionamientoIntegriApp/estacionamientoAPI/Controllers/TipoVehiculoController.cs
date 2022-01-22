using Microsoft.AspNetCore.Mvc;
using estacionamientoAPI.Models;
using System.Collections.Generic;
using System.Linq;
 
namespace estacionamientoAPI.Controllers;

[Route("api/[controller]")]
public class TipoVehiculoController : Controller
{
    private readonly  ParkingLotDbContext _context;

    public TipoVehiculoController(ParkingLotDbContext context)
    {
        _context=context;
    }
    //Devuelve tosos los tipos de vehículos
    [HttpGet]
    public List<TipoVehiculo> Get()
    {
        return _context.TiposVehiculo.ToList();
    }
    
    //retorna el tipo de vehículo que coincida con el id
    [HttpGet("{id:int}")]
    public IActionResult GetTipoVehiculoById(int id)
    {
        var tvehiculo= this._context.TiposVehiculo.SingleOrDefault(ct=>ct.id==id);
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
    public IActionResult AddTiposVehiculo([FromBody] TipoVehiculo TiposVehiculo)
    {
        if(!this.ModelState.IsValid)
        {
            return BadRequest();
        }
        this._context.TiposVehiculo.Add(TiposVehiculo);
        this._context.SaveChanges();
        return Created($"TiposVehiculo/{TiposVehiculo.id}",TiposVehiculo);
    }

    //Actualiza tipos de vehículo
    [HttpPut("{id}")]
    public IActionResult PutTiposVehiculo(int id, [FromBody] TipoVehiculo tipoVehiculo)
    {
        var target=_context.TiposVehiculo.FirstOrDefault(ct=> ct.id==id);
        if(target==null)
        {
            return NotFound();
        }
        else
        {
            target.id=tipoVehiculo.id;
            target.tipo=tipoVehiculo.tipo;
            target.costoPorMin=tipoVehiculo.costoPorMin;

            _context.TiposVehiculo.Update(target);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }

    //Elimina tipos de vehículos
    [HttpDelete("{id}")]
    public IActionResult DeleteTiposVehiculos(int id)
    {
        var target = _context.TiposVehiculo.FirstOrDefault(ct=> ct.id==id);
        if(!this.ModelState.IsValid)
        {
            return BadRequest();
        }
        else
        {
            _context.TiposVehiculo.Remove(target);
            _context.SaveChanges();
            return Ok();
        }
    }


}