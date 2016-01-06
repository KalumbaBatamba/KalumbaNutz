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
        private ProjectCriterionController projCritCont;
        public ProjCritBalance_View()
        {
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
    }
}
