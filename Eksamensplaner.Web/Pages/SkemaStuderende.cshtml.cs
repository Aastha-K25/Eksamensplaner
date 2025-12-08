using System.Collections.Generic;
using Eksamensplaner.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Eksamensplaner.Models;
using Eksamensplaner.Data;


namespace Eksamensplaner.Pages
{
    public class SkemaStuderende : PageModel
    {
        public List<Eksamen> EksamenerForStuderende { get; set; }

        public void OnGet(string holdId)
        {
            if (holdId == null)
            {
                holdId = "";
            }

            EksamenerForStuderende = EksamenRepository.GetForStuderende(holdId);
        }
    }
}