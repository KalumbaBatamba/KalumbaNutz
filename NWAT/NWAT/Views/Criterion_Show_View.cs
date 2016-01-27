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
        private Criterion _criterion;

        public Criterion Criterion
        {
            get { return _criterion; }
            set { _criterion = value; }
        }

        private CriterionController _criterionCont;

        public CriterionController CriterionCont
        {
            get { return _criterionCont; }
            set { _criterionCont = value; }
        }

        public Criterion_Show_View(int criterionId)
        {
            this.CriterionCont = new CriterionController();
            this.Criterion = this.CriterionCont.GetCriterionById(criterionId);
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the Criterion_Show_Form control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        private void Criterion_Show_Form_Load(object sender, EventArgs e)
        {
            try{
            label_CritShowName.Text = this.Criterion.Name; 
            label_CritShowDesc.Text = this.Criterion.Description;
            }
            catch (Exception x)
            {
                MessageBox.Show("Ups da lief was schief");
            }
        }
        private void GetCritSpecs()
        {
           
        }

        private void label_CritShowName_Click(object sender, EventArgs e)
        {

        }

        private void btn_CritShowClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
