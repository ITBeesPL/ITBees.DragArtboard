using ITBees.DragArtboard.Interfaces;
using ITBees.DragArtboard.Interfaces.Models;
using ITBees.RestfulApiControllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ITBees.DragArtboard.Controllers;

//[Authorize] todo security
public class ArtboardElementsController : RestfulControllerBase<ArtboardElementsController>
{
    private readonly IArtboardElementsService _artboardElementsService;

    public ArtboardElementsController(ILogger<ArtboardElementsController> logger, IArtboardElementsService artboardElementsService) : base(logger)
    {
        _artboardElementsService = artboardElementsService;
    }

    [HttpGet]
    [Produces(typeof(List<ArtboardElementVm>))]
    public IActionResult Get(Guid artboardGuid)
    {
        try
        {
            List<ArtboardElementVm> result = _artboardElementsService.GetAllElementsForArtboard(artboardGuid);
            return Ok(result);  
        }
        catch (Exception e)
        {
            return CreateBaseErrorResponse(e.Message, artboardGuid);
        }
    }
}