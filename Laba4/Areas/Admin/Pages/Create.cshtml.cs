using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using laba_1.DAL.Data;
using laba_1.DAL.Entities;

namespace laba_1.Areas.Admin.Pages
{
    public class CreateModel : PageModel
    {
        private readonly laba_1.DAL.Data.ApplicationDbContext _context;

        public CreateModel(laba_1.DAL.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["AjaxGroupId"] = new SelectList(_context.AjaxGroups, "AjaxGroupId", "AjaxGroupId");
            return Page();
        }

        [BindProperty]
        public Ajax Ajax { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Ajaxes.Add(Ajax);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}