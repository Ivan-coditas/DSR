using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;
using Task = Common.Domain.Task;

namespace DAL
{
    public class DSRContext:DbContext
    {
        public DbSet<Users> users { get; set; }
        public DbSet<UserRole> userRole { get; set; }
        public DbSet<Projects> projects { get; set; }
        public DbSet<AssignProjects> assignProjects { get; set; }
        public DbSet<TimeSheet> timeSheets { get; set; }
        public DbSet<Task> tasks { get; set; }

    }
}
