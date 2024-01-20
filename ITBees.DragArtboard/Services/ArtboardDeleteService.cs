using ITBees.DragArtboard.Interfaces;
using ITBees.DragArtboard.Models;
using ITBees.Interfaces.Repository;

namespace ITBees.DragArtboard.Services;

class ArtboardDeleteService : IArtboardDeleteService
{
    private readonly IWriteOnlyRepository<Artboard> _artboardRwRepository;

    public ArtboardDeleteService(IWriteOnlyRepository<Artboard> artboardRwRepository)
    {
        _artboardRwRepository = artboardRwRepository;
    }
    public void Delete(Guid guid)
    {
        //TODO add security
        _artboardRwRepository.DeleteData(x => x.Guid == guid);
    }
}