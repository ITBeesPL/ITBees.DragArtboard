using ITBees.DragArtboard.Interfaces;
using ITBees.DragArtboard.Interfaces.Models;
using ITBees.Interfaces.Repository;
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
    [Produces(typeof(PaginatedResult<ArtboardVm>))]
    public IActionResult Get(int? page, int? pageSize, string? sortColumn, SortOrder? sortOrder)
    {
        try
        {
            var result = _artboardsService.GetAllActive(page, pageSize, sortColumn, sortOrder);
            return Ok(result);
        }
        catch (Exception e)
        {
            return CreateBaseErrorResponse(e.Message, string.Empty);
        }
    }
}