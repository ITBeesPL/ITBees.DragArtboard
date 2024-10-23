using ITBees.DragArtboard.Interfaces.Models;

namespace ITBees.DragArtboard.Interfaces;

public interface IArtboardToolboxElementsService
{
    List<ArtboardToolboxElementVm> Get(Guid? guid);
}