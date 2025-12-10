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

        public void OnGet(string holdId = "DAT-RO-F-V25B")
        {
            EksamenerForStuderende = EksamenRepository.GetForStuderende(holdId);
        }
    }
}