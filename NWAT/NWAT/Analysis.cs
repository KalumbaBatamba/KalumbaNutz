using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NWAT.DB;

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




        // Erstellt von Weloko Tchokoua
        // calculate the fullfilment level of each product and generate a list to print.

        public void Analyse()
        {
            int projectId = 0;
             int productId= 0;
            int parentId = 0;
            int projCritId = 0;

            // this instance of project criterion controller is needed to work with the Project_Criterion table
            // This method will return all project ctiterions for one project
            ProjectCriterionController projCritController = new ProjectCriterionController();
            List<ProjectCriterion> projectCriterions = projCritController.GetAllProjectCriterionsForOneProject(projectId);
           
            // this method will give you all children of one project criterion (id)
            List<ProjectCriterion> children = projCritController.GetChildCriterionsByParentId(projectId, parentId);

            // this method will return all project Criterions, which don't have any parent_id --> so the base criterions will be returned
            List<ProjectCriterion> baseCriterions = projCritController.GetBaseProjectCriterions(projectId);

            // this instance of fulfillment controller is needed to work with the Fulfillment table
            // This method will return all fulfillment for one project
            FulfillmentController fulfillController = new FulfillmentController();
            Fulfillment fulfiller = fulfillController.GetFulfillmentByIds(projectId,productId,projCritId);

            // this instance of project product controller is needed to work with the Project_Product table
            // This method will return all product for one project
            ProjectProductController prodController = new ProjectProductController();
            List<ProjectProduct> productINproject = prodController.GetAllProjectProductsForOneProject(projectId);



            

                 foreach (ProjectProduct product in productINproject)
                 {
                      float sumOfpercentagelayerWeightings = 0;
                      float fulfillment_grad = 0;
                      //float fulfillgrad_final = 0;
                      List<ProjectCriterion> listbasecrit = projCritController.GetSortedCriterionStructure(projectId);
                     
                         foreach (ProjectCriterion projcrite in listbasecrit)
                         foreach (ProjectCriterion parent in baseCriterions)

                         {
                             int maxlayer = int.MaxValue;
                             maxlayer = Math.Max(projcrite.Layer_Depth, maxlayer) + 1;
                             for (projcrite.Layer_Depth = 1; projcrite.Layer_Depth < maxlayer; projcrite.Layer_Depth--)
                               {
                                   while (fulfiller.Fulfilled == true && projcrite.Layer_Depth > 1 )
                                   {
                                   projCritController.UpdateAllPercentageLayerWeightings(projectId);
                                
                                     sumOfpercentagelayerWeightings += (float)projcrite.Weighting_Percentage_Layer;
                                     fulfillment_grad = sumOfpercentagelayerWeightings * (float)parent.Weighting_Percentage_Layer;


                                   }

                               }
                         }

                 }

             }
            
        }
    }

    // Erstellt von Weloko Tchokoua
    class AnalysisCriterionResult
    {

        private String critName;
        private String critDescription;
        private int cardinalWeighting;
        private double layerPercentageWeighting;
        private double projectPercentageWeighting;
        List<ProductCriterionFulfillmentResult> productResults;

        public AnalysisCriterionResult()
        {
            /// this.critName = critName;
            // this.critDescription = critDescription;
            //this.cardinalWeighting = cardinalWeighting;
            // this.layerPercentageWeighting = layerPercentageWeighting;
            // this.projectPercentageWeighting = projectPercentageWeighting;


        }

        //Generate a list of all criterions for the view of the analysis.
        public void Analyseresult()
        {
            int projectId = 0;

            ProjectCriterionController projCritController = new ProjectCriterionController();
            ProjectProductController projprodContr = new ProjectProductController();
            List<ProjectProduct> projprod = projprodContr.GetAllProjectProductsForOneProject(projectId);
            List<ProjectCriterion> pjcrit = projCritController.GetBaseProjectCriterions(projectId);
            List<ProjectCriterion> critall = projCritController.GetAllProjectCriterionsForOneProject(projectId);
            List<ProductCriterionFulfillmentResult> Listtoshows = new List<ProductCriterionFulfillmentResult>();
            AnalysisCriterionResult Anacritresult = new AnalysisCriterionResult();

            // To do write the algo to generate a list of each product with all information of their criterions and their fulfillment

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

        //Constructor of the class to generate the list of product and criterion
        public ProductCriterionFulfillmentResult(string productName, int criterionId, String criterionName, double result)
        {
            this.productName = productName;
            this.result = result;
            this.criterionId = criterionId;
            this.criterionName = criterionName;


        }

        //calculate the Weighting_Percentage_Project for each parentcriterion and generate a list of each product with their respective  Weighting_Percentage_Project

        public List<ProductCriterionFulfillmentResult> Listtoshow()
        {


            ProjectCriterionController projCritController = new ProjectCriterionController();
            ProjectProductController projprodContr = new ProjectProductController();
            List<ProjectProduct> projprod = projprodContr.GetAllProjectProductsForOneProject(projectId);
            List<ProjectCriterion> pjcrit = projCritController.GetBaseProjectCriterions(projectId);
            List<ProjectCriterion> critall = projCritController.GetAllProjectCriterionsForOneProject(projectId);
            List<ProductCriterionFulfillmentResult> Listtoshows = new List<ProductCriterionFulfillmentResult>();


            foreach (ProjectCriterion allcrit in critall)
                foreach (ProjectProduct prod in projprod)
                    foreach (ProjectCriterion pcrit in pjcrit)
                    {
                        if (pcrit.Criterion.Criterion_Id.Equals(allcrit.Parent_Criterion_Id.Value))
                        {

                            result += pcrit.Weighting_Percentage_Project.Value;



                            ProductCriterionFulfillmentResult pf = new ProductCriterionFulfillmentResult(prod.Product.Name, pcrit.Criterion.Criterion_Id, pcrit.Criterion.Name, result);
                            Listtoshows.Add(pf);

                        }


                    }

            return Listtoshows;
        }

    }


