using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Eksamensplaner.Data;
using Eksamensplaner.Models;


namespace Eksamensplaner.Web.Pages
{
    public class SkemaLaerer : PageModel
    {
        public List<Eksamen> EksamenerForLaerer { get; set; }

        public void OnGet(string holdId)
        {
            if (holdId == null)
            {
                holdId = "";
            }

            EksamenerForLaerer = EksamenRepository.GetForLaerer(holdId);
        }
    }
}