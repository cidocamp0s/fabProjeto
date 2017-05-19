using System;
using System.Collections.Generic;
using System.Linq;
using fabProjeto.Context;
using fabProjeto.Code.DTO_atributos_;

namespace fabProjeto.Code.DAL
{
    class UsuariosDAO
    {
        public void InserirUsuarioDAO(usuarioDTO registro)
        {
            for (int i = 0; i < 200; i++)
            {


                using (var db = new Contexto())
                {
                    db.Usuario.Add(registro);
                    db.SaveChanges();


                }

            }


        }

        public void AtualizarUsuarioDAO(usuarioDTO registro)
        {
            using (var db = new Contexto())
            {
                usuarioDTO userUpdate = db.Usuario.FirstOrDefault(s => s.IdUsuario == registro.IdUsuario);


                userUpdate.nome = registro.nome;
                userUpdate.Administrador = registro.Administrador;
                db.SaveChanges();

            }
        }

        public void DeletarUsuarioDAO(usuarioDTO registro)
        {
            using (var db = new Contexto())
            {
                var userToRemove = db.Usuario.FirstOrDefault(x => x.IdUsuario == registro.IdUsuario);
                db.Usuario.Remove(userToRemove);
                db.SaveChanges();
               
            }


        }

        public usuarioDTO PrimeiroUsuarioDAO()
        {
            using (var db = new Contexto())
            {
                var resultado = db.Usuario.OrderByDescending(x => x.IdUsuario).ToArray().Last();

                return resultado;
            }
        }

        public usuarioDTO UltimoUsuarioDAO()
        {

            using (var db = new Contexto())
            {
                return db.Usuario.OrderByDescending(x => x.IdUsuario).ToArray().First();

            }
        }

        public Tuple<bool, bool> VerificarUsuarioDAO(usuarioDTO registro)
        {

            using (var db = new Contexto())
            {
                return Tuple.Create<bool, bool>(db.Usuario.Any(x => x.Senha == registro.Senha && x.nome == registro.nome), db.Usuario.Any(x => x.Senha == registro.Senha && x.nome == registro.nome && x.Administrador == true));
            }

        }

        public List<usuarioDTO> PesquisarUsuarioDAO(string txtPesquisa)
        {
            int pesquisaPorID;
           int.TryParse(txtPesquisa, out  pesquisaPorID);

            string pesquisaPorNome = txtPesquisa;

            
            using (var db = new Contexto())
            {
               IQueryable<usuarioDTO> consultaUsuario = db.Usuario.AsQueryable();
                consultaUsuario = consultaUsuario.Where(x => x.nome.StartsWith(pesquisaPorNome) || x.IdUsuario == pesquisaPorID).AsQueryable();


                return consultaUsuario.ToList();

            }



        }



    }


}


