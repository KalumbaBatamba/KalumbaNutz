using NWAT.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
namespace NWAT
{
    public partial class ProjCritStruUpdate_View : Form
    {
        private List<ProjectCriterion> _projCrits;

        public List<ProjectCriterion> ProjCrits
        {
            get { return _projCrits; }
            set { _projCrits = value; }
        }
        private int _projectId;

        public int ProjectId
        {
            get { return _projectId; }
            set { _projectId = value; }
        }

        private List<ProjectCriterion> _aktProjCrits;

        public List<ProjectCriterion> AktProjCrits
        {
            get { return _aktProjCrits; }
            set { _aktProjCrits = value; }
        }
        private BindingSource _critSource;

        public BindingSource CritSource
        {
            get { return _critSource; }
            set { _critSource = value; }
        }


        private Form parentView;

        private ProjectCriterionController projCritCont;
        public ProjCritStruUpdate_View(Form parentView, int projectID)
        {
            this.parentView = parentView;
            ProjectId = projectID;
            this.projCritCont = new ProjectCriterionController();
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the ProjCritStruUpdate_Form control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        private void ProjCritStruUpdate_Form_Load(object sender, EventArgs e)
        { 
            try{
            using (ProjectCriterionController proCriCont = new ProjectCriterionController())
            {
                ProjCrits = proCriCont.GetSortedCriterionStructure(ProjectId);
                using (CriterionController critCon = new CriterionController())
                {
                    foreach (ProjectCriterion projCrit in ProjCrits)
                    {
                        var singleCritId = critCon.GetCriterionById(projCrit.Criterion_Id);
                        projCrit.Name = singleCritId.Name.ToString();
                    }
                }

                var CritBindingList = new BindingList<ProjectCriterion>(ProjCrits);
                this.CritSource = new BindingSource(CritBindingList, null);
                dataGridView_CritStruUpd.DataSource = ProjCrits;
                dataGridView_CritStruUpd.Columns.Remove("Project_Id");
                dataGridView_CritStruUpd.Columns.Remove("Criterion");
                dataGridView_CritStruUpd.Columns.Remove("ParentCriterion");
                dataGridView_CritStruUpd.Columns.Remove("Project");
                dataGridView_CritStruUpd.Columns[0].ReadOnly = true;
                dataGridView_CritStruUpd.Columns[0].Width = 40;
                dataGridView_CritStruUpd.Columns[1].ReadOnly = true;
                dataGridView_CritStruUpd.Columns[1].HeaderText = "Layer";
                dataGridView_CritStruUpd.Columns[1].Width = 40;
                dataGridView_CritStruUpd.Columns[2].HeaderText = "P-ID";
                dataGridView_CritStruUpd.Columns[2].Width = 40;
                dataGridView_CritStruUpd.Columns[3].ReadOnly = true;
                dataGridView_CritStruUpd.Columns[3].HeaderText = "W(C)";
                dataGridView_CritStruUpd.Columns[4].ReadOnly = true;
                dataGridView_CritStruUpd.Columns[4].HeaderText = "W(PL)";
                dataGridView_CritStruUpd.Columns[5].ReadOnly = true;
                dataGridView_CritStruUpd.Columns[5].HeaderText = "W(PP)";
                dataGridView_CritStruUpd.Columns["Weighting_Percentage_Project"].Width = 40;
                dataGridView_CritStruUpd.Columns[6].ReadOnly = true;
                dataGridView_CritStruUpd.Columns[6].HeaderText = "Name";
                dataGridView_CritStruUpd.Columns.Add("Beschreibung", "Beschreibung");
                dataGridView_CritStruUpd.Columns["Beschreibung"].ReadOnly = true; 
                int i = 0;
                foreach (ProjectCriterion ProCri in ProjCrits)
                {

                    dataGridView_CritStruUpd["Beschreibung", i].Value = ProCri.Criterion.Description;
                    i++;
                } 



                dataGridView_CritStruUpd.Columns[1].DisplayIndex = 0;
                dataGridView_CritStruUpd.Columns[2].DisplayIndex = 1;
                dataGridView_CritStruUpd.Columns[6].DisplayIndex = 3;
                dataGridView_CritStruUpd.Columns[6].Width = 200;
                dataGridView_CritStruUpd.Columns[7].DisplayIndex = 4;
                dataGridView_CritStruUpd.Columns[7].Width = 200;
                dataGridView_CritStruUpd.Columns["Criterion_Id"].HeaderText = "ID";
                dataGridView_CritStruUpd.Columns["Name"].ReadOnly = true;
                dataGridView_CritStruUpd.Columns["Weighting_Percentage_Project"].Width = 100;

                dataGridView_CritStruUpd.Show();
            }
            this.dataGridView_CritStruUpd.CellValidating += new
            DataGridViewCellValidatingEventHandler(dataGridView_CritStruUpd_CellValidating);

            this.FormClosing += new FormClosingEventHandler(ProjCritStruUpdate_View_FormClosing);
            }
            catch (Exception i)
            {
                MessageBox.Show(i.Message);
            }
        }
        /// <summary>
        /// Handles the FormClosing event of the ProjCritStruUpdate_View control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        void ProjCritStruUpdate_View_FormClosing(object sender, FormClosingEventArgs e)
        {
            try{
                this.parentView.Show();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void GetProjectCritStructure()
        {

        }
        private void UpdateProjCritSturcture()
        {

        }

        /// <summary>
        /// Handles the Click event of the btn_ProjCritStruSave control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        private void btn_ProjCritStruSave_Click(object sender, EventArgs e)
        {
            try
            {
                int i = 0;

                List<ProjectCriterion> changedProjectCriterions = new List<ProjectCriterion>();
                foreach (DataGridViewRow row in dataGridView_CritStruUpd.Rows)
                {
                    ProjectCriterion fromList = ProjCrits[i];
                    i++;
                    if (row.Cells["Parent_Criterion_Id"].Value == null)
                    {
                        fromList.Parent_Criterion_Id = null;
                        //projCritCont.UpdateProjectCriterionInDb(fromList);
                    }
                    else
                    {
                        bool projCritExists = projCritCont.CheckIfProjectCriterionAlreadyExists(ProjectId, (int)row.Cells["Parent_Criterion_Id"].Value);
                        if (projCritExists == false)
                        {

                            MessageBox.Show("Das eingetragene Parentkriterium des Kriteriums mit der ID: " + (int)row.Cells["Criterion_Id"].Value + " existiert nicht.\n" +
                            "Es wurden keine Daten in der Datenbank gespeichert.");
                            // Ausstiegspunkt, da keine inkonsistenten Daten gespeichert werden sollen.
                            return;
                        }
                        else
                        {
                            fromList.Parent_Criterion_Id = (int)row.Cells["Parent_Criterion_Id"].Value;
                            //  projCritCont.UpdateProjectCriterionInDb(fromList);
                        }
                    }
                    changedProjectCriterions.Add(fromList);
                }
                
                projCritCont.UpdateAllProjectCriterions(this.ProjectId, changedProjectCriterions);
                refreshGrid();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void dataGridView_CritStruUpd_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
         
        }

        /// <summary>
        /// Refreshes the grid.
        /// </summary>
        /// Erstellt von Veit Berg, am 27.01.16
        private void refreshGrid()
        {
            try{
            dataGridView_CritStruUpd.DataSource = null;
            using (ProjectCriterionController proCriCont = new ProjectCriterionController())
            {
                ProjCrits = proCriCont.GetSortedCriterionStructure(ProjectId);
                using (CriterionController critCon = new CriterionController())
                {
                    foreach (ProjectCriterion projCrit in ProjCrits)
                    {
                        var singleCritId = critCon.GetCriterionById(projCrit.Criterion_Id);
                        projCrit.Name = singleCritId.Name.ToString();
                    }
                }

                var CritBindingList = new BindingList<ProjectCriterion>(ProjCrits);
                this.CritSource = new BindingSource(CritBindingList, null);
                dataGridView_CritStruUpd.DataSource = ProjCrits;
                dataGridView_CritStruUpd.Columns.Remove("Project_Id");
                dataGridView_CritStruUpd.Columns.Remove("Criterion");
                dataGridView_CritStruUpd.Columns.Remove("ParentCriterion");
                dataGridView_CritStruUpd.Columns.Remove("Project");
                dataGridView_CritStruUpd.Columns[0].ReadOnly = true;
                dataGridView_CritStruUpd.Columns[0].Width = 40;
                dataGridView_CritStruUpd.Columns[1].ReadOnly = true;
                dataGridView_CritStruUpd.Columns[1].HeaderText = "ID";
                dataGridView_CritStruUpd.Columns[1].Width = 40;
                dataGridView_CritStruUpd.Columns[2].HeaderText = "Layer";
                dataGridView_CritStruUpd.Columns[2].Width = 40;
                dataGridView_CritStruUpd.Columns[3].HeaderText = "testname";
                
                dataGridView_CritStruUpd.Columns[3].ReadOnly = true;
                dataGridView_CritStruUpd.Columns[3].HeaderText = "P-ID";
                dataGridView_CritStruUpd.Columns[4].ReadOnly = true;
                dataGridView_CritStruUpd.Columns[4].HeaderText = "W(C)";
                dataGridView_CritStruUpd.Columns[5].ReadOnly = true;
                dataGridView_CritStruUpd.Columns[5].HeaderText = "W(PL)";
                dataGridView_CritStruUpd.Columns[6].ReadOnly = true;
                dataGridView_CritStruUpd.Columns[6].HeaderText = "W(PP)";
                dataGridView_CritStruUpd.Columns["Weighting_Percentage_Project"].Width = 40;
                int i = 0;
                foreach (ProjectCriterion ProCri in ProjCrits)
                {
                    dataGridView_CritStruUpd["Beschreibung", i].Value = ProCri.Criterion.Description;
                    i++;
                } 
                dataGridView_CritStruUpd.Columns[0].DisplayIndex = 4;
                dataGridView_CritStruUpd.Columns[1].DisplayIndex = 2;
                dataGridView_CritStruUpd.Columns["Parent_Criterion_Id"].Width = 40;
                dataGridView_CritStruUpd.Columns["Parent_Criterion_Id"].ReadOnly = false;
                dataGridView_CritStruUpd.Columns["Layer_Depth"].ReadOnly = true;
                dataGridView_CritStruUpd.Columns[2].DisplayIndex = 0;
                dataGridView_CritStruUpd.Columns["Name"].DisplayIndex = 3;
                dataGridView_CritStruUpd.Columns["Beschreibung"].DisplayIndex = 4;
                dataGridView_CritStruUpd.Columns["Name"].Width = 200;
                dataGridView_CritStruUpd.Columns["Beschreibung"].Width = 200;
                dataGridView_CritStruUpd.Columns["Weighting_Percentage_Project"].Width = 100;
                dataGridView_CritStruUpd.Columns["Name"].ReadOnly = true;
                dataGridView_CritStruUpd.Show();
            }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }
        private void btn_refresh_Click(object sender, EventArgs e)
        {
    
        }

        /// <summary>
        /// Handles the CellValidating event of the dataGridView_CritStruUpd control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DataGridViewCellValidatingEventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        private void dataGridView_CritStruUpd_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try{
            if (e.ColumnIndex == 2|| e.ColumnIndex == 3)
            {
                dataGridView_CritStruUpd.Rows[e.RowIndex].ErrorText = "";
                int newInteger;
                if (e.FormattedValue.ToString() == "")
                {
                  
                }
                else if (!int.TryParse(e.FormattedValue.ToString(),
                    out newInteger) || newInteger < 0)
                {
                    e.Cancel = true;
                    dataGridView_CritStruUpd.Rows[e.RowIndex].ErrorText = "Nur Zahlen erlaubt";
                    MessageBox.Show("Bitte nur Ganzzahlen eintragen");
                }
            }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        /// <summary>
        /// Handles the Click event of the btn_ProjCritStruCancle control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        private void btn_ProjCritStruCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
