using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWAT.DB
{
    class ProjectProductController
    {

        // TODO get Project Product by ids
        public ProjectProduct GetProjectProductByIds(int projectId, int productId)
        {
            return new ProjectProduct();
        }

        // TODO get all projectProducts for one Project from db
        public List<ProjectProduct> GetAllProjectProductsForOneProject(int projectId)
        {
            return new List<ProjectProduct>();

        }

        // TODO insert Project Product 
        // private machen?
        public bool InserttProjectProductIntoDb(ProjectProduct newProd)
        { return true; }

        // TODO delete single Product wird in delete from list aufgerufen
        // private machen?
        public bool DeleteProjectProductFromDb(int projectId, int productId)
        { return true; }

        // TODO updateProjectProductListInDb 
        // params: ProjectID und die aktuelle Liste die vom Benutzer zugeordnet wurde.
        // Diese liste wird nun mit den Einträgen verglichen und die Db auf diese Liste aktualisiert
        // --> lösche nicht mehr vorhandene Einträge
        // --> füge neue Einträge hinzu
        public bool ChangeAllocationOfProjectProducstListInDb(int projectId, ProjectProduct newProjectProductList)
        {
            /*
             * listFromDb = GetAllProjectProductsForOneProject(projectId)
             * 
             * oldToDelete = GetOldProjectProductsWhichWereDeallocated(listFromDb, newProjectProductList);
             * foreach (prod in oldToDelete)
             * {
             *      DeleteSingleProduct(prod)
             * }
             * 
             * newToAdd = GetNewProjectProductsWhichWereAllocated(listFromDb, newProjectProductList);
             * foreach (prod in newToAdd)
             * {
             *      Insert(prod)
             * }
             * 
             */
            return true;
        }
        
        /*
         * Private section
         */

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
            resultProjProdList = listFromDb.Except(newProjectProductList).ToList();
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
            resultProjProdList = newProjectProductList.Except(listFromDb).ToList();
            return resultProjProdList;
        }

    }
}
