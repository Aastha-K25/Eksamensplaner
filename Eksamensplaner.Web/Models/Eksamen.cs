using System;
namespace Eksamensplaner.Models;

public class Eksamen
{
   public string HoldId { get; set; }
   public string ProeveNavn { get; set; }
   public string Form { get; set; }
   public string EksamensType { get; set; }
   public string Rolle { get; set; }
   public string Dato { get; set; }
   public string StartTid { get; set; }  // Underviser
   public string SlutTid { get; set; }   // Underviser
   public string Tidspunkt { get; set; } // Studerende
   public string AntalStuderende { get; set; }
   public bool HarTilsyn { get; set; } 
   public string MaalGruppe { get; set; }  // Underviser el. Studerende
}


