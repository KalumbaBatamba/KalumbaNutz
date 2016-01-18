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
    public partial class Criterion_Show_View : Form
    {
        private CriterionController critCont;

        public Criterion_Show_View()
        {
         this.critCont = new CriterionController();

            InitializeComponent();
        }

        private void Criterion_Show_Form_Load(object sender, EventArgs e)
        {
            label_CritShowName.Text = aktRowCrit.CritName.ToString();
            label_CritShowDesc.Text = aktRowCrit.CritDescription.ToString();
        }
        private void GetCritSpecs()
        {
           
        }

        private void label_CritShowName_Click(object sender, EventArgs e)
        {

        }
    }
}
