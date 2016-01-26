using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NWAT.DB;
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


        private ProjectCriterionController projCritCont;
        public ProjCritStruUpdate_View(int projectID)
        {
            ProjectId = projectID;
            this.projCritCont = new ProjectCriterionController();
            InitializeComponent();

        }

        private void ProjCritStruUpdate_Form_Load(object sender, EventArgs e)
        {
            using (ProjectCriterionController proCriCont = new ProjectCriterionController())
            {
                ProjCrits = proCriCont.GetSortedCriterionStructure(ProjectId);
                //.GetSortedCriterionStructure(ProjectId); 
                //.GetAllProjectCriterionsForOneProject(ProjectId);
                using (CriterionController critCon = new CriterionController())
                {
                    foreach (ProjectCriterion projCrit in ProjCrits)
                    {
                        //    MessageBox.Show(projCrit.Criterion_Id.ToString());
                        //      projCrit.Name = "test";
                        var singleCritId = critCon.GetCriterionById(projCrit.Criterion_Id);
                        projCrit.Name = singleCritId.Name.ToString();
                    }
                }




                dataGridView_CritStruUpd.Rows.Clear();
                refreshGrid();
  /*              var CritBindingList = new BindingList<ProjectCriterion>(ProjCrits);
                var CritSource = new BindingSource(CritBindingList, null);
                dataGridView_CritStruUpd.DataSource = ProjCrits;
                dataGridView_CritStruUpd.Columns.Remove("Project_Id");
               
                
                ////       dataGridView_ProjCritBalance.Columns.Remove("Weighting_Percentage_Layer");
                //dataGridView_CritStruUpd.Columns.Remove("Weighting_Percentage_Project");
                dataGridView_CritStruUpd.Columns.Remove("Criterion");
                dataGridView_CritStruUpd.Columns.Remove("ParentCriterion");
                dataGridView_CritStruUpd.Columns.Remove("Project");
                dataGridView_CritStruUpd.Columns[0].ReadOnly = true;
                dataGridView_CritStruUpd.Columns[1].ReadOnly = true;
                dataGridView_CritStruUpd.Columns[3].ReadOnly = true;
                dataGridView_CritStruUpd.Columns[4].ReadOnly = true;
                dataGridView_CritStruUpd.Columns[5].ReadOnly = true;
                dataGridView_CritStruUpd.Columns[6].ReadOnly = true;
                //dataGridView_CritStruUpd.Columns[7].ReadOnly = true;

                dataGridView_CritStruUpd.Columns[1].DisplayIndex = 0;
                dataGridView_CritStruUpd.Columns[2].DisplayIndex = 1;
                dataGridView_CritStruUpd.Columns[6].DisplayIndex = 3;
                dataGridView_CritStruUpd.Columns[6].Width = 200;
                //dataGridView_CritStruUpd.Columns[1].HeaderText = "ID";
                //dataGridView_CritStruUpd.Columns[1].Width = 30;
                //dataGridView_CritStruUpd.Columns[1].ReadOnly = true;
                //dataGridView_CritStruUpd.Columns[2].HeaderText = "P-ID";
                //dataGridView_CritStruUpd.Columns[2].Width = 30;
                //dataGridView_CritStruUpd.Columns[2].ReadOnly = true;
                //dataGridView_CritStruUpd.Columns[3].HeaderText = "G(C)";
                //dataGridView_CritStruUpd.Columns[3].Width = 30;
                //dataGridView_CritStruUpd.Columns[4].ReadOnly = true;
                //dataGridView_CritStruUpd.Columns[4].Width = 30;
                //dataGridView_CritStruUpd.Columns[5].Width = 350;
                //dataGridView_CritStruUpd.Columns[5].ReadOnly = true;

*/
            }
            this.dataGridView_CritStruUpd.CellValidating += new
            DataGridViewCellValidatingEventHandler(dataGridView_CritStruUpd_CellValidating);

            this.FormClosing += new FormClosingEventHandler(ProjCritStruUpdate_View_FormClosing);
        }
        void ProjCritStruUpdate_View_FormClosing(object sender, FormClosingEventArgs e)
        {
            //your code here
            aktuellesProjekt_View back = new aktuellesProjekt_View(ProjectId);
            back.Show();
        }
       // }
        private void GetProjectCritStructure()
        {

        }
        private void UpdateProjCritSturcture()
        {

        }

        private void btn_ProjCritStruSave_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach (DataGridViewRow row in dataGridView_CritStruUpd.Rows)
            {

                //   int c = int.Parse(row.Cells[3].Value.);
                //     if( row.Cells[3].Value.isNumber);
                // GetType() == int;
                //int.TryParse(row.Cells[3].Value, out c);
                //    if (row.Cells[3].Value. )
                //  {
              //  int i = 0;
                ProjectCriterion fromList = ProjCrits[i];
               // var str = row.Cells[1].Value.GetType();
                //    MessageBox.Show("Var = " + str);
                i++;
             //   fromList.Parent_Criterion_Id = (int)row.Cells[2].Value;
                if (row.Cells[2].Value == null)
                {
                    fromList.Parent_Criterion_Id = null;
                    //(int)row.Cells[2].Value;
                }
                else
                {
                    fromList.Parent_Criterion_Id = (int)row.Cells[2].Value;
                }
             projCritCont.UpdateProjectCriterionInDb(fromList);
            }
            refreshGrid();
    //        this.Close();
           
      
        }

        private void dataGridView_CritStruUpd_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
         
        }

        private void refreshGrid()
        {
            using (ProjectCriterionController proCriCont = new ProjectCriterionController())
            {
                ProjCrits = proCriCont.GetSortedCriterionStructure(ProjectId);
                //.GetSortedCriterionStructure(ProjectId); 
                //.GetAllProjectCriterionsForOneProject(ProjectId);
                using (CriterionController critCon = new CriterionController())
                {
                    foreach (ProjectCriterion projCrit in ProjCrits)
                    {
                        //    MessageBox.Show(projCrit.Criterion_Id.ToString());
                        //      projCrit.Name = "test";
                        var singleCritId = critCon.GetCriterionById(projCrit.Criterion_Id);
                        projCrit.Name = singleCritId.Name.ToString();
                    }
                }

                var CritBindingList = new BindingList<ProjectCriterion>(ProjCrits);
                var CritSource = new BindingSource(CritBindingList, null);
                dataGridView_CritStruUpd.DataSource = ProjCrits;
                dataGridView_CritStruUpd.Columns.Remove("Project_Id");
                dataGridView_CritStruUpd.Columns.Remove("Criterion");
                dataGridView_CritStruUpd.Columns.Remove("ParentCriterion");
                dataGridView_CritStruUpd.Columns.Remove("Project");
                dataGridView_CritStruUpd.Columns[0].ReadOnly = true;
                dataGridView_CritStruUpd.Columns[1].ReadOnly = true;
                dataGridView_CritStruUpd.Columns[3].ReadOnly = true;
                dataGridView_CritStruUpd.Columns[4].ReadOnly = true;
                dataGridView_CritStruUpd.Columns[5].ReadOnly = true;
                dataGridView_CritStruUpd.Columns[6].ReadOnly = true;
                dataGridView_CritStruUpd.Columns[1].DisplayIndex = 0;
                dataGridView_CritStruUpd.Columns[2].DisplayIndex = 1;
                dataGridView_CritStruUpd.Columns[6].DisplayIndex = 3;
                dataGridView_CritStruUpd.Columns[6].Width = 200;

            }
        }
        private void btn_refresh_Click(object sender, EventArgs e)
        {
    
        }

        private void dataGridView_CritStruUpd_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                dataGridView_CritStruUpd.Rows[e.RowIndex].ErrorText = "";
                int newInteger;

                // Don't try to validate the 'new row' until finished 
                // editing since there
                // is not any point in validating its initial value.
                //      if (dataGridView_ProjCritBalance.Rows[e.RowIndex].IsNewRow) { return; }
                if (e.FormattedValue.ToString() == "")
                {
                  
                }
                else if (!int.TryParse(e.FormattedValue.ToString(),
                    out newInteger) || newInteger < 0)
                {
                    e.Cancel = true;
                    dataGridView_CritStruUpd.Rows[e.RowIndex].ErrorText = "Nur Zahlen erlaubt";
                    //       dataGridView_ProjCritBalance.Rows[e.RowIndex].Cells[3].Value = ProjCrits[e.RowIndex].Weighting_Cardinal ;
                    //      dataGridView_ProjCritBalance.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 9;
                    MessageBox.Show("Bitte nur Ganzzahlen eintragen");
                }
                
            }
            //       refreshGrid();
        }

    }
}
