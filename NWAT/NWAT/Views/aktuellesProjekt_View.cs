using NWAT.DB;
using NWAT.Printer;
using System;
using System.Windows.Forms;

namespace NWAT
{
    public partial class aktuellesProjekt_View : Form
    {

/* View mit den Auswahlbuttons für die Funktionen eines ausgewählten Projektes (Kriterien zuordnen, Projektkriterien exportieren,
 *Kriterienstruktur anlegen/ändern, Kriterienstruktur drucken,Gewichtung engeben/ändern, Gewichtung drucken,
 * Produkte zuordnen, Produkt/Kriterienerfüllung erfassen, Erfüllung drucken, Analyse durchführen
 */
  
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

        private Form parentView;

  //      private ProjectController _projectController;


        public aktuellesProjekt_View(Form parentView, int projectId)
        {
            this.parentView = parentView;
            this.ProjectCont = new ProjectController();
            this.Project = this.ProjectCont.GetProjectById(projectId);
            InitializeComponent();

        }

        /// <summary>
        /// Handles the Load event of the aktuellesProjekt control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        private void aktuellesProjekt_Load(object sender, EventArgs e)
        {
                using (ProjectController AktProjForm = new ProjectController())
                {
                    Project proj = AktProjForm.GetProjectById(Project.Project_Id);
                    String ProjName = proj.Name;
                    String ProjDesc = proj.Description;
                    label_CurrProjNameShow.Text = this.Project.Name;
                    label_CurrProjDescShow.Text = this.Project.Description;
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
                //}
                this.FormClosing += new FormClosingEventHandler(aktuellesProject_View_FormClosing);
            
        }
        /// <summary>
        /// Handles the FormClosing event of the aktuellesProject_View control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        void aktuellesProject_View_FormClosing(object sender, FormClosingEventArgs e)
        {
            try{
                this.parentView.Show();
            }
            catch (Exception x)
            { MessageBox.Show("Ups da lief was schief"); }
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

        /// <summary>
        /// Handles the Click event of the btn_CurrProjKritAssign control.
        /// Öffnet die Maske der Kriterienzuordnung
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        private void btn_CurrProjKritAssign_Click(object sender, EventArgs e)
        {
            try{

            ProjCritAssign_View ProjCritAssign = new ProjCritAssign_View(this, Project.Project_Id);
            ProjCritAssign.Show();
            Hide
                ();
            }
            catch (Exception x)
            { MessageBox.Show("Ups da lief was schief"); }
        }

        /// <summary>
        /// Handles the Click event of the btn_CurrProjCritStruShow control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        /*private void btn_CurrProjCritStruShow_Click(object sender, EventArgs e)
        {
            try{
            ProjCritShow_View ProjCritShow = new ProjCritShow_View();
            ProjCritShow.Show();
            }
            catch (Exception x)
            { 
                MessageBox.Show("Ups da lief was schief"); 
            }
        }*/

        /// <summary>
        /// Handles the Click event of the btn_CurrProjCritStruUpdate control.
        /// Öffnet die Maske der Kriterienstruktur 
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        private void btn_CurrProjCritStruUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                ProjCritStruUpdate_View ProjCritStruUpdate = new ProjCritStruUpdate_View(this, Project.Project_Id);
                ProjCritStruUpdate.Show();
                Hide();
            }
            catch (Exception x)
            {
                MessageBox.Show("Ups da lief was schief");
            }
        }

        /// <summary>
        /// Handles the Click event of the btn_CurrProjCritStruPrint control.
        /// Butten zum Öffnen der Kriterienstruktur-Printer
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        private void btn_CurrProjCritStruPrint_Click(object sender, EventArgs e)
        {
            try{
            CriterionStructurePrinter printobject = new CriterionStructurePrinter(Project.Project_Id);
            printobject.CreateCriterionStructurePdf();
            }
            catch (Exception x)
            {
                MessageBox.Show("Ups da lief was schief");
            }
        }

        private void btn_CurrProjCritStruBalance_Click(object sender, EventArgs e)
        {

        }

