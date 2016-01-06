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
