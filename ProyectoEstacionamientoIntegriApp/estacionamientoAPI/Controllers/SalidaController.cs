using Microsoft.AspNetCore.Mvc;
using estacionamientoAPI.Models;
using System.Collections.Generic;
using System.Linq;
 
namespace estacionamientoAPI.Controllers;

[Route("api/[controller]")]
public class SalidaController : Controller
{
    private readonly  ParkingLotDbContext _context;

    public SalidaController(ParkingLotDbContext context)
    {
        _context=context;
    }
    //Devuelve tosos los tipos de vehículos
    [HttpGet]
    public List<Salida> Get()
    {
        return _context.Salidas.ToList();
    }
    
    //retorna el tipo de vehículo que coincida con el id
    [HttpGet("{id:int}")]
    public IActionResult GetSalida(int id)
    {
        var salida= this._context.Salidas.SingleOrDefault(ct=>ct.id==id);
        if(salida!=null)
        {
            return Ok(salida);
        } 
        else
        {
            return NotFound();
        }
    }

    //Agrega tipos de vehículo
    [HttpPost]
    public IActionResult AddSalida([FromBody] Salida Salida)
    {
        if(!this.ModelState.IsValid)
        {
            return BadRequest();
        }
        this._context.Salidas.Add(Salida);
        this._context.SaveChanges();
        return Created($"Salida/{Salida.id}",Salida);
    }

    //Actualiza tipos de vehículo
    [HttpPut("{id}")]
    public IActionResult PutSalida(int id, [FromBody] Salida Salida)
    {
        var target=_context.Salidas.FirstOrDefault(ct=> ct.id==id);
        if(target==null)
        {
            return NotFound();
        }
        else
        {
            target.id=Salida.id;
            target.fecha=Salida.fecha;
            target.hora=Salida.hora;
            target.idVehiculo=Salida.idVehiculo;
            target.idEntrada=Salida.idEntrada;

            _context.Salidas.Update(target);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }

    //Elimina tipos de vehículos
    [HttpDelete("{id}")]
    public IActionResult DeleteSalida(int id)
    {
        var target = _context.Salidas.FirstOrDefault(ct=> ct.id==id);
        if(!this.ModelState.IsValid)
        {
            return BadRequest();
        }
        else
        {
            _context.Salidas.Remove(target);
            _context.SaveChanges();
            return Ok();
        }
    }


}