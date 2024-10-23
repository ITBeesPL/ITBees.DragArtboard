using ITBees.DragArtboard.Interfaces;
using ITBees.DragArtboard.Interfaces.Models;
using ITBees.RestfulApiControllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ITBees.DragArtboard.Controllers;

public class ArtboardToolboxController : RestfulControllerBase<ArtboardToolboxController>
{
    private readonly IArtboardToolboxElementAddingService _artboardElementToolboxAddingService;
    private readonly IArtboardToolboxElementDeleteService _artboardElementToolboxDeleteService;
    private readonly IArtbaordToolboxElementUpdateService _artbaordElementToolboxUpdateService;
    private readonly IArtboardToolboxElementsService      _artboardElementsToolboxService;

    public ArtboardToolboxController(ILogger<ArtboardToolboxController> logger,
        IArtboardToolboxElementAddingService artboardToolboxElementAddingService,
        IArtboardToolboxElementDeleteService artboardToolboxElementDeleteService,
        IArtbaordToolboxElementUpdateService artbaordToolboxElementUpdateService,
        IArtboardToolboxElementsService artboardToolboxElementsService) : base(logger)
    {
        _artboardElementToolboxAddingService = artboardToolboxElementAddingService;
        _artboardElementToolboxDeleteService = artboardToolboxElementDeleteService;
        _artbaordElementToolboxUpdateService = artbaordToolboxElementUpdateService;
        _artboardElementsToolboxService = artboardToolboxElementsService;
    }

    [HttpGet]
    [Produces(typeof(ArtboardToolboxElementVm))]
    public IActionResult Get(Guid guid)
    {
        return ReturnOkResult(() => _artboardElementsToolboxService.Get(guid));
    }

    [HttpPost]
    [Produces(typeof(ArtboardToolboxElementVm))]
    public IActionResult Post([FromBody] ArtboardToolboxElementIm artboardToolboxElementIm)
    {
        try
        {
            ArtboardToolboxElementVm result = _artboardElementToolboxAddingService.CreateNew(artboardToolboxElementIm);
            return Ok(result);
        }
        catch (Exception e)
        {
            return CreateBaseErrorResponse(e.Message, artboardToolboxElementIm);
        }
    }

    [HttpPut]
    [Produces(typeof(ArtboardToolboxElementVm))]
    public IActionResult Put([FromBody] ArtboardToolboxElementUm artboardToolboxElementUm)
    {
        try
        {
            ArtboardToolboxElementVm result = _artbaordElementToolboxUpdateService.Update(artboardToolboxElementUm);
            return Ok(result);
        }
        catch (Exception e)
        {
            return CreateBaseErrorResponse(e.Message, artboardToolboxElementUm);
        }
    }

    [HttpDelete]
    public IActionResult Del(Guid guid)
    {
        try
        {
            _artboardElementToolboxDeleteService.Delete(guid);
            return Ok();
        }
        catch (Exception e)
        {
            return CreateBaseErrorResponse(e.Message, guid);
        }
    }
}