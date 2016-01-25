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
using NWAT.Printer;

namespace NWAT
{

    public partial class ProjCritProdFulfilment_View : Form
    {
        int PID = 0;
        private List<Fulfillment> _fulFill;

        public List<Fulfillment> FulFill
        {
            get { return _fulFill; }
            set { _fulFill = value; } 
        }

        private List<ProjectCriterion> _projCrits;

        public List<ProjectCriterion> ProjCrits
        {
            get { return _projCrits; }
            set { _projCrits = value; }
        }
        private Project _project;

        public Project Project
        {
            get { return _project; }
            set { _project = value; }
        }

        private ProjectController _projectCont;

        public ProjectController ProjectCont
        {
            get { return _projectCont; }
            set { _projectCont = value; }
        }


        int aktProd;

        private ProjectController _projectController;


        private ProjectCriterionController projCritCont;

        public ProjCritProdFulfilment_View(int projectId)
        {
            int ProjectID = projectId;
            PID = projectId;
            this.ProjectCont = new ProjectController();
            this.Project = this.ProjectCont.GetProjectById(projectId);
            InitializeComponent();
        }

        private void ProjCritProdFulfilment_Form_Load(object sender, EventArgs e)
        {

            using (ProjectProductController Projverw = new ProjectProductController())
            {
                ProjectProduct projprod = (ProjectProduct)comboBox_ProjCritProdFulf.SelectedItem;
                List<ProjectProduct> ProdList = Projverw.GetAllProjectProductsForOneProject(Project.Project_Id); //Project.Project_Id
                List<Product> productsList = new List<Product>();
                foreach (ProjectProduct projProd in ProdList)
                {
                    productsList.Add(projProd.Product); 
                }
                comboBox_ProjCritProdFulf.DataSource = productsList;
                
                comboBox_ProjCritProdFulf.DisplayMember = "Name";
                comboBox_ProjCritProdFulf.SelectedIndex = -1;
         //       comboBox_ProjCritProdFulf.ValueMember = "Product_ID";
            }
            using (ProjectCriterionController proCriCont = new ProjectCriterionController())
            {
                ProjCrits = proCriCont.GetSortedCriterionStructure(Project.Project_Id);
                using (CriterionController critCon = new CriterionController())
                {
                    foreach (ProjectCriterion projCrit in ProjCrits)
                    {
                        var singleCritId = critCon.GetCriterionById(projCrit.Criterion_Id);
                        projCrit.Name = singleCritId.Name.ToString();
                    }
                }

                //           dataGridView_ProjCritProdFulf.Rows.Clear();
                var CritBindingList = new BindingList<ProjectCriterion>(ProjCrits);
                var CritSource = new BindingSource(CritBindingList, null);
                dataGridView_ProjCritProdFulf.DataSource = ProjCrits;
                dataGridView_ProjCritProdFulf.Columns.Remove("Project_Id");
                //   dataGridView_ProjCritProdFulf.Columns.Remove("Criterion_Id");
                //   dataGridView_ProjCritProdFulf.Columns.Remove("Layer_Depth");
                //   dataGridView_ProjCritProdFulf.Columns.Remove("Parent_Criterion_Id");
                dataGridView_ProjCritProdFulf.Columns.Remove("Weighting_Cardinal");
                dataGridView_ProjCritProdFulf.Columns.Remove("Weighting_Percentage_Layer");
                dataGridView_ProjCritProdFulf.Columns.Remove("Weighting_Percentage_Project");
                dataGridView_ProjCritProdFulf.Columns.Remove("Criterion");
                dataGridView_ProjCritProdFulf.Columns.Remove("ParentCriterion");
                dataGridView_ProjCritProdFulf.Columns.Remove("Project");
                DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                dataGridView_ProjCritProdFulf.Columns.Add(chk);
                //   dataGridView_ProjCritProdFulf.Columns[0].CellType = Boolean;
                chk.Name = "Erfüllung";
                //   dataGridView_ProjCritProdFulf.Columns[0].CellType = Boolean;
                //  dataGridView_ProjCritProdFulf.Columns[1].ReadOnly = true;
                //dataGridView_ProjCritProdFulf.Columns[2].ReadOnly = true;
                //dataGridView_ProjCritProdFulf.Columns[3].ReadOnly = true;
                //dataGridView_ProjCritProdFulf.Columns[4].ReadOnly = true;
                //dataGridView_ProjCritProdFulf.Columns[5].ReadOnly = true;
                //dataGridView_ProjCritProdFulf.Columns[6].ReadOnly = true;
                //dataGridView_ProjCritProdFulf.Columns[7].ReadOnly = true;
                DataGridViewTextBoxColumn bem = new DataGridViewTextBoxColumn();
                bem.Name = "Bemerkung";
                dataGridView_ProjCritProdFulf.Columns.Add(bem);
                dataGridView_ProjCritProdFulf.Columns[4].DisplayIndex = 0;
                dataGridView_ProjCritProdFulf.Columns[3].DisplayIndex = 1;
                dataGridView_ProjCritProdFulf.Columns[5].DisplayIndex = 2;
                dataGridView_ProjCritProdFulf.Columns[1].DisplayIndex = 3;
                dataGridView_ProjCritProdFulf.Columns[0].DisplayIndex = 4;
                dataGridView_ProjCritProdFulf.Columns[2].DisplayIndex = 5;
                //dataGridView_ProjCritProdFulf.Columns[6].Width = 200;
                dataGridView_ProjCritProdFulf.Columns[0].HeaderText = "C-ID";
                dataGridView_ProjCritProdFulf.Columns[1].HeaderText = "Layer";
                dataGridView_ProjCritProdFulf.Columns[2].HeaderText = "P-ID";
                dataGridView_ProjCritProdFulf.Columns[3].HeaderText = "Name";
                //         dataGridView_ProjCritProdFulf.Columns[4].HeaderText = "Erfüllung";
                dataGridView_ProjCritProdFulf.Columns[4].Name = "Erfüllung";
                dataGridView_ProjCritProdFulf.Columns[0].Width = 50;
                dataGridView_ProjCritProdFulf.Columns[1].Width = 50;
                dataGridView_ProjCritProdFulf.Columns[2].Width = 50;
                dataGridView_ProjCritProdFulf.Columns[4].Width = 50;
                dataGridView_ProjCritProdFulf.Columns[3].Width = 150;
                dataGridView_ProjCritProdFulf.Columns[5].Width = 200;
                foreach (DataGridViewRow row in dataGridView_ProjCritProdFulf.Rows)
                {
                    row.Cells["Erfüllung"].Value = false;
                }

            }

            this.dataGridView_ProjCritProdFulf.CellValidating += new
         DataGridViewCellValidatingEventHandler(dataGridView_ProjCritProdFulf_CellValidating);

        }
        private void AddProjProdCritFulfilment()
        {
            Product selectedProd = (Product)comboBox_ProjCritProdFulf.SelectedItem;
            aktProd = selectedProd.Product_Id;

        }
        private void GetProjProdFromDB()
        {

        }
        private void GetProjCritsFromDB()
        {

        }

