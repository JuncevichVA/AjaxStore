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
    public class IndexModel : PageModel
    {
        private readonly laba_1.DAL.Data.ApplicationDbContext _context;

        public IndexModel(laba_1.DAL.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Ajax> Ajax { get;set; }

        public async Task OnGetAsync()
        {
            Ajax = await _context.Ajaxes
                .Include(a => a.Group).ToListAsync();
        }
    }
}
