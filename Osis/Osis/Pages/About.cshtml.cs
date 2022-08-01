using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Osis.Model;

namespace Osis.Pages
{
    public class AboutModel : PageModel
    {
        [BindProperty]
        public List<DataOsis> DataOsis { get; set; }
        public string Message { get; set; }

        public IActionResult OnGet()
        {
            
            ProsesOsis proses = new ProsesOsis();
            DataOsis = proses.getOsis();
            Message = "Your application description page.";
            return Page();
        }
       
    }
}
