using ITBees.DragArtboard.Controllers.Models;
using ITBees.DragArtboard.Interfaces.Models;

namespace ITBees.DragArtboard.Interfaces;

public interface IArtboardPostionService
{
    ArtboardVm UpdatePosition(ArtboardPositionUm artboardPositionUm);
}