using NWAT.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace NWAT
{
    public partial class ProjCritBalance_View : Form
    {

        private List<Product> _allProds;

        public List<Product> AllProds
        {
            get { return _allProds; }
            set { _allProds = value; }
        }

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

     
        private ProjectCriterionController projCritCont;
        private Form parentView;
        
        public ProjCritBalance_View(Form parentView, int projectID)
        {
            this.parentView = parentView;
            ProjectId = projectID;
            this.projCritCont = new ProjectCriterionController();
            InitializeComponent();
        }
        /// <summary>
        /// Handles the Load event of the ProjCritBalance_View control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        private void ProjCritBalance_View_Load(object sender, EventArgs e)
        {
            try
            {
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
                    dataGridView_ProjCritBalance.Rows.Clear();
                    var CritBindingList = new BindingList<ProjectCriterion>(ProjCrits);
                    var CritSource = new BindingSource(CritBindingList, null);
                    dataGridView_ProjCritBalance.DataSource = ProjCrits;
                    dataGridView_ProjCritBalance.Columns.Remove("Project_Id");
                    dataGridView_ProjCritBalance.Columns.Remove("Strukture");
                    dataGridView_ProjCritBalance.Columns.Remove("Criterion");
                    dataGridView_ProjCritBalance.Columns.Remove("ParentCriterion");
                    dataGridView_ProjCritBalance.Columns.Remove("Project");
                    dataGridView_ProjCritBalance.Columns.Add("Beschreibung1", "Beschreibung");
                    int i = 0;
                    foreach (ProjectCriterion ProCri in ProjCrits)
                    {

                        dataGridView_ProjCritBalance["Beschreibung1", i].Value = ProCri.Criterion.Description;
                        i++;
                    }
                    dataGridView_ProjCritBalance.Columns["Name"].Width = 150;
                    dataGridView_ProjCritBalance.Columns["Criterion_ID"].HeaderText = "ID";
                    dataGridView_ProjCritBalance.Columns["Criterion_ID"].Width = 40;
                    dataGridView_ProjCritBalance.Columns["Layer_Depth"].DisplayIndex = 0;
                    dataGridView_ProjCritBalance.Columns["Layer_Depth"].HeaderText = "Layer";
                    dataGridView_ProjCritBalance.Columns[1].Width = 40;
                    dataGridView_ProjCritBalance.Columns[1].ReadOnly = true;
                    dataGridView_ProjCritBalance.Columns[2].HeaderText = "P-ID";
                    dataGridView_ProjCritBalance.Columns[2].Width = 40;
                    dataGridView_ProjCritBalance.Columns[2].ReadOnly = true;
                    dataGridView_ProjCritBalance.Columns[3].HeaderText = "G(C)";
                    dataGridView_ProjCritBalance.Columns[3].Width = 40;
                    dataGridView_ProjCritBalance.Columns["Parent_Criterion_Id"].Width = 40;
                    
                    dataGridView_ProjCritBalance.Columns[4].HeaderText ="G(PL)";
                    dataGridView_ProjCritBalance.Columns[4].Width = 100;
                    dataGridView_ProjCritBalance.Columns["Weighting_Percentage_Project"].HeaderText = "G(PP)";
                    dataGridView_ProjCritBalance.Columns["Weighting_Percentage_Project"].Width = 100;
                    dataGridView_ProjCritBalance.Columns["Weighting_Percentage_Project"].DisplayIndex = 5;
                    dataGridView_ProjCritBalance.Columns["Weighting_Percentage_Project"].ReadOnly = true;
                    dataGridView_ProjCritBalance.Columns[4].ReadOnly = true;
                    dataGridView_ProjCritBalance.Columns[5].ReadOnly = true;
                    dataGridView_ProjCritBalance.Columns[5].Width = 100;
                    dataGridView_ProjCritBalance.Columns["Beschreibung1"].DisplayIndex = 7;
                    dataGridView_ProjCritBalance.Columns["Beschreibung1"].Width = 350;
                    dataGridView_ProjCritBalance.Columns["Layer_Depth"].Width = 50;
                    dataGridView_ProjCritBalance.Columns["Beschreibung1"].ReadOnly = true;
                    dataGridView_ProjCritBalance.Columns["Name"].ReadOnly = true;
                    dataGridView_ProjCritBalance.Columns["Criterion_Id"].ReadOnly = true;
                    dataGridView_ProjCritBalance.Columns["Parent_Criterion_Id"].ReadOnly = true;
                }
            }
            catch (FormatException){
            MessageBox.Show("Bitte nur Zahlen eingeben");
            }
            this.dataGridView_ProjCritBalance.CellValidating += new
         DataGridViewCellValidatingEventHandler(dataGridView_ProjCritBalance_CellValidating);
            this.FormClosing += new FormClosingEventHandler(ProjCritBalance_View_FormClosing);
        }
        /// <summary>
        /// Handles the FormClosing event of the ProjCritBalance_View control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        void ProjCritBalance_View_FormClosing(object sender, FormClosingEventArgs e)
        {
            try{
                this.parentView.Show();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        /// <summary>
        /// Handles the CellValueChanged event of the dataGridView_ProjCritBalance control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DataGridViewCellEventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        private void dataGridView_ProjCritBalance_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        { 
            try{
        int zeile = (dataGridView_ProjCritBalance.Rows.Count -1);
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        /// <summary>
        /// Handles the Click event of the btn_SameBalance control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
       private void btn_SameBalance_Click(object sender, EventArgs e)
        {
           try{
            foreach (DataGridViewRow row in dataGridView_ProjCritBalance.Rows)
            {
                row.Cells["Weighting_Cardinal"].Value = 1;
            }
            int i = 0;
            foreach (DataGridViewRow row in dataGridView_ProjCritBalance.Rows)
            {
                int critID = (int)row.Cells["Weighting_Cardinal"].Value;
                ProjectCriterion fromList = ProjCrits[i];
                i++;
                fromList.Weighting_Cardinal = (int)row.Cells["Weighting_Cardinal"].Value;
                projCritCont.UpdateProjectCriterionInDb(fromList);
            }
            refreshGrid();
           }
           catch (Exception x)
           {
               MessageBox.Show(x.Message);
           }
       }

       /// <summary>
       /// Handles the Click event of the btn_ProjCritBalaSave control.
       /// </summary>
       /// <param name="sender">The source of the event.</param>
       /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
       /// Erstellt von Veit Berg, am 27.01.16
       private void btn_ProjCritBalaSave_Click(object sender, EventArgs e)
       {
               try{
               int i = 0;
               foreach (DataGridViewRow row in dataGridView_ProjCritBalance.Rows)
               {
                   int critID = (int)row.Cells["Weighting_Cardinal"].Value ;
                   ProjectCriterion fromList = ProjCrits[i];
                   i++;
                   fromList.Weighting_Cardinal = (int)row.Cells["Weighting_Cardinal"].Value; //wc vorher 3
                   projCritCont.UpdateProjectCriterionInDb(fromList);
               }

               refreshGrid();
               }
               catch (Exception x)
               {
                   MessageBox.Show(x.Message);
               }
       }

       /// <summary>
       /// Handles the Click event of the btn_ProjCritBalaCancle control.
       /// </summary>
       /// <param name="sender">The source of the event.</param>
       /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
       /// Erstellt von Veit Berg, am 27.01.16
        private void btn_ProjCritBalaCancle_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        /// <summary>
        /// Refreshes the grid.
        /// </summary>
        /// Erstellt von Veit Berg, am 27.01.16
        private void refreshGrid()
        {
            try{
            dataGridView_ProjCritBalance.DataSource = null;
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
                var CritSource = new BindingSource(CritBindingList, null);
                dataGridView_ProjCritBalance.DataSource = ProjCrits;
        
                
                dataGridView_ProjCritBalance.Columns.Remove("Project_Id");
                dataGridView_ProjCritBalance.Columns.Remove("Criterion");
                dataGridView_ProjCritBalance.Columns.Remove("ParentCriterion");
                dataGridView_ProjCritBalance.Columns.Remove("Project");
                int i = 0;
                foreach (ProjectCriterion ProCri in ProjCrits)
                {

                    dataGridView_ProjCritBalance["Beschreibung1", i].Value = ProCri.Criterion.Description;
                    i++;
                }
                dataGridView_ProjCritBalance.Columns["Criterion_Id"].HeaderText = "ID";
                dataGridView_ProjCritBalance.Columns[1].Width = 40;
                dataGridView_ProjCritBalance.Columns[1].ReadOnly = true;
                dataGridView_ProjCritBalance.Columns["Parent_Criterion_Id"].HeaderText = "P-ID";
                dataGridView_ProjCritBalance.Columns[2].Width = 40;
                dataGridView_ProjCritBalance.Columns[2].ReadOnly = true;
                dataGridView_ProjCritBalance.Columns["Weighting_Cardinal"].HeaderText = "G(C)";
                dataGridView_ProjCritBalance.Columns["Weighting_Cardinal"].Width = 40;
                dataGridView_ProjCritBalance.Columns["Weighting_Percentage_Layer"].HeaderText = "G(PL)";
                dataGridView_ProjCritBalance.Columns["Criterion_Id"].ReadOnly = true;
                dataGridView_ProjCritBalance.Columns["Weighting_Cardinal"].Width = 40;
                dataGridView_ProjCritBalance.Columns["Weighting_Percentage_Layer"].Width = 100;
                dataGridView_ProjCritBalance.Columns["Weighting_Percentage_Project"].Width = 100;
                dataGridView_ProjCritBalance.Columns["Weighting_Percentage_Project"].HeaderText = "G(PP)";
                dataGridView_ProjCritBalance.Columns[5].ReadOnly = true;
                dataGridView_ProjCritBalance.Columns["Layer_Depth"].HeaderText = "Layer";
                dataGridView_ProjCritBalance.Columns["Layer_Depth"].DisplayIndex = 0;
                dataGridView_ProjCritBalance.Columns["Layer_Depth"].Width = 50;
                dataGridView_ProjCritBalance.Columns["Criterion_Id"].DisplayIndex = 1;
                dataGridView_ProjCritBalance.Columns["Parent_Criterion_Id"].DisplayIndex = 2;
                dataGridView_ProjCritBalance.Columns["Weighting_Cardinal"].DisplayIndex = 3;
                dataGridView_ProjCritBalance.Columns["Weighting_Percentage_Layer"].DisplayIndex = 4;
                dataGridView_ProjCritBalance.Columns["Weighting_Percentage_Project"].DisplayIndex = 5;
                dataGridView_ProjCritBalance.Columns["Name"].DisplayIndex = 6;
                dataGridView_ProjCritBalance.Columns["Name"].Width = 150;
                dataGridView_ProjCritBalance.Columns["Beschreibung1"].DisplayIndex = 7;
                dataGridView_ProjCritBalance.Columns["Beschreibung1"].Width = 350;
                dataGridView_ProjCritBalance.Columns["Parent_Criterion_Id"].Width = 40;
                dataGridView_ProjCritBalance.Columns["Beschreibung1"].ReadOnly = true;
                dataGridView_ProjCritBalance.Columns["Name"].ReadOnly = true;
                dataGridView_ProjCritBalance.Columns["Criterion_Id"].ReadOnly = true;
                dataGridView_ProjCritBalance.Columns["Parent_Criterion_Id"].ReadOnly = true;
                dataGridView_ProjCritBalance.Columns["Weighting_Percentage_Project"].ReadOnly = true;
            }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void dataGridView_ProjCritBalance_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /// <summary>
        /// Handles the CellValidating event of the dataGridView_ProjCritBalance control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DataGridViewCellValidatingEventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        private void dataGridView_ProjCritBalance_CellValidating(object sender,   DataGridViewCellValidatingEventArgs e)
        { 
            try{
            if (e.ColumnIndex == 3 || e.ColumnIndex == 4 )
           {
                dataGridView_ProjCritBalance.Rows[e.RowIndex].ErrorText = "";
                int newInteger;
                if (e.FormattedValue.ToString() == "")
                {

                }
                else if (!int.TryParse(e.FormattedValue.ToString(),
                    out newInteger) || newInteger < 0)
                {
                    e.Cancel = true;
                    dataGridView_ProjCritBalance.Rows[e.RowIndex].ErrorText = "the value must be a non-negative integer";

                    MessageBox.Show("Bitte nur Ganzzahlen eintragen");
                }
           }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }
    }
}
