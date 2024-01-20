using ITBees.DragArtboard.Interfaces;
using ITBees.DragArtboard.Interfaces.Models;
using ITBees.RestfulApiControllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ITBees.DragArtboard.Controllers;

//todo security
public class ArtboardToolboxesController : RestfulControllerBase<ArtboardToolboxesController>
{
    private readonly IArtboardToolboxElementsService _artboardToolboxElementsService;

    public ArtboardToolboxesController(ILogger<ArtboardToolboxesController> logger, IArtboardToolboxElementsService artboardToolboxElementsService) : base(logger)
    {
        _artboardToolboxElementsService = artboardToolboxElementsService;
    }

    [HttpGet]
    [Produces(typeof(List<ArtboardToolboxElementVm>))]
    public IActionResult Get(Guid artboardGuid)
    {
        try
        {
            return Ok(_artboardToolboxElementsService.Get(artboardGuid));
        }
        catch (Exception e)
        {
            return CreateBaseErrorResponse(e.Message, artboardGuid);
        }
    }
}