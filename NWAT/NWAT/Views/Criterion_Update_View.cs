using NWAT.DB;
using NWAT.HelperClasses;
using System;
using System.Windows.Forms;

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

        private Kriterienverwaltung_View parentView;

        public Criterion_Update_View(Kriterienverwaltung_View parentView, int criterionId)
        {
            this.parentView = parentView;
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
            try
            {
                using (CriterionController CritUpdClick = new CriterionController())
                {
                    Criterion critUpd = CritUpdClick.GetCriterionById(Criterion.Criterion_Id);
                    critUpd.Criterion_Id = this.Criterion.Criterion_Id;
                    if (CommonMethods.CheckIfForbiddenDelimiterInDb(textBox_CritNameUpdate.Text) ||
                        CommonMethods.CheckIfForbiddenDelimiterInDb(textBox_CritDescUpdate.Text))
                    {
                        MessageBox.Show(CommonMethods.MessageForbiddenDelimiterWasFoundInText());
                    }
                    else
                    {
                        critUpd.Name = textBox_CritNameUpdate.Text;
                        critUpd.Description = textBox_CritDescUpdate.Text;
                        CritUpdClick.UpdateCriterionInDb(critUpd);
                        this.Close();
                    }
                }
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

        /// <summary>
        /// Handles the FormClosing event of the Criterion_Update_View control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        private void Criterion_Update_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.parentView.RefreshList();
            this.parentView.Show();
        }
    }
}
