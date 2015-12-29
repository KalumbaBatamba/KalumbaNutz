using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWAT.DB
{
    class FulfillmentController : DbController
    {
        public FulfillmentController() : base() { }
        public FulfillmentController(NWATDataContext dataContext)
            : base(dataContext) { }

        /// <summary>
        /// Gets the fulfillment by ids.
        /// </summary>
        /// <param name="projectId">The project identifier.</param>
        /// <param name="productId">The product identifier.</param>
        /// <param name="criterionId">The criterion identifier.</param>
        /// <returns>
        /// An instance of Fullfilment with given params from database 
        /// </returns>
        /// Erstellt von Joshua Frey, am 29.12.2015
        public Fulfillment GetFulfillmentByIds(int projectId, int productId, int criterionId)
        {
            return base.DataContext.Fulfillment.SingleOrDefault(fulfillment => fulfillment.Project_Id == projectId
                                                                            && fulfillment.Product_Id == productId
                                                                            && fulfillment.Criterion_Id == criterionId);
        }

        /// <summary>
        /// Fills the fulfillment table initially.
        /// </summary>
        /// <param name="projectId">The project identifier.</param>
        /// <param name="allProjectProducts">All project products.</param>
        /// <param name="allProjectCriterions">All project criterions.</param>
        /// Erstellt von Joshua Frey, am 28.12.2015
        /// <exception cref="DatabaseException">
        /// </exception>
        public void FillFulfillmentTableInitially(int projectId,
                                                  List<ProjectProduct> allProjectProducts,
                                                  List<ProjectCriterion> allProjectCriterions)
        {
            foreach (ProjectProduct projProd in allProjectProducts)
            {
                int productId = projProd.Product_Id;

                if (allProjectCriterions.Count == 0)
                {
                    throw new DatabaseException(MessageGivenParamListIsEmpty("Projektkriterien Liste"));
                }
                else if(allProjectProducts.Count == 0)
                {
                    throw new DatabaseException(MessageGivenParamListIsEmpty("Projektprodukte Liste"));
                }
                else
                {
                    foreach (ProjectCriterion projCrit in allProjectCriterions)
                    {
                        int criterionId = projCrit.Criterion_Id;
                        Fulfillment newFulfillmentEntry = new Fulfillment
                        {
                            Project_Id = projectId,
                            Product_Id = productId,
                            Criterion_Id = criterionId
                        };
                        if (!CheckIfFullfilmentCombinationAlreadyExists(projectId, productId, criterionId))
                        {
                            base.DataContext.Fulfillment.InsertOnSubmit(newFulfillmentEntry);
                            base.DataContext.SubmitChanges();

                        }
                        else
                        {
                            throw new DatabaseException(MessageFulfillmentEntryAlreadyExists(projectId, productId, criterionId));
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Updates the fulfillment entry.
        /// </summary>
        /// <param name="alteredFulfillment">The altered fulfillment.</param>
        /// <returns></returns>
        /// Erstellt von Joshua Frey, am 29.12.2015
        /// <exception cref="DatabaseException"></exception>
        public bool UpdateFulfillmentEntry(Fulfillment alteredFulfillment)
        {
            int projectId = alteredFulfillment.Project_Id;
            int productId = alteredFulfillment.Product_Id;
            int criterionId = alteredFulfillment.Criterion_Id;
            if (alteredFulfillment != null)
            {
                Fulfillment fulfillmentFromDb = base.DataContext.Fulfillment.SingleOrDefault(fulfillment => fulfillment.Project_Id == projectId
                                                                                                && fulfillment.Product_Id == productId
                                                                                                && fulfillment.Criterion_Id == criterionId);
                fulfillmentFromDb.Fulfilled = alteredFulfillment.Fulfilled;
                fulfillmentFromDb.Comment = alteredFulfillment.Comment;
            }
            else
            {
                throw new DatabaseException(MessageFulfillmentCouldNotBeSaved());
            }

            Fulfillment newFulfillmentInDb = GetFulfillmentByIds(projectId, productId, criterionId);
            return CheckIfEqualFulfillments(alteredFulfillment, newFulfillmentInDb);
        }



        /*
         * Private section
         */

        /// <summary>
        /// Checks if fullfilment combination already exists in db.
        /// </summary>
        /// <param name="projectId">The project identifier.</param>
        /// <param name="productId">The product identifier.</param>
        /// <param name="criterionId">The criterion identifier.</param>
        /// <returns>
        /// bool if fulfillment with given params already exists in db
        /// </returns>
        /// Erstellt von Joshua Frey, am 28.12.2015
        private bool CheckIfFullfilmentCombinationAlreadyExists(int projectId, int productId, int criterionId)
        {
            Fulfillment existingFulfillmentEntry = base.DataContext.Fulfillment.SingleOrDefault(fulfillment => fulfillment.Project_Id == projectId
                                                                                                && fulfillment.Product_Id == productId
                                                                                                && fulfillment.Criterion_Id == criterionId);
            if (existingFulfillmentEntry != null)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Checks if fulfillments are equal.
        /// </summary>
        /// <param name="fulfillmentOne">The fulfillment one.</param>
        /// <param name="fulfillmentTwo">The fulfillment two.</param>
        /// <returns>
        /// bool if fulfillments are equal.
        /// </returns>
        /// Erstellt von Joshua Frey, am 29.12.2015
        private bool CheckIfEqualFulfillments(Fulfillment fulfillmentOne, Fulfillment fulfillmentTwo)
        {
            bool sameProjectId = fulfillmentOne.Project_Id == fulfillmentTwo.Project_Id;
            bool sameProductId = fulfillmentOne.Product_Id == fulfillmentTwo.Product_Id;
            bool sameCriterionId = fulfillmentOne.Criterion_Id == fulfillmentTwo.Criterion_Id;
            bool sameDegreeOfFulfillment = fulfillmentOne.Fulfilled == fulfillmentTwo.Fulfilled;
            bool sameComment = fulfillmentOne.Comment == fulfillmentTwo.Comment;

            return sameComment &&
                   sameCriterionId &&
                   sameDegreeOfFulfillment &&
                   sameProductId &&
                   sameProjectId;
        }



        /*
         * Messages
         */

        private string MessageGivenParamListIsEmpty(string listType)
        {
            return "Die übergebene " + listType + " ist leer.";
        }

        private string MessageFulfillmentEntryAlreadyExists(int projectId, int productId, int criterionId)
        {
            return String.Format(@"Es existiert schon ein Eintrag in der Erfüllungstabelle 
                                  mit der Project ID {0}, der Product ID {1} und der Kriterium ID {2}.",
                         projectId, productId, criterionId);
        }

        private string MessageFulfillmentCouldNotBeSaved()
        {
            return @"Der Erfüllungseintrag konnte nicht gespeichert werden. 
                     Bitte überprüfen Sie das übergebene Objekt";
        }


    }
}
