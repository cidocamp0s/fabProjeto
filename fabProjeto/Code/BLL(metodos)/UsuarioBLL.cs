using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using fabProjeto.Code.DTO_atributos_;
using fabProjeto.Code.DAL;
using fabProjeto.Context;


namespace fabProjeto.Code.BLL_métodos_
{
    class UsuarioBLL
    {

        public void AdicionarUsuarioBLL(usuarioDTO registro)
        {
            usuarioDTO userDto = new usuarioDTO();

            userDto.nome = registro.nome;
            userDto.Senha = registro.Senha;
            userDto.Administrador = registro.Administrador;

            if (!string.IsNullOrEmpty(userDto.nome) || !string.IsNullOrEmpty(userDto.Senha))
            {
                UsuariosDAO d = new UsuariosDAO();
                d.InserirUsuarioDAO(userDto);


                MessageBox.Show("Usuário adicionado co sucesso", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Usuário não adicionado por falta de dados", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }




        }

        public void ModificarUsuarioBLL(int id, string nome, bool administrador)
        {

            if (!string.IsNullOrEmpty(id.ToString()) || string.IsNullOrEmpty(nome))
            {
                usuarioDTO user = new usuarioDTO();
                user.IdUsuario = id;
                user.nome = nome;
                user.Administrador = administrador;


                UsuariosDAO d = new UsuariosDAO();
                d.AtualizarUsuarioDAO(user);

                MessageBox.Show("\n Usuário atualizado com sucesso ", "Sucesso", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("\n Usuário não atualizado ", "erro", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }




        }

        public Tuple<DialogResult, bool> VerificarUsuarioBll(usuarioDTO registro)
        {

            usuarioDTO user = new usuarioDTO();
            user = registro;
            UsuariosDAO u = new UsuariosDAO();

            bool eAdministrador = u.VerificarUsuarioDAO(user).Item2;

            if (u.VerificarUsuarioDAO(user).Item1)
            {
                return Tuple.Create(DialogResult.OK, eAdministrador);

            }

            else
            {
                MessageBox.Show("Usuário ou senha incorretos", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return Tuple.Create(DialogResult.None, false);
            }

        }

        public usuarioDTO PrimeiroUsuarioBLL()
        {

            UsuariosDAO ultimoUsuario = new UsuariosDAO();
            usuarioDTO t = ultimoUsuario.PrimeiroUsuarioDAO();



            return t;



        }

        public usuarioDTO UltimoUsuarioBLL()
        {
            UsuariosDAO u = new UsuariosDAO();
            return u.UltimoUsuarioDAO();
        }

        public void RemoverUsuarioBLL(usuarioDTO usuario)
        {
            if (usuario.IdUsuario > 1)
            {
                UsuariosDAO user = new UsuariosDAO();
                user.DeletarUsuarioDAO(usuario);
                MessageBox.Show("\n Usuário deletado com sucesso ", "Sucesso", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            else
            {
                MessageBox.Show("\n Usuário não deletado ", "Erro", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

        }

        public List<usuarioDTO> procurarUsuarioBLL(string txtPesquisa)
        {

            UsuariosDAO userDAO = new UsuariosDAO();

            var t = userDAO.PesquisarUsuarioDAO(txtPesquisa);



            return t;







        }
    }



}

