using System.Collections.Generic;
using System.Security;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Eksamensplaner.Data;
using Eksamensplaner.Models;


namespace Eksamensplaner.Pages
{
    public class SkemaLaerer : PageModel
    {
        public List<Eksamen> EksamenerForLaerer { get; set; }

        public void OnGet(string holdId = "DAT-RO-F-V25B")
        {
            EksamenerForLaerer = EksamenRepository.GetForLaerer("holdId");
        }
    }
}