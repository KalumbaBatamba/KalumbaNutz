using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NWAT.DB;
using System.Collections.ArrayList;

namespace NWAT
{
    class Analysis
    {
        private FulfillmentController fulfillContr;
        private ProjectCriterionController projCritContr;

        public Analysis()
        {
            this.fulfillContr = new FulfillmentController();
            this.projCritContr = new ProjectCriterionController();
        }




        // TODO By Yann
        public void Analyse()
        {
            // this instance of project criterion controller is needed to work with the Project_Criterion table
            ProjectCriterionController projCritController = new ProjectCriterionController();

            // This method will return all project ctiterions for one project
            int projectId = 0;
            List<ProjectCriterion> projectCriterions = projCritController.GetAllProjectCriterionsForOneProject(projectId);

            // this method will give you all children of one project criterion (id)
            int parentId = 1;
            List<ProjectCriterion> children = projCritController.GetChildCriterionsByParentId(projectId, parentId);

            // this method will return all project Criterions, which don't have any parent_id --> so the base criterions will be returned
            List<ProjectCriterion> baseCriterions = projCritController.GetBaseProjectCriterions(projectId);




        }
    }

    // TODO By Yann
    class AnalysisCriterionResult
    {

        private String critName;
        private String critDescription;
        private int cardinalWeighting;
        private double layerPercentageWeighting;
        private double projectPercentageWeighting;
        List<ProductCriterionFulfillmentResult> productResults;

        public AnalysisCriterionResult(String critName)
        {
            this.critName = critName;
        }


    }



    // Class for the list of each Product with their respective Criterion and their fulfillment
    class ProductCriterionFulfillmentResult
    {
        int criterionId;
        string productName;
        double result;
        int projectId = 0;
        String criterionName;



        public ProductCriterionFulfillmentResult(string productName, int criterionId, String criterionName, double result)
        {
            this.productName = productName;
            this.result = result;
            this.criterionId = criterionId;
            this.criterionName = criterionName;

        }

        public List<ProductCriterionFulfillmentResult> Listtoshow()
        {
            //calculate the Weighting_Percentage_Project for each parentcriterion and generate a list of each product with their respective  Weighting_Percentage_Project



            ProjectCriterionController projCritController = new ProjectCriterionController();
            ProjectProductController projprodContr = new ProjectProductController();
            List<ProjectProduct> projprod = projprodContr.GetAllProjectProductsForOneProject(projectId);
            List<ProjectCriterion> pjcrit = projCritController.GetBaseProjectCriterions(projectId);
            List<ProjectCriterion> critall = projCritController.GetAllProjectCriterionsForOneProject(projectId);

            foreach (ProjectCriterion allcrit in critall)
                foreach (ProjectProduct prod in projprod)
                    foreach (ProjectCriterion pcrit in pjcrit)
                    {
                        if (pcrit.Criterion.Criterion_Id.Equals(allcrit.Parent_Criterion_Id.Value))
                        {

                            result += pcrit.Weighting_Percentage_Project;

                            List<ProductCriterionFulfillmentResult> Listtoshows = new List<ProductCriterionFulfillmentResult>();

                            ProductCriterionFulfillmentResult pf = new ProductCriterionFulfillmentResult(prod.Product.Name, pcrit.Criterion.Criterion_Id, pcrit.Criterion.Name, result);
                            Listtoshows.Add(pf);

                        }
                        

                    }

            
        }

    }
}
