using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
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
        public void importWholeProject()
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
                List<string> extracedFiles = zipper.extractArchiveDataToDir(tempExtractDir, this.ZipArchiveFilePath);
                setImportFilePaths(extracedFiles);
            }

            importProjectData();
            importCriterionData();

        }


        /// <summary>
        /// Sets the import file paths.
        /// </summary>
        /// Erstellt von Joshua Frey, am 14.01.2016
        private void setImportFilePaths(List<string> extractedFilePaths)
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
            }
        }


        /// <summary>
        /// Imports the project data.
        /// </summary>
        /// Erstellt von Joshua Frey, am 15.01.2016
        /// <exception cref="NWAT.DB.NWATException"></exception>
        private void importProjectData()
        {
            this.ImportLogWriter.Log(MessageStartImportOfData("Project"));
            using (StreamReader sr = new StreamReader(this.ProjectImportFilePath))
            {
                string line;
                Project importProj;
                while ((line = sr.ReadLine()) != null)
                {
                    importProj = getProjectByLineFromImportFile(line);

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

                        bool importSuccessful = this.ImportProjectController.InsertProjectIntoDb(importProj, importProjId);
                        if (importSuccessful)
                        {
                            this.ImportLogWriter.Log(MessageImportSucceeded(importProjId, importProj.Name));
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
                        this.ImportLogWriter.Log(MessageDatasetAlreadyExists(importProjId, originImportProjName));
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
        private Project getProjectByLineFromImportFile(string projectImportLine)
        {
            Project importProject;
            // Project_Id|Name|Description
            var lineAsArray = projectImportLine.Split(this._delimiter);
            importProject = new Project()
            {
                Project_Id = Convert.ToInt32(lineAsArray[0]),
                Name = lineAsArray[1],
                Description = lineAsArray[2]
            };
            return importProject;
        }

        /// <summary>
        /// Imports the criterion data.
        /// </summary>
        /// Erstellt von Joshua Frey, am 15.01.2016
        private void importCriterionData()
        {
            this.ImportLogWriter.Log(MessageStartImportOfData("Criterion"));
            using (StreamReader sr = new StreamReader(this.CriterionImportFilePath))
            {
                string line;
                Criterion importCriterion;
                while ((line = sr.ReadLine()) != null)
                {
                    importCriterion = getCriterionByLineFromImportFile(line);
                    int importCritId = importCriterion.Criterion_Id;
                    string originImportCritName = importCriterion.Name;

                    // if id does not already exist in table --> import; else skip
                    if (!this.ImportCriterionController.CheckIfCriterionIdAlreadyExists(importCritId))
                    {
                        // if name of criterion already exists in table, then expand the name of
                        // importProject by "_imported"
                        if (this.ImportCriterionController.CheckIfCriterionNameAlreadyExists(importCriterion.Name))
                        {
                            importCriterion.Name += "_imported";
                            // if name was changed, logfile will be updated
                            this.ImportLogWriter.Log(MessageSuffixWasAppendedToDataName(originImportCritName, importCriterion.Name));
                        }

                        bool importSuccessful = this.ImportCriterionController.InsertCriterionIntoDb(importCriterion, importCritId);
                        //bool importSuccessful = true;
                        if (importSuccessful)
                        {
                            this.ImportLogWriter.Log(MessageImportSucceeded(importCritId, importCriterion.Name));
                        }
                        else
                        {
                            string dataSet = String.Format("Project_Id = {0}\n Name = {1}\n Description = {3}",
                                                            importCritId,
                                                            importCriterion.Name,
                                                            importCriterion.Description);

                            throw new NWATException(MessageImportFailed("Project", dataSet));
                        }
                        
                    }
                    else
                    {
                        this.ImportLogWriter.Log(MessageDatasetAlreadyExists(importCritId, originImportCritName));
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
        private Criterion getCriterionByLineFromImportFile(string criterionImportLine)
        {
            Criterion importCriterion;
            // Project_Id|Name|Description
            var lineAsArray = criterionImportLine.Split(this._delimiter);
            importCriterion = new Criterion()
            {
                Criterion_Id = Convert.ToInt32(lineAsArray[0]),
                Name = lineAsArray[1],
                Description = lineAsArray[2]
            };
            return importCriterion;
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

        private string MessageImportSucceeded(int dataSetId, string dataSetName)
        {
            return String.Format("Der Datensatz mit der Id \"{0}\" und dem Namen \"{1}\" wurde erfolgreich importiert.", dataSetId, dataSetName);
        }

        private string MessageStartImportOfData(string tableName)
        {
            return String.Format("\tImport der Daten für die Tabelle \"{0}\" wurde gestartet.", tableName);
        }

        private string MessageEndImportOfData(string tableName)
        {
            return String.Format("\tImport der Daten für die Tabelle \"{0}\" wurde beendet.", tableName);
        }

        private string MessageSuffixWasAppendedToDataName(string originName, string changedName)
        {
            return String.Format("Der Datensatz mit dem Namen \"{0}\" wurde als \"{1}\" importiert, da ein weitere Datensatz mit" +
                                " den ursprünglichen Namen in der Tabelle enthalten ist.", originName, changedName);
        }

        private string MessageDatasetAlreadyExists(int dataSetId, string dataSetName)
        {
            return String.Format("Der Datensatz mit der Id \"{0}\" und dem Namen \"{1}\" wurde nicht importiert, "+
                                 "da der Datensatz bereits in der Tabelle existiert.", dataSetId, dataSetName);
        }
    }
}
