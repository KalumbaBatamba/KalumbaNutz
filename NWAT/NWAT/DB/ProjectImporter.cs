using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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

            extractArchiveDataToTempDir();

            importProjectData();

        }

        /// <summary>
        /// Extracts the archive data to temporary dir.
        /// </summary>
        /// <returns></returns>
        /// Erstellt von Joshua Frey, am 13.01.2016
        private void extractArchiveDataToTempDir()
        {
            string tempExtractDir = this.TemporaryExtractionDirectory;
            
            if(Directory.Exists(tempExtractDir))
            {
                Directory.Delete(tempExtractDir, true);
                // sleep is needed. If tempExtractDir is open in file explorer
                // it needs more time to delete tempExtractDir and handle the user interruption from gui
                // closing window so the create statement will not actually create a tempExtractDir
                Thread.Sleep(20);
            }
            Directory.CreateDirectory(tempExtractDir);

            using (ZipArchive archive = ZipFile.OpenRead(this.ZipArchiveFilePath))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    if (entry.FullName.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
                    {
                        
                        string extractedFilePath = Path.Combine(tempExtractDir, entry.FullName);
                        setImportFilePaths(extractedFilePath);
                        entry.ExtractToFile(extractedFilePath);
                    }
                }
            }
        }


        /// <summary>
        /// Sets the import file paths.
        /// </summary>
        /// Erstellt von Joshua Frey, am 14.01.2016
        private void setImportFilePaths(string extractedFilePath)
        {
            if (extractedFilePath.EndsWith("_Fulfillment.txt", StringComparison.OrdinalIgnoreCase))
            {
                this.FulfillmenImportFilePath = extractedFilePath;
            }
            else if (extractedFilePath.EndsWith("_ProjectProduct.txt", StringComparison.OrdinalIgnoreCase))
            {
                this.ProjectProductImportFilePath = extractedFilePath;
            }
            else if (extractedFilePath.EndsWith("_ProjectCriterion.txt", StringComparison.OrdinalIgnoreCase))
            {
                this.ProjectCriterionImportFilePath = extractedFilePath;
            }
            else if (extractedFilePath.EndsWith("_Criterion.txt", StringComparison.OrdinalIgnoreCase))
            {
                this.CriterionImportFilePath = extractedFilePath;
            }
            else if (extractedFilePath.EndsWith("_Product.txt", StringComparison.OrdinalIgnoreCase))
            {
                this.ProductImportFilePath = extractedFilePath;
            }
            else if (extractedFilePath.EndsWith("_Project.txt", StringComparison.OrdinalIgnoreCase))
            {
                this.ProjectImportFilePath = extractedFilePath;
            }
        }

        /// <summary>
        /// Imports the project data.
        /// </summary>
        /// Erstellt von Joshua Frey, am 13.01.2016
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

                        this.ImportProjectController.InsertProjectIntoDb(importProj, importProj.Project_Id);


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

        
        /*
         * Messages
         */

        private string MessageArchiveFileDoesNotExistAnyMore()
        {
            return String.Format("Die Archivdatei '{0}' existiert nicht mehr.\n"+
                                 "Import abgebrochen.", this.ZipArchiveFilePath);
        }
    }
}
