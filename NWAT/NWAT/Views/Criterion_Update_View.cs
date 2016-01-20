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

        private Criterion _criterion;

        public Criterion Criterion
        {
            get { return _criterion; }
            set { _criterion = value; }
        }

        //private CriterionController _criterionCont;

        //public CriterionController CriterionCont
        //{
        //    get { return _criterionCont; }
        //    set { _criterionCont = value; }
        //}



       // private CriterionController critCont;
        public Criterion_Update_View(int criterionId)
        {
 //         this.critCont = new CriterionController();
            using (CriterionController CritUpdView = new CriterionController())
            {
                this.Criterion = CritUpdView.GetCriterionById(criterionId);
            }
            
    //        this.CriterionCont = new CriterionController();
    //        this.Criterion = this.CriterionCont.GetCriterionById(criterionId);

            
            InitializeComponent();
        }

        private void btn_CritUpdate_Click(object sender, EventArgs e)
        {
            using (CriterionController CritUpdClick = new CriterionController())
            {
                Criterion critUpd = CritUpdClick.GetCriterionById(Criterion.Criterion_Id);
                critUpd.Criterion_Id = this.Criterion.Criterion_Id;   //aktRowCrit.CritID;
                critUpd.Name = textBox_CritNameUpdate.Text;
                critUpd.Description = textBox_CritDescUpdate.Text;
                CritUpdClick.UpdateCriterionInDb(critUpd);
            }
            
   //         Criterion critUpd = CriterionCont.GetCriterionById(Criterion.Criterion_Id); //new Criterion();
            //critUpd.Criterion_Id = this.Criterion.Criterion_Id;   //aktRowCrit.CritID;
            //critUpd.Name = textBox_CritNameUpdate.Text;
            //critUpd.Description = textBox_CritDescUpdate.Text;
            //CriterionCont.UpdateCriterionInDb(critUpd);
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
            textBox_CritNameUpdate.Text = this.Criterion.Name;  //aktRowCrit.CritName.ToString();
            textBox_CritDescUpdate.Text = this.Criterion.Description; //aktRowCrit.CritDescription.ToString();
        }
    }
}
