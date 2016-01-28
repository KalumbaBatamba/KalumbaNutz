using NWAT.DB;
using System;
using System.Windows.Forms;
namespace NWAT
{
    public partial class ProjCritShow_View : Form
    {
        private ProjectCriterionController projCritCont;
        public ProjCritShow_View()
        {
            this.projCritCont = new ProjectCriterionController();
            InitializeComponent();
        }

        private void ProjCritShow_Form_Load(object sender, EventArgs e)
        {

        }
        private void ShowProjCritSturcture()
        {

        }
    }
}
