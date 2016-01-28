using NWAT.DB;
using NWAT.Printer;
using System;
using System.Windows.Forms;

namespace NWAT
{
    /* Zeigt Nutzerhinweis fürs Drucken an, dass vorher gespeichert werden muss, gibt Möglichkeit für zurück oder drucken
     
     */
    public partial class FulfPrint_View : Form
    {
        private Project _project;
        private ProductController prodCont;

        public Project Project
        {
            get { return _project; }
            set { _project = value; }
        }
        private ProjectController ProjectCont;
        int prodID;

        public FulfPrint_View(int  projectId, int prodId)
        {
            prodID = prodId;
            int ProjectId = projectId;
            this.ProjectCont = new ProjectController();
            this.Project = this.ProjectCont.GetProjectById(projectId);
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the FulfPrint_View control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        private void FulfPrint_View_Load(object sender, EventArgs e)
        {

            this.FormClosing += new FormClosingEventHandler(FulfPrint_View_FormClosing);
        }
        void FulfPrint_View_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        /// <summary>
        /// Handles the Click event of the btn_back control.
        /// schliesst die Form, dass der Nutzer die Änderungen speichern kann
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        /// <summary>
        /// Handles the Click event of the btn_print control.
        /// weiter zum Drucken
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        private void btn_print_Click(object sender, EventArgs e)
        {
   
            FulfillmentForEachProductPrinter PrintEachProduct = new FulfillmentForEachProductPrinter(Project.Project_Id, prodID);
            PrintEachProduct.CreateFulfillmentForEachProductPdf();
            this.Close();
            

        }
    }
}
