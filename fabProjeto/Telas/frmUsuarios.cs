using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using fabProjeto.Code.DTO_atributos_;
using fabProjeto.Code.BLL_métodos_;
using fabProjeto.Code.DAL;
using fabProjeto.Context;



namespace fabProjeto.Telas
{
    public partial class frmUsuarios : Form
    {

        public frmUsuarios()
        {
            InitializeComponent();


        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {


            UsuarioBLL user = new UsuarioBLL();
            usuarioDTO usuarioDto = new usuarioDTO();
            usuarioDto.nome = txtUsuario.Text;
            usuarioDto.Senha = txtSenha.Text;
            usuarioDto.Administrador = chkAdm.Checked;
            user.AdicionarUsuario(usuarioDto);

            using (var db = new Contexto())
            {
                db.Set<usuarioDTO>().Add(usuarioDto);


            }
            frmUsuarios_Load(sender, e);


        }

        private void btnalterar_Click(object sender, EventArgs e)
        {
            UsuarioBLL user = new UsuarioBLL();
            user.ModificarUsuario(Convert.ToInt32(txtId.Text), txtUsuario.Text, chkAdm.Checked);

            frmUsuarios_Load(sender, e);




        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {


            if (txtId.Text == string.Empty)
            {
                btnRemover.Enabled = false;
                btnalterar.Enabled = false;
            }
            using (var db = new Contexto())
            {
                var user = db.Usuario.ToList();

                dataGridView1.DataSource = user;

                dataGridView1.Columns[0].HeaderText = "ID";

            }

            LimparControles();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtUsuario.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtSenha.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);


            UsuarioBLL user = new UsuarioBLL();
            usuarioDTO c = new usuarioDTO();
            c.IdUsuario = id;

            user.RemoverRegistro(c);


            frmUsuarios_Load(sender, e);

        }

        private void btnProximo_Click(object sender, EventArgs e)
        {

            if (dataGridView1.CurrentRow.Index < dataGridView1.RowCount - 1)
            {


                dataGridView1.CurrentCell = dataGridView1[0, dataGridView1.CurrentCell.RowIndex + 1];

                txtId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtUsuario.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txtSenha.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();



            }



        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index > 0)


                dataGridView1.CurrentCell = dataGridView1[0, dataGridView1.CurrentCell.RowIndex - 1];

            txtId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtUsuario.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtSenha.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();

        }


        private void btn_Primeiro_Click(object sender, EventArgs e)
        {
            UsuarioBLL user = new UsuarioBLL();

            dataGridView1.CurrentCell = dataGridView1[0, 0];

            txtId.Text = user.PrimeiroRegistro().IdUsuario.ToString();
            txtUsuario.Text = user.PrimeiroRegistro().nome;
            txtSenha.Text = user.PrimeiroRegistro().Senha;

        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            UsuarioBLL user = new UsuarioBLL();

            dataGridView1.CurrentCell = dataGridView1[0, dataGridView1.RowCount - 1];
            txtId.Text = user.UltimoRegistro().IdUsuario.ToString();
            txtUsuario.Text = user.UltimoRegistro().nome;
            txtSenha.Text = user.UltimoRegistro().Senha;
        }

        private void LimparControles()
        {
            txtUsuario.Text = string.Empty;
            txtId.Text = string.Empty;
            txtSenha.Text = String.Empty;
            chkAdm.Checked = false;
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparControles();
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {
            if (txtId.Text == String.Empty)
            {
                btnRemover.Enabled = false;
                btnalterar.Enabled = false;
                btnAdicionar.Enabled = true;
            }

            else
            {
                btnRemover.Enabled = true;
                btnalterar.Enabled = true;
                btnAdicionar.Enabled = false;
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
        }

        private void btnProcurar_Click(object sender, EventArgs e)
        {
            string txtPesquisa = txtPesquisar.Text;
            UsuarioBLL user = new UsuarioBLL();
            var t = user.procurarRegistroBLL(txtPesquisa);

            dataGridView1.DataSource = t;

        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            btnProcurar_Click(sender, e);
        }
    }
}


