using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Eksamensplaner.Data;
using Eksamensplaner.Models;

namespace Eksamensplaner.Pages
{
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

            return Page();
        }

        public IActionResult OnPostStudent()
        {
            Eksamen eksamen = new Eksamen();

            eksamen.HoldId = Request.Form["student-hold"];
            eksamen.ProeveNavn = Request.Form["student-proevenavn"];
            eksamen.Form = Request.Form["student-form"];
            eksamen.EksamensType = Request.Form["student-type"];
            eksamen.Dato = Request.Form["student-date"];
            eksamen.Tidspunkt = Request.Form["student-time"];
            eksamen.AntalStuderende = Request.Form["student-antal"];
            eksamen.HarTilsyn = Request.Form["student-tilsyn"] == "on";
            eksamen.MaalGruppe = "Studerende";

            EksamenRepository.Add(eksamen);

            return Page();
        }
    }
}
