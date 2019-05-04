using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    [Table("Task")]

    public class Task
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public DateTime DueDate { get; set; }
        public int TaskStatus { get; set; }
        public bool IsActive { get; set; }
        public int AssignTo { get; set; }

        [NotMapped]
        public string ProjectName { get; set; }
        [NotMapped]
        public string Active { get; set; }
        [NotMapped]
        public string StatusName { get; set; }
    }
}
