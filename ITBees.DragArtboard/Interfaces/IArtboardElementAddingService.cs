using ITBees.DragArtboard.Interfaces.Models;

namespace ITBees.DragArtboard.Interfaces;

public interface IArtboardElementAddingService
{
    ArtboardElementVm CreateNew(ArtboardElementIm artboardElementIm);
}