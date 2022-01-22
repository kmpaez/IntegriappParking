using Microsoft.AspNetCore.Mvc;
using estacionamientoAPI.Models;
using System.Collections.Generic;
using System.Linq;
 
namespace estacionamientoAPI.Controllers;

[Route("api/[controller]")]
public class EntradaController : Controller
{
    private readonly  ParkingLotDbContext _context;

    public EntradaController(ParkingLotDbContext context)
    {
        _context=context;
    }
    //Devuelve tosos los tipos de vehículos
    [HttpGet]
    public List<Entrada> Get()
    {
        return _context.Entradas.ToList();
    }
    
    //retorna el tipo de vehículo que coincida con el id
    [HttpGet("{id:int}")]
    public IActionResult GetEntrada(int id)
    {
        var entrada= this._context.TiposVehiculo.SingleOrDefault(ct=>ct.id==id);
        if(entrada!=null)
        {
            return Ok(entrada);
        } 
        else
        {
            return NotFound();
        }
    }

    //Agrega tipos de vehículo
    [HttpPost]
    public IActionResult AddEntrada([FromBody] Entrada Entrada)
    {
        if(!this.ModelState.IsValid)
        {
            return BadRequest();
        }
        this._context.Entradas.Add(Entrada);
        this._context.SaveChanges();
        return Created($"Entrada/{Entrada.id}",Entrada);
    }

    //Actualiza tipos de vehículo
    [HttpPut("{id}")]
    public IActionResult PutEntrada(int id, [FromBody] Entrada Entrada)
    {
        var target=_context.Entradas.FirstOrDefault(ct=> ct.id==id);
        if(target==null)
        {
            return NotFound();
        }
        else
        {
            target.id=Entrada.id;
            target.fecha=Entrada.fecha;
            target.hora=Entrada.hora;
            target.idVehiculo=Entrada.idVehiculo;

            _context.Entradas.Update(target);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }

    //Elimina tipos de vehículos
    [HttpDelete("{id}")]
    public IActionResult DeleteEntrada(int id)
    {
        var target = _context.Entradas.FirstOrDefault(ct=> ct.id==id);
        if(!this.ModelState.IsValid)
        {
            return BadRequest();
        }
        else
        {
            _context.Entradas.Remove(target);
            _context.SaveChanges();
            return Ok();
        }
    }


}