using ITBees.DragArtboard.Interfaces.Models;

namespace ITBees.DragArtboard.Interfaces;

public interface IArtboardElementsService
{
    List<ArtboardElementVm> GetAllElementsForArtboard(Guid artboardGuid);
    ArtboardElementVm Get(Guid guid);
}