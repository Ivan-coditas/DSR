using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Manager
{
   public class UserRoleManager
    {
        DSRContext dsrContext = new DSRContext();

        public List<UserRole> GetUserRoles()
        {
            return dsrContext.userRole.ToList();
        }
    }
}
