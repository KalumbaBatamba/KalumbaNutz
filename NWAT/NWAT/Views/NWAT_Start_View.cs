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
    public partial class NWAT_Start_View : Form
    {
        public NWAT_Start_View()
        {
            InitializeComponent();
        }

    /*    private void button1_Click(object sender, EventArgs e)
        {
            Kriterienverwaltung_View CriterionAdmin = new Kriterienverwaltung_View();
            CriterionAdmin.Show();
        }
*/
        private void NWA_Start_Form_Load(object sender, EventArgs e)
        {
           
        }

        private void btn_ProjAdm_Click(object sender, EventArgs e)
        {
            Projektverwaltung_View ProjectAdmin = new Projektverwaltung_View();
            ProjectAdmin.Show();
        }

   //     private void btn_CritAdm_Click(object sender, EventArgs e)
   //    {
   //         Kriterienverwaltung_View CriterionAdmin = new Kriterienverwaltung_View();
   //         CriterionAdmin.Show();
   //     }

        private void btn_ProdAdm_Click(object sender, EventArgs e)
        {
            Produktverwaltung_View ProductAdmin = new Produktverwaltung_View();
            ProductAdmin.Show();
        }

        private void btn_CritAdm_Click(object sender, EventArgs e)
        {
            Kriterienverwaltung_View CriterionAdmin = new Kriterienverwaltung_View();
            CriterionAdmin.Show();
        }
    }
}
