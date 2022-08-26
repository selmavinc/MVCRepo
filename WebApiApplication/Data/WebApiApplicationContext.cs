using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiApplication.Model;

namespace WebApiApplication.Data
{
    public class WebApiApplicationContext : DbContext
    {
        public WebApiApplicationContext (DbContextOptions<WebApiApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<WebApiApplication.Model.Order> Order { get; set; } = default!;
    }
}
