using ITBees.DragArtboard.Interfaces.Models;

namespace ITBees.DragArtboard.Interfaces;

public interface IArtboardUpdatingService
{
    ArtboardVm Update(ArtboardUm artboardIm);
}