using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Eksamensplaner.Core.Models;
using Eksamensplaner.Infrastructure.Repositories;

namespace Eksamensplaner.Pages
{
    public class EksamenAdmin : PageModel
    {
        private readonly RegistreretEksamenRepository _repository;

        public EksamenAdmin(RegistreretEksamenRepository repository)
        {
            _repository = repository;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPostTeacher()
        {
            RegistreretEksamen e = new RegistreretEksamen();

            e.HoldId = Request.Form["teacher-holdid"];
            e.Navn = Request.Form["UnderviserNavn"];
            e.ProeveNavn = Request.Form["teacher-proevenavn"];
            e.Form = Request.Form["teacher-form"];
            e.EksamensType = Request.Form["teacher-type"];
            e.Rolle = Request.Form["teacher-role"];

            e.Dato = DateTime.Parse(Request.Form["teacher-date"]);

            e.StartTid = ParseTime(Request.Form["teacher-starttime"]);
            e.SlutTid = ParseTime(Request.Form["teacher-endtime"]);

            e.AntalStuderende = ParseNullableInt(Request.Form["teacher-antal"]);
            e.HarTilsyn = Request.Form["teacher-tilsyn"] == "on";

            e.MaalGruppe = "Lærer";

            _repository.Add(e);
            return RedirectToPage();
        }

        public IActionResult OnPostStudent()
        {
            RegistreretEksamen e = new RegistreretEksamen();

            e.HoldId = Request.Form["student-holdid"];
            e.Navn = Request.Form["Student-name"];
            e.ProeveNavn = Request.Form["student-proevenavn"];
            e.Form = Request.Form["student-form"];
            e.EksamensType = Request.Form["student-type"];

            e.Rolle = "Studerende";
            e.Dato = DateTime.Parse(Request.Form["student-date"]);
            e.Tidspunkt = ParseTime(Request.Form["student-time"]);

            e.HarTilsyn = Request.Form["student-tilsyn"] == "on";
            e.MaalGruppe = "Studerende";

            _repository.Add(e);
            return RedirectToPage();
        }

        private TimeSpan? ParseTime(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }
            return TimeSpan.Parse(value);
        }

        private int? ParseNullableInt(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }

            int result;
            if (int.TryParse(value, out result))
            {
                return result;
            }

            return null;
        }
    }
}
