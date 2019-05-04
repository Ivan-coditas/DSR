using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = Common.Domain.Task;

namespace DAL.Manager
{
   public class TaskManager
    {
        DSRContext dSRContext = new DSRContext();

        public Task Add(Task task)
        {
            dSRContext.tasks.Add(task);
            dSRContext.SaveChanges();
            return task;
        }

        public Task Update(Task task)
        {
            var result=dSRContext.tasks.Where(o => o.Id == task.Id).FirstOrDefault();
            result.Id = task.Id;
            result.ProjectId = task.ProjectId;
            result.TaskName = task.TaskName;
            result.TaskDescription = task.TaskDescription;
            result.DueDate = task.DueDate;
            result.TaskStatus = task.TaskStatus;
            result.IsActive = task.IsActive;
            dSRContext.SaveChanges();
            return task;

        }
        public void Delete(int Id)
        {
            Task task = dSRContext.tasks.Where(o => o.Id == Id).First();
            dSRContext.tasks.Remove(task);
            dSRContext.SaveChanges();
        }

        public List<Task> GetTasks()
        {
            return(from t in dSRContext.tasks.ToList()
                    join
                    p in dSRContext.projects.ToList()
                    on
                    t.ProjectId equals p.Id
                    join
                    u in dSRContext.users.ToList().DefaultIfEmpty()
                    on
                    t.AssignTo equals u.Id
                    
                    
                    select new Task
                    {
                        Id = t.Id,
                        ProjectId = t.ProjectId,
                        TaskName = t.TaskName,
                        TaskDescription = t.TaskDescription,
                        DueDate = t.DueDate,
                        TaskStatus = t.TaskStatus,
                        IsActive = t.IsActive,
                        ProjectName = p.Name,
                        Active = t.IsActive == true ? "Active" : "InActive",
                        StatusName =t.TaskStatus==0 ? "ToDo" : t.TaskStatus==1 ? "InProgress" : t.TaskStatus==2 ? "Complete":""

                    }).ToList();
        }
    }
}
