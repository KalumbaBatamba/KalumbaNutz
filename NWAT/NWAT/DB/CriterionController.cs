using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// Inserts the criterion into database.
        /// </summary>
        /// <param name="newCriterion">The new criterion.</param>
        /// <returns>
        /// bool if insert of new criterion was successfull.
        /// </returns>
        /// Erstellt von Joshua Frey, am 14.12.2015
        /// <exception cref="DatabaseException">
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
                    base.DataContext.Criterion.InsertOnSubmit(newCriterion);
                    base.DataContext.SubmitChanges();
                }
                else
                {
                    throw (new DatabaseException((MessageCriterionAlreadyExists(newCriterionName))));
                }
            }
            else
            {
                throw (new DatabaseException(MessageCriterionCouldNotBeSavedEmptyObject()));        
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
        /// <exception cref="DatabaseException">
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
                throw (new DatabaseException(MessageCriterionHasNoId()));

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
                    throw (new DatabaseException(MessageCriterionAlreadyExists(newCriterionName)));
                }
            }
            else
            {
                throw (new DatabaseException(MessageCriterionDoesNotExist(criterionId) + "\n" + 
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
        /// <exception cref="DatabaseException">
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
                base.DataContext.Criterion.DeleteOnSubmit(delCriterion);
                base.DataContext.SubmitChanges();
            }
            else
            {
                throw(new DatabaseException(MessageCriterionDoesNotExist(criterionId)));
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
        /// Checks if criterion name already exists.
        /// </summary>
        /// <param name="criterionName">Name of the criterion.</param>
        /// <returns>
        /// bool if criterion name already exists in db.
        /// </returns>
        /// Erstellt von Joshua Frey, am 14.12.2015
        private bool CheckIfCriterionNameAlreadyExists(String criterionName)
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
    }
}
