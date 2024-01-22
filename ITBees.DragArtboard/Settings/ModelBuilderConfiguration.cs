using Microsoft.EntityFrameworkCore;

namespace ITBees.DragArtboard.Settings;

public class ModelBuilderConfiguration
{
    public ModelBuilder ModelBuilder { get; }
    public bool SkipDefaultConfiguration { get; }

    /// <summary>
    /// Wrapping class for database configuration, so You can declare if You know how to configure db models for artboard by Your onw, or want to use default configuration
    /// </summary>
    /// <param name="modelBuilder"></param>
    /// <param name="skipDefaultConfiguration">Set true if You know what are You doing, and You will configure database entities by Your own.</param>
    public ModelBuilderConfiguration(ModelBuilder modelBuilder, bool skipDefaultConfiguration)
    {
        ModelBuilder = modelBuilder;
        SkipDefaultConfiguration = skipDefaultConfiguration;
    }
}