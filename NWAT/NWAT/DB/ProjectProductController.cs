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
        public bool Insert(ProjectProduct newProd)
        { return true; }

        // TODO update Project Product
        public bool Update(ProjectProduct alteredProjectProduct)
        { return true; }

        // TODO delete single Product wird in delete from list aufgerufen
        public bool DeleteSingleProduct(ProjectProduct projectProductToDelete)
        { return true; }

        // TODO updateProjectProductListInDb 
        // params: ProjectID und die aktuelle Liste die vom Benutzer zugeordnet wurde.
        // Diese liste wird nun mit den Einträgen verglichen und die Db auf diese Liste aktualisiert
        // --> lösche nicht mehr vorhandene Einträge
        // --> füge neue Einträge hinzu
        public bool UpdateProjectProductListInDb(int projectId, ProjectProduct newProjectProductList)
        {
            /*
             * listFromDb = GetAllProjectProductsForOneProject(projectId)
             * 
             * oldToDelete = getOldProjectProductsWhichWereDeallocated();
             * foreach (prod in oldToDelete)
             * {
             *      DeleteSingleProduct(prod)
             * }
             * 
             * newToAdd = getNewProjectProductsWhichWereAllocated();
             * foreach (prod in newToAdd)
             * {
             *      Insert(prod)
             * }
             * 
             */
            return true;
        }
        



    }
}
