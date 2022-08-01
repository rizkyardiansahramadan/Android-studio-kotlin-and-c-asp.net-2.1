using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Osis.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Credential Credential { get; set; }
        public void OnGet()
        {
        }
        public string Message { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid) return Page();
            if (Credential.UserName == "admin" && Credential.Password == "kelompokuas")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, "admin")
                };
                var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);

                return RedirectToPage("/Index");
            }
            Message = "Your application description page.";
            return Page();

        }
    }


    public class Credential
    {
        public static object Identity { get; internal set; }
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
 }

