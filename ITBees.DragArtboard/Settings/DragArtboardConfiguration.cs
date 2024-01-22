using ITBees.DragArtboard.Interfaces;

namespace ITBees.DragArtboard.Settings;

public class DragArtboardConfiguration : IDragArtboardConfiguration
{
    public DragArtboardConfiguration(ModelBuilderConfiguration modelBuilderConfiguration)
    {
        ModelBuilderConfiguration = modelBuilderConfiguration;
    }
    public ModelBuilderConfiguration ModelBuilderConfiguration { get; set; }
}