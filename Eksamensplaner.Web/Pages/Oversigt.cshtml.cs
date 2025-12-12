using Eksamensplaner.Core.Models;
using Eksamensplaner.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

public class OversigtModel : PageModel
{
    private readonly ExamRepository _repo;

    public int SemesterFilter { get; set; }
    public List<Eksamen> Eksamener { get; set; }

    public OversigtModel(ExamRepository repo)
    {
        _repo = repo;
        Eksamener = new List<Eksamen>();
    }

    public void OnGet(int? semesterFilter)
    {
        SemesterFilter = semesterFilter.HasValue ? semesterFilter.Value : 0;

        Eksamener = _repo.GetBySemester(SemesterFilter);
    }
}