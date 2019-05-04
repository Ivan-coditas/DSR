using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
  public  class TimeSheet
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Project { get; set; }
        public string Description { get; set; }

        public DateTime DueDate { get; set; }
    }
}
