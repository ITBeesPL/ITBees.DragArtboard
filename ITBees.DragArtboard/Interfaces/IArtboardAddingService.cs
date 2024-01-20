using ITBees.DragArtboard.Interfaces.Models;

namespace ITBees.DragArtboard.Interfaces;

public interface IArtboardAddingService
{
    ArtboardVm CreateNew(ArtboardIm artboardIm);
}