using NWAT.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NWAT.Views
{
    public partial class ProjCritParentAllocation_View : Form
    {
        private List<ProjectCriterion> _allAllocProjCrits;

        public List<ProjectCriterion> AllAllocProjCrits
        {
            get { return _allAllocProjCrits; }
            set { _allAllocProjCrits = value; }
        }

        private int _criterionIdToAllocate;

        public int CriterionIdToAllocate
        {
            get { return _criterionIdToAllocate; }
            set { _criterionIdToAllocate = value; }
        }

        private int _criterionIdDeleteFromList;

        public int CriterionIdDeleteFromList
        {
            get { return _criterionIdDeleteFromList; }
            set { _criterionIdDeleteFromList = value; }
        }
        

        private int _projectId;

        public int ProjectId
        {
            get { return _projectId; }
            set { _projectId = value; }
        }

        private ProjCritAssign_View _parentView;

        public ProjCritAssign_View ParentView
        {
            get { return _parentView; }
            set { _parentView = value; }
        }
        
        

        public ProjCritParentAllocation_View(
            List<ProjectCriterion> allAllocatedProjCrits, 
            int projectId, 
            int criterionIdToAllocate,
            int index,
            ProjCritAssign_View parentView)
        {
            ParentView = parentView;
            ProjectId = projectId;
            AllAllocProjCrits = allAllocatedProjCrits;
            CriterionIdToAllocate = criterionIdToAllocate;
            CriterionIdDeleteFromList = index;
            InitializeComponent();
        }

        private void ProjCritParentAllocation_Load(object sender, EventArgs e)
        {
            List<Criterion> allocCrits = new List<Criterion>();

            using (CriterionController critCont = new CriterionController())
            {


                foreach (ProjectCriterion projCrit in AllAllocProjCrits)
                {


                    Criterion addCrit = critCont.GetCriterionById(projCrit.Criterion_Id);

                    allocCrits.Add(addCrit);
                }
            }
            comboBox_CritName.DataSource = allocCrits;
            comboBox_CritName.DisplayMember = "Name";
        }

        private void btn_zuordnen_Click(object sender, EventArgs e)
        {
            
            Criterion selectedParentCiterion = (Criterion)comboBox_CritName.SelectedItem;
                ProjectCriterion projCritToAllocate = new ProjectCriterion()
                {
                    Project_Id = ProjectId,
                    Criterion_Id = CriterionIdToAllocate,
                    Parent_Criterion_Id = selectedParentCiterion.Criterion_Id
                };
                ParentView.AllocateNewProjectCriterion(projCritToAllocate, CriterionIdDeleteFromList);
                this.Close();
        }

        private void btn_cancle_Click(object sender, EventArgs e)
        {
            ProjectCriterion projCritToAllocate = new ProjectCriterion()
            {
                Project_Id = ProjectId,
                Criterion_Id = CriterionIdToAllocate
            };
            ParentView.AllocateNewProjectCriterion(projCritToAllocate, CriterionIdDeleteFromList);
            this.Close();
        }
    }
}
