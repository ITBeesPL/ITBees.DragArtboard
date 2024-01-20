using ITBees.DragArtboard.Interfaces;
using ITBees.DragArtboard.Interfaces.Models;
using ITBees.RestfulApiControllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ITBees.DragArtboard.Controllers;

//todo security
public class ArtboardElementController : RestfulControllerBase<ArtboardElementController>
{
    private readonly IArtbaordElementUpdateService _artbaordElementUpdateService;
    private readonly IArtboardElementAddingService _artboardElementAddingService;
    private readonly IArtboardElementDeleteService _artboardElementDeleteService;
    private readonly IArtboardElementsService _artboardElementsService;

    public ArtboardElementController(ILogger<ArtboardElementController> logger, 
        IArtbaordElementUpdateService artbaordElementUpdateService,
        IArtboardElementAddingService artboardElementAddingService,
        IArtboardElementDeleteService artboardElementDeleteService,
        IArtboardElementsService artboardElementsService) : base(logger)
    {
        _artbaordElementUpdateService = artbaordElementUpdateService;
        _artboardElementAddingService = artboardElementAddingService;
        _artboardElementDeleteService = artboardElementDeleteService;
        _artboardElementsService = artboardElementsService;
    }


    [HttpGet]
    [Produces(typeof(ArtboardElementVm))]
    public IActionResult Get(Guid guid)
    {
        try
        {
            return Ok(_artboardElementsService.Get(guid));
        }
        catch (Exception e)
        {
            return CreateBaseErrorResponse(e.Message, guid);
        }
    }

    [HttpPost]
    [Produces(typeof(ArtboardElementVm))]
    public IActionResult Post([FromBody] ArtboardElementIm artboardElementIm)
    {
        try
        {
            ArtboardElementVm result = _artboardElementAddingService.CreateNew(artboardElementIm);
            return Ok(result);
        }
        catch (Exception e)
        {
            return CreateBaseErrorResponse(e.Message, artboardElementIm);
        }

    }

    [HttpPut]
    [Produces(typeof(ArtboardElementVm))]
    public IActionResult Put([FromBody] ArtboardElementUm artboardElementUm)
    {
        try
        {
            ArtboardElementVm result = _artbaordElementUpdateService.Update(artboardElementUm);
            return Ok(result);
        }
        catch (Exception e)
        {
            return CreateBaseErrorResponse(e.Message, artboardElementUm);
        }
    }

    [HttpDelete]
    public IActionResult Del(Guid guid)
    {
        try
        {
            _artboardElementDeleteService.Delete(guid);
            return Ok();
        }
        catch (Exception e)
        {
            return CreateBaseErrorResponse(e.Message, guid);
        }
    }
}

