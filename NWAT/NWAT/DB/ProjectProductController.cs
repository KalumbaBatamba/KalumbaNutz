using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NWAT.DB
{
    public class ProjectProductController : DbController
    {

        public ProjectProductController() : base() { }
        public ProjectProductController(NWATDataContext dataContext) 
            : base(dataContext) { }



        /// <summary>
        /// Gets the project product by ids.
        /// </summary>
        /// <param name="projectId">The project identifier.</param>
        /// <param name="productId">The product identifier.</param>
        /// <returns>
        /// A instance of ProjectProduct with given projectId and productId
        /// </returns>
        /// Erstellt von Joshua Frey, am 12.01.2016
        public ProjectProduct GetProjectProductByIds(int projectId, int productId)
        {
            ProjectProduct resultProduct = base.DataContext.ProjectProduct.SingleOrDefault(projProd => projProd.Project_Id == projectId &&
                                                                                                       projProd.Product_Id == productId);
            return resultProduct;
        }


        /// <summary>
        /// Gets all project products for one project.
        /// </summary>
        /// <param name="projectId">The project identifier.</param>
        /// <returns>
        /// list of all project products for one project
        /// </returns>
        /// Erstellt von Joshua Frey, am 04.01.2016
        public List<ProjectProduct> GetAllProjectProductsForOneProject(int projectId)
        {
            List<ProjectProduct> allProjectProductsForOneProject = base.DataContext.ProjectProduct.Where(projectProduct => projectProduct.Project_Id == projectId).ToList();
            return allProjectProductsForOneProject;
        }

        /// <summary>
        /// Changes the allocation of project producst list in database.
        /// </summary>
        /// <param name="projectId">The project identifier.</param>
        /// <param name="newProjectProductList">The new project product list.</param>
        /// <returns>
        /// boolean, if chacnges were done successfully
        /// </returns>
        /// Erstellt von Joshua Frey, am 12.01.2016
        public bool ChangeAllocationOfProjectProducstListInDb(int projectId, List<ProjectProduct> newProjectProductList)
        {
            bool deallocationSuccessful = true;
            bool allocationSuccessful = true;
            List<ProjectProduct> listFromDb = GetAllProjectProductsForOneProject(projectId);

            List<ProjectProduct> newToAdd = GetNewProjectCriterionsWhichWereAllocated(listFromDb, newProjectProductList);

            foreach (ProjectProduct newProjProd in newToAdd)
            {
                allocationSuccessful = AllocateProduct(projectId, newProjProd);
            }
           

            List<ProjectProduct> oldToDelete = GetOldProjectProductsWhichWereDeallocated(listFromDb, newProjectProductList);
            
            foreach(ProjectProduct oldProjProd in oldToDelete)
            {
                deallocationSuccessful = DeallocateProductFromProject(projectId, oldProjProd);
            }

            return deallocationSuccessful && allocationSuccessful;

        }

        /// <summary>
        /// Deletes the project product from database.
        /// </summary>
        /// <param name="projectId">The project identifier.</param>
        /// <param name="productId">The product identifier.</param>
        /// <returns>
        /// boolean if deletion was successful
        /// </returns>
        /// Erstellt von Joshua Frey, am 12.01.2016
        public bool DeleteProjectProductFromDb(int projectId, int productId)
        {
            ProjectProduct projProdToDelete = base.DataContext.ProjectProduct.SingleOrDefault(projProd => projProd.Project_Id == projectId &&
                                                                                                          projProd.Product_Id == productId);
            base.DataContext.ProjectProduct.DeleteOnSubmit(projProdToDelete);
            base.DataContext.SubmitChanges();

            return GetProjectProductByIds(projectId, productId) == null;
        }

        
        /*
         * Private section
         */


        /// <summary>
        /// Deallocates the product from project and deletes all allocated fulfillment entries
        /// </summary>
        /// <param name="projectId">The project identifier.</param>
        /// <param name="productToDeallocate">The product to deallocate.</param>
        /// <returns>
        /// boolean, if deallocation was successful and all allocated fulfillment entries were delted successfully
        /// </returns>
        /// Erstellt von Joshua Frey, am 12.01.2016
        private bool DeallocateProductFromProject(int projectId, ProjectProduct productToDeallocate)
        {
            bool fulfillmentDeletionSuccessful;
            int idOfProductToDeallocate = productToDeallocate.Product_Id;
            string nameOfProductToDeallocate = productToDeallocate.Product.Name;
            using (FulfillmentController fulfillContr = new FulfillmentController())
            {
                fulfillmentDeletionSuccessful = fulfillContr.DeleteAllFulfillmentsForOneProductInOneProject(projectId, idOfProductToDeallocate);
            }

            if (fulfillmentDeletionSuccessful && DeleteProjectProductFromDb(projectId, idOfProductToDeallocate))
            {
                return true;
            }
            else
            {
                MessageBox.Show(String.Format(@"Bei dem Entkoppeln des Produkts {0} ist ein Fehler aufgetreten."), nameOfProductToDeallocate);
                return false;
            }
        }


        /// <summary>
        /// Allocates the product.
        /// </summary>
        /// <param name="projectId">The project identifier.</param>
        /// <param name="projProd">The proj product.</param>
        /// <returns>
        /// boolean, if allocation to ProjectProduct and Fulfillment table was successful
        /// </returns>
        /// Erstellt von Joshua Frey, am 12.01.2016
        /// <exception cref="NWATException"></exception>
        private bool AllocateProduct(int projectId, ProjectProduct projProd)
        {
            bool insertionProjectProductSuccessful = true;
            bool insertionFulfillmentSuccessful = true;

            int productId = projProd.Product_Id;
            
            if (productId != 0 && projProd.Project_Id != 0)
            {
                insertionProjectProductSuccessful = InsertProjectProductIntoDb(projProd);

                // get all project criterions to create new fulfillment entries
                List<ProjectCriterion> allProjectCriterions;
                using (ProjectCriterionController projCritCont = new ProjectCriterionController())
                {
                    allProjectCriterions = projCritCont.GetAllProjectCriterionsForOneProject(projectId);
                }

                // create fulfillment entry for this product and each project criterion
                using (FulfillmentController fulfillCont = new FulfillmentController())
                {
                    foreach (ProjectCriterion projCrit in allProjectCriterions)
                    {
                        int criterionId = projCrit.Criterion_Id;
                        if (!fulfillCont.InsertFullfillmentInDb(projectId, productId, criterionId))
                        {
                            insertionFulfillmentSuccessful = false;
                            throw (new NWATException(CommonMethods.MessageInsertionToFulFillmentTableFailed(productId, criterionId)));
                        }
                    }
                }
            }
            return insertionFulfillmentSuccessful && insertionProjectProductSuccessful;
        }

        /// <summary>
        /// Insertts the project product into database.
        /// </summary>
        /// <param name="newProjectProduct">The new project product.</param>
        /// <returns>
        /// true if insertion was successful
        /// </returns>
        /// Erstellt von Joshua Frey, am 12.01.2016
        /// <exception cref="NWATException">
        /// </exception>
        private bool InsertProjectProductIntoDb(ProjectProduct newProjectProduct)
        {
            if (newProjectProduct != null)
            {
                int newProjectId = newProjectProduct.Project_Id;
                int newProductId = newProjectProduct.Product_Id;

                if (!CheckIfProjectProductAlreadyExists(newProjectId, newProductId))
                {
                    base.DataContext.ProjectProduct.InsertOnSubmit(newProjectProduct);
                    base.DataContext.SubmitChanges();
                }
                else
                {
                    ProjectProduct alreadyExistingProjectProduct = GetProjectProductByIds(newProjectId, newProductId);
                    string existingProjectName = alreadyExistingProjectProduct.Project.Name;
                    string existingProductName = alreadyExistingProjectProduct.Product.Name;
                    throw new NWATException(MessageProductIsAlreadyAllocatedToProject(existingProjectName, existingProductName));
                }
                return CheckIfSameProjectProduct(newProjectProduct, GetProjectProductByIds(newProjectId, newProductId));
            }
            else
            {
                throw new NWATException(MessageProjectProductCouldNotBeSavedEmptyObject());
            }
        }



        /// <summary>
        /// Checks if project product already exists.
        /// </summary>
        /// <param name="projectId">The project identifier.</param>
        /// <param name="productId">The product identifier.</param>
        /// <returns>
        /// bool if project product with given ids already exists.
        /// </returns>
        /// Erstellt von Joshua Frey, am 28.12.2015
        private bool CheckIfProjectProductAlreadyExists(int projectId, int productId)
        {
            ProjectProduct existingProjectProduct = this.GetProjectProductByIds(projectId, productId);
            if (existingProjectProduct != null)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Checks if same project product.
        /// </summary>
        /// <param name="projProdOne">The proj product one.</param>
        /// <param name="projProdTwo">The proj product two.</param>
        /// <returns>
        /// boolean if given project products are the same.
        /// </returns>
        /// Erstellt von Joshua Frey, am 12.01.2016
        public bool CheckIfSameProjectProduct(ProjectProduct projProdOne, ProjectProduct projProdTwo)
        {
            bool sameProjectId = projProdOne.Project_Id == projProdTwo.Project_Id;
            bool sameProductId = projProdOne.Product_Id == projProdTwo.Product_Id;
            return sameProductId && sameProjectId;
        }

        /// <summary>
        /// Gets the old project products which were deallocated in a new list. This list contains all project products
        /// which have to be deleted in the db table
        /// </summary>
        /// <param name="listFromDb">The list from database.</param>
        /// <param name="newProjectProductList">The new project produc list.</param>
        /// <returns>
        /// A list that contains all project product
        /// which have to be deleted in the db table
        /// </returns>
        /// Erstellt von Joshua Frey, am 28.12.2015
        private List<ProjectProduct> GetOldProjectProductsWhichWereDeallocated(List<ProjectProduct> listFromDb, List<ProjectProduct> newProjectProductList)
        {
            List<ProjectProduct> resultProjProdList = new List<ProjectProduct>();

            foreach (ProjectProduct projProdFromDb in listFromDb)
            {
                ProjectProduct projProdExistingInBothList = newProjectProductList.SingleOrDefault(newProjProd =>
                                                                    newProjProd.Product_Id == projProdFromDb.Product_Id);
                if (projProdExistingInBothList == null)
                {
                    resultProjProdList.Add(projProdFromDb);
                }
            }

            return resultProjProdList;
        }

        /// <summary>
        /// Gets the new project product which were allocated in a new list. This list contains all project products
        /// which have to be inserted into the db table
        /// </summary>
        /// <param name="listFromDb">The list from database.</param>
        /// <param name="newProjectProductList">The new project product list.</param>
        /// <returns> 
        /// A list that contains all project products
        /// which have to be inserted in the db table
        /// </returns>
        /// Erstellt von Joshua Frey, am 28.12.2015
        private List<ProjectProduct> GetNewProjectCriterionsWhichWereAllocated(List<ProjectProduct> listFromDb, List<ProjectProduct> newProjectProductList)
        {
            List<ProjectProduct> resultProjProdList = new List<ProjectProduct>();

            foreach (ProjectProduct newAllocatedProd in newProjectProductList)
            {
                ProjectProduct projProdExistingInBothLists = listFromDb.SingleOrDefault(allocatedProdInDb =>
                                                    allocatedProdInDb.Product_Id == newAllocatedProd.Product_Id);
                if (projProdExistingInBothLists == null)
                {
                    resultProjProdList.Add(newAllocatedProd);
                }
            }
            return resultProjProdList;
        }


        /*
         * Messages
         */

        private string MessageProjectProductCouldNotBeSavedEmptyObject()
        {
            return "Das Projektprodukt konnte nicht in der Datenbank gespeichert werden." +
                   " Bitte überprüfen Sie das übergebene Projektprodukt Objekt.";
        }

        private string MessageProductIsAlreadyAllocatedToProject(string projectName, string productName)
        {
            return String.Format(@"Das Produkt {0} ist bereits dem Projekt {1} zugeordnet", projectName, productName);
        }
    }
}
