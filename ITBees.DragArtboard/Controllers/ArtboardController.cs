using ITBees.DragArtboard.Interfaces;
using ITBees.DragArtboard.Interfaces.Models;
using ITBees.RestfulApiControllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ITBees.DragArtboard.Controllers;

[Authorize]
public class ArtboardController : RestfulControllerBase<ArtboardController>
{
    private readonly IArtboardsService _artboardsService;
    private readonly IArtboardAddingService _artboardAddingService;
    private readonly IArtboardUpdatingService _artboardUpdatingService;
    private readonly IArtboardDeleteService _artboardDeleteService;

    public ArtboardController(ILogger<ArtboardController> logger, 
        IArtboardsService artboardsService, 
        IArtboardAddingService artboardAddingService, 
        IArtboardUpdatingService artboardUpdatingService,
        IArtboardDeleteService artboardDeleteService) : base(logger)
    {
        _artboardsService = artboardsService;
        _artboardAddingService = artboardAddingService;
        _artboardUpdatingService = artboardUpdatingService;
        _artboardDeleteService = artboardDeleteService;
    }

    [HttpGet]
    [Produces(typeof(ArtboardVm))]
    public IActionResult Get(Guid guid)
    {
        try
        {
            var artbaord = _artboardsService.Get(guid);
            return Ok(artbaord);
        }
        catch (Exception e)
        {
            return CreateBaseErrorResponse(e.Message, guid);
        }
    }

    [HttpPost]
    [Produces(typeof(ArtboardVm))]
    public IActionResult Post([FromBody] ArtboardIm artboardIm)
    {
        try
        {
            var artbaord = _artboardAddingService.CreateNew(artboardIm);
            return Ok(artbaord);
        }
        catch (Exception e)
        {
            return CreateBaseErrorResponse(e.Message, artboardIm);
        }
    }

    [HttpPut]
    [Produces(typeof(ArtboardVm))]
    public IActionResult Put([FromBody] ArtboardUm artboardUm)
    {
        try
        {
            var artbaord = _artboardUpdatingService.Update(artboardUm);
            return Ok(artbaord);
        }
        catch (Exception e)
        {
            return CreateBaseErrorResponse(e.Message, artboardUm);
        }
    }

    [HttpDelete]
    public IActionResult Del(Guid guid)
    {
        try
        {
            _artboardDeleteService.Delete(guid);
            return Ok();
        }
        catch (Exception e)
        {
            return CreateBaseErrorResponse(e.Message, guid);
        }
    }
}