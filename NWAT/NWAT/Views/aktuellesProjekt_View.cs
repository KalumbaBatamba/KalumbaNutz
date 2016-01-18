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
    public partial class aktuellesProjekt_View : Form
    {

        private ProjectController _projectController;
        public aktuellesProjekt_View()
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
        private void OpenCritAssign()
        {

        }
        private void OpenCritStructure()
        {

        }

        private void btn_CurrProjKritAssign_Click(object sender, EventArgs e)
        {
            ProjCritAssign_View ProjCritAssign = new ProjCritAssign_View();
            ProjCritAssign.Show();
        }

        private void btn_CurrProjCritStruShow_Click(object sender, EventArgs e)
        {
            ProjCritShow_View ProjCritShow = new ProjCritShow_View();
            ProjCritShow.Show();
        }

        private void btn_CurrProjCritStruUpdate_Click(object sender, EventArgs e)
        {
            ProjCritStruUpdate_View ProjCritStruUpdate = new ProjCritStruUpdate_View();
            ProjCritStruUpdate.Show();
        }

        private void btn_CurrProjCritStruPrint_Click(object sender, EventArgs e)
        {

        }

        private void btn_CurrProjCritStruBalance_Click(object sender, EventArgs e)
        {

        }

        private void btn_CurrProjCritStruEval_Click(object sender, EventArgs e)
        {

        }

        private void btn_CurrProjProdAssign_Click(object sender, EventArgs e)
        {
            ProjProdAssign_View ProjProdAssign = new ProjProdAssign_View();
            ProjProdAssign.Show();
        }

        private void btn_CurrProjProdFulfCapt_Click(object sender, EventArgs e)
        {
            ProjCritProdFulfilment_View ProjCritProdFulfillment = new ProjCritProdFulfilment_View();
            ProjCritProdFulfillment.Show();
        }

        private void btnCurrProjProdFulfPrint_Click(object sender, EventArgs e)
        {

        }

        private void btn_CurrProjProdAnalShow_Click(object sender, EventArgs e)
        {

        }

        private void btn_Balance_Click(object sender, EventArgs e)
        {
            ProjCritBalance_View ProjCritBalance = new ProjCritBalance_View();
            ProjCritBalance.Show();
        }
    }
}
