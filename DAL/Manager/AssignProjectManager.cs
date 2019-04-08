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
            dSRContext.projectTeams.Add(projectTeam);
            dSRContext.SaveChanges();
            return projectTeam;
        }

        public AssignProjects Update(AssignProjects projectTeam)
        {
            AssignProjects pro = dSRContext.projectTeams.Where(o => o.UserId == projectTeam.UserId).First();
            pro.UserId = projectTeam.UserId;
            pro.ProjectId = projectTeam.ProjectId;
            pro.IsActive = projectTeam.IsActive;
            dSRContext.SaveChanges();
            return projectTeam;
        }


        public void Delete(int Id)
        {
            AssignProjects pro=  dSRContext.projectTeams.Where(o => o.UserId == Id).First();
            dSRContext.projectTeams.Remove(pro);
            dSRContext.SaveChanges();
        }

        public List<AssignProjects> GetProjectTeams()
        {
            return dSRContext.projectTeams.ToList();
        }       
    }
}
