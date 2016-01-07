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
namespace NWAT.Views
{
    public partial class ProjCritStrucShow_View : Form
    {
        private ProjectCriterionController projCritCont;
        public ProjCritStrucShow_View()
        {
            this.projCritCont = new ProjectCriterionController();
            InitializeComponent();
        }

        private void ProjCritStrucShow_View_Load(object sender, EventArgs e)
        {

        }

        private void btn_close_Click(object sender, EventArgs e)
        {

        }
    }
}
