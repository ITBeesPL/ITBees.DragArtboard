using ITBees.DragArtboard.Interfaces;
using ITBees.DragArtboard.Interfaces.Models;
using ITBees.DragArtboard.Models;
using ITBees.Interfaces.Repository;

namespace ITBees.DragArtboard.Services;

class ArtbaordElementUpdateService : IArtbaordElementUpdateService
{
    private readonly IWriteOnlyRepository<ArtboardElement> _rwRepo;
    private readonly IDragArtboardUserManager _artboardUserManager;

    public ArtbaordElementUpdateService(IWriteOnlyRepository<ArtboardElement> rwRepo,
        IDragArtboardUserManager artboardUserManager)
    {
        _rwRepo = rwRepo;
        _artboardUserManager = artboardUserManager;
    }

    public ArtboardElementVm Update(ArtboardElementUm artboardElementUm)
    {
        var currentUser = _artboardUserManager.GetCurrentUser();
        var result = _rwRepo.UpdateData(x => x.Guid == artboardElementUm.Guid,
            x =>
            {
                x.CustomSerializedObject = artboardElementUm.CustomSerializedObject;
                x.ElementPropertiesHash = GetElementPropertiesHash(artboardElementUm);
                x.Height = artboardElementUm.Height;
                x.Width = artboardElementUm.Width;
                x.LocationX = artboardElementUm.LocationX;
                x.LocationY = artboardElementUm.LocationY;
                x.LocationZ = artboardElementUm.LocationZ;
                x.ZIndex = artboardElementUm.ZIndex;
            }, x => x.Artboard,
            x => x.ArtboardToolboxElement,
            x => x.CreatedBy,
            x => x.CreatedBy.Language);

        return new ArtboardElementVm(result.FirstOrDefault(), currentUser);
    }

    private string GetElementPropertiesHash(ArtboardElementUm artboardElementUm)
    {
        return String.Empty;
    }
}