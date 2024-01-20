using ITBees.DragArtboard.Models;
using Microsoft.EntityFrameworkCore;

namespace ITBees.DragArtboard.Services;

public class DbModelBuilder
{
    public static void Register(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Artboard>().HasKey(x => x.Guid);
    }

}
