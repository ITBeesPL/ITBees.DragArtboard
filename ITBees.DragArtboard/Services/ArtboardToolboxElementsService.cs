using ITBees.DragArtboard.Interfaces;
using ITBees.DragArtboard.Interfaces.Models;
using ITBees.DragArtboard.Models;
using ITBees.Interfaces.Repository;

namespace ITBees.DragArtboard.Services;

class ArtboardToolboxElementsService : IArtboardToolboxElementsService
{
    private readonly IReadOnlyRepository<ArtboardToolboxElement> _roRepo;
    private readonly IDragArtboardUserManager _artboardUserManager;

    public ArtboardToolboxElementsService(IReadOnlyRepository<ArtboardToolboxElement> roRepo, IDragArtboardUserManager artboardUserManager)
    {
        _roRepo = roRepo;
        _artboardUserManager = artboardUserManager;
    }
    public ArtboardToolboxElementVm Get(Guid guid)
    {
        //todo security
        return new ArtboardToolboxElementVm(_roRepo.GetData(x=>x.Guid == guid).FirstOrDefault());
    }
}