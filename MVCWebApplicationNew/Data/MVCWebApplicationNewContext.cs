using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCWebApplicationNew.Models;

namespace MVCWebApplicationNew.Data
{
    public class MVCWebApplicationNewContext : DbContext
    {
        public MVCWebApplicationNewContext (DbContextOptions<MVCWebApplicationNewContext> options)
            : base(options)
        {
        }

        public DbSet<MVCWebApplicationNew.Models.Employee> Employee { get; set; } = default!;
    }
}
