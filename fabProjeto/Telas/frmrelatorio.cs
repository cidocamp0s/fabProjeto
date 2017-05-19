using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using static fabProjeto.FabricaDBDataSet;

namespace fabProjeto.Telas
{
    public partial class frmrelatorio : Form
    {
        public frmrelatorio()
        {
            InitializeComponent();
        }

        private void frmrelatorio_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'fabricaDBDataSet.Usuarios' table. You can move, or remove it, as needed.
            this.usuariosTableAdapter.Fill(this.fabricaDBDataSet.Usuarios);

            this.ReportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           ReportViewer1.Clear();

            // Indica o arquivo de relatório que será aberto
            ReportViewer1.LocalReport.ReportEmbeddedResource ="fabProjeto.Telas.Report2.rdlc";


            ReportViewer1.LocalReport.DataSources.Clear();

            // Especifica o ReportDataSource que será utilizad
            var reportDataSource = new ReportDataSource("DataSet1", usuariosBindingSource);

           
            
            // Limpa DataSource do ReportView para receber o novo ReporDataSource
            ReportViewer1.LocalReport.DataSources.Add(reportDataSource);
            

           

            this.ReportViewer1.RefreshReport();


      
        }









        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void ReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
