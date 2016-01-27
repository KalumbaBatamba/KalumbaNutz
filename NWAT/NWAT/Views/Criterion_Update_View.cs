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
        public Criterion_Update_View(int criterionId)
        {
 
            using (CriterionController CritUpdView = new CriterionController())
            {
                this.Criterion = CritUpdView.GetCriterionById(criterionId);
            }
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the btn_CritUpdate control.
        /// speichert den neuen Namen und Beschreibung in der DB ab sofern keine unerlaubten Zeichen vorkommen
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        private void btn_CritUpdate_Click(object sender, EventArgs e)
        {
            try{
            using (CriterionController CritUpdClick = new CriterionController())
            {
                Criterion critUpd = CritUpdClick.GetCriterionById(Criterion.Criterion_Id);
                critUpd.Criterion_Id = this.Criterion.Criterion_Id; 
                critUpd.Name = textBox_CritNameUpdate.Text;
                critUpd.Description = textBox_CritDescUpdate.Text;
                CritUpdClick.UpdateCriterionInDb(critUpd);
            }
            this.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show("Ups da lief was schief");
            }
        }
        private void GetCritsSpecs()
        {

        }
        private void UpdateCritSpecs()
        {

        }

        /// <summary>
        /// Handles the Load event of the Criterion_Update_Form control.
        /// Läd beim Öffnen Name und Beschreibung des ausgewählten Kriteriums, dass diese bearbeitet werden können
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        private void Criterion_Update_Form_Load(object sender, EventArgs e)
        {
            try{
            textBox_CritNameUpdate.Text = this.Criterion.Name; 
            textBox_CritDescUpdate.Text = this.Criterion.Description;
            }
            catch (Exception x)
            {
                MessageBox.Show("Ups da lief was schief");
            }
        }
    }
}
