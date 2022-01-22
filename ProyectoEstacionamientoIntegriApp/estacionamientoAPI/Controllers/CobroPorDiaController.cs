using Microsoft.AspNetCore.Mvc;
using estacionamientoAPI.Models;
using System.Collections.Generic;
using System.Linq;
 
namespace estacionamientoAPI.Controllers;

[Route("api/[controller]")]
public class CobroPorDiaController : Controller
{
    private readonly  ParkingLotDbContext _context;

    public CobroPorDiaController(ParkingLotDbContext context)
    {
        _context=context;
    }
    //Devuelve tosos los tipos de vehículos
    [HttpGet]
    public List<CobroPorDia> Get()
    {
        return _context.CobrosPorDia.ToList();
    }
    
    //retorna el tipo de vehículo que coincida con el id
    [HttpGet("{id:int}")]
    public IActionResult GetCobroPorDia(int id)
    {
        var cobro= this._context.CobrosPorDia.SingleOrDefault(ct=>ct.id==id);
        if(cobro!=null)
        {
            return Ok(cobro);
        } 
        else
        {
            return NotFound();
        }
    }

    //Agrega tipos de vehículo
    [HttpPost]
    public IActionResult AddCobroPorDia([FromBody] CobroPorDia CobroPorDia)
    {
        if(!this.ModelState.IsValid)
        {
            return BadRequest();
        }
        this._context.CobrosPorDia.Add(CobroPorDia);
        this._context.SaveChanges();
        return Created($"CobroPorDia/{CobroPorDia.id}",CobroPorDia);
    }

    //Actualiza tipos de vehículo
    [HttpPut("{id}")]
    public IActionResult PutCobroPorDia(int id, [FromBody] CobroPorDia CobroPorDia)
    {
        var target=_context.CobrosPorDia.FirstOrDefault(ct=> ct.id==id);
        if(target==null)
        {
            return NotFound();
        }
        else
        {
            target.id=CobroPorDia.id;
            target.fecha=CobroPorDia.fecha;
            target.tiempoTotal=CobroPorDia.tiempoTotal;
            target.totalPagar=CobroPorDia.totalPagar;
            target.idVehiculo=CobroPorDia.idVehiculo;
            target.idSalida=CobroPorDia.idSalida;

            _context.CobrosPorDia.Update(target);
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