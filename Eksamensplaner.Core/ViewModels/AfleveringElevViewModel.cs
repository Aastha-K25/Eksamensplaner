namespace Eksamensplaner.Core.ViewModels;

public class AfleveringElevViewModel
{
    public string Navn { get; set; }
    public string SkoleEmail { get; set; }
    public bool HarAfleveret { get; set; }
    public DateTime? AfleveretDato { get; set; }
}