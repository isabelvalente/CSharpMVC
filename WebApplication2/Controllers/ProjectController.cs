using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ProjectController : Controller
    {
        ObjectCache cache = MemoryCache.Default;
        List<Project> projects;

        public ProjectController()
        {
            projects = cache["projects"] as List<Project>;
            if (projects == null)
            {
                projects = new List<Project>();
            }
        }

        public void SaveCache()
        {
            cache["projects"] = projects;
        }

        // GET: Project
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewProject(string id)
        {
            Project project = projects.FirstOrDefault(c => c.Id == id);
            if(project == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(project);
            }

            
        }

        public ActionResult AddProject()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddProject(Project project)
        {
            project.Id = Guid.NewGuid().ToString();
            projects.Add(project);
            SaveCache();

            return RedirectToAction("ProjectList");
        }

        public ActionResult EditProject(string id)
        {
            Project project = projects.FirstOrDefault(c => c.Id == id);
            if (project == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(project);
            }

        }

        [HttpPost]
        public ActionResult EditProject(Project project, string id)
        {
            var projectToEdit = projects.FirstOrDefault(c => c.Id == id);

            if (project == null)
            {
                return HttpNotFound();
            }
            else
            {
                projectToEdit.Name = project.Name;
                projectToEdit.RepositoryLink = project.RepositoryLink;
                projectToEdit.Language = project.Language;
                SaveCache();

                return RedirectToAction("ProjectList");
            }
        }

        public ActionResult DeleteProject(string id)
        {
            Project project = projects.FirstOrDefault(c => c.Id == id);
            if (project == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(project);
            }
        }

        [HttpPost]
        [ActionName("DeleteProject")]
        public ActionResult ConfirmDeleteProject(string id)
        {
            Project project = projects.FirstOrDefault(c => c.Id == id);
            if (project == null)
            {
                return HttpNotFound();
            }
            else
            {
                projects.Remove(project);
                return RedirectToAction("ProjectList");
            }
        }

        public ActionResult ProjectList()
        {
             return View(projects);
        }
    }


}