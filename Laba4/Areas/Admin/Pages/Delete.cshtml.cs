using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using laba_1.DAL.Data;
using laba_1.DAL.Entities;

namespace laba_1.Areas.Admin.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly laba_1.DAL.Data.ApplicationDbContext _context;

        public DeleteModel(laba_1.DAL.Data.ApplicationDbContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Ajax = await _context.Ajaxes.FindAsync(id);

            if (Ajax != null)
            {
                _context.Ajaxes.Remove(Ajax);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
