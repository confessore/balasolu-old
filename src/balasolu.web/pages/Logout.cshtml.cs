using balasolu.web.models.abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace balasolu.web.pages
{
    public class LogoutModel : PageModel
    {
        readonly SignInManager<User> _signInManager;

        public LogoutModel(
            SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult OnGet()
        {
            return Redirect("/");
        }

        public async Task<IActionResult> OnPost()
        {
            await _signInManager.SignOutAsync();
            return Redirect("/");
        }
    }
}
