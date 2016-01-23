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
                var CritBindingList = new BindingList<ProjectCriterion>(ProjCrits);
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


            }
        }
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
                if (row.Cells[2].Value != null)
                {
                    fromList.Parent_Criterion_Id = (int)row.Cells[2].Value;

                    projCritCont.UpdateProjectCriterionInDb(fromList);
                }
            }
        }

        private void dataGridView_CritStruUpd_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
         
        }
    }
}
