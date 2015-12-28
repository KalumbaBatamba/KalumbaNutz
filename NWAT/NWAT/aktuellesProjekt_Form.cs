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

namespace NWAT
{
    public partial class aktuellesProjekt_Form : Form
    {

        private ProjectController _projectController;
        public aktuellesProjekt_Form()
        {
            InitializeComponent();
            _projectController = new ProjectController();
        }

        private void aktuellesProjekt_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox_CurrProjProds_Enter(object sender, EventArgs e)
        {

        }
    }
}
