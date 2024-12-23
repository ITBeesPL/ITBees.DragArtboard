using ITBees.DragArtboard.Models;
using ITBees.Models.Users;

namespace ITBees.DragArtboard.Interfaces.Models;

public class ArtboardToolboxElementVm
{
    public ArtboardToolboxElementVm()
    {
        
    }
    public ArtboardToolboxElementVm(ArtboardToolboxElement x, CurrentUser currentUser= null)
    {
        if (x.CreatedBy == null)
        {
            this.DisplayName = currentUser?.DisplayName;
        }
        else
        {
            this.DisplayName = x.DisplayName;
        }

        this.Guid = x.Guid;
        this.IsActive = x.IsActive;
        this.CustomCss = x.CustomCss;
        this.CustomHtml = x.CustomHtml;
        
        this.ElementType = x.ElementType;
        this.ElementTypeId = x.ElementTypeId;
        this.Header = x.Header;
        this.ImageUrl = x.ImageUrl;
        this.TooltipText = x.TooltipText;
        this.IsEnabled = x.IsEnabled;
        this.CreatedBy = x.CreatedBy == null ? "" : x.CreatedBy.DisplayName;
        this.CreatedDate = x.CreatedDate;
    }

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
    public string CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
}