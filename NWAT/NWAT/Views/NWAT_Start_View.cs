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
        private void NWA_Start_Form_Load(object sender, EventArgs e)
        {
           
        }

        /// <summary>
        /// Handles the Click event of the btn_ProjAdm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        private void btn_ProjAdm_Click(object sender, EventArgs e)
        {
            Projektverwaltung_View ProjectAdmin = new Projektverwaltung_View();
            ProjectAdmin.Show();
            Hide();
        }

        /// <summary>
        /// Handles the Click event of the btn_ProdAdm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        private void btn_ProdAdm_Click(object sender, EventArgs e)
        {
            Produktverwaltung_View ProductAdmin = new Produktverwaltung_View();
            ProductAdmin.Show();
        }

        /// <summary>
        /// Handles the Click event of the btn_CritAdm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        private void btn_CritAdm_Click(object sender, EventArgs e)
        {
            Kriterienverwaltung_View CriterionAdmin = new Kriterienverwaltung_View();
            CriterionAdmin.Show();
            Hide();
        }
    }
}
