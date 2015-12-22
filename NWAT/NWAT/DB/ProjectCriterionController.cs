﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWAT.DB
{


    class ProjectCriterionController : DbController
    {
        public ProjectCriterionController(NWATDataContext dataContext)
            : base(dataContext)
        { }

        /// <summary>
        /// Gets the project criterion by ids.
        /// </summary>
        /// <param name="projectId">The project identifier.</param>
        /// <param name="criterionId">The criterion identifier.</param>
        /// <returns>
        /// An instance of 'ProjectCriterion' 
        /// </returns>
        /// Erstellt von Joshua Frey, am 18.12.2015
        public ProjectCriterion GetProjectCriterionByIds(int projectId, int criterionId)
        {
            ProjectCriterion resultProjectCriterion = base.DataContext.ProjectCriterion.SingleOrDefault(projectCriterion => projectCriterion.Criterion_Id == criterionId 
                                                                              && projectCriterion.Project_Id == projectId);
            return resultProjectCriterion;
        }

        /// <summary>
        /// Gets all project criterions for one project.
        /// </summary>
        /// <param name="projectId">The project identifier.</param>
        /// <returns>
        /// A list of all project criterions of one project
        /// </returns>
        /// Erstellt von Joshua Frey, am 21.12.2015
        public List<ProjectCriterion> GetAllProjectCriterionsForOneProject(int projectId)
        {
            List<ProjectCriterion> resultProjectCriterions = base.DataContext.ProjectCriterion.Where(projectCriterion => projectCriterion.Project_Id == projectId).ToList();
            return resultProjectCriterions;
        }

        /// <summary>
        /// Gets the child criterions by parent identifier.
        /// </summary>
        /// <param name="projectId">The project identifier.</param>
        /// <param name="parentId">The parent identifier.</param>
        /// <returns>
        /// A list with all project criterions where project id = given project id and parent id = given parent id
        /// </returns>
        /// Erstellt von Joshua Frey, am 21.12.2015
        public List<ProjectCriterion> GetChildCriterionsByParentId(int projectId, int parentId)
        {
            List<ProjectCriterion> resultProjectCriterions = base.DataContext.ProjectCriterion.Where(projectCriterion => projectCriterion.Parent_Criterion_Id == parentId
                                                                                                     && projectCriterion.Project_Id == projectId).ToList();
            return resultProjectCriterions;
        }

        /// <summary>
        /// Inserts the project criterion into database.
        /// </summary>
        /// <param name="newProjectCriterion">The new project criterion.</param>
        /// <returns>
        /// bool if insertion was sucessfully
        /// </returns>
        /// Erstellt von Joshua Frey, am 22.12.2015
        /// <exception cref="DatabaseException">
        /// </exception>
        public bool InsertProjectCriterionIntoDb(ProjectCriterion newProjectCriterion)
        {
            if (newProjectCriterion != null)
            {
                int projectId = newProjectCriterion.Project_Id;
                int criterionId = newProjectCriterion.Criterion_Id;

                // set equal weighting
                newProjectCriterion.Weighting_Cardinal = 1;

                ProjectCriterion alreadyExistingProjectCriterion = this.GetProjectCriterionByIds(projectId, criterionId);

                // if == null then this project criterion does not exist yet and it can be inserted into db
                if (alreadyExistingProjectCriterion == null)
                {
                    base.DataContext.ProjectCriterion.InsertOnSubmit(newProjectCriterion);
                    base.DataContext.SubmitChanges();
                }

                // project criterion already exists --> throw exception
                else
                {
                    string projectName = alreadyExistingProjectCriterion.Project.Name;
                    string criterionName = alreadyExistingProjectCriterion.Criterion.Name;
                    throw (new DatabaseException((MessageProjectCriterionAlreadyExists(projectName, criterionName))));
                }
                return checkIfEqualProjectCriterions(newProjectCriterion, this.GetProjectCriterionByIds(projectId, criterionId));   
            }
            else
            {
                throw (new DatabaseException(MessageProjectCriterionCouldNotBeSavedEmptyObject()));        
            }
        }


        /*
        * Private Section
        */


        /// <summary>
        /// Checks if equal project criterions.
        /// </summary>
        /// <param name="projectCriterionOne">The project criterion one.</param>
        /// <param name="projectCriterionTwo">The project criterion two.</param>
        /// <returns>
        /// bool if same project criterions
        /// </returns>
        /// Erstellt von Joshua Frey, am 22.12.2015
        private bool checkIfEqualProjectCriterions(ProjectCriterion projectCriterionOne, ProjectCriterion projectCriterionTwo)
        {
            bool sameProjectId = projectCriterionOne.Project_Id == projectCriterionTwo.Project_Id;
            bool sameCriterionId = projectCriterionOne.Criterion_Id == projectCriterionTwo.Criterion_Id;
            bool sameCardinalWeighting = projectCriterionOne.Weighting_Cardinal == projectCriterionTwo.Weighting_Cardinal;
            bool samePercentageLayerWeighting = projectCriterionOne.Weighting_Percentage_Layer == projectCriterionTwo.Weighting_Percentage_Layer;
            bool samePercentageProjectWeighting = projectCriterionOne.Weighting_Percentage_Project == projectCriterionTwo.Weighting_Percentage_Project;

            return sameProjectId &&
                   sameCriterionId &&
                   sameCardinalWeighting &&
                   samePercentageLayerWeighting &&
                   samePercentageProjectWeighting;
        }

        /// <summary>
        /// Checks if project criterion already exists.
        /// </summary>
        /// <param name="projectId">The project identifier.</param>
        /// <param name="criterionId">The criterion identifier.</param>
        /// <returns>
        /// bool if project criterion already exists
        /// </returns>
        /// Erstellt von Joshua Frey, am 22.12.2015
        private bool checkIfProjectCriterionAlreadyExists(int projectId, int criterionId)
        {
            ProjectCriterion existingProjectCriterion = this.GetProjectCriterionByIds(projectId, criterionId);
            if(existingProjectCriterion != null)
                return true;
            else
                return false;
        }
        
        /// <summary>
        /// Checks if parent exists in project as project criteroin.
        /// </summary>
        /// <param name="projectId">The project identifier.</param>
        /// <param name="parentCritId">The parent crit identifier.</param>
        /// <returns>
        /// bool which says if given parent is a projectCriterion
        /// </returns>
        /// Erstellt von Joshua Frey, am 22.12.2015
        private bool checkIfParentExistsInProjectAsProjectCriteroin(int projectId, int parentCritId)
        {
            ProjectCriterion resultProjectCriterion = base.DataContext.ProjectCriterion.FirstOrDefault(projectCriterion => projectCriterion.Project_Id == projectId && projectCriterion.Criterion_Id == parentCritId);
            if (resultProjectCriterion == null)
                return false;
            else
                return true;
        }


        /*
         Messages
         */
        private string MessageProjectCriterionCouldNotBeSavedEmptyObject()
        {
            return "Das Projektkriterium konnte nicht in der Datenbank gespeichert werden." +
                   " Bitte überprüfen Sie das übergebene Projektkriterium Objekt.";
        }

        private string MessageProjectCriterionAlreadyExists(string projectName, string criterionName)
        {
            return "Das Kriterium mit dem Namen \"" + criterionName +
                   "\" ist bereits dem Projekt \"" + projectName + "\" zugeordnet";
        }

        //private string MessageCriterionDoesNotExist(int criterionId)
        //{
        //    return "Das Kriterium mit der Id \"" + criterionId +
        //           "\" existiert nicht in der Datenbank.";
        //}

        //private string MessageCriterionHasNoId()
        //{
        //    return "Das Criterion Object besitzt keine ID. Bitte überprüfen Sie das übergebene Object";
        //}

    }
}
