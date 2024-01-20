using ITBees.DragArtboard.Interfaces;
using ITBees.RestfulApiControllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ITBees.DragArtboard.Controllers;

[Authorize]
public class ArtboardsController : RestfulControllerBase<ArtboardsController>
{
    private readonly IArtboardsService _artboardsService;

    public ArtboardsController(ILogger<ArtboardsController> logger, IArtboardsService artboardsService) : base(logger)
    {
        _artboardsService = artboardsService;
    }

    [HttpGet]
    [Produces(typeof(List<ArtboardVm>))]
    public IActionResult Get(Guid ownerGuid, int take = 50, int skip = 0)
    {
        try
        {
            var result = _artboardsService.GetAllActive(ownerGuid, take, skip);
            return Ok(result);
        }
        catch (Exception e)
        {
            return CreateBaseErrorResponse(e.Message, string.Empty);
        }
    }
}