        private void btn_CurrProjCritStruEval_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the Click event of the btn_CurrProjProdAssign control.
        /// Öffnet die Maske der Produktzuordnung für ein Projekt
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        private void btn_CurrProjProdAssign_Click(object sender, EventArgs e)
        {
            try{
            ProjProdAssign_View ProjProdAssign = new ProjProdAssign_View(this, Project.Project_Id);
            ProjProdAssign.Show();
            Hide();
            }
            catch (Exception x)
            {
                MessageBox.Show("Ups da lief was schief");
            }
        }

        /// <summary>
        /// Handles the Click event of the btn_CurrProjProdFulfCapt control.
        /// Öffnet die Maske in der die Erfüllung der Projektkriterien für die Produkte eingetragen werden kann.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        private void btn_CurrProjProdFulfCapt_Click(object sender, EventArgs e)
        {
            try{
            ProjCritProdFulfilment_View ProjCritProdFulfillment = new ProjCritProdFulfilment_View(this, Project.Project_Id);
            ProjCritProdFulfillment.Show();
            Hide();
            }
            catch (Exception x)
            {
                MessageBox.Show("Ups da lief was schief");
            }
        }

        /// <summary>
        /// Handles the Click event of the btnCurrProjProdFulfPrint control.
        /// Button zum Öffnen der Projekt-Produkt-Kriterienerfüllungs-Printer
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        private void btnCurrProjProdFulfPrint_Click(object sender, EventArgs e)
        {
            try{
            MessageBox.Show("Alle projektspezifischen Produkte inklusive der Kriterienstruktur und deren Erfüllungen sind auf dem Pdf abgebildet!");
            FulfillmentForEveryProduct fulfillmentEveryProdPrint = new FulfillmentForEveryProduct(Project.Project_Id);
            fulfillmentEveryProdPrint.CreateFulfillmentForEveryProductPdf();
            }
            catch (Exception x)
            {
                MessageBox.Show("Ups da lief was schief");
            }
        }

        /// <summary>
        /// Handles the Click event of the btn_CurrProjProdAnalShow control.
        /// Button zzum Öffnen des Analyseprinters
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        private void btn_CurrProjProdAnalShow_Click(object sender, EventArgs e)
        {
            try{
            AnalysePrinter analyseObject = new AnalysePrinter(Project.Project_Id);
            analyseObject.PrintAnalysisResult();
            }
            catch (Exception x)
            {
                MessageBox.Show("Ups da lief was schief");
            }
        }

        /// <summary>
        /// Handles the Click event of the btn_Balance control.
        /// Öffnet die Maske zum Eintragen der Gewichtungsfaktoren
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        private void btn_Balance_Click(object sender, EventArgs e)
        {
            try{
            ProjCritBalance_View ProjCritBalance = new ProjCritBalance_View(this, Project.Project_Id);
            ProjCritBalance.Show();
            Hide();
            }
            catch (Exception x)
            {
                MessageBox.Show("Ups da lief was schief");
            }
        }

        /// <summary>
        /// Handles the Click event of the label_CurrProjNameShow control.
        /// 
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        private void label_CurrProjNameShow_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the Click event of the button1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        private void button1_Click(object sender, EventArgs e)
        {
            try{
            SpellVerification newObject = new SpellVerification(Project.Project_Id);
            newObject.CreateTextFileWithCriterions();
            }
            catch (Exception x)
            {
                MessageBox.Show("Ups da lief was schief");
            }
        }

        /// <summary>
        /// Handles the Click event of the btn_CurrProjCritStruPrintCostumer control.
        /// Öffnet den Printer für die Kriterienstruktur
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        private void btn_CurrProjCritStruPrintCostumer_Click(object sender, EventArgs e)
        {
            try{
            CriterionStructurePrinterCostumer printObject = new CriterionStructurePrinterCostumer(Project.Project_Id);
            printObject.CreateCriterionStructurePdfForCostumer();
            }
            catch (Exception x)
            {
                MessageBox.Show("Ups da lief was schief");
            }
        }
    }
}
