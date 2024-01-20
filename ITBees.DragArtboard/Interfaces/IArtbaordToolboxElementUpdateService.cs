using ITBees.DragArtboard.Interfaces.Models;
using ITBees.DragArtboard.Models;
using ITBees.Interfaces.Repository;

namespace ITBees.DragArtboard.Interfaces;

public interface IArtbaordToolboxElementUpdateService
{
    ArtboardToolboxElementVm Update(ArtboardToolboxElementUm um);
}

class ArtbaordToolboxElementUpdateService : IArtbaordToolboxElementUpdateService
{
    private readonly IWriteOnlyRepository<ArtboardToolboxElement> _rwRepo;

    public ArtbaordToolboxElementUpdateService(IWriteOnlyRepository<ArtboardToolboxElement> rwRepo)
    {
        _rwRepo = rwRepo;
    }
    public ArtboardToolboxElementVm Update(ArtboardToolboxElementUm um)
    {
        //TODO add security
        var result =_rwRepo.UpdateData(x => x.Guid == um.Guid, x =>
        {
            x.IsActive = um.IsActive;
            x.CustomCss = um.CustomCss;
            x.CustomHtml = um.CustomHtml;
            x.DisplayName = um.DisplayName;
            x.ElementType= um.ElementType;
            x.ElementTypeId = um.ElementTypeId;
            x.Header = um.Header;
            x.ImageUrl = um.ImageUrl;
            x.TooltipText = um.TooltipText;
            x.IsEnabled = um.IsEnabled;
        }, x=>x.CreatedBy, x=>x.CreatedBy.Language).ToList();
        if (result.Any())
        {
            return new ArtboardToolboxElementVm(result.FirstOrDefault());
        }
        else
        {
            throw new Exception($"Element not found");
        }
    }
}