using NWAT.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWAT
{
    class FunctioningAnalysis
    {
        private ProjectProductController _projProdContr;

        public enum SortDirection { Ascending, Descending }

        public ProjectProductController ProjProdContr
        {
            get { return _projProdContr; }
            set { _projProdContr = value; }
        }
        

        private List<ProjectProduct> _projectProductsForThisProject;

        public List<ProjectProduct> ProjectProductsForThisProject
        {
            get { return _projectProductsForThisProject; }
            set { _projectProductsForThisProject = value; }
        }

        private int _projectId;

        public int ProjectId
        {
            get { return _projectId; }
            set { _projectId = value; }
        }

        private List<AnalysedProduct> _sortedAnalysedProducts;

        public List<AnalysedProduct> SortedAnalysedProducts
        {
            get { return _sortedAnalysedProducts; }
            set { _sortedAnalysedProducts = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FunctioningAnalysis"/> class.
        /// </summary>
        /// <param name="projectId">The project identifier.</param>
        /// Erstellt von Joshua Frey, am 24.01.2016
        public FunctioningAnalysis(int projectId)
        {
            this.ProjectId = projectId;
            this.ProjProdContr = new ProjectProductController();
            this.ProjectProductsForThisProject = this.ProjProdContr.GetAllProjectProductsForOneProject(projectId);
            this.SortedAnalysedProducts = new List<AnalysedProduct>();
        }

        /// <summary>
        /// Gets the sorted analysed products in a list
        /// </summary>
        /// <returns></returns>
        /// Erstellt von Joshua Frey, am 24.01.2016
        public List<AnalysedProduct> GetSortedAnalysedProducts()
        {
            foreach (ProjectProduct projProdToAnalyse in this.ProjectProductsForThisProject)
            {
                AnalysedProduct currAnalysedProd = new AnalysedProduct(projProdToAnalyse);
                this.SortedAnalysedProducts.Add(currAnalysedProd);
            }

            // the sorting: list will be returned sorted descending
            this.SortedAnalysedProducts = this.SortedAnalysedProducts.OrderByDescending(anaProd => anaProd.ProductAnalysisResult).ToList();

            return this.SortedAnalysedProducts;
        }

    }
}
