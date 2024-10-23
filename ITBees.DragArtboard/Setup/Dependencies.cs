using ITBees.DragArtboard.Interfaces;
using ITBees.DragArtboard.Services;
using ITBees.FAS.Setup;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ITBees.DragArtboard.Setup;

public class Dependencies : IFasDependencyRegistration
{
    public void Register(IServiceCollection services, IConfigurationRoot configurationRoot)
    {
        if (services.Any(descriptor =>
                descriptor.ServiceType == typeof(IDragArtboardUserManager)) == false)
        {
            throw new Exception($"You must create implementation for IDragArtboardUserManager - it could base on IAspCurrentUserService.");
        };

        services.AddScoped<IArtbaordElementUpdateService, ArtbaordElementUpdateService>();
        services.AddScoped<IArtboardAddingService, ArtboardAddingService>();
        services.AddScoped<IArtboardDeleteService, ArtboardDeleteService>();
        services.AddScoped<IArtboardElementAddingService, ArtboardElementAddingService>();
        services.AddScoped<IArtboardElementDeleteService, ArtboardElementDeleteService>();
        services.AddScoped<IArtboardElementsService, ArtboardElementsService>();
        services.AddScoped<IArtboardsService, ArtboardsService>();
        services.AddScoped<IArtboardToolboxElementAddingService, ArtboardToolboxElementAddingService>();
        services.AddScoped<IArtboardToolboxElementDeleteService, ArtboardToolboxElementDeleteService>();
        services.AddScoped<IArtboardToolboxElementsService, ArtboardToolboxElementsService>();
        services.AddScoped<IArtboardUpdatingService, ArtboardUpdatingService>();

    }
}