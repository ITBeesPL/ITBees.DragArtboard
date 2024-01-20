using ITBees.DragArtboard.Interfaces.Models;

namespace ITBees.DragArtboard.Interfaces;

public interface IArtboardsService
{
    List<ArtboardVm> GetAllActive(Guid artboardOwnerGuid, int take, int skip);
    ArtboardVm Get(Guid guid);
}