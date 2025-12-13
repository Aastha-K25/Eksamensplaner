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

        public SkemaStuderende(IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            _repository = new RegistreretEksamenRepository(connectionString);
            EksamenForStuderende = new List<RegistreretEksamen>();
        }

        public void OnGet()
        {
            EksamenForStuderende = _repository.GetForStuderende("DAT-RO-F-V25B");
        }
    }
}