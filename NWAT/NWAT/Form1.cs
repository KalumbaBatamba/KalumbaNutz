using NWAT.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace NWAT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            ProjectCriterionController pro = new ProjectCriterionController();
            List<ProjectCriterion> child = pro.GetAllProjectCriterionsForOneProject(1);

            foreach (ProjectCriterion pc in child)
            {
                ProjectCriterion currentprojcrit = pc;
               float productpercentageweigthing = (float)pc.Weighting_Percentage_Layer.Value;
                while (pc.Parent_Criterion_Id != null || pc.Parent_Criterion_Id != 0)
                {
                    ProjectCriterion parent = pro.GetProjectCriterionByIds(1, pc.Parent_Criterion_Id.Value);
                    productpercentageweigthing *= (float)parent.Weighting_Percentage_Layer.Value;
                    currentprojcrit = parent;
                    //MessageBox.Show();
                    Console.WriteLine("je suis vraiment énervé");
                }
            }

        } 
   
            
            
           

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
