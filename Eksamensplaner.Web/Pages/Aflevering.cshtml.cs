using Microsoft.AspNetCore.Mvc.RazorPages;
using Eksamensplaner.Core.ViewModels;
using Eksamensplaner.Infrastructure.Repositories;

namespace Eksamensplaner.Pages
{
    public class AfleveringModel : PageModel
    {
        public List<AfleveringElevViewModel> Elever { get; set; }

        private readonly EksamenDetaljerRepository _repo;

        public AfleveringModel(EksamenDetaljerRepository repo)
        {
            _repo = repo;
        }

        public void OnGet(int afleveringId)
        {
            Elever = _repo.GetAfleveringForHold(afleveringId);
        }
    }
}
