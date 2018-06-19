using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DynamicRdlcReport
{
    public partial class ProductListForm : Form
    {
        public ProductListForm()
        {
            InitializeComponent();
        }

        private void printToolStripButton_Click(object sender, EventArgs e)
        {
            var f = new ReportForm();
            f.ReportColumns = this.dataGridView1.Columns.Cast<DataGridViewColumn>()
                                  .Select(x => new ReportColumn(x.DataPropertyName)
                                  { Title = x.HeaderText, Width = x.Width }).ToList();
            f.ReportData = this.dataGridView1.DataSource;
            f.ShowDialog();
        }

        private void ProductListForm_Load(object sender, EventArgs e)
        {
            var list = new List<Product>() {
                new Product(){ Id= 1, Name = "product 1", Price = 100},
                new Product(){ Id= 2, Name = "product 2", Price = 200},
                new Product(){ Id= 3, Name = "product 3", Price = 300},
            };
            this.dataGridView1.DataSource = list;
        }
    }
}
