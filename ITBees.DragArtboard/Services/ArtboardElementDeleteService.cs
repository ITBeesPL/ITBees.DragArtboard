using ITBees.DragArtboard.Interfaces;
using ITBees.DragArtboard.Models;
using ITBees.Interfaces.Repository;

namespace ITBees.DragArtboard.Services;

class ArtboardElementDeleteService : IArtboardElementDeleteService
{
    private readonly IWriteOnlyRepository<ArtboardElement> _rwRepo;
    private readonly IDragArtboardUserManager _artboardUserManager;

    public ArtboardElementDeleteService(IWriteOnlyRepository<ArtboardElement> rwRepo, IDragArtboardUserManager artboardUserManager)
    {
        _rwRepo = rwRepo;
        _artboardUserManager = artboardUserManager;
    }
    public void Delete(Guid guid)
    {
        //todo security
        _rwRepo.DeleteData(x => x.Guid == guid);
    }
}