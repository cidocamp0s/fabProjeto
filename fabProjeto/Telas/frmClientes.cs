using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using fabProjeto.Code.BLL_métodos_;
using fabProjeto.Code.DTO_atributos_;
using fabProjeto.Code.DTO_propriedades_;
using fabProjeto.Context;
using MySql.Data.MySqlClient.Memcached;

namespace fabProjeto
{
    public partial class frmClientes : Form
    {
        private bool _eAdminstrador;

        public frmClientes(bool Administrador)
        {
            InitializeComponent();

            _eAdminstrador = Administrador;
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            if (txtId.Text == string.Empty)
            {
                btnRemover.Enabled = false;
                btnalterar.Enabled = false;

            }

            using (var db = new Contexto())
            {

                var user = db.Cliente.ToList();

                dgvClientes.DataSource = user;

                dgvClientes.Columns[0].HeaderText = "ID";

            }





        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {

            ClienteDTO clienteDTO = new ClienteDTO();
            ClienteBLL clienteBLL = new ClienteBLL();


            clienteDTO.Cidade = cboCidade.SelectedText;
            clienteDTO.Cnpj = txtCnpj.Text;
            clienteDTO.Contato = txtNomeContato.Text;
            clienteDTO.Email = txtEmail.Text;
            clienteDTO.Email2 = txtEmail2.Text;
            clienteDTO.Endereco = txtEnderco.Text;
            clienteDTO.Estado = cboEstado.SelectedText;
            clienteDTO.NomeFantasia = txtNomeFantasia.Text;
            clienteDTO.RazaoSocial = txtRazaoSocial.Text;
            clienteDTO.Telefone = mtxtTelefoneCliente.Text;
            clienteDTO.telContato = mtxtTelefoneContato.Text;
            clienteDTO.observacao = txtObservacao.Text;


            clienteBLL.AdicionarClienteBLL(clienteDTO);


        }

        private void btnProcurar_Click(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < Controls.Count; i++)
            {

                if (Controls[i] is TextBox || Controls[i] is ComboBox)
                {

                    (Controls[i] as TextBox).Clear();
                    (Controls[i] as ComboBox).SelectedIndex = -1;

                }
            }
        }
    }
}
