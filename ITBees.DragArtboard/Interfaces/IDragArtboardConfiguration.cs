using ITBees.DragArtboard.Settings;
using Microsoft.EntityFrameworkCore;

namespace ITBees.DragArtboard.Interfaces;

public interface IDragArtboardConfiguration
{
    public ModelBuilderConfiguration ModelBuilderConfiguration { get; set; }
}