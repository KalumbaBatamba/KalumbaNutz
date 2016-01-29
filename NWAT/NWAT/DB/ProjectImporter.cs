using NWAT.HelperClasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace NWAT.DB
{
    public class ProjectImporter
    {

        // the pipe symbol is used to seperate the columns in the csv files.
        private readonly char _delimiter = '|';

        private string _zipArchiveFilePath;

        public string ZipArchiveFilePath
        {
            get { return _zipArchiveFilePath; }
            set { _zipArchiveFilePath = value; }
        }

        private string _importFilesDirectory;

	    public string ImportFilesDirectory
	    {
		    get { return _importFilesDirectory;}
		    set { _importFilesDirectory = value;}
	    }
	
        private string _projectImportFilePath;

        public string ProjectImportFilePath
        {
            get { return _projectImportFilePath; }
            set { _projectImportFilePath = value; }
        }

        private string _criterionImportFilePath;

        public string CriterionImportFilePath
        {
            get { return _criterionImportFilePath; }
            set { _criterionImportFilePath = value; }
        }

        private string _productImportFilePath;

        public string ProductImportFilePath
        {
            get { return _productImportFilePath; }
            set { _productImportFilePath = value; }
        }

        private string _projectCriterionImportFilePath;

        public string ProjectCriterionImportFilePath
        {
            get { return _projectCriterionImportFilePath; }
            set { _projectCriterionImportFilePath = value; }
        }

        private string _projectProductImportFilePath;

        public string ProjectProductImportFilePath
        {
            get { return _projectProductImportFilePath; }
            set { _projectProductImportFilePath = value; }
        }

        private string _fulfillmenImportFilePath;

        public string FulfillmenImportFilePath
        {
            get { return _fulfillmenImportFilePath; }
            set { _fulfillmenImportFilePath = value; }
        }

        private LogWriter _importLogWriter;

        public LogWriter ImportLogWriter
        {
            get { return _importLogWriter; }
            set { _importLogWriter = value; }
        }

        private int _projectId;

        public int ProjectId
        {
            get { return _projectId; }
            set { _projectId = value; }
        }
        
        
        // DB controller

        private ProjectController _importProjectController;

        public ProjectController ImportProjectController
        {
            get { return _importProjectController; }
            set { _importProjectController = value; }
        }

        private CriterionController _importCriterionController;

        public CriterionController ImportCriterionController
        {
            get { return _importCriterionController; }
            set { _importCriterionController = value; }
        }

        private ProductController _importProductController;

        public ProductController ImportProductController
        {
            get { return _importProductController; }
            set { _importProductController = value; }
        }

        private ProjectCriterionController _importProjectCriterionController;

        public ProjectCriterionController ImportProjectCriterionController
        {
            get { return _importProjectCriterionController; }
            set { _importProjectCriterionController = value; }
        }

        private ProjectProductController _importProjectProductController;

        public ProjectProductController ImportProjectProductController
        {
            get { return _importProjectProductController; }
            set { _importProjectProductController = value; }
        }

        private FulfillmentController _importFulfillmentController;

        public FulfillmentController ImportFulfillmentController
        {
            get { return _importFulfillmentController; }
            set { _importFulfillmentController = value; }
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectImporter"/> class.
        /// </summary>
        /// <param name="archiveFilePath">The archive file path.</param>
        /// Erstellt von Joshua Frey, am 13.01.2016
        public ProjectImporter(string archiveFilePath)
        {
            // initialize db controller
            ImportProjectController = new ProjectController();
            ImportCriterionController = new CriterionController();
            ImportProductController = new ProductController();
            ImportProjectCriterionController = new ProjectCriterionController();
            ImportProjectProductController = new ProjectProductController();
            ImportFulfillmentController = new FulfillmentController();
            this.ZipArchiveFilePath = archiveFilePath;

            this.ImportFilesDirectory = CreateImportDirectory();

            // Create Logfile
            string logFilePath = this.ImportFilesDirectory + @"\Import.log";
            this.ImportLogWriter = new LogWriter(logFilePath, "Import Log");
        }

        /// <summary>
        /// Creates the import directory.
        /// </summary>
        /// <returns>
        /// Import dir path
        /// </returns>
        /// Erstellt von Joshua Frey, am 15.01.2016
        private string CreateImportDirectory()
        {
            string importDirName = "";
            string zipFileRootDir = Path.GetDirectoryName(this.ZipArchiveFilePath);
            string zipArchiveFileName = Path.GetFileNameWithoutExtension(this.ZipArchiveFilePath);
            string timeStamp = CommonMethods.GetTimestamp();
            string projectName = "";
            int indexOfProjectInZipName = zipArchiveFileName.IndexOf("Project");
            if (indexOfProjectInZipName != -1)
            {
                projectName = zipArchiveFileName.Substring(indexOfProjectInZipName);
                
            }
            else
            {
                projectName = "Default_Project";
            }
            
            importDirName = String.Format(@"{0}\{1}_{2}_Import_Dateien", zipFileRootDir, timeStamp, projectName);
            
            

            if (Directory.Exists(importDirName))
            {
                Directory.Delete(importDirName, true);
                // sleep is needed. If tempExtractDir is open in file explorer
                // it needs more time to delete tempExtractDir and handle the user interruption from gui
                // closing window so the create statement will not actually create a tempExtractDir
                Thread.Sleep(20);
            }
            Directory.CreateDirectory(importDirName);
            return importDirName;
        }



        /******************************************************************
         
                                   Import Funktion
         
         *****************************************************************/


        /// <summary>
        /// Imports the whole project.
        /// </summary>
        /// Erstellt von Joshua Frey, am 13.01.2016
        public void ImportWholeProject()
        {
            // if archive file does not exist any more, cancel import.
            if (!File.Exists(this.ZipArchiveFilePath))
            {
                MessageBox.Show(MessageArchiveFileDoesNotExistAnyMore());
                return;
            }

            // extract archive data to temporary dir.
            using (ArchiveZipper zipper = new ArchiveZipper())
            {
                string tempExtractDir = this.ImportFilesDirectory;
                List<string> extracedFiles = zipper.ExtractArchiveDataToDir(tempExtractDir, this.ZipArchiveFilePath);
                SetImportFilePaths(extracedFiles);
            }
            MessageBox.Show("Importvorgang wird gestartet. Bitte bestätigen Sie mit \"Ok\"");
            ImportProjectData();
            ImportCriterionData();
            ImportProductData();
            ImportProjectCriterionData();
            ImportProjectProductData();
            ImportFulfillmentData();
            MessageBox.Show(MessageEndOfImportProcess()); 
        }


        /// <summary>
        /// Sets the import file paths.
        /// </summary>
        /// Erstellt von Joshua Frey, am 14.01.2016
        private void SetImportFilePaths(List<string> extractedFilePaths)
        {
            foreach (string filePath in extractedFilePaths)
            {

                if (filePath.EndsWith("_Fulfillment.txt", StringComparison.OrdinalIgnoreCase))
                {
                    this.FulfillmenImportFilePath = filePath;
                }
                else if (filePath.EndsWith("_ProjectProduct.txt", StringComparison.OrdinalIgnoreCase))
                {
                    this.ProjectProductImportFilePath = filePath;
                }
                else if (filePath.EndsWith("_ProjectCriterion.txt", StringComparison.OrdinalIgnoreCase))
                {
                    this.ProjectCriterionImportFilePath = filePath;
                }
                else if (filePath.EndsWith("_Criterion.txt", StringComparison.OrdinalIgnoreCase))
                {
                    this.CriterionImportFilePath = filePath;
                }
                else if (filePath.EndsWith("_Product.txt", StringComparison.OrdinalIgnoreCase))
                {
                    this.ProductImportFilePath = filePath;
                }
                else if (filePath.EndsWith("_Project.txt", StringComparison.OrdinalIgnoreCase))
                {
                    this.ProjectImportFilePath = filePath;
                }
                // if another file is in archive or archivefile was renamed so it could not be found
                // and differs from log filet, hrow an exception
                else if(!filePath.EndsWith(".log", StringComparison.OrdinalIgnoreCase))
                {
                    throw new NWATException(MessageWrongFileInExportArchive(filePath));
                }
            }
        }


        /// <summary>
        /// Imports the project data.
        /// </summary>
        /// Erstellt von Joshua Frey, am 15.01.2016
        /// <exception cref="NWAT.DB.NWATException"></exception>
        private void ImportProjectData()
        {
            this.ImportLogWriter.LogSubHeading(MessageStartImportOfData("Project"));
            using (StreamReader sr = new StreamReader(this.ProjectImportFilePath))
            {
                string line;
                Project importProj;
                while ((line = sr.ReadLine()) != null)
                {
                    importProj = GetProjectByLineFromImportFile(line);

                    int importProjId = importProj.Project_Id;
                    string originImportProjName = importProj.Name;
                    // if id does not already exist in table --> import; else skip
                    if (!this.ImportProjectController.CheckIfProjectIdAlreadyExists(importProjId))
                    {

                        // if name of project already exists in table, then expand the name of
                        // importProject by "_imported"
                        if (this.ImportProjectController.CheckIfProjectNameAlreadyExists(importProj.Name))
                        {
                            importProj.Name += "_imported";
                            // if name was changed, logfile will be updated
                            this.ImportLogWriter.Log(MessageSuffixWasAppendedToDataName(originImportProjName, importProj.Name));
                        }

                        bool importSuccessful = this.ImportProjectController.ImportProjectIntoDb(importProj);
                        if (importSuccessful)
                        {
                            this.ImportLogWriter.Log(MessageImportOfMasterDataSucceeded(importProjId, importProj.Name));
                        }
                        else
                        {
                            string dataSet = String.Format("Project_Id = {0}\n Name = {1}\n Description = {3}",
                                                            importProjId,
                                                            importProj.Name,
                                                            importProj.Description);

                            throw new NWATException(MessageImportFailed("Project", dataSet));
                        }
                    }
                    else
                    {
                        this.ImportLogWriter.Log(MessageMasterDatasetAlreadyExists(importProjId, originImportProjName));
                    }
                }
            }
            this.ImportLogWriter.Log(MessageEndImportOfData("Project"));
        }

        /// <summary>
        /// Gets the project by line from import file.
        /// </summary>
        /// <param name="projectImportLine">The project import line.</param>
        /// <returns></returns>
        /// Erstellt von Joshua Frey, am 14.01.2016
        private Project GetProjectByLineFromImportFile(string projectImportLine)
        {
            Project importProject;
            // Project_Id|Name|Description
            var lineAsArray = projectImportLine.Split(this._delimiter);
            int project_Id;
            try
            {
                project_Id = Convert.ToInt32(lineAsArray[0]);
            }
            catch (FormatException formatException)
            {
                throw new NWATException(String.Format("{0}\n\n{1}", 
                    formatException, MessageWrongDatatypeInExportedLine("Project", projectImportLine, "int|string|string")));
            }

            importProject = new Project()
            {
                Project_Id = project_Id,
                Name = lineAsArray[1],
                Description = lineAsArray[2]
            };
            return importProject;
        }

        /// <summary>
        /// Imports the criterion data.
        /// </summary>
        /// Erstellt von Joshua Frey, am 15.01.2016
        private void ImportCriterionData()
        {
            this.ImportLogWriter.LogSubHeading(MessageStartImportOfData("Criterion"));
            using (StreamReader sr = new StreamReader(this.CriterionImportFilePath))
            {
                string line;
                Criterion importCriterion;
                while ((line = sr.ReadLine()) != null)
                {
                    importCriterion = GetCriterionByLineFromImportFile(line);
                    int importCritId = importCriterion.Criterion_Id;
                    string originImportCritName = importCriterion.Name;

                    // if id does not already exist in table --> import; else skip
                    if (!this.ImportCriterionController.CheckIfCriterionIdAlreadyExists(importCritId))
                    {
                        // if name of criterion already exists in table, then expand the name of
                        // importCriterion by "_imported"
                        if (this.ImportCriterionController.CheckIfCriterionNameAlreadyExists(importCriterion.Name))
                        {
                            importCriterion.Name += "_imported";
                            // if name was changed, logfile will be updated
                            this.ImportLogWriter.Log(MessageSuffixWasAppendedToDataName(originImportCritName, importCriterion.Name));
                        }

                        bool importSuccessful = this.ImportCriterionController.ImportCriterionIntoDb(importCriterion);
                        //bool importSuccessful = true;
                        if (importSuccessful)
                        {
                            this.ImportLogWriter.Log(MessageImportOfMasterDataSucceeded(importCritId, importCriterion.Name));
                        }
                        else
                        {
                            string dataSet = String.Format("Project_Id = {0}\n Name = {1}\n Description = {3}",
                                                            importCritId,
                                                            importCriterion.Name,
                                                            importCriterion.Description);

                            throw new NWATException(MessageImportFailed("Criterion", dataSet));
                        }
                        
                    }
                    else
                    {
                        this.ImportLogWriter.Log(MessageMasterDatasetAlreadyExists(importCritId, originImportCritName));
                    }
                }
            }
            this.ImportLogWriter.Log(MessageEndImportOfData("Criterion"));
        }

        /// <summary>
        /// Gets the criterion by line from import file.
        /// </summary>
        /// <param name="criterionImportLine">The criterion import line.</param>
        /// <returns></returns>
        /// Erstellt von Joshua Frey, am 15.01.2016
        private Criterion GetCriterionByLineFromImportFile(string criterionImportLine)
        {
            Criterion importCriterion;
            // Criterion_Id|Name|Description
            var lineAsArray = criterionImportLine.Split(this._delimiter);
            int criterionId;
            try 
            {
                criterionId = Convert.ToInt32(lineAsArray[0]);
            }
            catch (FormatException formatException)
            {
                throw new NWATException(String.Format("{0}\n\n{1}", 
                    formatException, MessageWrongDatatypeInExportedLine("Criterion", criterionImportLine, "int|string|string")));
            }
            importCriterion = new Criterion()
            {
                Criterion_Id = criterionId,
                Name = lineAsArray[1],
                Description = lineAsArray[2]
            };
            return importCriterion;
        }


        /// <summary>
        /// Imports the product data.
        /// </summary>
        /// Erstellt von Joshua Frey, am 20.01.2016
        /// <exception cref="NWATException"></exception>
        private void ImportProductData()
        {
            this.ImportLogWriter.LogSubHeading(MessageStartImportOfData("Product"));
            using (StreamReader sr = new StreamReader(this.ProductImportFilePath))
            {
                string line;
                Product importProduct;
                while ((line = sr.ReadLine()) != null)
                {
                    importProduct = GetProductByLineFromImportFile(line);
                    int importProdId = importProduct.Product_Id;
                    string originImportProdName = importProduct.Name;

                    // if id does not already exist in table --> import; else skip
                    if (!this.ImportProductController.CheckIfProductIdAlreadyExists(importProdId))
                    {
                        // if name of product already exists in table, then expand the name of
                        // importProduct by "_imported"
                        if (this.ImportProductController.CheckIfProductNameAlreadyExists(importProduct.Name))
                        {
                            importProduct.Name += "_imported";
                            // if name was changed, logfile will be updated
                            this.ImportLogWriter.Log(MessageSuffixWasAppendedToDataName(originImportProdName, importProduct.Name));
                        }

                        bool importSuccessful = this.ImportProductController.ImportProductIntoDb(importProduct);
                        //bool importSuccessful = true;
                        if (importSuccessful)
                        {
                            this.ImportLogWriter.Log(MessageImportOfMasterDataSucceeded(importProdId, importProduct.Name));
                        }
                        else
                        {
                            string dataSet = String.Format("Project_Id = {0}\n Name = {1}\n Description = {3}\n Price = {4}",
                                                            importProdId,
                                                            importProduct.Name,
                                                            importProduct.Producer,
                                                            importProduct.Price);

                            throw new NWATException(MessageImportFailed("Product", dataSet));
                        }

                    }
                    else
                    {
                        this.ImportLogWriter.Log(MessageMasterDatasetAlreadyExists(importProdId, originImportProdName));
                    }
                }
            }
            this.ImportLogWriter.Log(MessageEndImportOfData("Product"));
        }


        /// <summary>
        /// Gets the product by line from import file.
        /// </summary>
        /// <param name="productImportLine">The product import line.</param>
        /// <returns></returns>
        /// Erstellt von Joshua Frey, am 20.01.2016
        private Product GetProductByLineFromImportFile(string productImportLine)
        {
            Product importProduct;
            // Product_Id|Name|Producer|Price
            var lineAsArray = productImportLine.Split(this._delimiter);

            int productId;
            System.Nullable<double> extractedPrice;
            try
            {
                productId = Convert.ToInt32(lineAsArray[0]);
                extractedPrice = CommonMethods.GetNullableDoubleValueFromString(lineAsArray[3]);
            }
            catch (FormatException formatException)
            {
                throw new NWATException(String.Format("{0}\n\n{1}",
                    formatException, MessageWrongDatatypeInExportedLine("Product", productImportLine, "int|string|string|int")));
            }

            importProduct = new Product()
            {
                Product_Id = productId,
                Name = lineAsArray[1],
                Producer = lineAsArray[2],
                Price = extractedPrice
            };
            return importProduct;
        }


        /// <summary>
        /// Imports the project criterion data.
        /// </summary>
        /// Erstellt von Joshua Frey, am 20.01.2016
        /// <exception cref="NWATException"></exception>
        private void ImportProjectCriterionData()
        {
            this.ImportLogWriter.LogSubHeading(MessageStartImportOfData("Project Criterion"));
            using (StreamReader sr = new StreamReader(this.ProductImportFilePath))
            {
                List<ProjectCriterion> unsortedProjCritsFromFile = GetUnsortedProjectCriterionListFromExportFile();

                // creates a sorted list, that a child criterion will not be imported before its parent
                List<ProjectCriterion> sortedProjCritList = GetSortedProjectCriterionList(unsortedProjCritsFromFile);

                foreach (ProjectCriterion importProjectCriterion in sortedProjCritList)
                {
                    int projectId = importProjectCriterion.Project_Id;
                    int criterionId = importProjectCriterion.Criterion_Id;

                    // checks if master criterion data which this project criterion refers to exists.
                    if (!this.ImportCriterionController.CheckIfCriterionIdAlreadyExists(criterionId))
                    {
                        throw new NWATException(MessageCriterionWhichProjCritRefersToDoesNotExist(criterionId));
                    }
                    // checks if master project data which this project criterion refers to exists.
                    if (!this.ImportProjectController.CheckIfProjectIdAlreadyExists(projectId))
                    {
                        throw new NWATException(MessageCriterionWhichProjCritRefersToDoesNotExist(criterionId));
                    }
                    
                    // if ids do not already exist in table --> import; else skip
                    if (!this.ImportProjectCriterionController.CheckIfProjectCriterionAlreadyExists(projectId, criterionId))
                    {
                        bool importSuccessful = this.ImportProjectCriterionController.ImportProjectCriterion(importProjectCriterion);
                        if (importSuccessful)
                        {
                            this.ImportLogWriter.Log(MessageImportOfProjectCiterionSucceeded(projectId, criterionId));
                        }
                        else
                        {
                            string dataSet = String.Format("Project_Id = {0}\nCriterion_Id = {1}\nLayer_Depth = {3}\n"+
                                                           "Parent_Criterion_Id = {4}\nWeighting_Cardinal = {5}\n"+
                                                           "Weighting_Percentage_Layer = {6}\nWeighting_Percentage_Project = {7}",
                                                            projectId,
                                                            criterionId,
                                                            importProjectCriterion.Layer_Depth,
                                                            importProjectCriterion.Parent_Criterion_Id,
                                                            importProjectCriterion.Weighting_Cardinal,
                                                            importProjectCriterion.Weighting_Percentage_Layer,
                                                            importProjectCriterion.Weighting_Percentage_Project);

                            throw new NWATException(MessageImportFailed("ProjectCriterion", dataSet));
                        }

                    }
                    else
                    {
                        this.ImportLogWriter.Log(MessageProjectCriterionAlreadyExists(projectId, criterionId));
                    }
                }
            }
            this.ImportLogWriter.Log(MessageEndImportOfData("ProjectCriterion"));
        }


        /// <summary>
        /// Gets the unsorted project criterion list from export file.
        /// </summary>
        /// <returns></returns>
        /// Erstellt von Joshua Frey, am 20.01.2016
        private List<ProjectCriterion> GetUnsortedProjectCriterionListFromExportFile()
        {
            List<ProjectCriterion> unsortedList = new List<ProjectCriterion>();
            using (StreamReader sr = new StreamReader(this.ProjectCriterionImportFilePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    unsortedList.Add(GetProjectCriterionByLineFromImportFile(line));
                }
            }
            return unsortedList;
        }

        /// <summary>
        /// Gets the sorted project criterion list.
        /// </summary>
        /// <param name="unsortedProjCrits">The unsorted proj crits.</param>
        /// <returns></returns>
        /// Erstellt von Joshua Frey, am 20.01.2016
        private List<ProjectCriterion> GetSortedProjectCriterionList(List<ProjectCriterion> unsortedProjCrits)
        {
            List<ProjectCriterion> sortedProjCritList = new List<ProjectCriterion>();
            List<ProjectCriterion> baseCriterions = GetBaseCriterionsFromUnsortedList(unsortedProjCrits);
            FillSortedProjCritList(unsortedProjCrits, baseCriterions, ref sortedProjCritList);
            return sortedProjCritList;
        }

        /// <summary>
        /// Gets the base criterions from unsorted list.
        /// </summary>
        /// <param name="unsortedProjCrits">The unsorted proj crits.</param>
        /// <returns></returns>
        /// Erstellt von Joshua Frey, am 20.01.2016
        private List<ProjectCriterion> GetBaseCriterionsFromUnsortedList(List<ProjectCriterion> unsortedProjCrits)
        {
            return unsortedProjCrits.Where(projCrit => projCrit.Parent_Criterion_Id == null).ToList();
        }

        /// <summary>
        /// Fills the sorted proj crit list.
        /// </summary>
        /// <param name="unsortedList">The unsorted list.</param>
        /// <param name="siblings">The siblings.</param>
        /// <param name="sortedList">The sorted list.</param>
        /// Erstellt von Joshua Frey, am 20.01.2016
        private void FillSortedProjCritList(
                                        List<ProjectCriterion> unsortedList,
                                        List<ProjectCriterion> siblings, 
                                        ref List<ProjectCriterion> sortedList)
        {
            foreach (ProjectCriterion sibling in siblings)
            {
                sortedList.Add(sibling);

                List<ProjectCriterion> childrenCriterions = unsortedList.Where(projCrit => 
                        projCrit.Parent_Criterion_Id == sibling.Criterion_Id).ToList();

                if (childrenCriterions.Count > 0)
                {
                    FillSortedProjCritList(unsortedList, childrenCriterions, ref sortedList);
                }
            }
        }

        /// <summary>
        /// Gets the project criterion by line from import file.
        /// </summary>
        /// <param name="projectCriterionImportLine">The project criterion import line.</param>
        /// <returns></returns>
        /// Erstellt von Joshua Frey, am 20.01.2016
        /// <exception cref="NWATException"></exception>
        private ProjectCriterion GetProjectCriterionByLineFromImportFile(string projectCriterionImportLine)
        {
            ProjectCriterion importProjectCriterion;
            // Project_Id|Criterion_Id|Layer_Depth|Parent_Criterion_Id|Weighting_Cardinal|Weighting_Percentage_Layer|Weigthing_Percentage_Project
            var lineAsArray = projectCriterionImportLine.Split(this._delimiter);

            int projectId;
            int criterionId;
            int layerDepth;
            System.Nullable<int> parentCritId;
            int cardinalWeighting;
            System.Nullable<double> percentageLayerWeighting;
            System.Nullable<double> percentageProjectWeighting;
            try
            {
                projectId = Convert.ToInt32(lineAsArray[0]);
                criterionId = Convert.ToInt32(lineAsArray[1]);
                layerDepth = Convert.ToInt32(lineAsArray[2]);
                parentCritId = CommonMethods.GetNullableIntValueFromString(lineAsArray[3]);
                cardinalWeighting = Convert.ToInt32(lineAsArray[4]);
                percentageLayerWeighting = CommonMethods.GetNullableDoubleValueFromString(lineAsArray[5]);
                percentageProjectWeighting = CommonMethods.GetNullableDoubleValueFromString(lineAsArray[6]);
            }
            catch (FormatException formatException)
            {
                throw new NWATException(String.Format("{0}\n\n{1}",
                    formatException,
                    MessageWrongDatatypeInExportedLine("Product", projectCriterionImportLine, "int|int|int|int|int|double (mit Kommata)|double (mit Kommata)")));
            }

            importProjectCriterion = new ProjectCriterion()
            {
                Project_Id = projectId,
                Criterion_Id = criterionId, 
                Layer_Depth = layerDepth,
                Parent_Criterion_Id = parentCritId,
                Weighting_Cardinal = cardinalWeighting,
                Weighting_Percentage_Layer = percentageLayerWeighting,
                Weighting_Percentage_Project = percentageProjectWeighting
            };
            return importProjectCriterion;
        }


        /// <summary>
        /// Imports the project product data.
        /// </summary>
        /// Erstellt von Joshua Frey, am 26.01.2016
        /// <exception cref="NWATException"></exception>
        private void ImportProjectProductData()
        {
            this.ImportLogWriter.LogSubHeading(MessageStartImportOfData("ProjectProduct"));
            using (StreamReader sr = new StreamReader(this.ProjectProductImportFilePath))
            {
                string line;
                ProjectProduct importProjectProduct;
                while ((line = sr.ReadLine()) != null)
                {
                    importProjectProduct = GetProjectProductByLineFromImportFile(line);
                    int importProjId = importProjectProduct.Project_Id;
                    int importProdId = importProjectProduct.Product_Id;

                    // if id does not already exist in table --> import; else skip
                    if (!this.ImportProjectProductController.CheckIfProjectProductIdAlreadyExists(importProjId, importProdId))
                    {
                        bool importSuccessful = this.ImportProjectProductController.ImportProjectProductIntoDb(importProjectProduct);
                        //bool importSuccessful = true;
                        if (importSuccessful)
                        {
                            this.ImportLogWriter.Log(MessageImportOfProjectProductSucceeded(importProjId, importProdId));
                        }
                        else
                        {
                            string dataSet = String.Format("Project_Id = {0}\n Product_Id = {1}",
                                                            importProjId,
                                                            importProdId);

                            throw new NWATException(MessageImportFailed("ProjectProduct", dataSet));
                        }

                    }
                    else
                    {
                        this.ImportLogWriter.Log(MessageProjectProductAlreadyExists(importProdId, importProjId));
                    }
                }
            }
            this.ImportLogWriter.Log(MessageEndImportOfData("ProjectProduct"));
        }


        /// <summary>
        /// Gets the project product by line from import file.
        /// </summary>
        /// <param name="line">The line.</param>
        /// <returns></returns>
        /// Erstellt von Joshua Frey, am 26.01.2016
        private ProjectProduct GetProjectProductByLineFromImportFile(string projectProductImportLine)
        {
            ProjectProduct importProjectProduct;
            // Project_Id|Product_Id
            var lineAsArray = projectProductImportLine.Split(this._delimiter);

            int projectId;
            int productId;
            try
            {
                projectId = Convert.ToInt32(lineAsArray[0]);
                productId = Convert.ToInt32(lineAsArray[1]);
            }
            catch (FormatException formatException)
            {
                throw new NWATException(String.Format("{0}\n\n{1}",
                    formatException, MessageWrongDatatypeInExportedLine("ProjectProduct", projectProductImportLine, "int|int")));
            }

            importProjectProduct = new ProjectProduct()
            {
                Project_Id = projectId,
                Product_Id = productId
            };
            return importProjectProduct;
        }



        /// <summary>
        /// Imports the fulfillment data.
        /// </summary>
        /// Erstellt von Joshua Frey, am 27.01.2016
        /// <exception cref="NWATException"></exception>
        private void ImportFulfillmentData()
        {
            this.ImportLogWriter.LogSubHeading(MessageStartImportOfData("Fulfillment"));
            using (StreamReader sr = new StreamReader(this.FulfillmenImportFilePath))
            {
                string line;
                Fulfillment importFulfillment;
                while ((line = sr.ReadLine()) != null)
                {
                    importFulfillment = GetFulfillmentByLineFromImportFile(line);
                    int importProjId = importFulfillment.Project_Id;
                    int importProdId = importFulfillment.Product_Id;
                    int importCritId = importFulfillment.Criterion_Id;

                    // if id does not already exist in table --> import; else skip
                    if (!this.ImportFulfillmentController.CheckIfFulfillmentAlreadyExists(importProjId, importProdId, importCritId))
                    {
                        bool importSuccessful = this.ImportFulfillmentController.InsertFullfillmentInDb(importFulfillment);
                        //bool importSuccessful = true;
                        if (importSuccessful)
                        {
                            this.ImportLogWriter.Log(MessageImportOfFulfillmentSucceeded(importProjId, importProdId, importCritId));
                        }
                        else
                        {
                            string dataSet = String.Format("Project_Id = {0}\n" +
                                                           "Product_Id = {1}\n" +
                                                           "Criterion_Id = {2}\n" +
                                                           "Fulfilled = {3}\n" +
                                                           "Comment = {4}\n" +
                                                            importProjId,importProdId,
                                                            importCritId, importFulfillment.Fulfilled,
                                                            importFulfillment.Comment);

                            throw new NWATException(MessageImportFailed("Fulfillment", dataSet));
                        }

                    }
                    else
                    {
                        this.ImportLogWriter.Log(MessageFulfillmentAlreadyExists(importProjId, importProdId, importCritId));
                    }
                }
            }
            this.ImportLogWriter.Log(MessageEndImportOfData("Fullfillment"));
        }



        /// <summary>
        /// Gets the fulfillment by line from import file.
        /// </summary>
        /// <param name="fulfillmentImportLine">The fulfillment import line.</param>
        /// <returns></returns>
        /// Erstellt von Joshua Frey, am 27.01.2016
        /// <exception cref="NWATException"></exception>
        private Fulfillment GetFulfillmentByLineFromImportFile(string fulfillmentImportLine)
        {
            Fulfillment importFulfillment;
            // Project_Id|Product_Id|Criterion_Id|Fulfilled|Comment
            var lineAsArray = fulfillmentImportLine.Split(this._delimiter);

            int projectId;
            int productId;
            int criterionId;
            bool fulfilled;
            string comment =  CommonMethods.GetNullableStringValueFromString(lineAsArray[4]);
            try
            {
                projectId = Convert.ToInt32(lineAsArray[0]);
                productId = Convert.ToInt32(lineAsArray[1]);
                criterionId = Convert.ToInt32(lineAsArray[2]);
                fulfilled = Convert.ToBoolean(lineAsArray[3]);
            }
            catch (FormatException formatException)
            {
                throw new NWATException(String.Format("{0}\n\n{1}",
                    formatException, MessageWrongDatatypeInExportedLine("ProjectProduct", fulfillmentImportLine, 
                                                                        "int|int|int|bool(\"True\" or \"False\")|string")));
            }

            importFulfillment = new Fulfillment()
            {
                Project_Id = projectId,
                Product_Id = productId,
                Criterion_Id = criterionId,
                Fulfilled = fulfilled,
                Comment = comment
            };
            return importFulfillment;
        }


        
        
        /*
         * Messages
         */

        private string MessageArchiveFileDoesNotExistAnyMore()
        {
            return String.Format("Die Archivdatei '{0}' existiert nicht mehr.\n"+
                                 "Import abgebrochen.", this.ZipArchiveFilePath);
        }

        private string MessageImportFailed(string tableName, string dataSet)
        {
            return String.Format("Der Import in die Tabelle {1} war nicht erfolgreich. \n" + 
                                 "Folgender Datensatz ist betroffen:\n",
                                    dataSet, tableName);
        }

        private string MessageImportOfMasterDataSucceeded(int dataSetId, string dataSetName)
        {
            return String.Format("Der Datensatz mit der Id \"{0}\" und dem Namen \"{1}\" wurde erfolgreich importiert.", dataSetId, dataSetName);
        }

        private string MessageImportOfProjectCiterionSucceeded(int projectId, int criterionId)
        {
            return String.Format("Das Kriterium mit der Id \"{0}\" des Projektes mit der Id {1} "+
                                 "wurde erfolgreich importiert", criterionId, projectId);
        }

        private string MessageImportOfProjectProductSucceeded(int projectId, int productId)
        {
            return String.Format("Das Produkt mit der Id \"{0}\" des Projektes mit der Id {1} " +
                                 "wurde erfolgreich importiert", productId, projectId);
        }

        private string MessageImportOfFulfillmentSucceeded(int projectId, int productId, int criterionId)
        {
            return String.Format("Der Eintrag in der Fulfillment-Tabelle mit der Project_Id \"{0}\" "+ 
                                 "und der Product_Id {1} " +
                                 "und der Criterion_Id {2} " +
                                 "wurde erfolgreich importiert", productId, projectId, criterionId);
        }

        private string MessageStartImportOfData(string tableName)
        {
            return String.Format("Import \"{0}\" gestartet.", tableName);
        }

        private string MessageEndImportOfData(string tableName)
        {
            return String.Format("Import der Daten für die Tabelle \"{0}\" wurde beendet.", tableName);
        }

        private string MessageSuffixWasAppendedToDataName(string originName, string changedName)
        {
            return String.Format("Der Datensatz mit dem Namen \"{0}\" wurde als \"{1}\" importiert, da ein weitere Datensatz mit" +
                                " dem ursprünglichen Namen in der Tabelle enthalten ist.", originName, changedName);
        }

        private string MessageProjectCriterionAlreadyExists(int criterionId, int projectid)
        {
            return String.Format("Das Kriterium mit der Id \"{0}\" ist bereits dem Projekt mit der "+
                "Id \"{1}\" zugeordnet und wird deshalb nicht importiert.",
                criterionId, projectid);
        }

        private string MessageProjectProductAlreadyExists(int productId, int projectid)
        {
            return String.Format("Das Produkt mit der Id \"{0}\" ist bereits dem Projekt mit der " +
                "Id \"{1}\" zugeordnet und wird deshalb nicht importiert.",
                productId, projectid);
        }

        private string MessageFulfillmentAlreadyExists(int projectId, int productId, int criterionId)
        {
            return String.Format("Der Eintrag in der Fulfillment-Tabelle mit der Project_Id \"{0}\" " +
                                 "und der Product_Id {1} " +
                                 "und der Criterion_Id {2} " +
                                 "existiert bereits und wird deshalb nicht importiert", 
                                 productId, projectId, criterionId);
        }

        private string MessageMasterDatasetAlreadyExists(int dataSetId, string dataSetName)
        {
            return String.Format("Der Datensatz mit der Id \"{0}\" und dem Namen \"{1}\" wurde nicht importiert, "+
                                 "da der Datensatz bereits in der Tabelle existiert.", dataSetId, dataSetName);
        }

        private string MessageWrongFileInExportArchive(string fileName)
        {
            return String.Format("Die Datei \n\n{0}\n\n ist keine gültige Export Datei. Exportdateien enden mit ihrem Tabellennamen");
        }

        private string MessageWrongDatatypeInExportedLine(string tableName, string line, string dataTypesOrder)
        {
            return String.Format("Der folgende Datensatz aus der Tabelle {0} enthält Einträge mit falschen Datentypen.\n" +
                                 "Datentypenreihenfolge: {1} \n\n" +
                                 "Datensatz: {2}", tableName, dataTypesOrder, line);
        }

        private string MessageCriterionWhichProjCritRefersToDoesNotExist(int criterionId)
        {
            return String.Format("Das Projectkriterium mit der Kriteriums-Id {0} kann nicht importiert werden, da das zugehörige Kriterium in der Tabelle Criterion nicht existiert.", criterionId);
        }

        private string MessageProjectWhichProjCritRefersToDoesNotExist(int projectId)
        {
            return String.Format("Das Projectkriterium mit der Projekt-Id {0} kann nicht importiert werden, da das zugehörige Projekt in der Tabelle Project nicht existiert.", projectId);
        }

        private string MessageEndOfImportProcess()
        {
            return "Der Importvorgang wurde abgeschlossen.\nGenauere Informationen entnehmen Sie bitte der erstellten Import-Log-Datei.";
        }
    }
}
