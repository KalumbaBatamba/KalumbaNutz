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
    public partial class ProjProdAssign_View : Form
    {
        private ProjectProductController projProdCont;
        public ProjProdAssign_View()
        {
            this.projProdCont = new ProjectProductController();
            InitializeComponent();
        }

        private void ProjProdAssign_Form_Load(object sender, EventArgs e)
        {

        }
        private void AddProdToProject()
        {

        }
        private void DeleteProdFromProject()
        {

        }
        private void GetAllProdsFromDB()
        {

        }
       
    }
}
