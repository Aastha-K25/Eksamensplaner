namespace Eksamensplaner.Core.Models;

public class  RegistreretEksamen
{
    public string HoldId { get; set; }
    public string Navn { get; set; }
    public string ProeveNavn { get; set; }
    public string Form { get; set; }
    public string EksamensType { get; set; }
    public string Rolle { get; set; }

    public System.DateTime Dato { get; set; }

    public System.TimeSpan? StartTid { get; set; }
    public System.TimeSpan? SlutTid { get; set; }
    public System.TimeSpan? Tidspunkt { get; set; }

    public int? AntalStuderende { get; set; }
    public bool HarTilsyn { get; set; }

    public string MaalGruppe { get; set; }
}