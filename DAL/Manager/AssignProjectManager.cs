using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Manager
{
    public class AssignProjectManager
    {
        DSRContext dSRContext = new DSRContext();

        public AssignProjects Add(AssignProjects projectTeam)
        {
            dSRContext.assignProjects.Add(projectTeam);
            dSRContext.SaveChanges();
            return projectTeam;
        }

        public AssignProjects Update(AssignProjects projectTeam)
        {
            AssignProjects pro = dSRContext.assignProjects.Where(o => o.Id == projectTeam.Id).First();
            pro.UserId = projectTeam.UserId;
            pro.ProjectId = projectTeam.ProjectId;
            pro.Description = projectTeam.Description;
            pro.IsActive = projectTeam.IsActive;
            dSRContext.SaveChanges();
            return projectTeam;
        }


        public void Delete(int Id)
        {
            AssignProjects pro=  dSRContext.assignProjects.Where(o => o.Id == Id).First();
            dSRContext.assignProjects.Remove(pro);
            dSRContext.SaveChanges();
        }

        public List<AssignProjects> GetProjectTeams()
        {
            return (from ap in dSRContext.assignProjects.ToList()
                    join
                    u in dSRContext.users.ToList()
                    on
                    ap.UserId equals u.Id
                    join
                    p in dSRContext.projects.ToList()
                    on
                    ap.ProjectId equals p.Id
                    select new AssignProjects
                    {
                        Id=ap.Id,
                        ProjectId=ap.ProjectId,
                        UserId=ap.UserId,
                        Description=ap.Description,
                        IsActive=ap.IsActive,
                        UserName=u.UserName,
                        ProjectName=p.Name,
                        Active= ap.IsActive == true ? "Active" : "InActive"

                    }
                   ).ToList();
        }       
    }
}
