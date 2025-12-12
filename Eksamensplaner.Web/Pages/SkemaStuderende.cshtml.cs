using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Eksamensplaner.Core.Models;
using Eksamensplaner.Infrastructure.Repositories;

namespace Eksamensplaner.Pages
{
    public class SkemaStuderende : PageModel
    {
        private readonly RegistreretEksamenRepository _repository;

        public List<RegistreretEksamen> EksamenForStuderende { get; set; }

        public SkemaStuderende(RegistreretEksamenRepository repository)
        {
            _repository = repository;
            EksamenForStuderende = new List<RegistreretEksamen>();
        }

        public void OnGet(string holdId = "DAT-R0-F-V25B")
        {
            EksamenForStuderende = _repository.GetForStuderende(holdId);
        }
    }
}