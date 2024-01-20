using ITBees.DragArtboard.Interfaces;
using ITBees.DragArtboard.Interfaces.Models;
using ITBees.DragArtboard.Models;
using ITBees.Interfaces.Repository;

namespace ITBees.DragArtboard.Services;

class ArtboardToolboxElementAddingService : IArtboardToolboxElementAddingService
{
    private readonly IWriteOnlyRepository<ArtboardToolboxElement> _rwRepo;
    private readonly IDragArtboardUserManager _artboardUserManager;

    public ArtboardToolboxElementAddingService(IWriteOnlyRepository<ArtboardToolboxElement> rwRepo, IDragArtboardUserManager artboardUserManager)
    {
        _rwRepo = rwRepo;
        _artboardUserManager = artboardUserManager;
    }
    public ArtboardToolboxElementVm CreateNew(ArtboardToolboxElementIm im)
    {
        //todo security
        var currentUser = _artboardUserManager.GetCurrentUser();
        var result = _rwRepo.InsertData(new ArtboardToolboxElement()
        {
            IsActive = im.IsActive,
            CreatedByGuid = currentUser.Guid,
            CreatedDate = DateTime.Now,
            CustomCss = im.CustomCss,
            CustomHtml = im.CustomHtml,
            DisplayName = im.DisplayName,
            ElementType = im.ElementType,
            ElementTypeId = im.ElementTypeId,
            Header = im.Header,
            ImageUrl = im.ImageUrl,
            IsEnabled = im.IsEnabled,
            TooltipText = im.TooltipText
        });

        return new ArtboardToolboxElementVm(result, currentUser);
    }
}