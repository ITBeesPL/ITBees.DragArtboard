using ITBees.DragArtboard.Interfaces;
using ITBees.DragArtboard.Models;
using ITBees.Interfaces.Repository;
using ITBees.Models.Users;

namespace ITBees.DragArtboard.Services;

public class ArtboardAddingService
{
    private readonly IDragArtboardUserManager _dragArtboardUserManager;
    private readonly IWriteOnlyRepository<Artboard> _artboardWoRepository;

    public ArtboardAddingService(IDragArtboardUserManager dragArtboardUserManager, 
        IWriteOnlyRepository<Artboard> artboardWoRepository)
    {
        _dragArtboardUserManager = dragArtboardUserManager;
        _artboardWoRepository = artboardWoRepository;
    }

    public ArtboardVm CreateNew(ArtboardIm artboardIm)
    {
        if (_dragArtboardUserManager.TryCanIDoForCompany(TypeOfOperation.Rw, artboardIm.ArtboardOwnerGuid) == false)
        {
            throw new UnauthorizedAccessException(
                $"You are not allowed to create new artbord for this owner : {artboardIm.ArtboardOwnerGuid}");
        };

        var currentUserGuid = _dragArtboardUserManager.GetCurrentUser();
        var result = _artboardWoRepository.InsertData(new Artboard()
        {
            ArtboardOwnerGuid = artboardIm.ArtboardOwnerGuid,
            ArtboardName = artboardIm.ArtboardName,
            ArtboardType = artboardIm.ArtboardType,
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
            Zoom = artboardIm.Zoom
        });

        return new ArtboardVm(result, currentUserGuid);
    }
}