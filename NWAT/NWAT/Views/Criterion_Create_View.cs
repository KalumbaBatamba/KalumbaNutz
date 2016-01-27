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
            if (Name.Contains("|") || Desc.Contains("|"))
            { 
            MessageBox.Show("Das Zeichen: | ist nicht erlaubt. Bitte ändern Sie Ihre Eingabe");
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
    }
}

