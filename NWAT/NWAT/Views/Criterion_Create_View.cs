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
    public partial class Criterion_Create_View : Form
    {

        private CriterionController critCont;
        public Criterion_Create_View()
        {
         this.critCont = new CriterionController();
            InitializeComponent();
        }

        private void btn_CritCreate_Click(object sender, EventArgs e)
        {
            String Name = textBox_CritNameCreate.Text;
            String Desc = textBox_CritDescCreate.Text;

           // MessageBox.Show(Name + Desc);
            Criterion Crit = new Criterion { Name = Name, Description = Desc };
            this.critCont.InsertCriterionIntoDb(Crit);
          //  Criterion_Create_View CritCreate = new Criterion_Create_View();
            this.Close();
          
            
        }
        private void CreateNewCrit()
        {

        }

        private void Criterion_Create_Form_Load(object sender, EventArgs e)
        {

        }
    }
}
