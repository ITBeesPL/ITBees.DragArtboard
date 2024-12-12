using ITBees.DragArtboard.Controllers.Models;
using ITBees.DragArtboard.Interfaces;
using ITBees.DragArtboard.Interfaces.Models;
using ITBees.DragArtboard.Models;
using ITBees.Interfaces.Repository;
using ITBees.Models.Users;
using ITBees.RestfulApiControllers.Exceptions;
using ITBees.RestfulApiControllers.Models;

namespace ITBees.DragArtboard.Services;

public class ArtboardPostionService : IArtboardPostionService
{
    private readonly IDragArtboardUserManager _artboardUserManager;
    private readonly IWriteOnlyRepository<Artboard> _arboardRwRepo;

    public ArtboardPostionService(IDragArtboardUserManager artboardUserManager, IWriteOnlyRepository<Artboard> arboardRwRepo)
    {
        _artboardUserManager = artboardUserManager;
        _arboardRwRepo = arboardRwRepo;
    }
    public ArtboardVm UpdatePosition(ArtboardPositionUm artboardPositionUm)
    {
        if (_artboardUserManager.GetCurrentUser().UserRoles.Contains("PlatformOperator") == false &&
            _artboardUserManager.TryCanIDoForCompany(TypeOfOperation.Rw,
                _artboardUserManager.GetCurrentUser().LastUsedCompanyGuid) == false)
        {
            throw new FasApiErrorException(new FasApiErrorVm("You don't have write access to this company", 403, ""));
        }

        var result = _arboardRwRepo.UpdateData(x => x.Guid == artboardPositionUm.ArtboardGuid,
            x =>
            {
                x.BackgroundImagePositionX = artboardPositionUm.BackgroundImagePositionX;
                x.BackgroundImagePositionY = artboardPositionUm.BackgroundImagePositionY;
                x.BackgroundImageZoom = artboardPositionUm.BackgroundImageZoom;
                x.ViewBoxData = artboardPositionUm.ViewBoxData;
                x.ViewBoxWidth = artboardPositionUm.ViewBoxWidth;
                x.ViewBoxHeight = artboardPositionUm.ViewBoxHeight;
                x.ViewBoxX = artboardPositionUm.ViewBoxX;
                x.ViewBoxY = artboardPositionUm.ViewBoxY;
            }).FirstOrDefault();

        return new ArtboardVm(result);
    }
}