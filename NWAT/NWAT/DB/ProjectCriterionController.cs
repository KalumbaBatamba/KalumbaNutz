using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NWAT.DB
{


    class ProjectCriterionController : DbController, IDisposable
    {
        public ProjectCriterionController() : base() { }
        public ProjectCriterionController(NWATDataContext dataContext)
            : base(dataContext) { }

        public void Dispose() { }

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


        /// <summary>
        /// Gets the base project criterions.
        /// </summary>
        /// <param name="projectId">The project identifier.</param>
        /// <returns>
        /// A list of all base criterions in first layer.
        /// </returns>
        /// Erstellt von Joshua Frey, am 12.01.2016
        public List<ProjectCriterion> GetBaseProjectCriterions(int projectId)
        {
            List<ProjectCriterion> baseCriterions = base.DataContext.ProjectCriterion.Where(projectCrit => projectCrit.Project_Id == projectId 
                                                                                                        && projectCrit.Parent_Criterion_Id == null).ToList();
            return baseCriterions;
        }

        /// <summary>
        /// Updates the project criterion in database.
        /// </summary>
        /// <param name="alteredProjectCriterion">The altered project criterion.</param>
        /// <returns></returns>
        /// Erstellt von Joshua Frey, am 12.01.2016
        /// <exception cref="DatabaseException"></exception>
        public bool UpdateProjectCriterionInDb(ProjectCriterion alteredProjectCriterion)
        {
            bool updateSuccess;
            updateSuccess = UpdateProjectCriterionDataSet(alteredProjectCriterion);
            if (!updateSuccess)
            {
                throw new DatabaseException(MessageUpdateProjectCriterionFailed(alteredProjectCriterion.Criterion.Name));
            }

            int projectId = alteredProjectCriterion.Project_Id;
            UpdateLayerDepthForProjectCriterion(projectId, alteredProjectCriterion.Criterion_Id);
            UpdateAllPercentageLayerWeightings(projectId);

            // TODO aktivieren sobald implementiert
            // UpdateAllPercentageProjectWeightings(projectId)
            return updateSuccess; 
        }

        /// <summary>
        /// Deletes the project criterion from database. This can also be called when a master criterion should be deleted
        /// </summary>
        /// <param name="projectId">The project identifier.</param>
        /// <param name="criterionId">The criterion identifier.</param>
        /// <returns></returns>
        /// Erstellt von Joshua Frey, am 04.01.2016
        public bool DeleteProjectCriterionFromDb(int projectId, int criterionId)
        {
            bool success;
            success = DeleteProjectCriterionDataSet(projectId, criterionId);
            if (!success)
            {
                throw new DatabaseException(MessageDeleteProjectCriterionFailed(criterionId.ToString()));
            }

            UpdateAllPercentageLayerWeightings(projectId);

            // TODO aktivieren sobald implementiert
            // UpdateAllPercentageProjectWeightings(projectId)

            return success;
        }
        


        /// <summary>
        /// Changes the allocation of project criterions in database.
        /// </summary>
        /// <param name="projectId">The project identifier.</param>
        /// <param name="newProjectCriterionList">The new project criterion list.</param>
        /// <returns></returns>
        /// Erstellt von Joshua Frey, am 12.01.2016
        public bool ChangeAllocationOfProjectCriterionsInDb(int projectId, List<ProjectCriterion> newProjectCriterionList)
        {
            bool deallocationSuccessful = true;
            bool allocationSuccessful = true;

            List<ProjectCriterion> projCritlistFromDb = GetAllProjectCriterionsForOneProject(projectId);
             
            List<ProjectCriterion> oldToDelete = GetOldProjectCriterionsWhichWereDeallocated(projCritlistFromDb, newProjectCriterionList);
            
            foreach (ProjectCriterion projCrit in oldToDelete)
            {
                // check if project criterion does still exist
                // if not, the criterion was a child Criterion and was deleted in any loop before by deletion of its parent criterion
                if (projCrit.Criterion_Id != 0)
                {
                    deallocationSuccessful = DeallocateCriterionAndAllChildCriterions(projectId, projCrit);
                }
            }
            List<ProjectCriterion> newToAdd = GetNewProjectCriterionsWhichWereAllocated(projCritlistFromDb, newProjectCriterionList);
            foreach (ProjectCriterion projCrit in newToAdd)
            {
                allocationSuccessful = AllocateCriterion(projectId, projCrit);
            }
             
            return deallocationSuccessful && allocationSuccessful;
        }

        /*
        * Private Section
        */

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
        private bool InsertProjectCriterionIntoDb(ProjectCriterion newProjectCriterion)
        {
            bool success;
            try
            {
                success = InsertProjectCriterionDataSet(newProjectCriterion);
            }
            catch (Exception e)
            {
                throw (e);
            }
            if (success)
            {
                int projectId = newProjectCriterion.Project_Id;
                UpdateLayerDepthForProjectCriterion(projectId, newProjectCriterion.Criterion_Id);
                UpdateAllPercentageLayerWeightings(projectId);

                // TODO aktivieren sobald implementiert
                // UpdateAllPercentageProjectWeightings(projectId)
            }
            return success;
        }

        /// <summary>
        /// Inserts the project criterion data set into Db
        /// </summary>
        /// <param name="newProjectCriterion">The new project criterion.</param>
        /// <returns></returns>
        /// Erstellt von Joshua Frey, am 12.01.2016
        /// <exception cref="DatabaseException">
        /// </exception>
        private bool InsertProjectCriterionDataSet(ProjectCriterion newProjectCriterion)
        {
            if (newProjectCriterion != null)
            {
                int projectId = newProjectCriterion.Project_Id;
                int criterionId = newProjectCriterion.Criterion_Id;

                // set equal weighting when inserting a new project criterion
                newProjectCriterion.Weighting_Cardinal = 1;
                // set default layer depth to 1
                newProjectCriterion.Layer_Depth = 1;

                // if == null then this project criterion does not exist yet and it can be inserted into db
                if (!CheckIfProjectCriterionAlreadyExists(projectId, criterionId))
                {
                    base.DataContext.ProjectCriterion.InsertOnSubmit(newProjectCriterion);
                    base.DataContext.SubmitChanges();
                }

                // project criterion already exists --> throw exception
                else
                {
                    ProjectCriterion alreadyExistingProjectCriterion = this.GetProjectCriterionByIds(projectId, criterionId);
                    string projectName = alreadyExistingProjectCriterion.Project.Name;
                    string criterionName = alreadyExistingProjectCriterion.Criterion.Name;
                    throw (new DatabaseException((MessageProjectCriterionAlreadyExists(projectName, criterionName))));
                }
                return checkIfSameProjectCriterions(newProjectCriterion, this.GetProjectCriterionByIds(projectId, criterionId));
            }
            else
            {
                throw (new DatabaseException(MessageProjectCriterionCouldNotBeSavedEmptyObject()));
            }
        }


        /// <summary>
        /// Updates the project criterion data set.
        /// </summary>
        /// <param name="alteredProjectCriterion">The altered project criterion.</param>
        /// <returns></returns>
        /// Erstellt von Joshua Frey, am 12.01.2016
        private bool UpdateProjectCriterionDataSet(ProjectCriterion alteredProjectCriterion)
        {
            int projectId = alteredProjectCriterion.Project_Id;
            int criterionId = alteredProjectCriterion.Criterion_Id;
            ProjectCriterion resultProjectCriterion = base.DataContext.ProjectCriterion.SingleOrDefault(projectCriterion => projectCriterion.Criterion_Id == criterionId
                                                                           && projectCriterion.Project_Id == projectId);
            resultProjectCriterion.Parent_Criterion_Id = alteredProjectCriterion.Parent_Criterion_Id;
            resultProjectCriterion.Weighting_Cardinal = alteredProjectCriterion.Weighting_Cardinal;
            resultProjectCriterion.Layer_Depth = alteredProjectCriterion.Layer_Depth;
            resultProjectCriterion.Weighting_Percentage_Layer = alteredProjectCriterion.Weighting_Percentage_Layer;
            resultProjectCriterion.Weighting_Percentage_Project = alteredProjectCriterion.Weighting_Percentage_Project;
            base.DataContext.SubmitChanges();

            ProjectCriterion changedProjCritFromDb = GetProjectCriterionByIds(alteredProjectCriterion.Project_Id, alteredProjectCriterion.Criterion_Id);

            bool successfulUpdate = checkIfSameProjectCriterions(alteredProjectCriterion, changedProjCritFromDb);

            return successfulUpdate;

        }


        /// <summary>
        /// Deletes the project criterion data set.
        /// </summary>
        /// <param name="projectId">The project identifier.</param>
        /// <param name="criterionId">The criterion identifier.</param>
        /// <returns></returns>
        /// Erstellt von Joshua Frey, am 12.01.2016
        private bool DeleteProjectCriterionDataSet(int projectId, int criterionId)
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
        private bool DeallocateCriterionAndAllChildCriterions(int projectId, ProjectCriterion projCrit)
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
                    MessageBox.Show("Das Kriterium " + projCritName + " wurde erfolgreich vom Projekt entkoppelt.");
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
        private bool AllocateCriterion(int projectId, ProjectCriterion projCrit)
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
                using (FulfillmentController fulfillContr = new FulfillmentController())
                {
                    foreach (ProjectProduct projProd in allProjectProducts)
                    {
                        int prodId = projProd.Product_Id;
                        if (!fulfillContr.InsertFullfillmentInDb(projectId, prodId, projCritId))
                        {
                            insertionFulfillmentSuccessful = false;
                            throw (new DatabaseException(CommonMethods.MessageInsertionToFulFillmentTableFailed(prodId, projCritId)));
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
        private void UpdateAllPercentageLayerWeightings(int projectId)
        {
            // calculate all weightings for the base layer
            List<ProjectCriterion> baseProjectCriterions = GetBaseProjectCriterions(projectId);
            CalculatePercentageLayerWeighting(ref baseProjectCriterions);

            // write calculated weightings back to db
            foreach (ProjectCriterion baseProjCrit in baseProjectCriterions)
            {
                UpdateProjectCriterionDataSet(baseProjCrit);
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
                        UpdateProjectCriterionDataSet(childProjCrit);
                    }
                }
            }
        }

        // TODO by Yann
        private void UpdateAllPercentageProjectWeightings(int projectId)
        {

        }




        /// <summary>
        /// Checks if same project criterions.
        /// </summary>
        /// <param name="projCritOne">The proj crit one.</param>
        /// <param name="projCritTwo">The proj crit two.</param>
        /// <returns></returns>
        /// Erstellt von Joshua Frey, am 12.01.2016
        private static bool checkIfSameProjectCriterions(ProjectCriterion projCritOne, ProjectCriterion projCritTwo)
        {
            bool sameParentCritId = projCritOne.Parent_Criterion_Id == projCritTwo.Parent_Criterion_Id;
            bool sameLayerDepth = projCritOne.Layer_Depth == projCritTwo.Layer_Depth;
            bool sameCardinalWeighting = projCritOne.Weighting_Cardinal == projCritTwo.Weighting_Cardinal;
            bool samePercentageLayerWeighting = projCritOne.Weighting_Percentage_Layer == projCritTwo.Weighting_Percentage_Layer;
            bool samePercentageProjectWeighting = projCritOne.Weighting_Percentage_Project == projCritTwo.Weighting_Percentage_Project;

            return sameCardinalWeighting &&
                   sameLayerDepth &&
                   sameParentCritId &&
                   samePercentageLayerWeighting &&
                   samePercentageProjectWeighting;
        }


        /// <summary>
        /// Calculates the layer depth of the Criterion and updates it in Database;
        /// </summary>
        /// <param name="projectId">The project identifier.</param>
        /// <param name="projCritId">The proj crit identifier.</param>
        /// Erstellt von Joshua Frey, am 12.01.2016
        private void UpdateLayerDepthForProjectCriterion(int projectId, int projCritId)
        {
            // base criterions are on layer one. So the lowest layer a criterion can exist in, is 1
            int layerCounter = 1;

            List<ProjectCriterion> allProjectCriterions = GetAllProjectCriterionsForOneProject(projectId);
            ProjectCriterion involvedProjCriterion;
            involvedProjCriterion = allProjectCriterions.Single(projCrit => projCrit.Criterion_Id == projCritId);

            bool hasParent = false;

            // traverse all parent criterion and count them in layerCounter
            do
            {
                
                if (involvedProjCriterion.Parent_Criterion_Id != null && involvedProjCriterion.Parent_Criterion_Id.Value != 0)
                {
                    int parentCritId = involvedProjCriterion.Parent_Criterion_Id.Value;
                    hasParent = true;
                    layerCounter++;
                    involvedProjCriterion = allProjectCriterions.Single(projCrit => projCrit.Criterion_Id == parentCritId);
                }   
                else
                {
                    hasParent = false;
                }
            }while(hasParent);

            ProjectCriterion projCritToUpdate = allProjectCriterions.Single(projCrit => projCrit.Criterion_Id == projCritId);
            projCritToUpdate.Layer_Depth = layerCounter;
            UpdateProjectCriterionDataSet(projCritToUpdate);
        }


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
                sumOfCardinalWeightings += projCrit.Weighting_Cardinal;
            }

            foreach (ProjectCriterion projCrit in projectCriterionsInOneLayer)
            {
                float percentageLayerWeighting = projCrit.Weighting_Cardinal / sumOfCardinalWeightings;
                projCrit.Weighting_Percentage_Layer = percentageLayerWeighting;
            }
        }

        // TODO by Yann
        private void CalculatePercentageProjectWeighting()
        {
            
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

        private string MessageUpdateProjectCriterionFailed(string critName)
        {
            return String.Format(@"Das Projekt Kriteriums {0} konnte nicht in der Datenbank geändert werden.", critName);
        }

        private string MessageDeleteProjectCriterionFailed(string critName)
        {
            return String.Format(@"Das Projekt Kriteriums {0} konnte nicht aus der Datenbank gelöscht werden.", critName);
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
