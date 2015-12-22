using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWAT.DB
{
    class ProjectController : DbController
    {

        public ProjectController() : base() { }
        public ProjectController(NWATDataContext dataContext)
            : base(dataContext) { }

       

        /// <summary>
        /// Gets the project by identifier from db.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// An instance of 'Project'
        /// </returns>
        /// Erstellt von Joshua Frey, am 14.12.2015
        public Project GetProjectById(int id)
        {
            Project resultProject;

            using (NWATDataContext dataContext = new NWATDataContext())
            {
                resultProject = base.DataContext.Project.SingleOrDefault(project => project.Project_Id == id);
            }
            return resultProject;
        }

        /// <summary>
        /// Gets all projects from database.
        /// </summary>
        /// <returns>
        ///  A linq table object with all projects from db
        /// </returns>
        /// Erstellt von Joshua Frey, am 14.12.2015
        public List<Project> GetAllProjectsFromDB()
        {
            List<Project> projects;
            projects = base.DataContext.Project.ToList();
            return projects;
        }

        /// <summary>
        /// Inserts the project into database.
        /// </summary>
        /// <param name="newProject">The new project.</param>
        /// <returns></returns>
        /// Erstellt von Joshua Frey, am 14.12.2015
        /// <exception cref="DatabaseException">
        /// Das Projekt mit dem Namen -Projektname- existiert bereits in einem anderen Datensatz in der Datenbank.
        /// or
        /// Das Projekt konnte nicht in der Datenbank angelegt werden. 
        /// Bitte überprüfen Sie das übergebene Projekt Objekt.
        /// </exception>
        public bool InsertProjectIntoDb(Project newProject)
        {
            if (newProject != null)
            {
                string newProjectName = newProject.Name;
                if (!CheckIfProjectNameAlreadyExists(newProjectName))
                {
                    base.DataContext.Project.InsertOnSubmit(newProject);
                    base.DataContext.SubmitChanges();
                }
                else
                {
                    throw (new DatabaseException(MessageProjectAlreadyExists(newProjectName)));
                }
            }
            else
            {
                throw (new DatabaseException(MessageProjectCouldNotBeSavedEmptyObject()));
            }

            Project newProjectFromDb = (from crit in base.DataContext.Project
                                            where crit.Name == newProject.Name
                                            && crit.Description == newProject.Description
                                            select crit).FirstOrDefault();

            return CheckIfEqualProjects(newProject, newProjectFromDb);
        }

        /// <summary>
        /// Updates the project in database.
        /// </summary>
        /// <param name="alteredProject">The altered project.</param>
        /// <returns></returns>
        /// Erstellt von Joshua Frey, am 14.12.2015
        /// <exception cref="DatabaseException">
        /// Das Projekt mit dem Namen -Projektname- existiert bereits in einem anderen Datensatz in der Datenbank.
        /// or
        /// Das Projekt konnte nicht in der Datenbank angelegt werden. 
        /// Bitte überprüfen Sie das übergebene Projekt Objekt.
        /// or 
        /// Das Project Object besitzt keine ID. Bitte überprüfen Sie das übergebene Object
        /// </exception>
        public bool UpdateProjectInDb(Project alteredProject)
        {
            if (!CheckIfProjectHasAnId(alteredProject))
                throw (new DatabaseException(MessageProjectHasNoId()));

            int projectId = alteredProject.Project_Id;
            Project projToUpdateFromDb = base.DataContext.Project.SingleOrDefault(proj => proj.Project_Id == projectId);

            if (projToUpdateFromDb != null)
            {
                string newProjectName = alteredProject.Name;
                if (!CheckIfProjectNameAlreadyExists(newProjectName, projectId))
                {
                    projToUpdateFromDb.Name = alteredProject.Name;
                    projToUpdateFromDb.Description = alteredProject.Description;
                }
                else
                {
                    throw (new DatabaseException(MessageProjectAlreadyExists(newProjectName)));
                }
            }
            else
            {
                throw (new DatabaseException(MessageProjectDoesNotExist(projectId) + "\n" +
                                                MessageProjectCouldNotBeSavedEmptyObject()));
            }
            base.DataContext.SubmitChanges();

            Project alteredCriterionFromDb = GetProjectById(projectId);
            return CheckIfEqualProjects(alteredProject, alteredCriterionFromDb);
        }

        /// <summary>
        /// Deletes the project from database.
        /// </summary>
        /// <param name="projectId">The project identifier.</param>
        /// <returns>
        /// bool if deletion was successful
        /// </returns>
        /// Erstellt von Joshua Frey, am 14.12.2015
        /// <exception cref="DatabaseException">
        /// "Das Projekt mit der Id X existiert nicht in der Datenbank."
        /// </exception>
        public bool DeleteProjectFromDb(int projectId)
        {
            Project delProject = (from proj in base.DataContext.Project
                                        where proj.Project_Id == projectId
                                        select proj).FirstOrDefault();
            if (delProject != null)
            {
                base.DataContext.Project.DeleteOnSubmit(delProject);
                base.DataContext.SubmitChanges();
            }
            else
            {
                throw (new DatabaseException(MessageProjectDoesNotExist(projectId)));
            }

            return GetProjectById(projectId) == null;
        }

        /*
         * Private Section
         */


        /// <summary>
        /// Checks if equal projects.
        /// </summary>
        /// <param name="projOne">The proj one.</param>
        /// <param name="projTwo">The proj two.</param>
        /// <returns>
        /// bool if given projects are equal
        /// </returns>
        /// Erstellt von Joshua Frey, am 14.12.2015
        private bool CheckIfEqualProjects(Project projOne, Project projTwo)
        {
            bool equalName = projOne.Name == projTwo.Name;
            bool equalDescription = projOne.Description == projTwo.Description;

            return equalName && equalDescription;
        }


        /// <summary>
        /// Checks if project name already exists.
        /// </summary>
        /// <param name="projectName">Name of the project.</param>
        /// <returns>
        /// bool if project name already exists in db.
        /// </returns>
        /// Erstellt von Joshua Frey, am 14.12.2015
        private bool CheckIfProjectNameAlreadyExists(String projectName)
        {
            Project projectWithExistingName = (from proj in base.DataContext.Project
                                                    where proj.Name == projectName
                                                    select proj).FirstOrDefault();
            if (projectWithExistingName != null)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Checks if project has an identifier.
        /// </summary>
        /// <param name="proj">The proj.</param>
        /// <returns>
        /// bool if given Project has an id and it differs zero
        /// </returns>
        /// Erstellt von Joshua Frey, am 15.12.2015
        private bool CheckIfProjectHasAnId(Project proj)
        {
            if (proj.Project_Id == 0)
                return false;
            else
                return true;
        }


        /// <summary>
        /// Checks if project name already exists.
        /// </summary>
        /// <param name="projectName">Name of the project.</param>
        /// <param name="excludedId">The excluded identifier, which identifies the project, that should be updated.</param>
        /// <returns>
        /// bool if other project exist with name to which user want to update given project to.
        /// </returns>
        /// Erstellt von Joshua Frey, am 14.12.2015
        private bool CheckIfProjectNameAlreadyExists(String projectName, int excludedId)
        {
            Project projectWithExistingName = (from proj in base.DataContext.Project
                                                    where proj.Name == projectName
                                                    && proj.Project_Id != excludedId
                                                    select proj).FirstOrDefault();
            if (projectWithExistingName != null)
                return true;
            else
                return false;
        }


        /*
         Messages
         */

        private string MessageProjectCouldNotBeSavedEmptyObject()
        {
            return "Das Projekt konnte nicht in der Datenbank gespeichert werden." +
                   " Bitte überprüfen Sie das übergebene Projekt Objekt.";
        }

        private string MessageProjectAlreadyExists(string projectName)
        {
            return "Das Projekt mit dem Namen \"" + projectName +
                   "\" existiert bereits in einem anderen Datensatz in der Datenbank.";
        }

        private string MessageProjectDoesNotExist(int projectId)
        {
            return "Das Projekt mit der Id \"" + projectId +
                   "\" existiert nicht in der Datenbank.";
        }

        private string MessageProjectHasNoId()
        {
            return "Das Project Object besitzt keine ID. Bitte überprüfen Sie das übergebene Object";
        }
    }
}
