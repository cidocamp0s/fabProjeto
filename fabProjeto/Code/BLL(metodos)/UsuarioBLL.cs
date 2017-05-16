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

        public void AdicionarUsuario(usuarioDTO registro)
        {
            usuarioDTO userDto = new usuarioDTO();
            userDto.nome = registro.nome;
            userDto.Senha = registro.Senha;
            userDto.Administrador = registro.Administrador;
            if (userDto.nome != String.Empty || userDto.Senha != string.Empty)
            {
                UsuariosDAO d = new UsuariosDAO();
                d.InserirUsuarioDAO(userDto);


                MessageBox.Show("Usuário adicionado", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Usuário não adicionado", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }




        }

        public void ModificarUsuario(int id, string nome, bool administrador)
        {

            if (!string.IsNullOrEmpty(id.ToString()) || string.IsNullOrEmpty(nome))
            {
                usuarioDTO user = new usuarioDTO();
                user.IdUsuario = id;
                user.nome = nome;
                user.Administrador = administrador;


                UsuariosDAO d = new UsuariosDAO();
                d.UpdateUsuarioDAO(user);

            }
            else
            {
                MessageBox.Show("naomudou");
            }



        }

        public Tuple<DialogResult, bool> VerificarUsuarioBll(usuarioDTO registro)
        {

            usuarioDTO user = new usuarioDTO();
            user = registro;
            UsuariosDAO u = new UsuariosDAO();

            bool eAdministrador = u.ValidarRegistroDAO(user).Item2;

            if (u.ValidarRegistroDAO(user).Item1 == true)
            {
                return Tuple.Create(DialogResult.OK, eAdministrador);

            }

            else
            {
                MessageBox.Show("Usuário ou senha incorretos", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return Tuple.Create(DialogResult.None, false);
            }

        }

        public usuarioDTO PrimeiroRegistro()
        {

            UsuariosDAO ultimoUsuario = new UsuariosDAO();
            usuarioDTO t = ultimoUsuario.PrimeiroRegistroDAO();



            return t;



        }

        public usuarioDTO UltimoRegistro()
        {
            UsuariosDAO u = new UsuariosDAO();
            return u.UltimoUsuarioDAO();
        }

        public bool RemoverRegistro(usuarioDTO usuario)
        {
            UsuariosDAO user = new UsuariosDAO();
            return user.DeletarUsuarioDAO(usuario);
        }

        public List<usuarioDTO> procurarRegistroBLL()
        {

            UsuariosDAO userDAO = new UsuariosDAO();

            var t = userDAO.PesquisarUsuarioDAO();



            return t;







        }
    }



}

