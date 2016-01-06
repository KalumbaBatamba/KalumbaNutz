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
    public partial class Project_Show_View : Form
    {
        
        private ProjectController projCont;
        public Project_Show_View()
        {
            this.projCont = new ProjectController();
            InitializeComponent();
        }

        private void Project_Show_Form_Load(object sender, EventArgs e)
        {

        }
        private void ShowProject()
        {

        }
    }
}
