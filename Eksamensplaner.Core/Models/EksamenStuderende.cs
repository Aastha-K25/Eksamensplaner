namespace Eksamensplaner.Core.Models;

public class EksamenStruderende
{
    public int EksamenStuderendeId { get; set; }
    public int EksamenId { get; set; }
    public int StuderendeId { get; set; }
    public DateTime EksamenTidspunkt { get; set; }
    public bool HarAfleveret {get; set;}
    public DateTime? AfleveretDato { get; set; }
}