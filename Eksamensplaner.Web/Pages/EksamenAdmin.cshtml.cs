using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Eksamensplaner.Data;
using Eksamensplaner.Models;

namespace Eksamensplaner.Pages;
public class EksamenAdmin : PageModel
{
    public void OnGet()
    {
    }

    public IActionResult OnPostTeacher()
    {
        Eksamen eksamen = new Eksamen();

        eksamen.HoldId = Request.Form["teacher-holdid"];
        eksamen.ProeveNavn = Request.Form["teacher-proevenavn"];
        eksamen.Form = Request.Form["teacher-form"];
        eksamen.EksamensType = Request.Form["teacher-type"];
        eksamen.Rolle = Request.Form["teacher-role"];
        eksamen.Dato = Request.Form["teacher-date"];
        eksamen.StartTid = Request.Form["teacher-starttime"];
        eksamen.SlutTid = Request.Form["teacher-endtime"];
        eksamen.AntalStuderende = Request.Form["teacher-antal"];
        eksamen.HarTilsyn = Request.Form["teacher-tilsyn"] == "on";
        eksamen.MaalGruppe = Request.Form["Underviser"];
        
        EksamenRepository.Add(eksamen);

        return RedirectToPage("SkemaLaerer", new { holdId = eksamen.HoldId });
    }

    public IActionResult OnPostStudent()
    {
        Eksamen eksamen = new Eksamen();
        
        eksamen.HoldId = Request.Form["student-hold"];
    }
}