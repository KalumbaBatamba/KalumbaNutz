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
    public partial class Kriterienverwaltung_View : Form
   

    {
        private CriterionController critCont;
        public Kriterienverwaltung_View()
        {
            this.critCont = new CriterionController();
            InitializeComponent();
        }

        private void Kriterienverwaltung_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_CritShow_Click(object sender, EventArgs e)
        {

        }

        private void btn_CritUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btn_CritDelete_Click(object sender, EventArgs e)
        {

        }

        private void btn_CritCreate_Click(object sender, EventArgs e)
        {

        }
        private void GetAllCritsFromDB()
        {

        }
        private void DeleteCritFromDB()
        {

        }
    }
}
