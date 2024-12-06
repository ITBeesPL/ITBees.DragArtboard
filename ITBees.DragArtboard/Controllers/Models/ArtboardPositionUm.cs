namespace ITBees.DragArtboard.Controllers.Models;

public class ArtboardPositionUm
{
    public Guid ArtboardGuid { get; set; }
    public decimal BackgroundImageZoom { get; set; }
    public string BackgroundImagePositionX { get; set; }
    public string BackgroundImagePositionY { get; set; }
    public string? ViewBoxData { get; set; }
    public string? ViewBoxX { get; set; }
    public string? ViewBoxY { get; set; }
    public string? ViewBoxWidth { get; set; }
    public string? ViewBoxHeight { get; set; }
}