        private void btn_ProdFulfPrint_Click(object sender, EventArgs e)
        {
            Product selectedItem = (Product)comboBox_ProjCritProdFulf.SelectedItem;

            FulfillmentForEachProductPrinter PrintEachProduct = new FulfillmentForEachProductPrinter(Project.Project_Id, selectedItem.Product_Id);
            PrintEachProduct.CreateFulfillmentForEachProductPdf();
        }

        private void dataGridView_ProjCritProdFulf_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_ProjCritProdFulfSave_Click(object sender, EventArgs e)
        {
          //  DataGridViewCheckBoxCell oCell;
            using(FulfillmentController fulCont = new FulfillmentController()){
                foreach (DataGridViewRow row in dataGridView_ProjCritProdFulf.Rows)
                {
                    Fulfillment fulFi = new Fulfillment();
                    fulFi.Criterion_Id = (int)row.Cells[0].Value;
                    fulFi.Project_Id = Project.Project_Id;
         //           fulFi.Product_Id = aktProd;

                    int selectedIndex = comboBox_ProjCritProdFulf.SelectedIndex;
                    Product selectedValue = new Product();
                    selectedValue = (Product)comboBox_ProjCritProdFulf.SelectedItem;


                    fulFi.Product_Id = selectedValue.Product_Id;
                    fulFi.Comment = (string)row.Cells["Bemerkung"].Value;           
                    if ((bool)row.Cells["Erfüllung"].Value == true)
                    {
                        fulFi.Fulfilled = true;
    //                    MessageBox.Show("this cell is checked");
                    }
                    else if ((bool)row.Cells["Erfüllung"].Value == false)
                    {
                        fulFi.Fulfilled = false;
  //                      MessageBox.Show("this cell not is checked");
                    }
                  //  string Bem = (string)row.Cells["Bemerkung"].Value;  

                    fulCont.UpdateFulfillmentEntry(fulFi);
                }

            }
            
        }

