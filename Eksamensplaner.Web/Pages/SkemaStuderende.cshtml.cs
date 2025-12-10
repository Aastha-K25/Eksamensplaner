using System.Collections.Generic;
using Eksamensplaner.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Eksamensplaner.Models;
using Eksamensplaner.Data;


namespace Eksamensplaner.Pages
{
    public class SkemaStuderende : PageModel
    {
        public List<Eksamen> EksamenForStuderende { get; set; }

        public void OnGet()
        {
            EksamenForStuderende = EksamenRepository.GetForStuderende("DAT-RO-F-V25B");
        }
    }
}