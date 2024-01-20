using ITBees.DragArtboard.Interfaces.Models;

namespace ITBees.DragArtboard.Interfaces;

public interface IArtboardToolboxElementAddingService
{
    ArtboardToolboxElementVm CreateNew(ArtboardToolboxElementIm im);
}