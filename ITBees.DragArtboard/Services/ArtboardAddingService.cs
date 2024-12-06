using ITBees.DragArtboard.Interfaces;
using ITBees.DragArtboard.Interfaces.Models;
using ITBees.DragArtboard.Models;
using ITBees.Interfaces.Repository;
using ITBees.Models.Users;

namespace ITBees.DragArtboard.Services;

public class ArtboardAddingService : IArtboardAddingService
{
    private readonly IDragArtboardUserManager _dragArtboardUserManager;
    private readonly IWriteOnlyRepository<Artboard> _artboardWoRepository;
    private readonly IDragArtboardUserManager _artboardUserManager;

    public ArtboardAddingService(IDragArtboardUserManager dragArtboardUserManager,
        IWriteOnlyRepository<Artboard> artboardWoRepository, IDragArtboardUserManager artboardUserManager)
    {
        _dragArtboardUserManager = dragArtboardUserManager;
        _artboardWoRepository = artboardWoRepository;
        _artboardUserManager = artboardUserManager;
    }

    public ArtboardVm CreateNew(ArtboardIm artboardIm)
    {
        var currentUser = _artboardUserManager.GetCurrentUser();
        if (artboardIm.ArtboardOwnerGuid == null ||
            artboardIm.ArtboardOwnerGuid == new Guid("00000000-0000-0000-0000-000000000000"))
        {
            artboardIm.ArtboardOwnerGuid = currentUser.Guid;
        }

        if (currentUser.UserRoles.Contains("PlatformOperator") == false && (_dragArtboardUserManager.TryCanIDoForCompany(TypeOfOperation.Rw, artboardIm.ArtboardOwnerGuid.Value) == false))
        {
            throw new UnauthorizedAccessException(
                $"You are not allowed to create new artbord for this owner : {artboardIm.ArtboardOwnerGuid}");
        };

        var currentUserGuid = _dragArtboardUserManager.GetCurrentUser();
        var result = _artboardWoRepository.InsertData(new Artboard()
        {
            ArtboardOwnerGuid = artboardIm.ArtboardOwnerGuid.Value,
            ArtboardName = artboardIm.ArtboardName,
            ArtboardType = artboardIm.ArtboardType ?? 0,
            BackgroundImagePositionX = artboardIm.BackgroundImagePositionX,
            BackgroundImagePositionY = artboardIm.BackgroundImagePositionY,
            BackgroundImageUrl = artboardIm.BackgroundImageUrl,
            BackgroundImageZoom = artboardIm.BackgroundImageZoom,
            ControlButtonsVisible = artboardIm.ControlButtonsVisible,
            Created = DateTime.Now,
            CreatedByGuid = currentUserGuid.Guid,
            DragEnabled = artboardIm.DragEnabled,
            IsActive = artboardIm.IsActive,
            MeshEnabled = artboardIm.MeshEnabled,
            ShowToolbox = artboardIm.ShowToolbox,
            CompanyGuid = artboardIm.CompanyGuid ?? currentUser.LastUsedCompanyGuid,
            BuildingGuid = artboardIm.BuildingGuid,
            ViewBoxHeight = artboardIm.ViewBoxHeight,
            ViewBoxWidth = artboardIm.ViewBoxWidth,
            ViewBoxX = artboardIm.ViewBoxX,
            ViewBoxY = artboardIm.ViewBoxY,
            ViewBoxData = artboardIm.ViewBoxData
        });

        return new ArtboardVm(result, currentUserGuid);
    }
}