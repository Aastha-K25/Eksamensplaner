namespace Eksamensplaner.Core.Models;

public class Eksamens
{
    public int EksamenId { get; set; }
    public string FagNavn { get; set; }
    public int HoldId { get; set; }
    public DateTime EksamenDato { get; set; }
}