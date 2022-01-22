using Microsoft.AspNetCore.Mvc;
using estacionamientoAPI.Models;
using System.Collections.Generic;
using System.Linq;
 
namespace estacionamientoAPI.Controllers;

[Route("api/[controller]")]
public class DatosResidenteController : Controller
{
    private readonly  ParkingLotDbContext _context;

    public DatosResidenteController(ParkingLotDbContext context)
    {
        _context=context;
    }
    //Devuelve tosos los tipos de vehículos
    [HttpGet]
    public List<DatosResidente> Get()
    {
        return _context.DatosResidentes.ToList();
    }
    
    //retorna el tipo de vehículo que coincida con el id
    [HttpGet("{id:int}")]
    public IActionResult GetVehiculoById(int id)
    {
        var residente= this._context.DatosResidentes.SingleOrDefault(ct=>ct.id==id);
        if(residente!=null)
        {
            return Ok(residente);
        } 
        else
        {
            return NotFound();
        }
    }

    //Agrega tipos de vehículo
    [HttpPost]
    public IActionResult AddDatosResidente([FromBody] DatosResidente DatosResidente)
    {
        if(!this.ModelState.IsValid)
        {
            return BadRequest();
        }
        this._context.DatosResidentes.Add(DatosResidente);
        this._context.SaveChanges();
        return Created($"DatosResidente/{DatosResidente.id}",DatosResidente);
    }

    //Actualiza tipos de vehículo
    [HttpPut("{id}")]
    public IActionResult PutDatosResidente(int id, [FromBody] DatosResidente DatosResidente)
    {
        var target=_context.DatosResidentes.FirstOrDefault(ct=> ct.id==id);
        if(target==null)
        {
            return NotFound();
        }
        else
        {
            target.id=DatosResidente.id;
            target.nombrePropietario=DatosResidente.nombrePropietario;
            target.direccion=DatosResidente.direccion;
            target.telefono=DatosResidente.telefono;
            target.correo=DatosResidente.correo;
            target.observaciones=DatosResidente.observaciones;
            target.idVehiculo=DatosResidente.idVehiculo;
            _context.DatosResidentes.Update(target);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }

    //Elimina tipos de vehículos
    [HttpDelete("{id}")]
    public IActionResult DeleteDatosResidente(int id)
    {
        var target = _context.DatosResidentes.FirstOrDefault(ct=> ct.id==id);
        if(!this.ModelState.IsValid)
        {
            return BadRequest();
        }
        else
        {
            _context.DatosResidentes.Remove(target);
            _context.SaveChanges();
            return Ok();
        }
    }


}