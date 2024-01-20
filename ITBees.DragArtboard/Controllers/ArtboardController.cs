using ITBees.DragArtboard.Interfaces;
using ITBees.RestfulApiControllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ITBees.DragArtboard.Controllers;

[Authorize]
public class ArtboardController : RestfulControllerBase<ArtboardController>
{
    private readonly IArtboardsService _artboardsService;

    public ArtboardController(ILogger<ArtboardController> logger, IArtboardsService artboardsService) : base(logger)
    {
        _artboardsService = artboardsService;
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
}