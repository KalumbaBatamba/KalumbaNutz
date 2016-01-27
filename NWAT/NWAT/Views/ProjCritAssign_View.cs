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
   //     private CriterionController CritContr;
        public ProjCritAssign_View(int projectId)
        {
            ProjectId = projectId;
            this.projCritCont = new ProjectCriterionController();
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the ProjCritAssign_Form control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 26.01.16
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
            dataGridView_CritAvail.Columns[0].HeaderText = "ID";
            dataGridView_CritAvail.Columns[0].Width = 30;
            dataGridView_CritAvail.Columns[1].Width = 200;
            dataGridView_CritAvail.Columns[2].Width = 240;
            dataGridView_CritAvail.Columns["Description"].HeaderText = "Beschreibung";
            dataGridView_ProjCrits.Rows.Clear();
      //      refreshGridL();
      
          using(CriterionController critCon = new CriterionController())
          {
            foreach (ProjectCriterion projCrit in ProjCrits)
            {
            //    MessageBox.Show(projCrit.Criterion_Id.ToString());
          //      projCrit.Name = "test";
               var singleCritId = critCon.GetCriterionById(projCrit.Criterion_Id);
               projCrit.Name = singleCritId.Name.ToString();
 //fi              projCrit.Description = singleCritId.Criterion_Id.ToString();
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
       
           
            //  dataGridView_ProjCrits.Columns.Add("Name","Name");
           // DataGridViewColumn col = new DataGridViewTextBoxColumn();
           // col.DataPropertyName = "Name";
           // col.HeaderText = "Name";
           // col.Name = "test";
           //// col.
           // dataGridView_ProjCrits.Columns.Add(col);
    //    }
            this.FormClosing += new FormClosingEventHandler(ProjCritAssign_View_FormClosing);
        }
        void ProjCritAssign_View_FormClosing(object sender, FormClosingEventArgs e)
        {
            //your code here
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
            DataGridViewRow row = dataGridView_CritAvail.SelectedRows[0];
            int CritId = (int)row.Cells[0].Value;
            string CritName = (string)row.Cells[1].Value ;
            int index = dataGridView_CritAvail.CurrentCell.RowIndex;
    //        dataGridView_CritAvail.Rows.RemoveAt(row.Index);
    //        AllCrits.RemoveAt(index);
            //if (ProjCrits.Count != 0)
            //{
                ProjCritParentAllocation_View projCritAllView = new ProjCritParentAllocation_View(
                    ProjCrits, 
                    ProjectId, 
                    CritId,
                    index,
                    this);
                projCritAllView.Show();
                
            //}
        }

        public void AllocateNewProjectCriterion(ProjectCriterion projCritToAllocate, int index)
        {
 //           AllCrits.RemoveAt(index);
            
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
      //      dataGridView_ProjCrits.Rows.Clear();

  /*          using (CriterionController critCon = new CriterionController())
            {
                foreach (ProjectCriterion projCrit in ProjCrits)
                {
                    //    MessageBox.Show(projCrit.Criterion_Id.ToString());
                    //      projCrit.Name = "test";
                    var singleCritId = critCon.GetCriterionById(projCrit.Criterion_Id);
                    projCrit.Name = singleCritId.Name.ToString();
                    //fi              projCrit.Description = singleCritId.Criterion_Id.ToString();
                }
            }
            */
            dataGridView_CritAvail.DataSource = null;
            dataGridView_CritAvail.DataSource = AllCrits;
  /* last          dataGridView_ProjCrits.DataSource = null;

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

            dataGridView_ProjCrits.DataSource = ProjCrits;
            dataGridView_ProjCrits.Columns.Remove("Project_Id");
            dataGridView_ProjCrits.Columns.Remove("Layer_Depth");
            dataGridView_ProjCrits.Columns.Remove("Weighting_Cardinal");
            dataGridView_ProjCrits.Columns.Remove("Weighting_Percentage_Layer");
            dataGridView_ProjCrits.Columns.Remove("Weighting_Percentage_Project");
            dataGridView_ProjCrits.Columns.Remove("Criterion");
            dataGridView_ProjCrits.Columns.Remove("ParentCriterion");
            dataGridView_ProjCrits.Columns.Remove("Project");
    //        dataGridView_ProjCrits.Columns.Add("C-Beschreibung", "C-Beschreibung");
            int i = 0;
            foreach (ProjectCriterion ProCri in ProjCrits)
            {

                dataGridView_ProjCrits["Beschreibung", i].Value = ProCri.Criterion.Description;
                i++;
            } 
            //dataGridView_ProjCrits.Columns[0].HeaderText = "Beschreibung";
            //dataGridView_ProjCrits.Columns[0].Width = 200;
            dataGridView_ProjCrits.Columns[0].DisplayIndex = 3;
            dataGridView_ProjCrits.Columns[1].HeaderText = "ID";
            dataGridView_ProjCrits.Columns[1].Width = 40;
            dataGridView_ProjCrits.Columns[2].HeaderText = "P-ID";
            dataGridView_ProjCrits.Columns[2].Width = 40;
            dataGridView_ProjCrits.Columns[3].Width = 200;
last */

            //DataGridViewColumn col = new DataGridViewTextBoxColumn();
            //col.DataPropertyName = "Name2";
            //col.HeaderText = "Name2";
            //col.Name = "test2";
            //col.Width = 200;
            // col.
          //  dataGridView_ProjCrits.Columns.Add(col);

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

            refreshGridL();

        }

        private void btn_ProjCritSave_Click(object sender, EventArgs e)
        {
            using (ProjectCriterionController projCritCon = new ProjectCriterionController()){
            projCritCon.ChangeAllocationOfProjectCriterionsInDb(ProjectId, ProjCrits);
            }
            this.Close();
        }

        private void btn_CritToPool_Click(object sender, EventArgs e)
        {
            if ((int)dataGridView_ProjCrits.SelectedRows[0].Index >= 0)
            {
               // MessageBox.Show("Bitte erst eine Zeile auswählen");
                DataGridViewRow row = dataGridView_ProjCrits.SelectedRows[0];
                int CritId = (int)row.Cells["Criterion_Id"].Value;
                //   string CritName = (string)row.Cells[1].Value ;
                int index = dataGridView_ProjCrits.CurrentCell.RowIndex;
                //        dataGridView_CritAvail.Rows.RemoveAt(row.Index);

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


                //using (ProjectCriterionController proCriCon = new ProjectCriterionController())
                //{
                //    ProjCrits = proCriCon.GetAllProjectCriterionsForOneProject(ProjectId);
                //}
                //using (ProjectCriterionController projCritCon = new ProjectCriterionController())
                //{
                //    projCritCon.ChangeAllocationOfProjectCriterionsInDb(ProjectId, ProjCrits);
                //}
                refreshGridL();







 //last               using (CriterionController critCont = new CriterionController())
 //last               {
                    //     foreach (ProjectCriterion projCrit in ProjCrits)
                    //     {
 //last                   Criterion addCrit = critCont.GetCriterionById(CritId);
                    //     }
         //           AllCrits.Add(addCrit);
                //last                }
                dataGridView_CritAvail.DataSource = null;
                dataGridView_CritAvail.DataSource = AllCrits;
                /*          
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
               */
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
            else
            {
                MessageBox.Show("Bitte erst eine Zeile auswählen");
            }
        }
        private void dataGridView_ProjCrits_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void refreshGridL()
        {
            dataGridView_ProjCrits.DataSource = null;
            using (ProjectCriterionController proCriCon = new ProjectCriterionController())
            {
                ProjCrits = proCriCon.GetAllProjectCriterionsForOneProject(ProjectId);
            }

            using (CriterionController critCon = new CriterionController())
            {
               // ProjCrits = proCriCon.GetAllProjectCriterionsForOneProject(ProjectId);
                foreach (ProjectCriterion projCrit in ProjCrits)
                {
                    //    MessageBox.Show(projCrit.Criterion_Id.ToString());
                    //      projCrit.Name = "test";
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
           // dataGridView_ProjCrits.Columns.Add("Beschreibung", "Beschreibung");
            //        dataGridView_ProjCrits.Columns.Add("C-Beschreibung", "C-Beschreibung");
            int i = 0;
            foreach (ProjectCriterion ProCri in ProjCrits)
            {

                dataGridView_ProjCrits["Beschreibung", i].Value = ProCri.Criterion.Description;
                i++;
            }
            //dataGridView_ProjCrits.Columns[0].HeaderText = "Beschreibung";
            //dataGridView_ProjCrits.Columns[0].Width = 200;
            dataGridView_ProjCrits.Columns[0].DisplayIndex = 3;
            dataGridView_ProjCrits.Columns[1].HeaderText = "ID";
            dataGridView_ProjCrits.Columns[1].Width = 40;
            dataGridView_ProjCrits.Columns[2].HeaderText = "P-ID";
            dataGridView_ProjCrits.Columns[2].Width = 40;
            dataGridView_ProjCrits.Columns[3].Width = 200;
        }

        private void btn_ProjCritCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
//DataGridViewRow row = dataGridView_Crits.SelectedRows[0];
//                int zelle1 = (int)row.Cells[0].Value;