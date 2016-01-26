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

        private void FulfPrint_View_Load(object sender, EventArgs e)
        {

            this.FormClosing += new FormClosingEventHandler(FulfPrint_View_FormClosing);
        }
        void FulfPrint_View_FormClosing(object sender, FormClosingEventArgs e)
        {
            //your code here
      //      ProjCritProdFulfilment_View back = new ProjCritProdFulfilment_View(Project.Project_Id);
      //      back.Show();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
        //    ProjCritProdFulfilment_View back = new ProjCritProdFulfilment_View(Project.Project_Id);
            this.Close();
            
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
          //  Product selectedItem = (Product)comboBox_ProjCritProdFulf.SelectedItem;

            FulfillmentForEachProductPrinter PrintEachProduct = new FulfillmentForEachProductPrinter(Project.Project_Id, prodID);
            PrintEachProduct.CreateFulfillmentForEachProductPdf();
     //       ProjCritProdFulfilment_View back = new ProjCritProdFulfilment_View(Project.Project_Id);
            this.Close();
            

        }
    }
}
