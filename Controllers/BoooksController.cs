using Microsoft.AspNetCore.Mvc;
using WebApi4Boooks.Models;
using WebApi4Boooks.Services.Interfaces;

namespace WebApi4Boooks.Controllers;

[ApiController]
[Route("[controller]")]
public class BoooksController : ControllerBase
{
    private readonly ILogger<BoooksController> _logger;
    private readonly IFakeRestAPIHttpClient _boooksHttpClient;

    public BoooksController(ILogger<BoooksController> logger, IFakeRestAPIHttpClient boooksHttpClient)
    {
        _logger = logger;
        _boooksHttpClient = boooksHttpClient;
    }

    [HttpGet(Name = "GetAllBooks")]
    public IEnumerable<Boook> Get()
    {
        //Query api to get all books, use pagination if supported.
        var boooks = _boooksHttpClient.GetBoooks().Result;
        return boooks;
    }
}
