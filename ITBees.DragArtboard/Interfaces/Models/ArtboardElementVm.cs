using ITBees.DragArtboard.Models;
using ITBees.Models.Users;

namespace ITBees.DragArtboard.Interfaces.Models;

public class ArtboardElementVm
{
    public ArtboardElementVm()
    {
        
    }
    public ArtboardElementVm(ArtboardElement x, CurrentUser currentUser = null)
    {
        this.ArtboardToolboxElement = new ArtboardToolboxElementVm(x.ArtboardToolboxElement, currentUser);
        this.ArtboardGuid = x.ArtboardGuid;
        this.ArtboardToolboxElementGuid = x.ArtboardToolboxElementGuid;
        this.CustomSerializedObject = x.CustomSerializedObject;
        this.ElementPropertiesHash = x.ElementPropertiesHash;
        this.Height = x.Height;
        this.Width = x.Width;
        this.LocationX = x.LocationX;
        this.LocationY = x.LocationY;
        this.LocationZ = x.LocationZ;
        if (x.CreatedBy == null)
        {
            this.CreatedBy = currentUser.DisplayName;
        }
        else
        {
            this.CreatedBy = x.CreatedBy.DisplayName;
        }
        this.ZIndex = x.ZIndex;
    }
    
    public Guid Guid { get; set; }
    public ArtboardToolboxElementVm ArtboardToolboxElement { get; set; }
    public Guid ArtboardGuid { get; set; }
    public Guid ArtboardToolboxElementGuid { get; set; }
    public string CreatedBy { get; set; }
    public string CreatedDate { get; set; }
    public string CustomSerializedObject { get; set; }
    public int LocationX { get; set; }
    public int LocationY { get; set; }
    public int LocationZ { get; set; }
    public int ZIndex { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public string ElementPropertiesHash { get; set; }
}