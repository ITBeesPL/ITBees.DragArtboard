using ITBees.DragArtboard.Interfaces;
using ITBees.DragArtboard.Interfaces.Models;
using ITBees.DragArtboard.Models;
using ITBees.Interfaces.Repository;

namespace ITBees.DragArtboard.Services;

class ArtboardElementAddingService : IArtboardElementAddingService
{
    private readonly IWriteOnlyRepository<ArtboardElement> _rwRepo;
    private readonly IDragArtboardUserManager _artboardUserManager;

    public ArtboardElementAddingService(IWriteOnlyRepository<ArtboardElement> rwRepo, IDragArtboardUserManager artboardUserManager)
    {
        _rwRepo = rwRepo;
        _artboardUserManager = artboardUserManager;
    }
    public ArtboardElementVm CreateNew(ArtboardElementIm artboardElementIm)
    {
        //todo security
        var currentUser = _artboardUserManager.GetCurrentUser();
        var result = _rwRepo.InsertData(new ArtboardElement()
        {
            CreatedByGuid = currentUser.Guid,
            ArtboardGuid = artboardElementIm.ArtboardGuid,
            ArtboardToolboxElementGuid = artboardElementIm.ArtboardToolboxElementGuid,
            CreatedDate = DateTime.Now,
            CustomSerializedObject = artboardElementIm.CustomSerializedObject,
            ElementPropertiesHash = artboardElementIm.ElementPropertiesHash,
            Height =  artboardElementIm.Height,
            Width = artboardElementIm.Width,
            LocationX = artboardElementIm.LocationX,
            LocationY = artboardElementIm.LocationY,
            LocationZ = artboardElementIm.LocationZ,
            ZIndex = artboardElementIm.ZIndex
        });

        return new ArtboardElementVm(result, currentUser);
    }
}