        private void comboBox_ProjCritProdFulf_SelectedIndexChanged(object sender, EventArgs e)
        {
/*
            Product selectedValue = new Product();
            ComboBox cmb = (ComboBox)sender;
            int selectedIndex = cmb.SelectedIndex;
            if (cmb.SelectedValue != null)
            {
                selectedValue = (Product)cmb.SelectedValue;

                if (selectedValue != null)
                {
                    using (FulfillmentController fuFiCont = new FulfillmentController())
                    {

                        var projProdFulf = fuFiCont.GetAllFulfillmentsForSingleProduct(PID, selectedValue.Product_Id);

                    }
                }
            }

            using (ProjectCriterionController proCriCont = new ProjectCriterionController())
            {
                ProjCrits = proCriCont.GetSortedCriterionStructure(Project.Project_Id);
                using (CriterionController critCon = new CriterionController())
                {
                    foreach (ProjectCriterion projCrit in ProjCrits)
                    {
                        var singleCritId = critCon.GetCriterionById(projCrit.Criterion_Id);
                        projCrit.Name = singleCritId.Name.ToString();
                    }
                }

                //           dataGridView_ProjCritProdFulf.Rows.Clear();
                var CritBindingList = new BindingList<ProjectCriterion>(ProjCrits);
                var CritSource = new BindingSource(CritBindingList, null);
                dataGridView_ProjCritProdFulf.DataSource = ProjCrits;
                dataGridView_ProjCritProdFulf.Columns.Remove("Project_Id");
                //   dataGridView_ProjCritProdFulf.Columns.Remove("Criterion_Id");
                //   dataGridView_ProjCritProdFulf.Columns.Remove("Layer_Depth");
                //   dataGridView_ProjCritProdFulf.Columns.Remove("Parent_Criterion_Id");
                dataGridView_ProjCritProdFulf.Columns.Remove("Weighting_Cardinal");
                dataGridView_ProjCritProdFulf.Columns.Remove("Weighting_Percentage_Layer");
                dataGridView_ProjCritProdFulf.Columns.Remove("Weighting_Percentage_Project");
                dataGridView_ProjCritProdFulf.Columns.Remove("Criterion");
                dataGridView_ProjCritProdFulf.Columns.Remove("ParentCriterion");
                dataGridView_ProjCritProdFulf.Columns.Remove("Project");
                DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                dataGridView_ProjCritProdFulf.Columns.Add(chk);
                //   dataGridView_ProjCritProdFulf.Columns[0].CellType = Boolean;
                chk.Name = "Erfüllung";
                //   dataGridView_ProjCritProdFulf.Columns[0].CellType = Boolean;
                //  dataGridView_ProjCritProdFulf.Columns[1].ReadOnly = true;
                //dataGridView_ProjCritProdFulf.Columns[2].ReadOnly = true;
                //dataGridView_ProjCritProdFulf.Columns[3].ReadOnly = true;
                //dataGridView_ProjCritProdFulf.Columns[4].ReadOnly = true;
                //dataGridView_ProjCritProdFulf.Columns[5].ReadOnly = true;
                //dataGridView_ProjCritProdFulf.Columns[6].ReadOnly = true;
                //dataGridView_ProjCritProdFulf.Columns[7].ReadOnly = true;
                DataGridViewTextBoxColumn bem = new DataGridViewTextBoxColumn();
                bem.Name = "Bemerkung";
                dataGridView_ProjCritProdFulf.Columns.Add(bem);
                dataGridView_ProjCritProdFulf.Columns[4].DisplayIndex = 0;
                dataGridView_ProjCritProdFulf.Columns[3].DisplayIndex = 1;
                dataGridView_ProjCritProdFulf.Columns[5].DisplayIndex = 2;
                dataGridView_ProjCritProdFulf.Columns[1].DisplayIndex = 3;
                dataGridView_ProjCritProdFulf.Columns[0].DisplayIndex = 4;
                dataGridView_ProjCritProdFulf.Columns[2].DisplayIndex = 5;
                //dataGridView_ProjCritProdFulf.Columns[6].Width = 200;
                dataGridView_ProjCritProdFulf.Columns[0].HeaderText = "C-ID";
                dataGridView_ProjCritProdFulf.Columns[1].HeaderText = "Layer";
                dataGridView_ProjCritProdFulf.Columns[2].HeaderText = "P-ID";
                dataGridView_ProjCritProdFulf.Columns[3].HeaderText = "Name";
                //         dataGridView_ProjCritProdFulf.Columns[4].HeaderText = "Erfüllung";
                dataGridView_ProjCritProdFulf.Columns[4].Name = "Erfüllung";
                dataGridView_ProjCritProdFulf.Columns[0].Width = 50;
                dataGridView_ProjCritProdFulf.Columns[1].Width = 50;
                dataGridView_ProjCritProdFulf.Columns[2].Width = 50;
                dataGridView_ProjCritProdFulf.Columns[4].Width = 50;
                dataGridView_ProjCritProdFulf.Columns[3].Width = 150;
                dataGridView_ProjCritProdFulf.Columns[5].Width = 200;
                using (FulfillmentController FuFi = new FulfillmentController())
                {
 //                  FulFill = FuFi.GetAllFulfillmentsForSingleProduct(Project.Project_Id, selectedValue.Product_Id);
 //                   int i = 1;
 //                   bool aktErf = FulFill
                    
                    foreach (DataGridViewRow row in dataGridView_ProjCritProdFulf.Rows)
                    {
                        row.Cells["Erfüllung"].Value = false;
//                        row.Cells["Erfüllung"].Value = FulFill.Criterion_Id ;
//                        row.Cells["Bemerkung"].Value = FulFill[i].Comment;
//                        i++;
                    }
                }
            }


 //          updateGrid(); */
        }
        private void updateGrid()
        {
    /*        using (ProjectCriterionController proCriCont = new ProjectCriterionController())
            {
                ProjCrits = proCriCont.GetSortedCriterionStructure(Project.Project_Id);
                using (CriterionController critCon = new CriterionController())
                {
                    foreach (ProjectCriterion projCrit in ProjCrits)
                    {
                        var singleCritId = critCon.GetCriterionById(projCrit.Criterion_Id);
                        projCrit.Name = singleCritId.Name.ToString();
                    }
                }

                //              dataGridView_ProjCritProdFulf.Rows.Clear();
                var CritBindingList = new BindingList<ProjectCriterion>(ProjCrits);
                var CritSource = new BindingSource(CritBindingList, null);
                dataGridView_ProjCritProdFulf.DataSource = ProjCrits;
                dataGridView_ProjCritProdFulf.Columns.Remove("Project_Id");
                //   dataGridView_ProjCritProdFulf.Columns.Remove("Criterion_Id");
                //   dataGridView_ProjCritProdFulf.Columns.Remove("Layer_Depth");
                //   dataGridView_ProjCritProdFulf.Columns.Remove("Parent_Criterion_Id");
                dataGridView_ProjCritProdFulf.Columns.Remove("Weighting_Cardinal");
                dataGridView_ProjCritProdFulf.Columns.Remove("Weighting_Percentage_Layer");
                dataGridView_ProjCritProdFulf.Columns.Remove("Weighting_Percentage_Project");
                dataGridView_ProjCritProdFulf.Columns.Remove("Criterion");
                dataGridView_ProjCritProdFulf.Columns.Remove("ParentCriterion");
                dataGridView_ProjCritProdFulf.Columns.Remove("Project");
                DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                dataGridView_ProjCritProdFulf.Columns.Add(chk);
                //   dataGridView_ProjCritProdFulf.Columns[0].CellType = Boolean;
                chk.Name = "Erfüllung";
                //   dataGridView_ProjCritProdFulf.Columns[0].CellType = Boolean;
                //  dataGridView_ProjCritProdFulf.Columns[1].ReadOnly = true;
                //dataGridView_ProjCritProdFulf.Columns[2].ReadOnly = true;
                //dataGridView_ProjCritProdFulf.Columns[3].ReadOnly = true;
                //dataGridView_ProjCritProdFulf.Columns[4].ReadOnly = true;
                //dataGridView_ProjCritProdFulf.Columns[5].ReadOnly = true;
                //dataGridView_ProjCritProdFulf.Columns[6].ReadOnly = true;
                //dataGridView_ProjCritProdFulf.Columns[7].ReadOnly = true;
                DataGridViewTextBoxColumn bem = new DataGridViewTextBoxColumn();
                bem.Name = "Bemerkung";
                dataGridView_ProjCritProdFulf.Columns.Add(bem);
                dataGridView_ProjCritProdFulf.Columns[4].DisplayIndex = 0;
                dataGridView_ProjCritProdFulf.Columns[3].DisplayIndex = 1;
                dataGridView_ProjCritProdFulf.Columns[5].DisplayIndex = 2;
                dataGridView_ProjCritProdFulf.Columns[1].DisplayIndex = 3;
                dataGridView_ProjCritProdFulf.Columns[0].DisplayIndex = 4;
                dataGridView_ProjCritProdFulf.Columns[2].DisplayIndex = 5;
                //dataGridView_ProjCritProdFulf.Columns[6].Width = 200;
                dataGridView_ProjCritProdFulf.Columns[0].HeaderText = "C-ID";
                dataGridView_ProjCritProdFulf.Columns[1].HeaderText = "Layer";
                dataGridView_ProjCritProdFulf.Columns[2].HeaderText = "P-ID";
                dataGridView_ProjCritProdFulf.Columns[3].HeaderText = "Name";
                //         dataGridView_ProjCritProdFulf.Columns[4].HeaderText = "Erfüllung";
                dataGridView_ProjCritProdFulf.Columns[4].Name = "Erfüllung";
                dataGridView_ProjCritProdFulf.Columns[0].Width = 50;
                dataGridView_ProjCritProdFulf.Columns[1].Width = 50;
                dataGridView_ProjCritProdFulf.Columns[2].Width = 50;
                dataGridView_ProjCritProdFulf.Columns[4].Width = 50;
                dataGridView_ProjCritProdFulf.Columns[3].Width = 150;
                dataGridView_ProjCritProdFulf.Columns[5].Width = 200;
                foreach (DataGridViewRow row in dataGridView_ProjCritProdFulf.Rows)
                {
                    row.Cells["Erfüllung"].Value = false;
                }
            }*/
        }
        private void dataGridView_ProjCritProdFulf_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                dataGridView_ProjCritProdFulf.Rows[e.RowIndex].ErrorText = "";
     //           int newInteger;
     //           string myStr;

                // Don't try to validate the 'new row' until finished 
                // editing since there
                // is not any point in validating its initial value.
                //      if (dataGridView_ProjCritBalance.Rows[e.RowIndex].IsNewRow) { return; }
                if (e.FormattedValue.ToString().Contains("|")){
                    MessageBox.Show("Das Zeichen: " + "| ist nicht erlaubt. Bitte ändern Sie Ihre Eingabe." );
                }{
                    //e.Cancel = true;
                    //dataGridView_ProjCritProdFulf.Rows[e.RowIndex].ErrorText = "the value must be a non-negative integer";
                    ////       dataGridView_ProjCritBalance.Rows[e.RowIndex].Cells[3].Value = ProjCrits[e.RowIndex].Weighting_Cardinal ;
                    ////      dataGridView_ProjCritBalance.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 9;


                    //MessageBox.Show("Bitte nur Ganzzahlen eintragen");
                }
            }
            //       refreshGrid();
        }
  

    }
}
