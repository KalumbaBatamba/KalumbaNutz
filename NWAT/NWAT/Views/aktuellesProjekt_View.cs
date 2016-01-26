﻿using NWAT.DB;
using NWAT.Views;
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

namespace NWAT
{
    public partial class aktuellesProjekt_View : Form
    {
        private Project _project;

        public Project Project
        {
            get { return _project; }
            set { _project = value; }
        }

        private ProjectController _projectCont;

        public ProjectController ProjectCont
        {
            get { return _projectCont; }
            set { _projectCont = value; }
        }

        private ProjectController _projectController;


        public aktuellesProjekt_View(int projectId)
        {
         //   _projectController = new ProjectController();
            this.ProjectCont = new ProjectController();
            this.Project = this.ProjectCont.GetProjectById(projectId);
            InitializeComponent();
            
        }

        private void aktuellesProjekt_Load(object sender, EventArgs e)
        {
            using (ProjectController AktProjForm = new ProjectController())
            {
                Project proj = AktProjForm.GetProjectById(Project.Project_Id);
                String ProjName = proj.Name;
                String ProjDesc = proj.Description;
                MessageBox.Show(ProjName + ProjDesc);
                label_CurrProjNameShow.Text = this.Project.Name; //proj.Name;
                label_CurrProjDescShow.Text = this.Project.Description; //proj.Description;
            }

            //Tool Tip für den Button Projektkriterienexport - Info an den User
            ToolTip toolTip1 = new ToolTip();
            toolTip1.ToolTipTitle = "Projektkriterienexport";
            toolTip1.UseFading = true;
            toolTip1.UseAnimation = true;
            toolTip1.IsBalloon = true;
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(btn_ProjCritExport, "Dieser Button erzeugt eine Textdatei mit allen Kriterien, die dem aktuellen Projekt zugeordnet sind. \nDiese Textdatei kann genutzt werden, um beispielsweise anschließend eine Rechtschreibprüfung durchführen zu lassen");
            ToolTip toolTip2 = new ToolTip();
            //Tool Tip für den Button Gewichtung drucken - Info an den User
            toolTip2.ToolTipTitle = "Gewichtung drucken";
            toolTip2.UseFading = true;
            toolTip2.UseAnimation = true;
            toolTip2.IsBalloon = true;
            toolTip2.AutoPopDelay = 5000;
            toolTip2.InitialDelay = 1000;
            toolTip2.ReshowDelay = 500;
            toolTip2.ShowAlways = true;
            toolTip2.SetToolTip(btn_CurrProjCritStruPrint, "Dieser Button erstellt eine Pdf Datei, in der die Kriterienstruktur mit den Anforderungen des Kunden inklusive der kardinalen Gewichtungen abgebildet werden");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox_CurrProjProds_Enter(object sender, EventArgs e)
        {

        }
        private void OpenCritAssign()
        {

        }
        private void OpenCritStructure()
        {

        }

        private void btn_CurrProjKritAssign_Click(object sender, EventArgs e)
        {
            
            
            ProjCritAssign_View ProjCritAssign = new ProjCritAssign_View(Project.Project_Id);
            ProjCritAssign.Show();
        }

        private void btn_CurrProjCritStruShow_Click(object sender, EventArgs e)
        {
            ProjCritShow_View ProjCritShow = new ProjCritShow_View();
            ProjCritShow.Show();
        }

        private void btn_CurrProjCritStruUpdate_Click(object sender, EventArgs e)
        {
            ProjCritStruUpdate_View ProjCritStruUpdate = new ProjCritStruUpdate_View(Project.Project_Id);
            ProjCritStruUpdate.Show();
        }

        private void btn_CurrProjCritStruPrint_Click(object sender, EventArgs e)
        {
            CriterionStructurePrinter printobject = new CriterionStructurePrinter(Project.Project_Id);
            printobject.CreateCriterionStructurePdf(); 
        }

        private void btn_CurrProjCritStruBalance_Click(object sender, EventArgs e)
        {

        }

        private void btn_CurrProjCritStruEval_Click(object sender, EventArgs e)
        {

        }

        private void btn_CurrProjProdAssign_Click(object sender, EventArgs e)
        {
            ProjProdAssign_View ProjProdAssign = new ProjProdAssign_View(Project.Project_Id);
            ProjProdAssign.Show();

       //     ProjectProductAssign_View ProjectProductAssign = new ProjectProductAssign_View(Project.Project_Id);
       //     ProjectProductAssign.Show();
        }

        private void btn_CurrProjProdFulfCapt_Click(object sender, EventArgs e)
        {
            ProjCritProdFulfilment_View ProjCritProdFulfillment = new ProjCritProdFulfilment_View(Project.Project_Id);
            ProjCritProdFulfillment.Show();
        }

        private void btnCurrProjProdFulfPrint_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Alle projektspezifischen Produkte inklusive der Kriterienstruktur und deren Erfüllungen werden auf dem Pdf abgebildet!");
            FulfillmentForEveryProduct fulfillmentEveryProdPrint = new FulfillmentForEveryProduct(Project.Project_Id);
            fulfillmentEveryProdPrint.CreateFulfillmentForEveryProductPdf();
        }

        private void btn_CurrProjProdAnalShow_Click(object sender, EventArgs e)
        {
            AnalysePrinter analyseObject = new AnalysePrinter(Project.Project_Id);
            analyseObject.PrintAnalysisResult();
        }

        private void btn_Balance_Click(object sender, EventArgs e)
        {
            ProjCritBalance_View ProjCritBalance = new ProjCritBalance_View(Project.Project_Id);
            ProjCritBalance.Show();
        }

        private void label_CurrProjNameShow_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SpellVerification newObject = new SpellVerification(Project.Project_Id);
            newObject.CreateTextFileWithCriterions();
        }

        private void btn_CurrProjCritStruPrintCostumer_Click(object sender, EventArgs e)
        {
            CriterionStructurePrinterCostumer printObject = new CriterionStructurePrinterCostumer(Project.Project_Id);
            printObject.CreateCriterionStructurePdfForCostumer();
        }
    }
}
