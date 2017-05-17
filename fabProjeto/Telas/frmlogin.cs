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
using fabProjeto.Code.DAL;
using fabProjeto.Code.DTO_atributos_;

namespace fabProjeto.Telas
{
    public partial class frmlogin : Form
    {
        public string NomeDeUsuario;
        public bool EAdministrador;


        public frmlogin()
        {
            
           
            InitializeComponent();


            
        }
       


        private void login_Load(object sender, EventArgs e)
        {
            AcessoBancoDados conn = new AcessoBancoDados();
            conn.CriarBanco();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            AcessoBancoDados conn = new AcessoBancoDados();

            if (conn.VerificarSeExistemRegistros())
            {

                if (MessageBox.Show("ADD user?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    btnLogar.Visible = false;
                }

                else

                {
                    textBox1.Clear();
                    textBox1.Clear();
                }


            }
            else
            {


                UsuarioBLL usuarioBll = new UsuarioBLL();
                usuarioDTO usuarioDto = new usuarioDTO();

                usuarioDto.nome = textBox1.Text;
                usuarioDto.Senha = textBox2.Text;

                EAdministrador = usuarioBll.VerificarUsuarioBll(usuarioDto).Item2;

                NomeDeUsuario = usuarioDto.nome;

                this.DialogResult = usuarioBll.VerificarUsuarioBll(usuarioDto).Item1;






            }




        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Deseja sair?", "Encerrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            usuarioDTO userDto = new usuarioDTO();
            UsuarioBLL userBll = new UsuarioBLL();

            userDto.nome = textBox1.Text;
            userDto.Senha = textBox2.Text;
            userDto.Administrador = true;
            userBll.AdicionarUsuarioBLL(userDto);

            btnLogar.Visible = true;

        }

    }
}
