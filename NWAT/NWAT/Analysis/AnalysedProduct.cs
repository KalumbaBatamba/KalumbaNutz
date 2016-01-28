using NWAT.DB;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NWAT.Analysis
{
    public class AnalysedProduct
    {
        private List<AnalysisResultCrit> _analysisResultCrits;

        public List<AnalysisResultCrit> AnalysisResultCrits
        {
            get { return _analysisResultCrits; }
            set { _analysisResultCrits = value; }
        }

        private List<AnalysisResultCrit> _sortedAnalysisResultCrits;

        public List<AnalysisResultCrit> SortedAnalysisResultCrits
        {
            get { return _sortedAnalysisResultCrits; }
            set { _sortedAnalysisResultCrits = value; }
        }
        

        private ProjectCriterionController _projCritContr;

        public ProjectCriterionController ProjCritContr
        {
            get { return _projCritContr; }
            set { _projCritContr = value; }
        }

        private double _productAnalysisResult;

        public double ProductAnalysisResult
        {
            get { return _productAnalysisResult; }
            set { _productAnalysisResult = value; }
        }

        private ProjectProduct _projProd;

        public ProjectProduct ProjProd
        {
            get { return _projProd; }
            set { _projProd = value; }
        }

        private int _projectId;

        public int ProjectId
        {
            get { return _projectId; }
            set { _projectId = value; }
        }

        private FulfillmentController _fulFillContr;

        public FulfillmentController FulFillContr
        {
            get { return _fulFillContr; }
            set { _fulFillContr = value; }
        }
        

        /// <summary>
        /// Initializes a new instance of the <see cref="AnalysedProduct"/> class.
        /// </summary>
        /// <param name="projProd">The proj product.</param>
        /// Erstellt von Joshua Frey, am 20.01.2016
        public AnalysedProduct(ProjectProduct projProd)
        {
            this.ProjProd = projProd;
            this.ProjCritContr = new ProjectCriterionController();
            this.FulFillContr = new FulfillmentController();
            this.AnalysisResultCrits = new List<AnalysisResultCrit>();
            this.ProjectId = this.ProjProd.Project_Id;
            CalculateAnalysedProductResult();
        }

        /// <summary>
        /// Calculates the analysed product result.
        /// </summary>
        /// Erstellt von Joshua Frey, am 20.01.2016
        /// <exception cref="NWATException">Vaterknoten konnte nicht gefunden werden.</exception>
        private void CalculateAnalysedProductResult()
        {
            FillResultProjectCriterionsList();

            // gets deepest layer in tree (no children below)
            int highestLayer = this.ProjCritContr.GetHighestLayerNumberInProject(this.ProjectId);

            // travers through all layers descending
            for (int currentLayer = highestLayer; currentLayer > 0; currentLayer--)
            {

                // gets all result criterion in ones layer
                List<AnalysisResultCrit> allResultCriterionsInOneLayer = this.AnalysisResultCrits.Where(
                                        resCrit => resCrit.ProjCrit.Layer_Depth == currentLayer).ToList();

                // if not layer 1 (base criterion) then calculate all parents above this layer
                if (currentLayer != 1)
                {
                    // travers through all result crits in one layer
                    foreach (AnalysisResultCrit resultCrit in allResultCriterionsInOneLayer)
                    {
                        // gets parent of current result crit
                        AnalysisResultCrit parentResultCrit = this.AnalysisResultCrits.SingleOrDefault(
                            resCrit => resCrit.ProjCrit.Criterion_Id == resultCrit.ProjCrit.Parent_Criterion_Id);

                        // if there is no parent and current result crit is not one of the base criterions, throw exception
                        // because every criterion that is not a base criterion should have one parent.
                        if (parentResultCrit == null)
                        {
                            throw new NWATException("Vaterknoten konnte nicht gefunden werden.");
                        }

                        // parent was not recalculated then calculate new result value of parent
                        // else parent has already a recalculated result value and calculation can be skipped
                        if (parentResultCrit.IsReCalculated == false)
                        {
                            List<AnalysisResultCrit> siblings = this.AnalysisResultCrits.Where(
                                resCrit => resCrit.ProjCrit.Parent_Criterion_Id == parentResultCrit.ProjCrit.Criterion_Id).ToList();
                            double tempResultForParent = CalculateWithSiblings(ref siblings);
                            parentResultCrit.ResultValue = tempResultForParent;
                            parentResultCrit.IsReCalculated = true;
                        }
                    }
                }

                // when loop reaches layer 1 (base criterions), then calculate total result for this product
                else
                {
                    this.ProductAnalysisResult = CalculateWithSiblings(ref allResultCriterionsInOneLayer);
                }
            }

            // sort result criterion list at the end, so that children are after their parents
            DetermineSortedAnalysisResultList();
        }

        /// <summary>
        /// Determines the sorted analysis result list.
        /// </summary>
        /// Erstellt von Joshua Frey, am 21.01.2016
        private void DetermineSortedAnalysisResultList()
        {
            this.SortedAnalysisResultCrits = new List<AnalysisResultCrit>();

            List<ProjectCriterion> sortedProjCriterionFromDb = this.ProjCritContr.GetSortedCriterionStructure(this.ProjectId);

            foreach (ProjectCriterion projCrit in sortedProjCriterionFromDb)
            {
                this.SortedAnalysisResultCrits.Add(this.AnalysisResultCrits.Single(resCrit => resCrit.ProjCrit.Criterion_Id == projCrit.Criterion_Id));
            }
        }

        /// <summary>
        /// Calculates the percentage project weighting for the parent/whole product with siblings.
        /// </summary>
        /// <param name="siblings">The siblings.</param>
        /// <returns></returns>
        /// Erstellt von Joshua Frey, am 20.01.2016
        private double CalculateWithSiblings(ref List<AnalysisResultCrit> siblings)
        {
            double tempResultForParent = 0;
            foreach (AnalysisResultCrit currentSibling in siblings)
            {
                Fulfillment siblingFulFillment = this.FulFillContr.GetFulfillmentByIds(
                    this.ProjectId,
                    this.ProjProd.Product_Id,
                    currentSibling.ProjCrit.Criterion_Id);

                bool currentSiblingIsFulfilled = siblingFulFillment.Fulfilled;

                if (currentSiblingIsFulfilled)
                {
                    tempResultForParent += currentSibling.ResultValue;
                }
                else
                {
                    currentSibling.ResultValue = 0;
                }
            }
            return Math.Round(tempResultForParent, 6, MidpointRounding.ToEven);
        }

        /// <summary>
        /// Fills the result project criterions list.
        /// </summary>
        /// Erstellt von Joshua Frey, am 20.01.2016
        private void FillResultProjectCriterionsList()
        {
            List<ProjectCriterion> allProjectCriterions = this.ProjCritContr.GetAllProjectCriterionsForOneProject(this.ProjectId);

            foreach (ProjectCriterion projCrit in allProjectCriterions)
            {
                this.AnalysisResultCrits.Add(new AnalysisResultCrit(projCrit));
            }
        }
        
        
        

    }
}
