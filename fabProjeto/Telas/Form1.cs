using System;
using System.Windows.Forms;
using fabProjeto.Telas;
using fabProjeto.Code.DAL;


namespace fabProjeto
{
    public partial class frmMenu : Form
    {
        private  bool _eAdministrador;

        public frmMenu(string nomeUsuario, bool Administrador)
        {

            InitializeComponent();
            lblNomeUsuario.Text="Bem vindo, "+ nomeUsuario+"!";
            _eAdministrador = Administrador;

        } 

        private void frmMenu_Load(object sender, EventArgs e)
        {
            AcessoBancoDados conn = new AcessoBancoDados();
            conn.CriarBanco();
        }
     

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClientes c = new frmClientes(_eAdministrador);
            c.ShowDialog();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void chequesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCheques c = new frmCheques();
            c.ShowDialog();
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProdutos p = new frmProdutos();
            p.ShowDialog();
        }

        private void funcionáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Funcionários f = new Funcionários();
            f.ShowDialog();
        }

        private void fornecedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFornecedores f = new frmFornecedores();
            f.ShowDialog();
        }

      

        private void novoOrçamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOrcamento o = new frmOrcamento();
            o.ShowDialog();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            frmHIstoricoOrçamento h = new frmHIstoricoOrçamento();
            h.ShowDialog();
        }

        private void atestadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAtestado a = new frmAtestado();
            a.ShowDialog();

        }

        private void faltasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFaltas f = new frmFaltas();
            f.ShowDialog();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmVendas v = new frmVendas();
            v.ShowDialog();
        }

       

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            frmContasReceber r = new frmContasReceber();
            r.ShowDialog();
        }

        private void logOffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja sair?", "Log off", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                DialogResult.Yes)
            {
                Application.Restart();
            }
            
        }

        private void usuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuarios u = new frmUsuarios();
            u.ShowDialog();
        }

        private void conversorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConversor c = new FrmConversor();
            c.ShowDialog();
        }

       
    }
    }

