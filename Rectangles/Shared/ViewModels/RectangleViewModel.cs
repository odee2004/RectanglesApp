using System.ComponentModel.DataAnnotations;

namespace Rectangles.Shared.ViewModels;

public class RectangleViewModel
{
    [Required]
    public int LeftX { get; set; }
    [Required]
    public int LeftY { get; set; }
    [Required]
    public int RightX { get; set; }
    [Required]
    public int RightY { get; set; }
    [Required]
    public string Color { get; set; } = "blue";
}
