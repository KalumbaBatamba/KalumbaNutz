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
    public partial class Criterion_Update_View : Form
    {

        private CriterionController critCont;
        public Criterion_Update_View()
        {
            this.critCont = new CriterionController();
            InitializeComponent();
        }

        private void btn_CritUpdate_Click(object sender, EventArgs e)
        {
            Criterion critUpd = new Criterion();
            critUpd.Criterion_Id = aktRowCrit.CritID;
            critUpd.Name = textBox_CritNameUpdate.Text;
            critUpd.Description = textBox_CritDescUpdate.Text;
            critCont.UpdateCriterionInDb(critUpd);
            this.Close();
            
        }
        private void GetCritsSpecs()
        {

        }
        private void UpdateCritSpecs()
        {

        }

        private void Criterion_Update_Form_Load(object sender, EventArgs e)
        {
            textBox_CritNameUpdate.Text = aktRowCrit.CritName.ToString();
            textBox_CritDescUpdate.Text = aktRowCrit.CritDescription.ToString();
        }
    }
}
