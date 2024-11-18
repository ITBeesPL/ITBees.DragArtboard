using ITBees.DragArtboard.Controllers.Models;
using ITBees.DragArtboard.Interfaces;
using ITBees.DragArtboard.Interfaces.Models;
using ITBees.DragArtboard.Services;
using ITBees.RestfulApiControllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ITBees.DragArtboard.Controllers;

[Authorize]
public class ArtboardPositionController : RestfulControllerBase<ArtboardPositionController>
{
    private readonly IArtboardPostionService _artboardPostionService;

    public ArtboardPositionController(ILogger<ArtboardPositionController> logger, IArtboardPostionService artboardPostionService) : base(logger)
    {
        _artboardPostionService = artboardPostionService;
    }

    [HttpPut]
    [Produces(typeof (ArtboardVm))]
    public IActionResult Put([FromBody] ArtboardPositionUm artboardPositionUm)
    {
        return ReturnOkResult(() => _artboardPostionService.UpdatePosition(artboardPositionUm));
    }
}