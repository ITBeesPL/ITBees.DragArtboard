using ITBees.DragArtboard.Settings;
using Microsoft.EntityFrameworkCore;

namespace ITBees.DragArtboard.Interfaces;

public class IDragArtboardConfiguration
{
    public ModelBuilderConfiguration ModelBuilderConfiguration { get; set; }
    public Tuple<ModelBuilder, bool> ConfiguredModelBuilder { get; set; }
}