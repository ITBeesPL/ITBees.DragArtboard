using ITBees.Models.Users;

namespace ITBees.DragArtboard.Models;

public class ArtboardElement
{
    public Guid Guid { get; set; }
    public ArtboardToolboxElement ArtboardToolboxElement { get; set; }
    public Artboard Artboard{ get; set; }
    public Guid ArtboardGuid{ get; set; }
    public Guid ArtboardToolboxElementGuid { get; set; }
    public UserAccount CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public string CustomSerializedObject { get; set; }
    public int LocationX { get; set; }
    public int LocationY { get; set; }
    public int LocationZ { get; set; }
    public int ZIndex { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public string ElementPropertiesHash { get; set; }
    public Guid CreatedByGuid { get; set; }
}