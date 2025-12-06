namespace Eksamensplaner.Core.ViewModels;

public class EksamenElevViewModel
{
    public int StuderendeId { get; set; }
    public string Navn { get; set; }
    public string SkoleMail { get; set; }
    public DateTime? EksamenTidspunkt { get; set; }
    public bool HarAfleveret { get; set; }
    public DateTime? AfleveretDato { get; set; }
}