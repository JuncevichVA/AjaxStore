using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using laba_1.DAL.Entities;

namespace laba_1.DAL.Data
{
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {


        }

        public DbSet<Ajax> Ajaxes { get; set; }
        public DbSet<AjaxGroup> AjaxGroups { get; set; }
    }
}
