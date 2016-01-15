using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NWAT.DB
{
    class CriterionController : DbController
    {
        public CriterionController() : base() { }
        public CriterionController(NWATDataContext dataContext)
            : base(dataContext) { }

        /// <summary>
        /// Gets the criterion by identifier from db.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// An instance of 'Criterion'
        /// </returns>
        /// Erstellt von Joshua Frey, am 14.12.2015
        public Criterion GetCriterionById(int id)
        {
            Criterion resultCriterion = base.DataContext.Criterion.SingleOrDefault(criterion => criterion.Criterion_Id == id);
            
            return resultCriterion;
        }

        /// <summary>
        /// Gets all criterions from database.
        /// </summary>
        /// <returns>
        /// A linq table object with all criterions from db
        /// </returns>
        /// Erstellt von Joshua Frey, am 14.12.2015
        public List<Criterion> GetAllCriterionsFromDb()
        {
            List<Criterion> criterions;
            criterions = base.DataContext.Criterion.ToList();
            return criterions;
        }

        /// <summary>
        /// Checks if criterion identifier already exists.
        /// </summary>
        /// <param name="criterionId">The criterion identifier.</param>
        /// <returns></returns>
        /// Erstellt von Joshua Frey, am 15.01.2016
        public bool CheckIfCriterionIdAlreadyExists(int criterionId)
        {
            Criterion existingCrit = GetCriterionById(criterionId);
            return existingCrit != null;
        }

        /// <summary>
        /// Checks if criterion name already exists.
        /// </summary>
        /// <param name="criterionName">Name of the criterion.</param>
        /// <returns>
        /// bool if criterion name already exists in db.
        /// </returns>
        /// Erstellt von Joshua Frey, am 14.12.2015
        public bool CheckIfCriterionNameAlreadyExists(String criterionName)
        {
            Criterion criterionWithExistingName = (from crit in base.DataContext.Criterion
                                                   where crit.Name == criterionName
                                                   select crit).FirstOrDefault();
            if (criterionWithExistingName != null)
                return true;
            else
                return false;
        }


        /// <summary>
        /// Checks if criterion is allocated to any project.
        /// </summary>
        /// <param name="criterionId">The criterion identifier.</param>
        /// <returns></returns>
        /// Erstellt von Joshua Frey, am 13.01.2016
        public bool checkIfCriterionIsAllocatedToAnyProject(int criterionId)
        {
            bool isAllocatedToProjects = false;
            List<ProjectCriterion> allocatedProjectCriterions = getAllProjecCriterionsWhichThisCriterionIsRelatedTo(criterionId);
            if (allocatedProjectCriterions.Count > 0)
            {
                isAllocatedToProjects = true;
            }
            return isAllocatedToProjects;
        }


        /// <summary>
        /// Gets all projec criterions which this criterion is related to.
        /// </summary>
        /// <param name="criterionId">The criterion identifier.</param>
        /// <returns></returns>
        /// Erstellt von Joshua Frey, am 13.01.2016
        public List<ProjectCriterion> getAllProjecCriterionsWhichThisCriterionIsRelatedTo(int criterionId)
        {
            Criterion crit = GetCriterionById(criterionId);
            List<ProjectCriterion> allocatedProjectCriterions = crit.ProjectCriterion.ToList();
            return allocatedProjectCriterions;
        }

        /// <summary>
        /// Inserts the criterion into database.
        /// </summary>
        /// <param name="newCriterion">The new criterion.</param>
        /// <returns>
        /// bool if insert of new criterion was successfull.
        /// </returns>
        /// Erstellt von Joshua Frey, am 14.12.2015
        /// <exception cref="NWATException">
        ///  Das Kriterium mit dem Namen -Kriteriumname- existiert bereits in einem anderen Datensatz in der Datenbank.
        /// or
        /// Das Kriterium konnte nicht in der Datenbank angelegt werden. 
        /// Bitte überprüfen Sie das übergebene Kriterium Objekt.
        /// </exception>
        public bool InsertCriterionIntoDb(Criterion newCriterion)
        {
            if (newCriterion != null)
            {
                string newCriterionName = newCriterion.Name;
                if (!CheckIfCriterionNameAlreadyExists(newCriterionName))
                {

                    using (CurrentMasterDataIdsController masterDataIdsContr = new CurrentMasterDataIdsController())
                    {
                        CurrentMasterDataIds masterDataIdsSet = masterDataIdsContr.GetCurrentMasterDataIds();

                        int currentCritId = masterDataIdsSet.CurrentCriterionId;

                        // if you inserted a criterion manually and forgot to adjust the currentCriterionId it will 
                        // increment to the free place and will use new id to insert new criterion
                        while (GetCriterionById(currentCritId) != null)
                        {
                            masterDataIdsContr.incrementCurrentCriterionId();
                            currentCritId = masterDataIdsSet.CurrentCriterionId;
                        }

                        newCriterion.Criterion_Id = currentCritId;

                        base.DataContext.Criterion.InsertOnSubmit(newCriterion);
                        base.DataContext.SubmitChanges();
                        masterDataIdsContr.incrementCurrentCriterionId();
                    }

                   
                }
                else
                {
                    throw (new NWATException((MessageCriterionAlreadyExists(newCriterionName))));
                }
            }
            else
            {
                throw (new NWATException(MessageCriterionCouldNotBeSavedEmptyObject()));        
            }

            Criterion newCriterionFromDb = (from crit in base.DataContext.Criterion
                                            where crit.Name == newCriterion.Name
                                            && crit.Description == newCriterion.Description
                                            select crit).FirstOrDefault();
            return CheckIfEqualCriterions(newCriterion, newCriterionFromDb);   
        }

        /// <summary>
        /// Updates the criterion in database.
        /// </summary>
        /// <param name="alteredCriterion">The altered criterion.</param>
        /// <returns>
        /// bool if update of criterion was successful
        /// </returns>
        /// Erstellt von Joshua Frey, am 14.12.2015
        /// <exception cref="NWATException">
        /// Das Kriterium mit dem Namen -Kriteriumname- existiert bereits in einem anderen Datensatz in der Datenbank.
        /// or
        /// Das Kriterium konnte nicht in der Datenbank gespeichert werden. 
        /// Bitte überprüfen Sie das übergebene Kriterium Objekt.
        /// or 
        /// Das Criterion Object besitzt keine ID. Bitte überprüfen Sie das übergebene Object
        /// </exception>
        public bool UpdateCriterionInDb(Criterion alteredCriterion)
        {
            if (!CheckIfCriterionHasAnId(alteredCriterion))
                throw (new NWATException(MessageCriterionHasNoId()));

            int criterionId = alteredCriterion.Criterion_Id;
            Criterion critToUpdateFromDb = base.DataContext.Criterion.SingleOrDefault(crit=>crit.Criterion_Id==criterionId);

            if (critToUpdateFromDb != null)
            {
                string newCriterionName = alteredCriterion.Name;
                if (!CheckIfCriterionNameAlreadyExists(newCriterionName, criterionId))
                {
                    critToUpdateFromDb.Name = alteredCriterion.Name;
                    critToUpdateFromDb.Description = alteredCriterion.Description;
                }
                else
                {
                    throw (new NWATException(MessageCriterionAlreadyExists(newCriterionName)));
                }
            }
            else
            {
                throw (new NWATException(MessageCriterionDoesNotExist(criterionId) + "\n" + 
                                                MessageCriterionCouldNotBeSavedEmptyObject()));  
            }
            base.DataContext.SubmitChanges();
              
            Criterion alteredCriterionFromDb = GetCriterionById(criterionId);
            return CheckIfEqualCriterions(alteredCriterion, alteredCriterionFromDb);
        }

        /// <summary>
        /// Deletes the criterion from database.
        /// </summary>
        /// <param name="criterionId">The criterion identifier.</param>
        /// <returns>
        /// bool if deletion was successfull<
        /// /returns>
        /// Erstellt von Joshua Frey, am 14.12.2015
        /// <exception cref="NWATException">
        /// "Das Kriterium mit der Id X existiert nicht in der Datenbank."
        /// or
        /// SqlException if you try to delete a criterion, which is a parent criterion in project criterion table
        /// </exception>
        public bool DeleteCriterionFromDb(int criterionId)
        {
            Criterion delCriterion = (from crit in base.DataContext.Criterion
                                        where crit.Criterion_Id == criterionId
                                        select crit).FirstOrDefault();
            if (delCriterion != null)
            {
                // check if criterion is parent Id in any project
                using (ProjectCriterionController tempProjCritContr = new ProjectCriterionController())
                {
                    List<ProjectCriterion> projectCriterionChildren = 
                        tempProjCritContr.GetAllProjectCriterionsWhichHaveGivenCriterionAsParent(delCriterion.Criterion_Id);
                    if (projectCriterionChildren.Count > 0)
                    {
                        
                        string caption = "Löschen der untergeordneten Kriterien";
                        var result = MessageBox.Show(MessageDeleteAllChildProjectCriterions(projectCriterionChildren, delCriterion), caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        // User interaction --> User can decide if export files outside the zip archive should be deleted
                        if (result == DialogResult.Yes)
                        {
                            foreach (ProjectCriterion childProjCritToDelete in projectCriterionChildren)
                            {
                                bool forceDeallocationOfAllChildren = false;
                                tempProjCritContr.DeallocateCriterionAndAllChildCriterions(childProjCritToDelete.Project_Id, childProjCritToDelete, forceDeallocationOfAllChildren);
                            }
                        }
                        // if user declines deallocation of all children, the criterion will not be removed from master table.
                        else
                        {
                            return false;
                        }
                    }

                }

                base.DataContext.Criterion.DeleteOnSubmit(delCriterion);
                base.DataContext.SubmitChanges();
            }
            else
            {
                throw(new NWATException(MessageCriterionDoesNotExist(criterionId)));
            }

            return GetCriterionById(criterionId) == null;
        }

        /*
         * Private Section
         */

        /// <summary>
        /// Checks if equal criterions.
        /// </summary>
        /// <param name="critOne">The crit one.</param>
        /// <param name="critTwo">The crit two.</param>
        /// <returns>
        /// bool if given criterions have equal properties
        /// </returns>
        /// Erstellt von Joshua Frey, am 14.12.2015
        private bool CheckIfEqualCriterions(Criterion critOne, Criterion critTwo)
        {
            bool equalName = critOne.Name == critTwo.Name;
            bool equalDescription = critOne.Description == critTwo.Description;

            return equalName && equalDescription;
        }


        /// <summary>
        /// Checks if product has an identifier.
        /// </summary>
        /// <param name="prod">The product.</param>
        /// <returns>
        /// bool if Criterion has an id and it differs zero
        /// </returns>
        /// Erstellt von Joshua Frey, am 15.12.2015
        private bool CheckIfCriterionHasAnId(Criterion crit)
        {
            if (crit.Criterion_Id == 0)
                return false;
            else
                return true;
        }

        /// <summary>
        /// Checks if criterion name already exists.
        /// </summary>
        /// <param name="criterionName">Name of the criterion.</param>
        /// <param name="excludedId">The excluded identifier, which identifies the criterion, that should be updated.</param>
        /// <returns>
        /// bool if other croterion exist with name to which user want to update given criterion to.
        /// </returns>
        /// Erstellt von Joshua Frey, am 14.12.2015
        private bool CheckIfCriterionNameAlreadyExists(String criterionName, int excludedId)
        {
            Criterion criterionWithExistingName = (from crit in base.DataContext.Criterion
                                                    where crit.Name == criterionName 
                                                    && crit.Criterion_Id != excludedId
                                                    select crit).FirstOrDefault();
            if (criterionWithExistingName != null)
                return true;
            else
                return false;
        }


        /*
         Messages
         */
        private string MessageCriterionCouldNotBeSavedEmptyObject()
        {
            return "Das Kriterium konnte nicht in der Datenbank gespeichert werden." +
                   " Bitte überprüfen Sie das übergebene Kriterium Objekt.";
        }

        private string MessageCriterionAlreadyExists(string criterionName)
        {
            return "Das Kriterium mit dem Namen \"" + criterionName +
                   "\" existiert bereits in einem anderen Datensatz in der Datenbank.";
        }

        private string MessageCriterionDoesNotExist(int criterionId)
        {
            return "Das Kriterium mit der Id \"" + criterionId +
                   "\" existiert nicht in der Datenbank.";
        }

        private string MessageCriterionHasNoId()
        {
            return "Das Criterion Object besitzt keine ID. Bitte überprüfen Sie das übergebene Object";
        }


        /// <summary>
        /// Return messages if all child project criterions should be deallocated.
        /// </summary>
        /// <param name="projectCriterionChildren">The project criterion children.</param>
        /// <param name="deleteCriterion">The delete criterion.</param>
        /// <returns></returns>
        /// Erstellt von Joshua Frey, am 13.01.2016
        private string MessageDeleteAllChildProjectCriterions(List<ProjectCriterion> projectCriterionChildren, Criterion deleteCriterion)
        {
            string begin = String.Format("Das Kriterium {0} (Id={1}) hat folgende Projektkriterien als untergeordnete Kriterien:\n\n", deleteCriterion.Name, deleteCriterion.Criterion_Id);
            string projectCriterionChildrenListAsString = "";

            foreach (ProjectCriterion projCrit in projectCriterionChildren)
            {
                projectCriterionChildrenListAsString += String.Format(" - Projekt: {0} (Id={1})\n   Kindkriterium: {2} (Id={3})\n\n", 
                    projCrit.Project.Name, projCrit.Project_Id, projCrit.Criterion.Name, projCrit.Criterion_Id);
            }

            string end = "\nWenn Sie das Kriterium löschen, entkoppeln sie auch alle \n"+
                         "untergeordneten Kriterien und deren untergeordneten Kriterien usw. \n"+
                         "von allen betroffenen Projekten. \n" + 
                         "Sind Sie sich sicher, dass Sie das Kriterium löschen wollen?";

            return begin + projectCriterionChildrenListAsString + end;
        }
    }
}
