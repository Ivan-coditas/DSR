using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Manager
{
    public class TimeSheetManager
    {
        DSRContext dSRContext = new DSRContext();

        public TimeSheet Add(TimeSheet timeSheet)
        {
            dSRContext.timeSheets.Add(timeSheet);
            dSRContext.SaveChanges();
            return timeSheet;
        }

        public TimeSheet Update(TimeSheet timeSheet)
        {
            var result=dSRContext.timeSheets.Where(o => o.Id == timeSheet.Id).First();
            result.Id = timeSheet.Id;
            result.Date = timeSheet.Date;
            result.Project = timeSheet.Project;
            result.Description = timeSheet.Description;
            result.DueDate = timeSheet.DueDate;
            dSRContext.SaveChanges();
            return timeSheet;
        }

        public void Delete(int Id)
        {
            var result=dSRContext.timeSheets.Where(o => o.Id == Id).FirstOrDefault();
            dSRContext.timeSheets.Remove(result);
            dSRContext.SaveChanges();
        }

        public List<TimeSheet> GetTimeSheet()
        {
            return dSRContext.timeSheets.ToList();
        }
    }
}
