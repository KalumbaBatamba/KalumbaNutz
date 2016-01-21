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
    public partial class ProjCritBalance_View : Form
    {

        private List<Product> _allProds;

        public List<Product> AllProds
        {
            get { return _allProds; }
            set { _allProds = value; }
        }

        private List<ProjectProduct> _projProds;

        public List<ProjectProduct> ProjProds
        {
            get { return _projProds; }
            set { _projProds = value; }
        }
        private int _projectId;

        public int ProjectId
        {
            get { return _projectId; }
            set { _projectId = value; }
        }

     
        private ProjectCriterionController projCritCont;
     
        
        public ProjCritBalance_View(int projectID)
        {
            ProjectId = projectID;
         
            this.projCritCont = new ProjectCriterionController();
            InitializeComponent();
        }

        private void btn_SameBalance_Click(object sender, EventArgs e)
        {

        }

        private void btn_ProjCritBalaSave_Click(object sender, EventArgs e)
        {

        }

        private void btn_ProjCritBalaCancle_Click(object sender, EventArgs e)
        {

        }

        private void ProjCritBalance_View_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView_ProjCritBalance_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
