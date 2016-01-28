using NWAT.DB;
using NWAT.HelperClasses;
using System;
using System.Windows.Forms;

namespace NWAT
{
    public partial class Criterion_Create_View : Form
    {

        private CriterionController critCont;
        private Kriterienverwaltung_View parentView;
        public Criterion_Create_View(Kriterienverwaltung_View parentView)
        {
            this.parentView = parentView;
            this.critCont = new CriterionController();
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the btn_CritCreate control.
        /// Holt die Einträge aus den Textboxen, überprüft diese auf unerlaubte Sonderzeichen und speichert das neue Kriterium ab
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        private void btn_CritCreate_Click(object sender, EventArgs e)
        {
            try{
            String Name = textBox_CritNameCreate.Text;
            String Desc = textBox_CritDescCreate.Text;
            if(CommonMethods.CheckIfForbiddenDelimiterInDb(Name) ||
               CommonMethods.CheckIfForbiddenDelimiterInDb(Desc))
            {
                MessageBox.Show(CommonMethods.MessageForbiddenDelimiterWasFoundInText());
            }else{
            Criterion Crit = new Criterion { Name = Name, Description = Desc };
            this.critCont.InsertCriterionIntoDb(Crit);
            this.Close();
            }
            }
            catch (Exception x)
            {
                MessageBox.Show("Name oder Beschreibung bereits vorhanden");
            }
        }
        private void CreateNewCrit()
        {

        }
     
        private void Criterion_Create_Form_Load(object sender, EventArgs e)
        {
        }
        /// <summary>
        /// Handles the FormClosing event of the Criterion_Create_View control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        private void Criterion_Create_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.parentView.RefreshList();
            this.parentView.Show();
        }
    }
}

