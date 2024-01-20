using ITBees.DragArtboard.Interfaces.Models;

namespace ITBees.DragArtboard.Interfaces;

public interface IArtboardToolboxElementsService
{
    ArtboardToolboxElementVm Get(Guid guid);
}