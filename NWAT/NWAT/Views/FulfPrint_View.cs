using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NWAT.Printer;
using NWAT.DB;

namespace NWAT
{
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

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        /// <summary>
        /// Handles the Click event of the btn_print control.
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
