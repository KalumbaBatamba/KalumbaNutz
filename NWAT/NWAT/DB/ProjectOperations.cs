using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWAT.DB
{
    class ProjectOperations
    {

        /// <summary>
        /// Gets the project by identifier from db.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// An instance of 'Project'
        /// </returns>
        /// Erstellt von Joshua Frey, am 14.12.2015
        static public Project GetProjectById(int id)
        {
            Project resultProject;

            using (NWATDataContext dataContext = new NWATDataContext())
            {
                resultProject = dataContext.Project.SingleOrDefault(project => project.Projekt_Id == id);
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
        static public List<Project> GetAllProjectsFromDB()
        {
            List<Project> projects;
            using (NWATDataContext dataContext = new NWATDataContext())
            {
                projects = dataContext.Project.ToList();
            }
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
        static public bool InsertProjectIntoDb(Project newProject)
        {
            using (NWATDataContext dataContext = new NWATDataContext())
            {
                if (newProject != null)
                {
                    string newProjectName = newProject.Name;
                    if (!checkIfProjectNameAlreadyExists(newProjectName))
                    {
                        dataContext.Project.InsertOnSubmit(newProject);
                        dataContext.SubmitChanges();
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

                Project newProjectFromDb = (from crit in dataContext.Project
                                                where crit.Name == newProject.Name
                                                && crit.Beschreibung == newProject.Beschreibung
                                                select crit).FirstOrDefault();

                return checkIfEqualProjects(newProject, newProjectFromDb);
            }
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
        /// </exception>
        static public bool UpdateProjectInDb(Project alteredProject)
        {
            using (NWATDataContext dataContext = new NWATDataContext())
            {
                int projectId = alteredProject.Projekt_Id;
                Project projToUpdateFromDb = dataContext.Project.SingleOrDefault(proj => proj.Projekt_Id == projectId);

                if (projToUpdateFromDb != null)
                {
                    string newProjectName = alteredProject.Name;
                    if (!checkIfProjectNameAlreadyExists(newProjectName, projectId))
                    {
                        projToUpdateFromDb.Name = alteredProject.Name;
                        projToUpdateFromDb.Beschreibung = alteredProject.Beschreibung;
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
                dataContext.SubmitChanges();

                Project alteredCriterionFromDb = GetProjectById(projectId);
                return checkIfEqualProjects(alteredProject, alteredCriterionFromDb);
            }
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
        static private bool checkIfEqualProjects(Project projOne, Project projTwo)
        {
            bool equalName = projOne.Name == projTwo.Name;
            bool equalDescription = projOne.Beschreibung == projTwo.Beschreibung;

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
        static private bool checkIfProjectNameAlreadyExists(String projectName)
        {
            using (NWATDataContext dataContext = new NWATDataContext())
            {
                Project projectWithExistingName = (from proj in dataContext.Project
                                                       where proj.Name == projectName
                                                       select proj).FirstOrDefault();
                if (projectWithExistingName != null)
                    return true;
                else
                    return false;
            }
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
        static private bool checkIfProjectNameAlreadyExists(String projectName, int excludedId)
        {
            using (NWATDataContext dataContext = new NWATDataContext())
            {
                Project projectWithExistingName = (from proj in dataContext.Project
                                                       where proj.Name == projectName
                                                       && proj.Projekt_Id != excludedId
                                                       select proj).FirstOrDefault();
                if (projectWithExistingName != null)
                    return true;
                else
                    return false;
            }
        }


        /*
         Messages
         */

        private static string MessageProjectCouldNotBeSavedEmptyObject()
        {
            return "Das Projekt konnte nicht in der Datenbank gespeichert werden." +
                   " Bitte überprüfen Sie das übergebene Projekt Objekt.";
        }

        private static string MessageProjectAlreadyExists(string projectName)
        {
            return "Das Projekt mit dem Namen \"" + projectName +
                   "\" existiert bereits in einem anderen Datensatz in der Datenbank.";
        }

        private static string MessageProjectDoesNotExist(int projectId)
        {
            return "Das Projekt mit der Id \"" + projectId +
                   "\" existiert nicht in der Datenbank.";
        }

    }
}
