using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Osis.Model;

namespace Osis.Pages
{
    public class DataJsonModel : PageModel
    {
        public String Message { get; set; }
        public void OnPost()
        {
            Message = "Your application description page.";
        }
        public JsonResult OnGet()
        {
            ProsesOsis proses = new ProsesOsis();
            var ProsesOsis = proses.getOsis();
            return new JsonResult(new { data = ProsesOsis.ToList(), status = "OK" });
        }
    }
}
