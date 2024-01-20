using ITBees.DragArtboard.Interfaces;
using ITBees.DragArtboard.Models;
using ITBees.Interfaces.Repository;

namespace ITBees.DragArtboard.Services;

class ArtboardToolboxElementDeleteService : IArtboardToolboxElementDeleteService
{
    private readonly IWriteOnlyRepository<ArtboardToolboxElement> _rwRepo;

    public ArtboardToolboxElementDeleteService(IWriteOnlyRepository<ArtboardToolboxElement> rwRepo)
    {
        _rwRepo = rwRepo;
    }
    public void Delete(Guid guid)
    {
        //todo add security
        _rwRepo.DeleteData(x => x.Guid == guid);
    }
}