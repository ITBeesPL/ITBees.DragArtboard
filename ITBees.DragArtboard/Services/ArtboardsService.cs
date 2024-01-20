using ITBees.DragArtboard.Interfaces;
using ITBees.DragArtboard.Interfaces.Models;
using ITBees.DragArtboard.Models;
using ITBees.Interfaces.Repository;
using ITBees.Models.Users;

namespace ITBees.DragArtboard.Services;

public class ArtboardsService : IArtboardsService
{
    private readonly IDragArtboardUserManager _artboardUserManager;
    private readonly IReadOnlyRepository<Artboard> _artboardRoRepository;

    public ArtboardsService(IDragArtboardUserManager artboardUserManager, IReadOnlyRepository<Artboard> artboardRoRepository)
    {
        _artboardUserManager = artboardUserManager;
        _artboardRoRepository = artboardRoRepository;
    }

    public List<ArtboardVm> GetAllActive(Guid artboardOwnerGuid, int take, int skip)
    {
        if (_artboardUserManager.TryCanIDoForCompany(TypeOfOperation.Ro, artboardOwnerGuid) == false)
        {
            throw new AccessViolationException($"You don't have access to owner of this");
        }

        var result = _artboardRoRepository.GetDataQueryable(x => x.ArtboardOwnerGuid == artboardOwnerGuid, x => x.CreatedBy, x => x.CreatedBy.Language)
               .Skip(skip)
               .Take(take)
               .Select(x => new ArtboardVm(x, null))
               .ToList();
        return result;
    }

    public ArtboardVm Get(Guid guid)
    {
        var result = _artboardRoRepository
            .GetDataQueryable(x => x.Guid == guid, x => x.CreatedBy, x => x.CreatedBy.Language)
            .Select(x => new ArtboardVm(x, null))
            .FirstOrDefault();

        if (result == null)
        {
            throw new Exception($"Missing artboard '{guid}' in repository");
        }

        if (_artboardUserManager.TryCanIDoForCompany(TypeOfOperation.Ro, result.ArtboardOwnerGuid) == false)
        {
            throw new AccessViolationException($"You don't have access to owner of this");
        }
        
        return result;
    }
}