using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sampleService.Model;

namespace sampleService.Data
{
    public class sampleServiceContext : DbContext
    {
        public sampleServiceContext (DbContextOptions<sampleServiceContext> options)
            : base(options)
        {
        }

        public DbSet<sampleService.Model.Employee> Employee { get; set; } = default!;
    }
}
