using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using fabProjeto.Code.DAL;

namespace fabProjeto.Telas
{
    public partial class reports : Form
    {
        public reports()
        {
            InitializeComponent();
        }

        private void reports_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.Usuarios' table. You can move, or remove it, as needed.
            this.usuariosTableAdapter.Fill(this.dataSet1.Usuarios);
            // TODO: This line of code loads data into the 'dataSet1.Usuarios' table. You can move, or remove it, as needed.
            this.usuariosTableAdapter.Fill(this.dataSet1.Usuarios);

            // TODO: This line of code loads data into the 'FabricaDBDataSet.Usuarios' table. You can move, or remove it, as needed.
          

            this.reportViewer1.RefreshReport();
        }
    }
}
