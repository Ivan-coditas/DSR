using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;


namespace DAL.Manager
{
   public class ProjectsManager
    {
        DSRContext dSRContext = new DSRContext();

        public Projects Add(Projects project)
        {
            dSRContext.projects.Add(project);
            dSRContext.SaveChanges();
            return project; 
        }

        public void Update(Projects projects)
        {
            Projects pro = dSRContext.projects.Where(o => o.Id == projects.Id).First();
            pro.Id = projects.Id;
            pro.Name = projects.Name;
            pro.Description = projects.Description;
            pro.IsActive = projects.IsActive;
            dSRContext.SaveChanges();

        }
         public void Delete(int Id)
        {
            Projects pro = dSRContext.projects.Where(o => o.Id == Id).First();
            dSRContext.projects.Remove(pro);
            dSRContext.SaveChanges();
        }

        public List<Projects> GetProjects()
        {
            return dSRContext.projects.ToList();
        }



    }
}
