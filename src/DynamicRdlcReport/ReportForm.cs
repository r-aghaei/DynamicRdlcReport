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
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
            ReportColumns = new List<ReportColumn>();
        }

        public List<ReportColumn> ReportColumns { get; set; }
        public Object ReportData { get; set; }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            var report = new DynamicReport();
            report.Session = new Dictionary<string, object>();
            report.Session["Model"] = this.ReportColumns;
            report.Initialize();
            var rds = new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", this.ReportData);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            var reportContent = System.Text.Encoding.UTF8.GetBytes(report.TransformText());
            using (var stream = new System.IO.MemoryStream(reportContent))
            {
                this.reportViewer1.LocalReport.LoadReportDefinition(stream);
            }
            this.reportViewer1.RefreshReport();
        }
    }
}