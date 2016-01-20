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
using NWAT.Views;

namespace NWAT
{
    public partial class ProjCritAssign_View : Form
    {
        private List<Criterion> _allCrits;

        public List<Criterion> AllCrits
        {
            get { return _allCrits; }
            set { _allCrits = value; }
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
        public ProjCritAssign_View(int projectId)
        {
            ProjectId = projectId;
            this.projCritCont = new ProjectCriterionController();
            InitializeComponent();
        }

        private void ProjCritAssign_Form_Load(object sender, EventArgs e)
        {

            using (ProjectCriterionController proCriCont = new ProjectCriterionController())
            {
                ProjCrits = proCriCont.GetAllProjectCriterionsForOneProject(ProjectId);

            }
            using (CriterionController critCont = new CriterionController())
            {
                AllCrits = critCont.GetAllCriterionsFromDb(); 
               
                if (ProjCrits.Count != 0)
                {
                    foreach (ProjectCriterion projCrit in ProjCrits)
                    {
                        Criterion allocatedCrit = AllCrits.Single(crit => crit.Criterion_Id == projCrit.Criterion_Id);
                        AllCrits.Remove(allocatedCrit);
                    }
                }
            }
            dataGridView_CritAvail.Rows.Clear();
            var CritBindingList = new BindingList<Criterion>(AllCrits);
            var CritSource = new BindingSource(CritBindingList, null);
            dataGridView_CritAvail.DataSource = AllCrits;

            dataGridView_ProjCrits.Rows.Clear();
            var ProjCritBindingList = new BindingList<ProjectCriterion>(ProjCrits);
            var projCritSource = new BindingSource(ProjCritBindingList, null);
            dataGridView_ProjCrits.DataSource = ProjCrits;
            dataGridView_ProjCrits.Columns.Remove("Project_Id");
            dataGridView_ProjCrits.Columns.Remove("Layer_Depth");
            dataGridView_ProjCrits.Columns.Remove("Weighting_Cardinal");
            dataGridView_ProjCrits.Columns.Remove("Weighting_Percentage_Layer");
            dataGridView_ProjCrits.Columns.Remove("Weighting_Percentage_Project");
            dataGridView_ProjCrits.Columns.Remove("Criterion");
            dataGridView_ProjCrits.Columns.Remove("ParentCriterion");
            dataGridView_ProjCrits.Columns.Remove("Project");
        }
        private void AddCritToProject()
        {

        }
        private void DeleteCritFromProject()
        {

        }
        private void GetAllCritsFromDB()
        {

        }

        private void btn_CritToProj_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView_CritAvail.SelectedRows[0];
            int CritId = (int)row.Cells[0].Value;
            string CritName = (string)row.Cells[1].Value ;
            int index = dataGridView_CritAvail.CurrentCell.RowIndex;
    //        dataGridView_CritAvail.Rows.RemoveAt(row.Index);
            AllCrits.RemoveAt(index);
            //if (ProjCrits.Count != 0)
            //{
                ProjCritParentAllocation_View projCritAllView = new ProjCritParentAllocation_View(
                    ProjCrits, 
                    ProjectId, 
                    CritId, 
                    this);
                projCritAllView.Show();
            //}
        }

        public void AllocateNewProjectCriterion(ProjectCriterion projCritToAllocate)
        {
            ProjCrits.Add(projCritToAllocate);
          //  AllCrits.Remove
            
            //Criterion Crit = new Criterion();
            //Crit = projCritToAllocate.Criterion;
            //AllCrits.Remove(Crit);
            // testzeile
            //dataGridView_ProjCrits = null;
      //      exerciseListDataGridView.DataSource = da.DefaultView;
 //           this.dataGridView_ProjCrits.Refresh();
         //   dataGridView_ProjCrits.Rows.Clear();
            dataGridView_CritAvail.DataSource = null;
            dataGridView_CritAvail.DataSource = AllCrits;
            dataGridView_ProjCrits.DataSource = null;

            dataGridView_ProjCrits.DataSource = ProjCrits;
            dataGridView_ProjCrits.Columns.Remove("Project_Id");
            dataGridView_ProjCrits.Columns.Remove("Layer_Depth");
            dataGridView_ProjCrits.Columns.Remove("Weighting_Cardinal");
            dataGridView_ProjCrits.Columns.Remove("Weighting_Percentage_Layer");
            dataGridView_ProjCrits.Columns.Remove("Weighting_Percentage_Project");
            dataGridView_ProjCrits.Columns.Remove("Criterion");
            dataGridView_ProjCrits.Columns.Remove("ParentCriterion");
            dataGridView_ProjCrits.Columns.Remove("Project");


          // projCritCont.
        //    dataGridView_ProjCrits.Refresh();
          //  using (ProjectCriterionController ProCritCon = new ProjectCriterionController())
            //{
                //List<Criterion> CritListTemp = ProCritCon.GetAllCriterionsFromDb();
                //var bindingList = new BindingList<Criterion>(CritList);
                //var source = new BindingSource(bindingList, null);
             //   dataGridView_Crits.DataSource = CritList;
            //    dataGridView_ProjCrits.DataSource = ProjCrits;

            //}



        }

        private void btn_ProjCritSave_Click(object sender, EventArgs e)
        {
            projCritCont.ChangeAllocationOfProjectCriterionsInDb(ProjectId, ProjCrits);
         //   this.Close;
        }

        private void btn_CritToPool_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView_ProjCrits.SelectedRows[0];
            int CritId = (int)row.Cells[0].Value;
         //   string CritName = (string)row.Cells[1].Value ;
            int index = dataGridView_ProjCrits.CurrentCell.RowIndex;
    //        dataGridView_CritAvail.Rows.RemoveAt(row.Index);
            ProjCrits.RemoveAt(index);
            using (CriterionController critCont = new CriterionController())
            {
           //     foreach (ProjectCriterion projCrit in ProjCrits)
           //     {
                    Criterion addCrit = critCont.GetCriterionById(CritId);
           //     }
                AllCrits.Add(addCrit);
            }
            dataGridView_CritAvail.DataSource = null;
            dataGridView_CritAvail.DataSource = AllCrits;
            dataGridView_ProjCrits.DataSource = null;
            dataGridView_ProjCrits.DataSource = ProjCrits;
            dataGridView_ProjCrits.Columns.Remove("Project_Id");
            dataGridView_ProjCrits.Columns.Remove("Layer_Depth");
            dataGridView_ProjCrits.Columns.Remove("Weighting_Cardinal");
            dataGridView_ProjCrits.Columns.Remove("Weighting_Percentage_Layer");
            dataGridView_ProjCrits.Columns.Remove("Weighting_Percentage_Project");
            dataGridView_ProjCrits.Columns.Remove("Criterion");
            dataGridView_ProjCrits.Columns.Remove("ParentCriterion");
            dataGridView_ProjCrits.Columns.Remove("Project");
    //        AllCrits.Add(critcont)
    //        AllCrits.Add(ProjCrits.)
            //if (ProjCrits.Count != 0)
            //{
                //ProjCritParentAllocation_View projCritAllView = new ProjCritParentAllocation_View(
                //    ProjCrits, 
                //    ProjectId, 
                //    CritId, 
                //    this);
                //projCritAllView.Show();
        }
       
    }
}
//DataGridViewRow row = dataGridView_Crits.SelectedRows[0];
//                int zelle1 = (int)row.Cells[0].Value;