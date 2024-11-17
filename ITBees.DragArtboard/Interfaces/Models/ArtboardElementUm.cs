using ITBees.DragArtboard.Models;

namespace ITBees.DragArtboard.Interfaces.Models;

public class ArtboardElementUm
{
    public Guid Guid { get; set; }
    public string CustomSerializedObject { get; set; }
    public int LocationX { get; set; }
    public int LocationY { get; set; }
    public int LocationZ { get; set; }
    public int ZIndex { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
}