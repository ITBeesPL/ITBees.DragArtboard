using ITBees.Models.Users;

namespace ITBees.DragArtboard.Models;

public class ArtboardToolboxElement
{
    public Guid Guid { get; set; }
    public string TooltipText { get; set; }
    public string Header { get; set; }
    public string DisplayName { get; set; }
    public string ElementType { get; set; }
    public int ElementTypeId { get; set; }
    public string ImageUrl { get; set; }
    public string CustomHtml { get; set; }
    public string CustomCss { get; set; }
    public bool IsEnabled { get; set; }
    public bool IsActive { get; set; }
    public UserAccount CreatedBy { get; set; }
    public Guid CreatedByGuid { get; set; }
    public DateTime CreatedDate { get; set; }
}