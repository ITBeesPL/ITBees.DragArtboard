using ITBees.DragArtboard.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ITBees.DragArtboard.Services;

public class Dependencies
{
    public static void Register(IServiceCollection services, IConfigurationRoot configurationRoot)
    {
        if(services.Any(descriptor =>
            descriptor.ServiceType == typeof(IDragArtboardUserManager)) == false)
        {
            throw new Exception($"You must create implementation for IDragArtboardUserManager - it could base on IAspCurrentUserService.");
        };
    }
}