using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Eksamensplaner.Pages;

public class LogInd : PageModel
{
    public void OnGet()
    {
        
    }

    public IActionResult OnPostStudentLogIn()
    {
        return RedirectToPage("SkemaStuderende");
    }

    public IActionResult OnPostTeacherLogIn()
    {
        return RedirectToPage("SkemaLaerer");
    }

    public IActionResult OnPostAdminLogin()
    {
        return RedirectToPage("EksamenAdmin");
    }
}