using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Osis.Model;

namespace Osis.Pages
{
    public class OsisAddModel : PageModel
    {
       
        KonekDb db = new KonekDb();
        [BindProperty]
        public DataOsis tw { get; set; }
        public IActionResult OnGet(string action, string id)
        {
            if (action != null && id != null)
            {
                ProsesOsis proses = new ProsesOsis();
                switch (action.ToUpper())
                {
                    case "EDIT":
                        tw = proses.getOsisById(id);
                        break;
                    case "DELETE":
                        if (proses.deleteOsis(id))
                        {
                            return new RedirectToPageResult("/About");
                        }
                        break;
                    default:
                        break;

                }

            }
            return Page();
        }
        public IActionResult OnPost()
        {
            ProsesOsis proses = new ProsesOsis();
            if (tw.id != 0)
            {
                if (proses.UpdateOsis(tw))
                {
                    return new RedirectToPageResult("/About");
                }
            }
            else
            {
                if (proses.saveOsis(tw))
                {
                    return new RedirectToPageResult("/About");
                }
            }
            return Page();
        }
    }
}
