using Microsoft.AspNetCore.Mvc.RazorPages;
using Eksamensplaner.Core.Models;
using Eksamensplaner.Infrastructure.Repositories;
using System.Collections.Generic;

namespace Eksamensplaner.Pages
{
    public class SkemaLaerer : PageModel
    {
        private readonly RegistreretEksamenRepository _repository;

        public List<RegistreretEksamen> EksamenerForLaerer { get; set; }

        public SkemaLaerer(IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            _repository = new RegistreretEksamenRepository(connectionString);
            EksamenerForLaerer = new List<RegistreretEksamen>();
        }

        public void OnGet(string holdId = "DAT-RO-F-V25B")
        {
            EksamenerForLaerer = _repository.GetForLaerer(holdId);
        }
    }
}