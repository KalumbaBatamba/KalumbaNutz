using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NWAT.DB
{
    class ProjectImporter
    {

        // the pipe symbol is used to seperate the columns in the csv files.
        private readonly char _delimiter = '|';

        private string _zipArchiveFilePath;

        public string ZipArchiveFilePath
        {
            get { return _zipArchiveFilePath; }
            set { _zipArchiveFilePath = value; }
        }

        private string _temporaryExtractionDirectory;

	    public string TemporaryExtractionDirectory
	    {
		    get { return _temporaryExtractionDirectory;}
		    set { _temporaryExtractionDirectory = value;}
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
            this.TemporaryExtractionDirectory = String.Format(@"{0}\NWATTempExtractDir",Path.GetDirectoryName(this.ZipArchiveFilePath));

        }

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
                string tempExtractDir = this.TemporaryExtractionDirectory;
                List<string> extracedFiles = zipper.extractArchiveDataToTempDir(tempExtractDir, this.ZipArchiveFilePath);
                setImportFilePaths(extracedFiles);
            }

            importProjectData();

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
            using (StreamReader sr = new StreamReader(this.ProjectImportFilePath))
            {
                string line;
                Project importProj;
                while ((line = sr.ReadLine()) != null)
                {
                    importProj = getProjectByLineFromImportFile(line);

                    // if does not already exist in table --> import; else skip
                    if (!this.ImportProjectController.CheckIfProjectIdAlreadyExists(importProj.Project_Id))
                    {
                        // if name of project already exists in table, then expand the name of
                        // importProject by "_imported"
                        if (this.ImportProjectController.CheckIfProjectNameAlreadyExists(importProj.Name))
                        {
                            importProj.Name += "_imported";
                            MessageBox.Show("abgeänderter Name");
                        }
                        
                        bool importSuccessful = this.ImportProjectController.InsertProjectIntoDb(importProj, importProj.Project_Id);
                        if (!importSuccessful)
                        {
                            string dataSet = String.Format("Project_Id = {0}\n Name = {1}\n Description = {3}",
                                                            importProj.Project_Id,
                                                            importProj.Name, 
                                                            importProj.Description);

                            throw new NWATException(MessageImportFailed("Project", dataSet));
                        }
                    }
                    else 
                        MessageBox.Show("ID gibts schon");
                    
                }
            }
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
    }
}
