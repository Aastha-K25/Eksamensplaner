using Eksamensplaner.Core.Models;
using Eksamensplaner.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

public class OversigtModel : PageModel
{
    private readonly ExamRepository _repo;

    public int SemesterFilter { get; set; }
    public string TypeFilter { get; set; }
    public List<Eksamen> Eksamener { get; set; } = new List<Eksamen>();

    public OversigtModel(ExamRepository repo)
    {
        _repo = repo;
        Eksamener = new List<Eksamen>();
        TypeFilter = "";
    }

    public void OnGet(int? semesterFilter, string? typeFilter)
    {
        if (semesterFilter.HasValue)
        {
            SemesterFilter = semesterFilter.Value;
        }
        else
        {
            SemesterFilter = 0;
        }

        if (string.IsNullOrEmpty(typeFilter))
        {
            TypeFilter = "";
        }
        else
        {
            TypeFilter = typeFilter;
        }
        Eksamener=_repo.GetByFilter(SemesterFilter, TypeFilter);
    }
}