using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NWAT.DB
{
    class ProjectExporter
    {
        // the pipe symbol is used to seperate the columns in the csv files.
        private readonly string _delimiter = "|";

        private int _projectId;

        public int ProjectId
        {
            get { return _projectId; }
            set { _projectId = value; }
        }

        private string _exportFilePath;

        public string ExportFilePath
        {
            get { return _exportFilePath; }
            set { _exportFilePath = value; }
        }

        private string _projectName;

        public string ProjectName
        {
            get { return _projectName; }
            set { _projectName = value; }
        }

        private string _timestamp;

	    public string Timestamp
	    {
		    get { return _timestamp;}
		    set { _timestamp = value;}
	    }

        private string _fileBaseName;

        public string FileBaseName
        {
            get { return _fileBaseName; }
            set { _fileBaseName = value; }
        }

        private List<string> _exportFilePaths;

        public List<string> ExportFilePaths
        {
            get { return _exportFilePaths; }
            set { _exportFilePaths = value; }
        }
        

        
        // DB controller

        private ProjectController _exportProjectController;

	    public ProjectController ExportProjectController
	    {
            get { return _exportProjectController; }
            set { _exportProjectController = value; }
	    }

        private CriterionController _exportCriterionController;

        public CriterionController ExportCriterionController
        {
            get { return _exportCriterionController; }
            set { _exportCriterionController = value; }
        }

        private ProductController _exportProductController;

        public ProductController ExportProductController
        {
            get { return _exportProductController; }
            set { _exportProductController = value; }
        }

        private ProjectCriterionController _exportProjectCriterionController;

        public ProjectCriterionController ExportProjectCriterionController
        {
            get { return _exportProjectCriterionController; }
            set { _exportProjectCriterionController = value; }
        }

        private ProjectProductController _exportProjectProductController;

        public ProjectProductController ExportProjectProductController
        {
            get { return _exportProjectProductController; }
            set { _exportProjectProductController = value; }
        }

        private FulfillmentController _exportFulfillmentController;

        public FulfillmentController ExportFulfillmentController
        {
            get { return _exportFulfillmentController; }
            set { _exportFulfillmentController = value; }
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectExporter"/> class.
        /// </summary>
        /// <param name="projectIdToExport">The project identifier to export.</param>
        /// <param name="exportDirectoryPath">The export file path.</param>
        /// Erstellt von Joshua Frey, am 13.01.2016
        public ProjectExporter(int projectIdToExport, string exportDirectoryPath)
        {
            // initialize db controller
            ExportProjectController = new ProjectController();
            ExportCriterionController = new CriterionController();
            ExportProductController = new ProductController();
            ExportProjectCriterionController = new ProjectCriterionController();
            ExportProjectProductController = new ProjectProductController();
            ExportFulfillmentController = new FulfillmentController();

            this.ExportFilePaths = new List<string>();

            ProjectId = projectIdToExport;
            ProjectName = ExportProjectController.GetProjectById(projectIdToExport).Name;
            Timestamp = CreateTimestampForFile();

            ExportFilePath = exportDirectoryPath;

            FileBaseName = String.Format(@"{0}\{1}_Project_{2}", ExportFilePath, Timestamp, ProjectName);
        }


        /// <summary>
        /// Archives the whole project. This is the main method which will be called
        /// </summary>
        /// Erstellt von Joshua Frey, am 13.01.2016
        public void ArchiveWholeProject()
        {
            string logFilePath = this.FileBaseName + ".log";
            this.ExportFilePaths.Add(logFilePath);

            // Create Logfile and Logfile Writer
            if (!File.Exists(logFilePath))
            {
                File.Create(logFilePath).Close();
            }
            StreamWriter archiveLogWriter = File.AppendText(logFilePath);
            // You have to stick to the export order. Otherwise there won't be exported all information.

            bool allExportsSucceeded = true;

            // export FulFillment
            string fulfillmentExportFilePath = ExportFulfillments();
            if (VerifyFulfillmentsExport(fulfillmentExportFilePath))
            {
                Log(MessageExportVerified("Fulfillment"), archiveLogWriter);
            }
            else
            {
                allExportsSucceeded = false;
                Log(MessageExportNotVerified("Fulfillment"), archiveLogWriter);
            }

            // Export ProjectProducts
            string projectProductExportFilePath = ExportProjectProducts();
            if (VerifyProjectProductsExport(projectProductExportFilePath))
            {
                Log(MessageExportVerified("ProjectProduct"), archiveLogWriter);
            }
            else
            {
                allExportsSucceeded = false;
                Log(MessageExportNotVerified("ProjectProduct"), archiveLogWriter);
            }


            // Export ProjectCriterions
            string projectCriterionExportFilePath = ExportProjectCriterions();
            if (VerifyProjectCriterionsExport(projectCriterionExportFilePath))
            {
                Log(MessageExportVerified("ProjectCriterion"), archiveLogWriter);
            }
            else
            {
                allExportsSucceeded = false;
                Log(MessageExportNotVerified("ProjectCriterion"), archiveLogWriter);
            }


            // Export Products 
            string productExportFilePath = ExportProducts();
            if (VerifyProductsExport(productExportFilePath))
            {
                Log(MessageExportVerified("Product"), archiveLogWriter);
            }
            else
            {
                allExportsSucceeded = false;
                Log(MessageExportNotVerified("Product"), archiveLogWriter);
            }


            // Export criterions
            string CriterionExportFilePath = ExportCriterion();
            if (VerifyCriterionsExport(CriterionExportFilePath))
            {
                Log(MessageExportVerified("Criterion"), archiveLogWriter);
            }
            else
            {
                allExportsSucceeded = false;
                Log(MessageExportNotVerified("Product"), archiveLogWriter);
            }


            // Export project
            string projectExportFilePath = ExportProjectInformation();
            if (VerifyProjectExport(projectExportFilePath))
            {
                Log(MessageExportVerified("Project"), archiveLogWriter);
            }
            else
            {
                allExportsSucceeded = false;
                Log(MessageExportNotVerified("Project"), archiveLogWriter);
            }


            if (!allExportsSucceeded)
            {
                string exportErrorMessage = MessageWholeExportProcessFailed();
                MessageBox.Show(exportErrorMessage);
                Log(exportErrorMessage, archiveLogWriter);
                archiveLogWriter.Close();
            }
            else
            {
                string exportSuccessMessage = MessageWholeExportProcessSucceeded();
                MessageBox.Show(exportSuccessMessage);
                Log(exportSuccessMessage, archiveLogWriter);

                bool allDeletionsSucceeded = true;
                    
                // delete Data from db
                if (DeleteFulFillmentData())
                {
                    Log(MessageDeletionVerified("Fulfillment"), archiveLogWriter);
                }
                else
                {
                    Log(MessageDeletionNotVerified("Fulfillment"), archiveLogWriter);
                    allDeletionsSucceeded = false;
                }

                if (DeleteProjectProductData())
                {
                    Log(MessageDeletionVerified("ProjectProduct"), archiveLogWriter);
                }
                else
                {
                    Log(MessageDeletionNotVerified("ProjectProduct"), archiveLogWriter);
                    allDeletionsSucceeded = false;
                }

                if (DeleteProjectCriterionData())
                {
                    Log(MessageDeletionVerified("ProjectCriterion"), archiveLogWriter);
                }
                else
                {
                    Log(MessageDeletionNotVerified("ProjectCriterion"), archiveLogWriter);
                    allDeletionsSucceeded = false;
                }

                if (DeleteProductData(productExportFilePath))
                {
                    Log(MessageDeletionVerified("Product"), archiveLogWriter);
                }
                else
                {
                    Log(MessageDeletionNotVerified("Product"), archiveLogWriter);
                    allDeletionsSucceeded = false;
                }

                if (DeleteCriterionData(CriterionExportFilePath))
                {
                    Log(MessageDeletionVerified("Criterion"), archiveLogWriter);
                }
                else
                {
                    Log(MessageDeletionNotVerified("Criterion"), archiveLogWriter);
                    allDeletionsSucceeded = false;
                }

                if (DeleteProjectData())
                {
                    Log(MessageDeletionVerified("Project"), archiveLogWriter);
                }
                else
                {
                    Log(MessageDeletionNotVerified("Project"), archiveLogWriter);
                    allDeletionsSucceeded = false;
                }

                // if everey deletion was successful, the zip Process will start
                if (allDeletionsSucceeded)
                {
                    string deletionSuccess = MessageWholeDeletionProcessSucceeded();
                    MessageBox.Show(deletionSuccess);
                    Log(deletionSuccess, archiveLogWriter);
                    archiveLogWriter.Close();
                       
                    // create zip archive
                    using (ArchiveZipper archZipper = new ArchiveZipper())
                    {
                        try
                        {
                            string zipArchivePath = this.FileBaseName + ".zip";
                            archZipper.CompressFilesToZipArchive(zipArchivePath, this.ExportFilePaths);
                        }
                        catch (NWATException zipperError)
                        {
                            throw zipperError;
                        }
                    }

                    string caption = "Löschen der Export Dateien";
                    var result = MessageBox.Show(MessageZipProcessSuccessful(), caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    // User interaction --> User can decide if export files outside the zip archive should be deleted
                    if (result == DialogResult.Yes)
                    {
                        foreach (string file in this.ExportFilePaths)
                        {
                            if (File.Exists(file))
                            {
                                File.Delete(file);
                            }
                        }
                    }
                }
                else
                {
                    string deletionError = MessageWholeDeletionProcessFailed();
                    MessageBox.Show(deletionError);
                    Log(deletionError, archiveLogWriter);
                    archiveLogWriter.Close();
                }
            }
        }

        /// <summary>
        /// Exports the fulfillments.
        /// </summary>
        /// <returns>
        /// path to created export file
        /// </returns>
        /// Erstellt von Joshua Frey, am 13.01.2016
        private string ExportFulfillments()
        {
            List<Fulfillment> allFulFillmentEntriesForThisProject = this.ExportFulfillmentController.GetAllFulfillmentsForOneProject(this.ProjectId);
            string fileUri = this.FileBaseName + "_Fulfillment.txt";

            this.ExportFilePaths.Add(fileUri);

            using (StreamWriter sw = new StreamWriter(fileUri))
            {
                foreach (Fulfillment fulfillment in allFulFillmentEntriesForThisProject)
                {
                    // Project_Id|Product_Id|Criterion_Id|Fulfilled|Comment
                    string csvLine = String.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}", this._delimiter, 
                                                                                  fulfillment.Project_Id, 
                                                                                  fulfillment.Product_Id, 
                                                                                  fulfillment.Criterion_Id,
                                                                                  fulfillment.Fulfilled.ToString(),
                                                                                  fulfillment.Comment);
                    sw.WriteLine(csvLine);
                }
            }
            return fileUri;
        }

        /// <summary>
        /// Verifies the fulfillments export.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns>
        /// boolean if verification was successful
        /// </returns>
        /// Erstellt von Joshua Frey, am 13.01.2016
        private bool VerifyFulfillmentsExport(string filePath)
        {
            
            bool verification = true;
            List<Fulfillment> fulfillmentsFromDb = this.ExportFulfillmentController.GetAllFulfillmentsForOneProject(this.ProjectId);
            List<Fulfillment> exportedFulfillments = new List<Fulfillment>();
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line = "";
                while ((line = sr.ReadLine()) != null)
                {
                    AddExportedFulfillmentToList(ref exportedFulfillments, line);
                }
            }
            // if the count of lists doesn't differ 
            if (fulfillmentsFromDb.Count == exportedFulfillments.Count)
            {
                foreach (Fulfillment dbPfulfillment in fulfillmentsFromDb)
                {
                    // if one comparison has any differences, there is no need to check all data
                    if (!verification)
                        break;

                    Fulfillment searchedFulfillmentInExportedList = exportedFulfillments.SingleOrDefault(
                        fulfillment => fulfillment.Project_Id == dbPfulfillment.Project_Id &&
                                       fulfillment.Product_Id == dbPfulfillment.Product_Id &&
                                       fulfillment.Criterion_Id == dbPfulfillment.Criterion_Id &&
                                       fulfillment.Fulfilled == dbPfulfillment.Fulfilled &&
                                       fulfillment.Comment == dbPfulfillment.Comment);

                    // check if fulfillment from db was not found in exported fulfillments
                    if (searchedFulfillmentInExportedList == null)
                    {
                        verification = false;
                    }
                }
                return verification;
            }
            else
                return false;
        }

        /// <summary>
        /// Adds the exported fulfillment to list.
        /// </summary>
        /// <param name="exportedFulfillments">The exported fulfillments.</param>
        /// <param name="line">The line.</param>
        /// Erstellt von Joshua Frey, am 13.01.2016
        private static void AddExportedFulfillmentToList(ref List<Fulfillment> exportedFulfillments, string line)
        {
            var lineAsArray = line.Split('|');
            int exportedProjectId = Convert.ToInt32(lineAsArray[0]);
            int exportedProductId = Convert.ToInt32(lineAsArray[1]);
            int exportedCriterionId = Convert.ToInt32(lineAsArray[2]);
            string exportedFulfilledAsString = lineAsArray[3];
            bool exportedFulfilled;
            switch (exportedFulfilledAsString.ToLower())
            {
                case "true":
                    exportedFulfilled = true;
                    break;
                case "false":
                    exportedFulfilled = false;
                    break;
                default:
                    exportedFulfilled = false;
                    break;
            }
            string exportedComment;
            if (lineAsArray[4] == "")
            {
                exportedComment = null;
            }
            else
            {
                exportedComment = lineAsArray[4];
            }


            exportedFulfillments.Add(new Fulfillment()
            {
                Project_Id = exportedProjectId,
                Product_Id = exportedProductId,
                Criterion_Id = exportedCriterionId,
                Fulfilled = exportedFulfilled,
                Comment = exportedComment
            });
        }

        /// <summary>
        /// Exports the project products.
        /// </summary>
        /// <returns>
        /// path to created export file
        /// </returns>
        /// Erstellt von Joshua Frey, am 12.01.2016
        private string ExportProjectProducts()
        {
            List<ProjectProduct> allProjectProductsForThisProject = this.ExportProjectProductController.GetAllProjectProductsForOneProject(this.ProjectId);
            string fileUri = this.FileBaseName + "_ProjectProduct.txt";
            this.ExportFilePaths.Add(fileUri);

            using (StreamWriter sw = new StreamWriter(fileUri))
            {
                foreach (ProjectProduct projProd in allProjectProductsForThisProject)
                {
                    // Project_Id|Product_Id
                    string csvLine = String.Format("{1}{0}{2}", this._delimiter, projProd.Project_Id, projProd.Product_Id);
                    sw.WriteLine(csvLine);
                }
            }
            return fileUri;
        }

        /// <summary>
        /// Verifies the project products.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns>
        /// boolean if export of project products was successful
        /// </returns>
        /// Erstellt von Joshua Frey, am 13.01.2016
        private bool VerifyProjectProductsExport(string filePath)
        {
            bool verification = true;
            List<ProjectProduct> projProdsFromDb = this.ExportProjectProductController.GetAllProjectProductsForOneProject(this.ProjectId);
            List<ProjectProduct> exportedProjProducts = new List<ProjectProduct>();
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line = "";
                while ((line = sr.ReadLine()) != null)
                {
                    var lineAsArray = line.Split('|');
                    int exportedProjectId = Convert.ToInt32(lineAsArray[0]);
                    int exportedProductId = Convert.ToInt32(lineAsArray[1]);
                    exportedProjProducts.Add(new ProjectProduct(){Project_Id = exportedProjectId, Product_Id = exportedProductId});
                }
            }
            // if the count of lists doesn't differ 
            if (projProdsFromDb.Count == exportedProjProducts.Count)
            {
                foreach (ProjectProduct dbProjProd in projProdsFromDb)
                {
                    // if one comparison has any differences, there is no need to check all data
                    if (!verification)
                        break;

                    ProjectProduct searchedProjProdInExportedList = exportedProjProducts.SingleOrDefault(expProjProd => 
                                                                                                    expProjProd.Project_Id == dbProjProd.Project_Id &&
                                                                                                    expProjProd.Product_Id == dbProjProd.Product_Id);
                    // check if project product from db was not found in exported project products
                    if (searchedProjProdInExportedList == null)
                    {
                        verification = false;
                    }
                }
                return verification;
            }
            else
                return false;
        }

        /// <summary>
        /// Exports the project criterions.
        /// </summary>
        /// <returns>
        /// path to created export file
        /// </returns>
        /// Erstellt von Joshua Frey, am 13.01.2016
        private string ExportProjectCriterions()
        {
            List<ProjectCriterion> allProjectCriterionsForThisProject = this.ExportProjectCriterionController.GetAllProjectCriterionsForOneProject(this.ProjectId);
            string fileUri = this.FileBaseName + "_ProjectCriterion.txt";
            this.ExportFilePaths.Add(fileUri);

            using (StreamWriter sw = new StreamWriter(fileUri))
            {
                foreach (ProjectCriterion projCrit in allProjectCriterionsForThisProject)
                {
                    // Project_Id|Criterion_Id|Layer_Depth|Parent_Criterion_Id|Weighting_Cardinal|Weighting_Percentage_Layer|Weighting_Percentage_Project
                    string csvLine = String.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}{7}", 
                        this._delimiter,
                        projCrit.Project_Id, 
                        projCrit.Criterion_Id,
                        projCrit.Layer_Depth,
                        projCrit.Parent_Criterion_Id,
                        projCrit.Weighting_Cardinal,
                        projCrit.Weighting_Percentage_Layer,
                        projCrit.Weighting_Percentage_Project);
                    sw.WriteLine(csvLine);
                }
            }
            return fileUri;
        }

        /// <summary>
        /// Verifies the project criterions export.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns>
        /// boolean if export of project citerions was successful
        /// </returns>
        /// Erstellt von Joshua Frey, am 13.01.2016
        private bool VerifyProjectCriterionsExport(string filePath)
        {
            
            bool verification = true;
            List<ProjectCriterion> ProjectCriterionsFromDb = this.ExportProjectCriterionController.GetAllProjectCriterionsForOneProject(this.ProjectId);
            List<ProjectCriterion> exportedProjectCriterions = new List<ProjectCriterion>();
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line = "";
                while ((line = sr.ReadLine()) != null)
                {
                    AddExportedProjectCriterionToList(ref exportedProjectCriterions, line);
                }
            }
            // if the count of lists doesn't differ 
            if (ProjectCriterionsFromDb.Count == exportedProjectCriterions.Count)
            {
                foreach (ProjectCriterion dbProjectCriterion in ProjectCriterionsFromDb)
                {
                    // if one comparison has any differences, there is no need to check all data
                    if (!verification)
                        break;

                    ProjectCriterion searchedProjectCriterionInExportedList = exportedProjectCriterions.SingleOrDefault(
                        projCrit => projCrit.Project_Id == dbProjectCriterion.Project_Id &&
                                    projCrit.Criterion_Id == dbProjectCriterion.Criterion_Id &&
                                    projCrit.Layer_Depth == dbProjectCriterion.Layer_Depth &&
                                    projCrit.Parent_Criterion_Id == dbProjectCriterion.Parent_Criterion_Id &&
                                    projCrit.Weighting_Cardinal == dbProjectCriterion.Weighting_Cardinal &&
                                    projCrit.Weighting_Percentage_Layer == dbProjectCriterion.Weighting_Percentage_Layer &&
                                    projCrit.Weighting_Percentage_Project == dbProjectCriterion.Weighting_Percentage_Project
                        );

                    // check if project criterion from db was not found in exported project criterions
                    if (searchedProjectCriterionInExportedList == null)
                    {
                        verification = false;
                    }
                }
                return verification;
            }
            else
                return false;
        }

        /// <summary>
        /// Adds the exported project criterion to list.
        /// </summary>
        /// <param name="exportedProjectCriterions">The exported project criterions.</param>
        /// <param name="line">The line.</param>
        /// Erstellt von Joshua Frey, am 13.01.2016
        private void AddExportedProjectCriterionToList(ref List<ProjectCriterion> exportedProjectCriterions, string line)
        {
            var lineAsArray = line.Split('|');
            int exportedProjectId = Convert.ToInt32(lineAsArray[0]);
            int exportedCriterionId = Convert.ToInt32(lineAsArray[1]);
            int exportedLayerDepth = Convert.ToInt32(lineAsArray[2]);
            System.Nullable<int> exportedParentCriterionId;
            
            // check if no Parent for this crit
            if (lineAsArray[3] == "")
                exportedParentCriterionId = null;
            else
                exportedParentCriterionId  = Convert.ToInt32(lineAsArray[3]);
            int exportedCardinalWeighting = Convert.ToInt32(lineAsArray[4]);

            System.Nullable<float> exportedPercentageLayerWeighting;
            if (lineAsArray[5] == "")
                exportedPercentageLayerWeighting = null;
            else
                exportedPercentageLayerWeighting = float.Parse(lineAsArray[5]);

            System.Nullable<float> exportedPercentageProjectWeighting;
            if (lineAsArray[6] == "")
                exportedPercentageProjectWeighting = null;
            else
                exportedPercentageProjectWeighting = float.Parse(lineAsArray[5]);

            exportedProjectCriterions.Add(new ProjectCriterion()
            {
                Project_Id = exportedProjectId,
                Criterion_Id = exportedCriterionId,
                Layer_Depth = exportedLayerDepth,
                Parent_Criterion_Id = exportedParentCriterionId,
                Weighting_Cardinal = exportedCardinalWeighting,
                Weighting_Percentage_Layer = exportedPercentageLayerWeighting,
                Weighting_Percentage_Project = exportedPercentageProjectWeighting
            });
        }

        /// <summary>
        /// Exports the products.
        /// </summary>
        /// <returns>
        /// path to created export file
        /// </returns>
        /// Erstellt von Joshua Frey, am 13.01.2016
        private string ExportProducts()
        {
            List<Product> exportProducts = new List<Product>();

            AddProjectSpecificProductsToProductList(ref exportProducts);

            string fileUri = this.FileBaseName + "_Product.txt";
            this.ExportFilePaths.Add(fileUri);

            using (StreamWriter sw = new StreamWriter(fileUri))
            {
                foreach (Product prod in exportProducts)
                {
                    // Product_Id|Name|Producer|Price
                    string csvLine = String.Format("{1}{0}{2}{0}{3}{0}{4}",
                        this._delimiter,
                        prod.Product_Id,
                        prod.Name,
                        prod.Producer,
                        prod.Price);
                    sw.WriteLine(csvLine);
                }
            }
            return fileUri;
        }

        /// <summary>
        /// Adds the project specific products to product list.
        /// </summary>
        /// <param name="productList">The product list.</param>
        /// Erstellt von Joshua Frey, am 13.01.2016
        private void AddProjectSpecificProductsToProductList(ref List<Product> productList)
        {
            List<ProjectProduct> allProjectProducts = this.ExportProjectProductController.GetAllProjectProductsForOneProject(this.ProjectId);
            foreach (ProjectProduct projProd in allProjectProducts)
            {
                productList.Add(projProd.Product);
            }
        }

        /// <summary>
        /// Verifies the products export.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns></returns>
        /// Erstellt von Joshua Frey, am 13.01.2016
        private bool VerifyProductsExport(string filePath)
        {
            bool verification = true;

            List<Product> productsFromDb = new List<Product>();
            AddProjectSpecificProductsToProductList(ref productsFromDb);

            List<Product> exportedProducts = new List<Product>();
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line = "";
                while ((line = sr.ReadLine()) != null)
                {
                    AddExportedProductToList(ref exportedProducts, line);
                }
            }
            // if the count of lists doesn't differ 
            if (productsFromDb.Count == exportedProducts.Count)
            {
                foreach (Product dbProjectCriterion in productsFromDb)
                {
                    // if one comparison has any differences, there is no need to check all data
                    if (!verification)
                        break;

                    Product searchedProductInExportedList = exportedProducts.SingleOrDefault(
                        prod => prod.Product_Id == dbProjectCriterion.Product_Id &&
                                prod.Name == dbProjectCriterion.Name &&
                                prod.Producer == dbProjectCriterion.Producer &&
                                prod.Price == dbProjectCriterion.Price
                        );

                    // check if product from db was not found in exported products
                    if (searchedProductInExportedList == null)
                    {
                        verification = false;
                    }
                }
                return verification;
            }
            else
                return false;
        }

        /// <summary>
        /// Adds the exported product to list.
        /// </summary>
        /// <param name="exportedProducts">The exported products.</param>
        /// <param name="line">The line.</param>
        /// Erstellt von Joshua Frey, am 13.01.2016
        private void AddExportedProductToList(ref List<Product> exportedProducts, string line)
        {
            var lineAsArray = line.Split('|');
            int exportedProductId = Convert.ToInt32(lineAsArray[0]);
            string exportedName = lineAsArray[1];
            string exportedProducer = lineAsArray[2];
            System.Nullable<float> exportedPrice;

            if (lineAsArray[3] == "")
                exportedPrice = null;
            else
                exportedPrice = float.Parse(lineAsArray[3]);

            exportedProducts.Add(new Product()
            {
                Product_Id = exportedProductId,
                Name = exportedName,
                Producer = exportedProducer,
                Price = exportedPrice
            });
        }

        /// <summary>
        /// Exports the criterion.
        /// </summary>
        /// <returns></returns>
        /// Erstellt von Joshua Frey, am 13.01.2016
        private string ExportCriterion()
        {
            List<Criterion> exportCriterions = new List<Criterion>();

            AddProjectSpecificCriterionsToCriterionList(ref exportCriterions);

            string fileUri = this.FileBaseName + "_Criterion.txt";
            this.ExportFilePaths.Add(fileUri);

            using (StreamWriter sw = new StreamWriter(fileUri))
            {
                foreach (Criterion crit in exportCriterions)
                {
                    // Criterion_Id|Name|Description
                    string csvLine = String.Format("{1}{0}{2}{0}{3}",
                        this._delimiter,
                        crit.Criterion_Id,
                        crit.Name,
                        crit.Description);
                    sw.WriteLine(csvLine);
                }
            }
            return fileUri;
        }

        /// <summary>
        /// Adds the project specific criterions to product list.
        /// </summary>
        /// <param name="exportCriterions">The export criterions.</param>
        /// Erstellt von Joshua Frey, am 13.01.2016
        /// <exception cref="NotImplementedException"></exception>
        private void AddProjectSpecificCriterionsToCriterionList(ref List<Criterion> criterionList)
        {
            List<ProjectCriterion> allProjectCriterions = this.ExportProjectCriterionController.GetAllProjectCriterionsForOneProject(this.ProjectId);
            foreach (ProjectCriterion projCrit in allProjectCriterions)
            {
                criterionList.Add(projCrit.Criterion);
            }
        }

        /// <summary>
        /// Verifies the criterions export.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns></returns>
        /// Erstellt von Joshua Frey, am 13.01.2016
        private bool VerifyCriterionsExport(string filePath)
        {
            bool verification = true;

            List<Criterion> criterionsFromDb = new List<Criterion>();
            AddProjectSpecificCriterionsToCriterionList(ref criterionsFromDb);

            List<Criterion> exportedCriterions = new List<Criterion>();
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line = "";
                while ((line = sr.ReadLine()) != null)
                {
                    AddExportedCriterionstToList(ref exportedCriterions, line);
                }
            }
            // if the count of lists doesn't differ 
            if (criterionsFromDb.Count == exportedCriterions.Count)
            {
                foreach (Criterion dbProjectCriterion in criterionsFromDb)
                {
                    // if one comparison has any differences, there is no need to check all data
                    if (!verification)
                        break;

                    Criterion searchedCriterionInExportedList = exportedCriterions.SingleOrDefault(
                        crit => crit.Criterion_Id == dbProjectCriterion.Criterion_Id &&
                                crit.Name == dbProjectCriterion.Name &&
                                crit.Description == dbProjectCriterion.Description
                        );

                    // check if criterion from db was not found in exported criterion
                    if (searchedCriterionInExportedList == null)
                    {
                        verification = false;
                    }
                }
                return verification;
            }
            else
                return false;
        }

        /// <summary>
        /// Adds the exported criterionst to list.
        /// </summary>
        /// <param name="exportedCriterions">The exported criterions.</param>
        /// <param name="line">The line.</param>
        /// Erstellt von Joshua Frey, am 13.01.2016
        /// <exception cref="NotImplementedException"></exception>
        private void AddExportedCriterionstToList(ref List<Criterion> exportedCriterions, string line)
        {
            var lineAsArray = line.Split('|');
            int exportedCriterionId = Convert.ToInt32(lineAsArray[0]);
            string exportedName = lineAsArray[1];
            string exportedDescription = lineAsArray[2];

            exportedCriterions.Add(new Criterion()
            {
                Criterion_Id = exportedCriterionId,
                Name = exportedName,
                Description = exportedDescription
            });
        }

        /// <summary>
        /// Exports the project information.
        /// </summary>
        /// <returns>
        /// path to created export file
        /// </returns>
        /// Erstellt von Joshua Frey, am 12.01.2016
        private string ExportProjectInformation()
        {
            Project proj = ExportProjectController.GetProjectById(this.ProjectId);

            // Project_ID|Name|Description
            string csvRow = String.Format(@"{1}{0}{2}{0}{3}", this._delimiter, proj.Project_Id.ToString(), proj.Name, proj.Description);

            string fileUri = this.FileBaseName + "_Project.txt";
            this.ExportFilePaths.Add(fileUri);

            using (StreamWriter sw = new StreamWriter(fileUri))
            {
                sw.WriteLine(csvRow);
            }
            
            return fileUri;
        }

        /// <summary>
        /// Verifies the project export.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns>
        /// boolean, if all project information were exported successfully
        /// </returns>
        /// Erstellt von Joshua Frey, am 12.01.2016
        private bool VerifyProjectExport(string filePath)
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line = sr.ReadLine();
                var lineAsArray = line.Split('|');
                int projId = Convert.ToInt32(lineAsArray[0]);
                string projName = lineAsArray[1];
                string projDescription = lineAsArray[2];

                Project projFromFile = new Project() { Project_Id = projId, Name = projName, Description = projDescription };
                Project projFromDb = this.ExportProjectController.GetProjectById(this.ProjectId);

                return this.ExportProjectController.CheckIfEqualProjects(projFromDb, projFromFile);
            }
        }


        /// <summary>
        /// Deletes the ful fillment data.
        /// </summary>
        /// Erstellt von Joshua Frey, am 13.01.2016
        private bool DeleteFulFillmentData()
        {
            this.ExportFulfillmentController.DeleteAllFulfillmentsForOneProject(this.ProjectId);

            // check if deletion was successful
            if (this.ExportFulfillmentController.GetAllFulfillmentsForOneProject(this.ProjectId).Count == 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Deletes the project product data.
        /// </summary>
        /// Erstellt von Joshua Frey, am 13.01.2016
        private bool DeleteProjectProductData()
        {
            bool projectProducstDeletionSuccessful = true;
            foreach (ProjectProduct projProd in this.ExportProjectProductController.GetAllProjectProductsForOneProject(this.ProjectId))
            {
                if (!this.ExportProjectProductController.DeleteProjectProductFromDb(projProd.Project_Id, projProd.Product_Id))
                {
                    projectProducstDeletionSuccessful = false;
                }
            }

            // check if deletion was successful
            if (projectProducstDeletionSuccessful)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Deletes the project criterion data.
        /// </summary>
        /// Erstellt von Joshua Frey, am 13.01.2016
        private bool DeleteProjectCriterionData()
        {
            bool projectCriterionDeletionSuccessfull = true;
            foreach (ProjectCriterion projCrit in this.ExportProjectCriterionController.GetAllProjectCriterionsForOneProject(this.ProjectId))
            {
                if (!this.ExportProjectCriterionController.DeleteProjectCriterionFromDb(projCrit.Project_Id, projCrit.Criterion_Id))
                {
                    projectCriterionDeletionSuccessfull = false;
                }
            }

            // check if deletion was successful
            if (projectCriterionDeletionSuccessfull)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Deletes the product data.
        /// </summary>
        /// <param name="productExportFilePath">The product export file path.</param>
        /// Erstellt von Joshua Frey, am 13.01.2016
        private bool DeleteProductData(string productExportFilePath)
        {
            List<Product> exportedProducts = new List<Product>();
            using (StreamReader sr = new StreamReader(productExportFilePath))
            {
                string line = "";
                while ((line = sr.ReadLine()) != null)
                {
                    AddExportedProductToList(ref exportedProducts, line);
                }
            }

            List<int> productsToDeleteIds = new List<int>();

            foreach (Product prod in exportedProducts)
            {
                // a list of all project products mapping which use this product in outher projects as this
                List<ProjectProduct> projectProductsWhichUseThisProdInOtherProjects =
                    this.ExportProductController.GetProductById(prod.Product_Id).
                    ProjectProduct.Where(projProd => projProd.Project_Id != this.ProjectId).ToList();

                // if product is not used in any other project --> put it into the deletionList.
                if (projectProductsWhichUseThisProdInOtherProjects.Count == 0)
                {
                    productsToDeleteIds.Add(prod.Product_Id);
                }
            }

            // delete all products which are not allocated to other projects

            bool productDeletionSuccessfull = true;
            foreach (int prodToDeleteId in productsToDeleteIds)
            {
                if (!this.ExportProductController.DeleteProductFromDb(prodToDeleteId))
                {
                    productDeletionSuccessfull = false;
                }
            }
            if (productDeletionSuccessfull)
                return true;
            else
                return false;
        }

        /// Deletes the criterion data.
        /// </summary>
        /// <param name="criterionExportFilePath">The product export file path.</param>
        /// Erstellt von Joshua Frey, am 13.01.2016
        private bool DeleteCriterionData(string criterionExportFilePath)
        {
            List<Criterion> exportedCriterions = new List<Criterion>();
            using (StreamReader sr = new StreamReader(criterionExportFilePath))
            {
                string line = "";
                while ((line = sr.ReadLine()) != null)
                {
                    AddExportedCriterionstToList(ref exportedCriterions, line);
                }
            }

            List<int> criterionsToDeleteIds = new List<int>();

            foreach (Criterion crit in exportedCriterions)
            {
                // a list of all project criterions mapping which use this criterion in outher projects as this
                List<ProjectCriterion> projectCriterionsWhichUseThisCriterionInOtherProjects =
                    this.ExportCriterionController.GetCriterionById(crit.Criterion_Id).
                    ProjectCriterion.Where(projCrit => projCrit.Project_Id != this.ProjectId).ToList();

                // if criterion is not used in any other project --> put it into the deletionList.
                if (projectCriterionsWhichUseThisCriterionInOtherProjects.Count == 0)
                {
                    criterionsToDeleteIds.Add(crit.Criterion_Id);
                }
            }

            // delete all criterions which are not allocated to other projects

            bool criterionDeletionSuccessfull = true;
            foreach (int critToDeleteId in criterionsToDeleteIds)
            {
                if (!this.ExportCriterionController.DeleteCriterionFromDb(critToDeleteId))
                {
                    criterionDeletionSuccessfull = false;
                }
            }
            if (criterionDeletionSuccessfull)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Deletes the project data.
        /// </summary>
        /// Erstellt von Joshua Frey, am 13.01.2016
        private bool DeleteProjectData()
        {
            if (this.ExportProjectController.DeleteProjectFromDb(this.ProjectId))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Creates the timestamp for file.
        /// </summary>
        /// <returns>
        /// a timestamp as string
        /// </returns>
        /// Erstellt von Joshua Frey, am 12.01.2016
        private string CreateTimestampForFile()
        {
            string timeStampDelimiter = ".";
            DateTime now = DateTime.Now;
            string year = now.Year.ToString();
            string month = now.Month.ToString();
            string day = now.Day.ToString();
            string hour = now.Hour.ToString();
            string minute = now.Minute.ToString();
            string second = now.Second.ToString();

            return String.Format(@"{1}{0}{2}{0}{3}_{4}{0}{5}{0}{6}", timeStampDelimiter, year, month, day, hour, minute, second);
        }

        /// <summary>
        /// Logs the specified log message.
        /// </summary>
        /// <param name="logMessage">The log message.</param>
        /// <param name="archiveLogWriter">The archive log writer.</param>
        /// Erstellt von Joshua Frey, am 13.01.2016
        private void Log(string logMessage, TextWriter archiveLogWriter)
        {
            archiveLogWriter.Write("\r\nLog Eintrag : ");
            archiveLogWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                DateTime.Now.ToLongDateString());
            archiveLogWriter.WriteLine(":");
            archiveLogWriter.WriteLine("{0}", logMessage);
            archiveLogWriter.WriteLine ("-------------------------------");
        }

        /*
         * Messages
         */
        private string MessageExportVerified(string tableName)
        {
            return String.Format("Der Export der Daten aus der Tabelle {0} ist verifiziert.", tableName);
        }

        private string MessageExportNotVerified(string tableName)
        {
            return String.Format("Beim Export der Daten aus der Tabelle {0} ein Fehler aufgetreten. Es konnten nicht alle Daten exportiert werden.", tableName);
        }

        private string MessageWholeExportProcessFailed()
        {
            return "Beim Export sind Fehler aufgetreten. Aus diesem Grund wird nicht gelöscht.\n" +
                   "Bitte überprüfen Sie die log Datei.";
        }

        private string MessageWholeExportProcessSucceeded()
        {
            return "Alle Exportvorgänge wurden erfolgreich abgeschlossen. \nLöschvorgang wird gestartet";
        }

        private string MessageWholeDeletionProcessSucceeded()
        {
            return "Alle Löschvorgänge wurden erfolgreich abgeschlossen. Das Archiv wird gezippt.";
        }

        private string MessageWholeDeletionProcessFailed()
        {
            return "Beim Löschen sind Fehler aufgetreten. Aus diesem Grund wird nicht gezippt.\n" +
                   "Bitte überprüfen Sie die log Datei.";
        }

        private string MessageDeletionVerified(string tableName)
        {
            return String.Format("Das Löschen der Daten aus der Tabelle {0} ist verifiziert. \n"+
                "Es sind nun keine diesem Projekt spezifische Daten in der Tabelle {0} enthalten.", tableName);
        }

        private string MessageDeletionNotVerified(string tableName)
        {
            return String.Format("Beim Löschen der Daten aus der Tabelle {0} ist ein Fehler aufgetreten. \n"+
                "Es konnten nicht alle relevanten Daten gelöscht werden, die gelöscht werden sollten.", tableName);
        }

        private string MessageZipProcessSuccessful()
        {
            return "Das Komprimieren der exportierten Daten in ein Ziparchiv war erfolgreich.\n" +
                "Möchten Sie die Exportdateien außerhalb des Ziparchivs löschen?";
        }
    }
}
