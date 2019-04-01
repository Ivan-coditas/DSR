using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    public class Users
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string LoginId { get; set; }
        public string EmailId { get; set; }

        public string Password { get; set; }
        public int RoleId { get; set; }
        public int ReportingId { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
