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
    public List<ArtboardToolboxElementVm> Get(Guid? guid)
    {
        //todo security
        if (guid == null || guid == new Guid("00000000-0000-0000-0000-000000000000"))
        {
            var elements = _roRepo.GetData(x => true, x=>x.CreatedBy).ToList();
            return elements.Select(x=>new ArtboardToolboxElementVm(x)).ToList();
        }
        var elements2 = _roRepo.GetData(x => x.Guid == guid, x => x.CreatedBy).ToList();
        return elements2.Select(x => new ArtboardToolboxElementVm(x)).ToList();
    }
}