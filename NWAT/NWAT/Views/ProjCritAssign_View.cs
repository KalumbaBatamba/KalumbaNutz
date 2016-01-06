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
    public partial class ProjCritAssign_View : Form
    {
        private ProjectCriterionController projCritCont;
        public ProjCritAssign_View()
        {
            this.projCritCont = new ProjectCriterionController();
            InitializeComponent();
        }

        private void ProjCritAssign_Form_Load(object sender, EventArgs e)
        {

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
       
    }
}
