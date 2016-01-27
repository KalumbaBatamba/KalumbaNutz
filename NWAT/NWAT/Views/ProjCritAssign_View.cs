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
            try{
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
            dataGridView_CritAvail.Columns[0].HeaderText = "ID";
            dataGridView_CritAvail.Columns[0].Width = 30;
            dataGridView_CritAvail.Columns[1].Width = 200;
            dataGridView_CritAvail.Columns[2].Width = 240;
            dataGridView_CritAvail.Columns["Description"].HeaderText = "Beschreibung";
            dataGridView_ProjCrits.Rows.Clear();   
          using(CriterionController critCon = new CriterionController())
          {
            foreach (ProjectCriterion projCrit in ProjCrits)
            {
              var singleCritId = critCon.GetCriterionById(projCrit.Criterion_Id);
              projCrit.Name = singleCritId.Name.ToString();
            }
          }

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
            dataGridView_ProjCrits.Columns.Add("Beschreibung", "Beschreibung");
            int i = 0;
            foreach (ProjectCriterion ProCri in ProjCrits)
            {
                
                dataGridView_ProjCrits["Beschreibung", i].Value = ProCri.Criterion.Description;
                i++;
            } 
            dataGridView_ProjCrits.Columns[0].HeaderText = "ID";
            dataGridView_ProjCrits.Columns[0].Width = 40;
            dataGridView_ProjCrits.Columns[1].HeaderText = "P-ID";
            dataGridView_ProjCrits.Columns[1].Width = 40;
            dataGridView_ProjCrits.Columns[2].Width = 200;
            dataGridView_ProjCrits.Columns[3].Width = 190;
            this.FormClosing += new FormClosingEventHandler(ProjCritAssign_View_FormClosing);
            }
            catch (Exception i)
            {
                MessageBox.Show("Ups da lief was schief");
            }
            }
        void ProjCritAssign_View_FormClosing(object sender, FormClosingEventArgs e)
        {
            aktuellesProjekt_View back = new aktuellesProjekt_View(ProjectId);
            back.Show();
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
            try{
            DataGridViewRow row = dataGridView_CritAvail.SelectedRows[0];
            int CritId = (int)row.Cells[0].Value;
            string CritName = (string)row.Cells[1].Value ;
            int index = dataGridView_CritAvail.CurrentCell.RowIndex;
                ProjCritParentAllocation_View projCritAllView = new ProjCritParentAllocation_View(
                    ProjCrits, 
                    ProjectId, 
                    CritId,
                    index,
                    this);
                projCritAllView.Show();
            }
            catch (Exception x)
            {
                MessageBox.Show("Ups da lief was schief");
            }
        }

        public void AllocateNewProjectCriterion(ProjectCriterion projCritToAllocate, int index)
        {            
            try{
            ProjCrits.Add(projCritToAllocate);
            projCritCont.ChangeAllocationOfProjectCriterionsInDb(ProjectId, ProjCrits);
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
            dataGridView_CritAvail.DataSource = null;
            dataGridView_CritAvail.DataSource = AllCrits;
 
            refreshGridL();
            }
            catch (Exception x)
            {
                MessageBox.Show("Ups da lief was schief");
            }
        }

        private void btn_ProjCritSave_Click(object sender, EventArgs e)
        {
            try{
            using (ProjectCriterionController projCritCon = new ProjectCriterionController()){
            projCritCon.ChangeAllocationOfProjectCriterionsInDb(ProjectId, ProjCrits);
            }
            this.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show("Ups da lief was schief");
            }
        }

        private void btn_CritToPool_Click(object sender, EventArgs e)
        {
            try{
            if ((int)dataGridView_ProjCrits.SelectedRows[0].Index >= 0)
            {
                DataGridViewRow row = dataGridView_ProjCrits.SelectedRows[0];
                int CritId = (int)row.Cells["Criterion_Id"].Value;
                int index = dataGridView_ProjCrits.CurrentCell.RowIndex;
                ProjCrits.RemoveAt(index);
                projCritCont.ChangeAllocationOfProjectCriterionsInDb(ProjectId, ProjCrits);
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
                refreshGridL();
                dataGridView_CritAvail.DataSource = null;
                dataGridView_CritAvail.DataSource = AllCrits;
            }
            else
            {
                MessageBox.Show("Bitte erst eine Zeile auswählen");
            }
            }
            catch (Exception x)
            {
                MessageBox.Show("Ups da lief was schief");
            }
        }
        private void dataGridView_ProjCrits_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void refreshGridL()
        {
            try{
            dataGridView_ProjCrits.DataSource = null;
            using (ProjectCriterionController proCriCon = new ProjectCriterionController())
            {
                ProjCrits = proCriCon.GetAllProjectCriterionsForOneProject(ProjectId);
            }

            using (CriterionController critCon = new CriterionController())
            {
                foreach (ProjectCriterion projCrit in ProjCrits)
                {
                    var singleCritId = critCon.GetCriterionById(projCrit.Criterion_Id);
                    projCrit.Name = singleCritId.Name.ToString();
                }
            }

            dataGridView_ProjCrits.DataSource = ProjCrits;
            dataGridView_ProjCrits.Columns.Remove("Project_Id");
            dataGridView_ProjCrits.Columns.Remove("Layer_Depth");
            dataGridView_ProjCrits.Columns.Remove("Weighting_Cardinal");
            dataGridView_ProjCrits.Columns.Remove("Weighting_Percentage_Layer");
            dataGridView_ProjCrits.Columns.Remove("Weighting_Percentage_Project");
            dataGridView_ProjCrits.Columns.Remove("Criterion");
            dataGridView_ProjCrits.Columns.Remove("ParentCriterion");
            dataGridView_ProjCrits.Columns.Remove("Project");
            int i = 0;
            foreach (ProjectCriterion ProCri in ProjCrits)
            {

                dataGridView_ProjCrits["Beschreibung", i].Value = ProCri.Criterion.Description;
                i++;
            }
            dataGridView_ProjCrits.Columns[0].DisplayIndex = 3;
            dataGridView_ProjCrits.Columns[1].HeaderText = "ID";
            dataGridView_ProjCrits.Columns[1].Width = 40;
            dataGridView_ProjCrits.Columns[2].HeaderText = "P-ID";
            dataGridView_ProjCrits.Columns[2].Width = 40;
            dataGridView_ProjCrits.Columns[3].Width = 200;
            }
            catch (Exception x)
            {
                MessageBox.Show("Ups da lief was schief");
            }
        }

        private void btn_ProjCritCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}