namespace ITBees.DragArtboard.Interfaces.Models;

public class ArtboardIm
{
    public Guid? ArtboardOwnerGuid { get; set; }
    public bool MeshEnabled { get; set; }
    public bool DragEnabled { get; set; }
    public bool ShowToolbox { get; set; }
    public bool ControlButtonsVisible { get; set; }
    public string? BackgroundImageUrl { get; set; }
    public int BackgroundImageZoom { get; set; }
    public int BackgroundImagePositionX { get; set; }
    public int BackgroundImagePositionY { get; set; }
    public int Zoom { get; set; }
    public bool IsActive { get; set; }
    public string? ArtboardName { get; set; }
    public int? ArtboardType { get; set; }
    public Guid? CompanyGuid { get; set; }
    public Guid? BuildingGuid { get; set; }
}