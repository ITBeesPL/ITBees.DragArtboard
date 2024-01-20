using ITBees.DragArtboard.Models;
using ITBees.Models.Users;

namespace ITBees.DragArtboard.Interfaces.Models;

public class ArtboardVm
{
    public ArtboardVm()
    {
        
    }

    public ArtboardVm(Artboard x, CurrentUser currentUser = null)
    {
        if (x.CreatedBy == null)
        {
            CreatedBy = currentUser?.DisplayName;
        }
        else
        {
            CreatedBy = x.CreatedBy.DisplayName;
        }

        Guid = x.Guid;
        ArtboardOwnerGuid = x.ArtboardOwnerGuid;
        ArtboardName = x.ArtboardName;
        ArtboardType = x.ArtboardType;
        BackgroundImagePositionX = x.BackgroundImagePositionX;
        BackgroundImagePositionY = x.BackgroundImagePositionY;
        BackgroundImageUrl = x.BackgroundImageUrl;
        BackgroundImageZoom = x.BackgroundImageZoom;
        ControlButtonsVisible = x.ControlButtonsVisible;
        Created = x.Created;
        Guid = x.CreatedByGuid;
        DragEnabled = x.DragEnabled;
        IsActive = x.IsActive;
        MeshEnabled = x.MeshEnabled;
        ShowToolbox = x.ShowToolbox;
        Zoom = x.Zoom;
    }

    public Guid Guid { get; set; }
    public string CreatedBy { get; set; }
    public DateTime Created { get; set; }
    public Guid ArtboardOwnerGuid { get; set; }
    public bool MeshEnabled { get; set; }
    public bool DragEnabled { get; set; }
    public bool ShowToolbox { get; set; }
    public bool ControlButtonsVisible { get; set; }
    public string BackgroundImageUrl { get; set; }
    public int BackgroundImageZoom { get; set; }
    public int BackgroundImagePositionX { get; set; }
    public int BackgroundImagePositionY { get; set; }
    public int Zoom { get; set; }
    public bool IsActive { get; set; }
    public string? ArtboardName { get; set; }
    public int ArtboardType { get; set; }
}