using Eksamensplaner.Core.Models;
using Eksamensplaner.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Eksamensplaner.Pages;

public class EksamenDetaljer : PageModel
{
    private readonly EksamenDetaljerRepository _repository;

    public List<EksamenElevViewModel> Elever {get; set;}

    public EksamenStuderendeModel(EksamenDetaljerRepository repository)
    {
        _repository = repository;
    }

    public void OnGet(int eksamenId)
    {
        Elever = _repository.GetEksamenData(eksamenId);
    }
}