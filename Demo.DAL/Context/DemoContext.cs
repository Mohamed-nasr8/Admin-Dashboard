using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DAL.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Demo.DAL.NewFolder;

namespace Demo.DAL.Context
{
    public class DemoContext: IdentityDbContext<ApplicationUser>
    {


        public DemoContext(DbContextOptions<DemoContext> opt) :base(opt)
        {

        }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{

        //    optionsBuilder.UseSqlServer("Server=.;database=DemoDb;Integrated Security=true");


        //}



        public DbSet<Department> Department { get; set; }


        public DbSet<Employee> Employee { get; set; }

        public DbSet<Country> Country { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<District> District { get; set; }



    }
}
