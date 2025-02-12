using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApi4Boooks.Models;
using WebApi4Boooks.Services.Interfaces;

namespace WebApi4Boooks.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BoooksController : ControllerBase
{
    private readonly ILogger<BoooksController> _logger;
    private readonly IFakeRestAPIHttpClient _boooksHttpClient;

    public BoooksController(ILogger<BoooksController> logger, IFakeRestAPIHttpClient boooksHttpClient)
    {
        _logger = logger;
        _boooksHttpClient = boooksHttpClient;
    }

    [HttpGet]
    [Route("")]
    public async Task<IEnumerable<Boook>> GetAllBoooks()
    {
        var boooks = await _boooksHttpClient.GetBoooks();
        return boooks;
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<Boook>> GetBoookById(int id)
    {
        Boook boook = await _boooksHttpClient.GetBoookById(id);
        if (boook == null)
        {
            return NotFound();
        }
        return boook;
    }

    [HttpPost]
    [Route("")]
    public ActionResult SubmitNewBoook(Boook boook) 
    //Podriamos especificar [FromBody], pero creo que es mejor dejar que el AutoMapper resuelva el mapeo, en caso de que se reciba tanto desde Body como desde un Form
    {
        //Agregar aqui a una base de datos. Puede involucrar _context, o _unitOfWork con patron de repositorio.
        //por ahora solo confirmamos que el Boook es un objeto valido.
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Created((Uri?)null,boook);//Uri es nulo porque no existe un nuevo Uri para este recurso "creado".
    }

    [HttpPut]
    [Route("{id}")]
    public ActionResult EditBoook(Boook boook, int id) 
    {
        //Actualizar el objeto aqui hacia una base de datos. Puede involucrar _context, o _unitOfWork con patron de repositorio.
        //por ahora solo confirmamos que el Boook es un objeto valido. y id es > 0.
        if (!ModelState.IsValid && id<1)  
        {
            return BadRequest(ModelState);
        }
        return Ok();
        //solo devuelve 200 OK
        //ref: https://stackoverflow.com/questions/797834/should-a-restful-put-operation-return-something
    }
    [HttpDelete]
    [Route("{id}")]
    public ActionResult DeleteBoook(int id) 
    {
        //Remover el objeto aqui de una base de datos.
        //por ahora solo confirmamos que el id es > 0.
        if (id<1)  
        {
            return BadRequest();
        }
        return NoContent(); //204
    }

}
