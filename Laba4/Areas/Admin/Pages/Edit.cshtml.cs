using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using laba_1.DAL.Data;
using laba_1.DAL.Entities;

namespace laba_1.Areas.Admin.Pages
{
    public class EditModel : PageModel
    {
        private readonly laba_1.DAL.Data.ApplicationDbContext _context;

        public EditModel(laba_1.DAL.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Ajax Ajax { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Ajax = await _context.Ajaxes
                .Include(a => a.Group).FirstOrDefaultAsync(m => m.DivicesID == id);

            if (Ajax == null)
            {
                return NotFound();
            }
           ViewData["AjaxGroupId"] = new SelectList(_context.AjaxGroups, "AjaxGroupId", "AjaxGroupId");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Ajax).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AjaxExists(Ajax.DivicesID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AjaxExists(int id)
        {
            return _context.Ajaxes.Any(e => e.DivicesID == id);
        }
    }
}
