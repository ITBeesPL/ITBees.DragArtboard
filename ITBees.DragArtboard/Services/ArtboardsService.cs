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
    private readonly IDragArtboardUserManager _dragArtboardUserManager;

    public ArtboardsService(IDragArtboardUserManager artboardUserManager,
        IReadOnlyRepository<Artboard> artboardRoRepository,
        IDragArtboardUserManager dragArtboardUserManager)
    {
        _artboardUserManager = artboardUserManager;
        _artboardRoRepository = artboardRoRepository;
        _dragArtboardUserManager = dragArtboardUserManager;
    }

    public PaginatedResult<ArtboardVm> GetAllActive(int? page, int? pageSize, string? sortColumn, SortOrder? sortOrder)
    {
        var currentUser = _artboardUserManager.GetCurrentUser();
        var lastUsedCompanyGuid = currentUser.LastUsedCompanyGuid;
        if (_artboardUserManager.TryCanIDoForCompany(TypeOfOperation.Ro, lastUsedCompanyGuid) == false)
        {
            throw new AccessViolationException($"You don't have access to owner of this");
        }

        if (currentUser.UserRoles.Contains("PlatformOperator"))
        {
            var result = _artboardRoRepository.GetDataPaginated(x => true,
                    new SortOptions(page, pageSize, sortColumn, sortOrder),
                    x => x.CreatedBy, x => x.CreatedBy.Language, x => x.Company)
                .MapTo(x => new ArtboardVm(x));

            return result;
        }
        else
        {
            var result = _artboardRoRepository.GetDataPaginated(x => x.CompanyGuid == lastUsedCompanyGuid,
                    new SortOptions(page, pageSize, sortColumn, sortOrder),
                    x => x.CreatedBy, x => x.CreatedBy.Language, x => x.Company)
                .MapTo(x => new ArtboardVm(x));

            return result;
        }
    }

    public ArtboardVm Get(Guid guid)
    {

        var result = _artboardRoRepository
            .GetDataQueryable(x => x.Guid == guid, x => x.CreatedBy, x => x.CreatedBy.Language, x => x.Company)
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