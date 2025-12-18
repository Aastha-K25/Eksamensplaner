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

        public EksamenAdmin(IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            _repository = new RegistreretEksamenRepository(connectionString);
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
            e.MaalGruppe = "Lærer";
            
            string datoText = Request.Form["teacher-date"];
            DateTime dato;
            if (DateTime.TryParse(datoText, out dato))
            {
                e.Dato = dato;
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Du skal vælge en dato.");
                return Page();
            }
            
            TimeSpan startTid;
            if (TimeSpan.TryParse(Request.Form["teacher-starttime"], out startTid))
            {
                e.StartTid = startTid;
            }

            TimeSpan slutTid;
            if (TimeSpan.TryParse(Request.Form["teacher-endtime"], out slutTid))
            {
                e.SlutTid = slutTid;
            }
            
            int antal;
            if (int.TryParse(Request.Form["teacher-antal"], out antal))
            {
                e.AntalStuderende = antal;
            }

            
            e.HarTilsyn = Request.Form["teacher-tilsyn"].Count > 0;

            _repository.Add(e);

            return RedirectToPage("SkemaLaerer");
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
            e.MaalGruppe = "Studerende";
            
            string datoText = Request.Form["student-date"];
            DateTime dato;
            if (DateTime.TryParse(datoText, out dato))
            {
                e.Dato = dato;
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Du skal vælge en dato.");
                return Page();
            }
            
            TimeSpan tidspunkt;
            if (TimeSpan.TryParse(Request.Form["student-time"], out tidspunkt))
            {
                e.Tidspunkt = tidspunkt;
            }
            
            e.HarTilsyn = Request.Form["student-tilsyn"].Count > 0;

            _repository.Add(e);

            return RedirectToPage("SkemaStuderende");
        }
    }
}
