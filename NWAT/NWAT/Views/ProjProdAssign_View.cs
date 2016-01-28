using NWAT.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
namespace NWAT
{
    /// <summary>
    /// Projekt-Produkt-Zuordnung
    /// </summary>
    /// Erstellt von Veit Berg, am 27.01.16
    public partial class ProjProdAssign_View : Form
    {
        private List<Product> _allProds;

        public List<Product> AllProds
        {
            get { return _allProds; }
            set { _allProds = value; }
        }

        private List<ProjectProduct> _projProds;

        public List<ProjectProduct> ProjProds
        {
            get { return _projProds; }
            set { _projProds = value; }
        }
        private int _projectId;

        public int ProjectId
        {
            get { return _projectId; }
            set { _projectId = value; }
        }

        private Form parentView;

        private ProjectProductController projProdCont;

        public ProjProdAssign_View(Form parentView, int projectID)
        {
            this.parentView = parentView;
            ProjectId = projectID;
            this.projProdCont = new ProjectProductController();
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the ProjProdAssign_Form control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        private void ProjProdAssign_Form_Load(object sender, EventArgs e)
        {
            try
            {
                using (ProjectProductController proProCont = new ProjectProductController())
                {
                    ProjProds = proProCont.GetAllProjectProductsForOneProject(ProjectId);
                    using (ProductController prodCon = new ProductController())
                    {
                        foreach (ProjectProduct projProd in ProjProds)
                        {
                            var singleProdId = prodCon.GetProductById(projProd.Product_Id);
                            projProd.Name = singleProdId.Name.ToString();
                        }
                    }

                }


                using (ProductController prodCont = new ProductController())
                {
                    AllProds = prodCont.GetAllProductsFromDb();

                    if (ProjProds.Count != 0)
                    {
                        foreach (ProjectProduct projProd in ProjProds)
                        {
                            Product allocatedProd = AllProds.Single(prod => prod.Product_Id == projProd.Product_Id);
                            AllProds.Remove(allocatedProd);
                        }
                    }
                }
                dataGridView_prodAvail.Rows.Clear();
                var ProdBindingList = new BindingList<Product>(AllProds);
                var prodSource = new BindingSource(ProdBindingList, null);
                dataGridView_prodAvail.DataSource = AllProds;
                dataGridView_prodAvail.Columns["Producer"].HeaderText = "Hersteller";
                dataGridView_prodAvail.Columns["Product_Id"].HeaderText = "Produkt ID";
                dataGridView_prodAvail.Columns["Price"].HeaderText = "Preis";

                dataGridView_ProjProd.Rows.Clear();

                var ProjProdBindingList = new BindingList<ProjectProduct>(ProjProds);
                var projProdSource = new BindingSource(ProjProdBindingList, null);
                dataGridView_ProjProd.DataSource = ProjProds;
                dataGridView_ProjProd.Columns.Remove("Project_Id");
                dataGridView_ProjProd.Columns.Remove("Product");
                dataGridView_ProjProd.Columns.Remove("Project");
                dataGridView_ProjProd.Columns["Product_Id"].HeaderText = "Produkt ID";
                dataGridView_ProjProd.Columns[1].Width = 200;
                this.FormClosing += new FormClosingEventHandler(ProjProdAssign_View_FormClosing);
            }
            catch (Exception i)
            {
                MessageBox.Show("Ups da lief was schief");
            }
        }
        /// <summary>
        /// Handles the FormClosing event of the ProjProdAssign_View control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs" /> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        void ProjProdAssign_View_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                this.parentView.Show();
            }catch (Exception i)
            {
                MessageBox.Show("Ups da lief was schief");
            }
        }

        private void AddProdToProject()
        {

        }
        private void DeleteProdFromProject()
        {

        }
        private void GetAllProdsFromDB()
        {

        }

        /// <summary>
        /// Handles the Click event of the btn_ProdToProj control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        private void btn_ProdToProj_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow row = dataGridView_prodAvail.SelectedRows[0];
                int ProdId = (int)row.Cells[0].Value;
                string ProdName = (string)row.Cells[1].Value;
                int index = dataGridView_prodAvail.CurrentCell.RowIndex;

                ProjectProduct projProdToAllocate = new ProjectProduct()
                {
                    Project_Id = ProjectId,
                    Product_Id = ProdId,
                };
                AllProds.RemoveAt(index);
                ProjProds.Add(projProdToAllocate);

                dataGridView_prodAvail.DataSource = null;
                dataGridView_prodAvail.DataSource = AllProds;
                dataGridView_ProjProd.DataSource = null;
                using (ProductController prodCon = new ProductController())
                {
                    foreach (ProjectProduct projProd in ProjProds)
                    {
                        var singleProdId = prodCon.GetProductById(projProd.Product_Id);
                        projProd.Name = singleProdId.Name.ToString();
                    }
                }


                dataGridView_ProjProd.DataSource = ProjProds;
                dataGridView_ProjProd.Columns.Remove("Project_Id");
                dataGridView_ProjProd.Columns.Remove("Product");
                dataGridView_ProjProd.Columns.Remove("Project");
                dataGridView_ProjProd.Columns[1].Width = 200;
                projProdCont.ChangeAllocationOfProjectProducstListInDb(ProjectId, ProjProds);
            }
            catch (Exception i)
            {
                MessageBox.Show("Ups da lief was schief");
            }
        }

        /// <summary>
        /// Handles the Click event of the btn_ProjProdSave control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        private void btn_ProjProdSave_Click(object sender, EventArgs e)
        {
            try
            {
                projProdCont.ChangeAllocationOfProjectProducstListInDb(ProjectId, ProjProds);
                this.parentView.Show();
                this.Close();
            }
            catch (Exception i)
            {
                MessageBox.Show("Ups da lief was schief");
            }
        }

        /// <summary>
        /// Handles the Click event of the btn_ProdToPool control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        private void btn_ProdToPool_Click(object sender, EventArgs e)
        {
            try{
            DataGridViewRow row = dataGridView_ProjProd.SelectedRows[0];
            int ProdId = (int)row.Cells[0].Value;
            int index = dataGridView_ProjProd.CurrentCell.RowIndex;
            ProjProds.RemoveAt(index);
            using (ProductController prodCont = new ProductController())
            {
                Product addProd = prodCont.GetProductById(ProdId);
                AllProds.Add(addProd);
                projProdCont.ChangeAllocationOfProjectProducstListInDb(ProjectId, ProjProds);
            }   
            dataGridView_prodAvail .DataSource = null;
            dataGridView_prodAvail.DataSource = AllProds;
            dataGridView_ProjProd.DataSource = null;
            dataGridView_ProjProd.DataSource = ProjProds;
            dataGridView_ProjProd.Columns.Remove("Project_Id");
            dataGridView_ProjProd.Columns.Remove("Product");
            dataGridView_ProjProd.Columns.Remove("Project");
            dataGridView_ProjProd.Columns[1].Width = 200;
            }
            catch (Exception i)
            {
                MessageBox.Show("Ups da lief was schief");
            }
        }

        /// <summary>
        /// Handles the Click event of the btn_ProjProdCancle control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        private void btn_ProjProdCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
    }
}
