using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NWAT.DB
{


    class ProjectCriterionController : DbController
    {
        public ProjectCriterionController() : base() { }
        public ProjectCriterionController(NWATDataContext dataContext)
            : base(dataContext) { }
       

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
        /// Gets the child criterions by project identifier and parent identifier.
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

        // TODO GetBaseProjectCriterions
        // liefert eine Liste mit allen Basis Projektkriterien zurück
        // d.h. die Kriterien die keine Eltern Kriterien haben
        // Ist dies sinnvoll?
        public List<ProjectCriterion> GetBaseProjectCriterions(int projectId)
        {
            List<ProjectCriterion> baseCriterions = base.DataContext.ProjectCriterion.Where(projectCrit => projectCrit.Project_Id == projectId 
                                                                                                        && projectCrit.Parent_Criterion_Id == null).ToList();


            return baseCriterions;
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

                // set equal weighting when inserting a new project criterion
                newProjectCriterion.Weighting_Cardinal = 1;

                ProjectCriterion alreadyExistingProjectCriterion = this.GetProjectCriterionByIds(projectId, criterionId);

                // if == null then this project criterion does not exist yet and it can be inserted into db
                if (!CheckIfProjectCriterionAlreadyExists(projectId, criterionId))
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
                return CheckIfEqualProjectCriterions(newProjectCriterion, this.GetProjectCriterionByIds(projectId, criterionId));   
            }
            else
            {
                throw (new DatabaseException(MessageProjectCriterionCouldNotBeSavedEmptyObject()));        
            }
        }


        // TODO update ProjectCrit
        // Ist dafür da, die Parent Id und die Gewichtungen zu ändern. 
        public bool UpdateProjectCriterionInDb(ProjectCriterion alteredProjectCriterion)
        {

             int projectId = alteredProjectCriterion.Project_Id;
             int criterionId = alteredProjectCriterion.Criterion_Id;
             ProjectCriterion resultProjectCriterion = base.DataContext.ProjectCriterion.SingleOrDefault(projectCriterion => projectCriterion.Criterion_Id == criterionId 
                                                                            && projectCriterion.Project_Id == projectId);
             resultProjectCriterion.Parent_Criterion_Id = alteredProjectCriterion.Parent_Criterion_Id;
             resultProjectCriterion.Weighting_Cardinal = alteredProjectCriterion.Weighting_Cardinal;
             resultProjectCriterion.Weighting_Percentage_Layer = alteredProjectCriterion.Weighting_Percentage_Layer;
             resultProjectCriterion.Weighting_Percentage_Project = alteredProjectCriterion.Weighting_Percentage_Project;
             base.DataContext.SubmitChanges();
            
            return true; 
        }


        /// <summary>
        /// Deletes the project criterion from database.
        /// </summary>
        /// <param name="projectId">The project identifier.</param>
        /// <param name="criterionId">The criterion identifier.</param>
        /// <returns></returns>
        /// Erstellt von Joshua Frey, am 04.01.2016
        public bool DeleteProjectCriterionFromDb(int projectId, int criterionId) 
        {
            ProjectCriterion delProjCrit = (from projCrit in base.DataContext.ProjectCriterion
                                            where projCrit.Project_Id == projectId
                                            && projCrit.Criterion_Id == criterionId
                                            select projCrit).FirstOrDefault();
            base.DataContext.ProjectCriterion.DeleteOnSubmit(delProjCrit);
            base.DataContext.SubmitChanges();

            return GetProjectCriterionByIds(projectId, criterionId) == null;
        }


        /// <summary>
        /// Deallocates the criterion and all child criterions from project. This includes the entries in the fulfillment table
        /// </summary>
        /// <param name="projectId">The project identifier.</param>
        /// <param name="projCrit">The proj crit.</param>
        /// <returns></returns>
        /// Erstellt von Joshua Frey, am 04.01.2016
        public bool DeallocateCriterionAndAllChildCriterions(int projectId, ProjectCriterion projCrit)
        {
            int projectCriterionId = projCrit.Criterion_Id;
            // checks if criterion has any children criterion (is a parent criterion)
            List<ProjectCriterion> eventualChildCriterions = GetChildCriterionsByParentId(projectId, projectCriterionId);
            bool deletionPermitted = true;
            if (eventualChildCriterions.Count > 0)
            {
                string decisionMessage = MessageUserDecisionOfDeallocatingAllChildCriterions(projCrit, eventualChildCriterions);
                const string caption = "Kriterienentkopplung";

                var result = MessageBox.Show(decisionMessage, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    foreach (ProjectCriterion childProjCrit in eventualChildCriterions)
                    {
                        if (deletionPermitted)
                        {
                            deletionPermitted = DeallocateCriterionAndAllChildCriterions(projectId, childProjCrit);
                        }
                        
                    }
                }
                else
                    deletionPermitted = false;

            }
            string projCritName = projCrit.Criterion.Name;
            if (deletionPermitted)
            {
                // delete all fulfillment entries which point to this project criterion
                bool fulfillmentDeletionSuccessfull;
                using (FulfillmentController fulfillmentContr = new FulfillmentController())
                {
                    fulfillmentDeletionSuccessfull = fulfillmentContr.DeleteAllFulfillmentsForOneCriterionInOneProject(projectId, projCrit.Criterion_Id);
                }

                if (fulfillmentDeletionSuccessfull && DeleteProjectCriterionFromDb(projectId, projectCriterionId))
                {
                    MessageBox.Show("Das Kriterium " +  projCritName + " wurde erfolgreich vom Projekt entkoppelt.");
                    return true;
                }
                else
                {
                    MessageBox.Show("Bei dem Löschvorgang ist ein Fehler aufgetreten.");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Löschen von " + projCritName + " konnte nicht durchgeführt werden, weil ein Löschvorgang vom Benutzer abgelehnt wurde.");
                return false;
            }
        }

       
        
        // TODO updateProjectCriterionListInDb 
        // params: ProjectID und die aktuelle Liste die vom Benutzer zugeordnet wurde.
        // Diese liste wird nun mit den Einträgen verglichen und die Db auf diese Liste aktualisiert
        // --> lösche nicht mehr vorhandene Einträge
        // --> füge neue Einträge hinzu
        public bool ChangeAllocationOfProjectCriterionsInDb(int projectId, List<ProjectCriterion> newProjectCriterionList)
        {
            List<ProjectCriterion> projCritlistFromDb = GetAllProjectCriterionsForOneProject(projectId);
             
            List<ProjectCriterion> oldToDelete = GetOldProjectCriterionsWhichWereDeallocated(projCritlistFromDb, newProjectCriterionList);
            
            foreach (ProjectCriterion projCrit in oldToDelete)
            {
                // check if project criterion does still exist
                // if not, the criterion was a child Criterion and was deleted in any loop before by deletion of its parent criterion
                if (projCrit.Criterion_Id != 0)
                {
                    DeallocateCriterionAndAllChildCriterions(projectId, projCrit);
                }
            }
            List<ProjectCriterion> newToAdd = GetNewProjectCriterionsWhichWereAllocated(projCritlistFromDb, newProjectCriterionList);
            foreach (ProjectCriterion projCrit in newToAdd)
            {
                AllocateCriterion(projectId, projCrit);
            }
             
            return true;
        }


        /// <summary>
        /// Allocates the criterion.
        /// </summary>
        /// <param name="projectId">The project identifier.</param>
        /// <param name="projCrit">The proj crit.</param>
        /// <returns>
        /// bool if insertions in projectCriterion table and fulfillment table were successful
        /// </returns>
        /// Erstellt von Joshua Frey, am 04.01.2016
        /// <exception cref="DatabaseException"></exception>
        public bool AllocateCriterion(int projectId, ProjectCriterion projCrit)
        {
            bool insertionProjectCritionSuccessful = true;
            bool insertionFulfillmentSuccessful = true;

            int projCritId = projCrit.Criterion_Id;
            if (projCritId != 0 && projCrit.Project_Id != 0)
            {
                insertionProjectCritionSuccessful = InsertProjectCriterionIntoDb(projCrit);

                // get all project products for insertion to fulfillment table
                List<ProjectProduct> allProjectProducts;
                using (ProjectProductController projProdCont = new ProjectProductController())
                {
                    allProjectProducts = projProdCont.GetAllProjectProductsForOneProject(projectId);
                }

                // insert criterions into fulfillment table for each product
                using(FulfillmentController fulfillContr = new FulfillmentController())
                {
                    foreach (ProjectProduct projProd in allProjectProducts)
                    {
                        int prodId = projProd.Product_Id;
                        if (!fulfillContr.InsertFullfillmentInDb(projectId, prodId, projCritId))
                        {
                            insertionFulfillmentSuccessful = false;
                            throw (new DatabaseException(MessageInsertionToFulFillmentTableFailed(prodId, projCritId)));
                        }
                    }
                }
            }
            return insertionFulfillmentSuccessful && insertionProjectCritionSuccessful;
        }


        /// <summary>
        /// Updates all percentage layer weightings for one project.
        /// </summary>
        /// <param name="projectId">The project identifier.</param>
        /// Erstellt von Joshua Frey, am 04.01.2016
        public void UpdateAllPercentageLayerWeightings(int projectId)
        {
            // calculate all weightings for the base layer
            List<ProjectCriterion> baseProjectCriterions = GetBaseProjectCriterions(projectId);
            CalculatePercentageLayerWeighting(ref baseProjectCriterions);

            // write calculated weightings back to db
            foreach (ProjectCriterion baseProjCrit in baseProjectCriterions)
            {
                UpdateProjectCriterionInDb(baseProjCrit);
            }
            
            // calculate all weightings for all child project criterions
            List<ProjectCriterion> allProjectCriterions = GetAllProjectCriterionsForOneProject(projectId);

            foreach (ProjectCriterion projCrit in allProjectCriterions)
            {
                List<ProjectCriterion> eventualChildrenOfCurrentProjCriterion = GetChildCriterionsByParentId(projectId, projCrit.Criterion_Id);
                if (eventualChildrenOfCurrentProjCriterion.Count > 0)
                {
                    CalculatePercentageLayerWeighting(ref eventualChildrenOfCurrentProjCriterion);
                    foreach (ProjectCriterion childProjCrit in eventualChildrenOfCurrentProjCriterion)
                    {
                        UpdateProjectCriterionInDb(childProjCrit);
                    }
                }
            }
        }

        /*
        * Private Section
        */

        /// <summary>
        /// Calculates the percentage layer weighting for one Layer. 
        /// </summary>
        /// <param name="projectCriterionsInOneLayer">Reference of a IEnumerable of the project criterions in one layer.</param>
        /// Erstellt von Joshua Frey, am 04.01.2016
        private void CalculatePercentageLayerWeighting(ref List<ProjectCriterion> projectCriterionsInOneLayer)
        {
            float sumOfCardinalWeightings = 0;
            foreach (ProjectCriterion projCrit in projectCriterionsInOneLayer)
            {
                sumOfCardinalWeightings += projCrit.Weighting_Cardinal.Value;
            }

            foreach (ProjectCriterion projCrit in projectCriterionsInOneLayer)
            {
                float percentageLayerWeighting = projCrit.Weighting_Cardinal.Value / sumOfCardinalWeightings;
                projCrit.Weighting_Percentage_Layer = percentageLayerWeighting;
            }
        }

        /// <summary>
        /// Checks if equal project criterions.
        /// </summary>
        /// <param name="projectCriterionOne">The project criterion one.</param>
        /// <param name="projectCriterionTwo">The project criterion two.</param>
        /// <returns>
        /// bool if same project criterions
        /// </returns>
        /// Erstellt von Joshua Frey, am 22.12.2015
        private bool CheckIfEqualProjectCriterions(ProjectCriterion projectCriterionOne, ProjectCriterion projectCriterionTwo)
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
        private bool CheckIfProjectCriterionAlreadyExists(int projectId, int criterionId)
        {
            ProjectCriterion existingProjectCriterion = this.GetProjectCriterionByIds(projectId, criterionId);
            if(existingProjectCriterion != null)
                return true;
            else
                return false;
        }
        
        /// <summary>
        /// Checks if parent exists in project as project criterion.
        /// </summary>
        /// <param name="projectId">The project identifier.</param>
        /// <param name="parentCritId">The parent crit identifier.</param>
        /// <returns>
        /// bool which says if given parent is a projectCriterion
        /// </returns>
        /// Erstellt von Joshua Frey, am 22.12.2015
        private bool CheckIfParentExistsInProjectAsProjectCriterion(int projectId, int parentCritId)
        {
            ProjectCriterion resultProjectCriterion = base.DataContext.ProjectCriterion.FirstOrDefault(projectCriterion => projectCriterion.Project_Id == projectId && projectCriterion.Criterion_Id == parentCritId);
            if (resultProjectCriterion == null)
                return false;
            else
                return true;
        }

        /// <summary>
        /// Gets the old project criterions which were deallocated in a new list. This list contains all project criterions
        /// which have to be deleted in the db table
        /// </summary>
        /// <param name="listFromDb">The list from database.</param>
        /// <param name="newProjectCriterionList">The new project criterion list.</param>
        /// <returns>
        /// A list that contains all project criterions
        /// which have to be deleted in the db table
        /// </returns>
        /// Erstellt von Joshua Frey, am 28.12.2015
        private List<ProjectCriterion> GetOldProjectCriterionsWhichWereDeallocated(List<ProjectCriterion> listFromDb, List<ProjectCriterion> newProjectCriterionList)
        {
            List<ProjectCriterion> resultProjCritList = new List<ProjectCriterion>();
            resultProjCritList = listFromDb.Except(newProjectCriterionList).ToList();
            return resultProjCritList;
        }

        /// <summary>
        /// Gets the new project criterions which were allocated in a new list. This list contains all project criterions
        /// which have to be inserted into the db table
        /// </summary>
        /// <param name="listFromDb">The list from database.</param>
        /// <param name="newProjectCriterionList">The new project criterion list.</param>
        /// <returns> 
        /// A list that contains all project criterions
        /// which have to be inserted in the db table
        /// </returns>
        /// Erstellt von Joshua Frey, am 28.12.2015
        private List<ProjectCriterion> GetNewProjectCriterionsWhichWereAllocated(List<ProjectCriterion> listFromDb, List<ProjectCriterion> newProjectCriterionList)
        {
            List<ProjectCriterion> resultProjCritList = new List<ProjectCriterion>();
            resultProjCritList = newProjectCriterionList.Except(listFromDb).ToList();
            return resultProjCritList;
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


        private static string MessageUserDecisionOfDeallocatingAllChildCriterions(ProjectCriterion projCrit, List<ProjectCriterion> eventualChildCriterions)
        {
            string critName = projCrit.Criterion.Name;
            // hier wird der benutzer gefragt ob
            string decisionMessage = @"Dem Kriterium " + critName + " sind noch folgende Kriterien untergeordnet: \n";
            foreach (ProjectCriterion childProjCrit in eventualChildCriterions)
            {
                decisionMessage += childProjCrit.Criterion.Name + "\n";
            }
            decisionMessage += "Wenn Sie das Kriterium dem Projekt entziehen, werden auch alle untergeordneten Kriterien dem Projekt entzogen\n" +
                "Des Weiteren werden alle Erfüllungseinträge mit den betroffenen Kriterien für dieses Projekt entfernt.\n" +
                "Möchten Sie das Kriterium " + critName + " und dessen Unterkriterien vom Projekt entkoppeln?";
            return decisionMessage;
        }

        private string MessageInsertionToFulFillmentTableFailed(int prodId, int projCritId)
        {
            return String.Format(@"Der Eintrag für das Produkt mit der ID {0} und das Kriterium mit der ID {1} 
                                    konnte nicht in die Erfüllungstabelle eingefügt werden.", prodId, projCritId);
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
