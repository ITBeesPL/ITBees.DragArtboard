using ITBees.DragArtboard.Interfaces;
using ITBees.DragArtboard.Interfaces.Models;
using ITBees.DragArtboard.Models;
using ITBees.Interfaces.Repository;

namespace ITBees.DragArtboard.Services;

class ArtboardElementsService : IArtboardElementsService
{
    private readonly IReadOnlyRepository<ArtboardElement> _roRepo;

    public ArtboardElementsService(IReadOnlyRepository<ArtboardElement> roRepo)
    {
        _roRepo = roRepo;
    }

    public List<ArtboardElementVm> GetAllElementsForArtboard(Guid artboardGuid)
    {
        //todo security
        var result = _roRepo.GetData(x => x.ArtboardGuid == artboardGuid,
            x => x.CreatedBy,
            x => x.Artboard,
            x => x.ArtboardToolboxElement,
            x => x.CreatedBy.Language);

        return result.Select(x => new ArtboardElementVm(x)).ToList();
    }

    public ArtboardElementVm Get(Guid guid)
    {
        //todo security
        var result = _roRepo.GetData(x => x.Guid == guid,
            x => x.CreatedBy,
            x => x.Artboard,
            x => x.ArtboardToolboxElement,
            x => x.CreatedBy.Language);
        if (result.Any())
        {
            return result.Select(x => new ArtboardElementVm(x)).FirstOrDefault();
        }
        else
        {
            throw new Exception($"Element not found.");
        }
    }
}