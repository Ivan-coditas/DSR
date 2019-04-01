using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    [Table("UserRole")]
    public class UserRole
    {
        public int Id { get; set; }
        public string Role { get; set; }
        public string Description { get; set; }
    }

}
