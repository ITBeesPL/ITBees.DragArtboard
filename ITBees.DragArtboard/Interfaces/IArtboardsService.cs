using ITBees.DragArtboard.Interfaces.Models;
using ITBees.Interfaces.Repository;

namespace ITBees.DragArtboard.Interfaces;

public interface IArtboardsService
{
    PaginatedResult<ArtboardVm> GetAllActive(int? page, int? pageSize, string? sortColumn, SortOrder? sortOrder);
    ArtboardVm Get(Guid guid);
}