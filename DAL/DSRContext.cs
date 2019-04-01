using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;


namespace DAL
{
    public class DSRContext:DbContext
    {
        public DbSet<Users> users { get; set; }
        public DbSet<UserRole> userRole { get; set; }
        public DbSet<Projects> projects { get; set; }

    }
}
