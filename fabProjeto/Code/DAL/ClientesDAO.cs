using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using fabProjeto.Code.BLL_métodos_;
using fabProjeto.Code.DTO_atributos_;
using fabProjeto.Code.DTO_propriedades_;
using fabProjeto.Context;

namespace fabProjeto.Code.DAL
{
    class ClientesDAO
    {
        public void InserirClienteDAO(ClienteDTO cliente)
        {
            using (var db = new Contexto())
            {
                db.Cliente.Add(cliente);
                db.SaveChanges();
            }

        }

        public bool UpdateClientDAO(ClienteDTO Cliente)
        {
            using (var db = new Contexto())
            {
                ClienteDTO clientUpdate = db.Cliente.FirstOrDefault(s => s.Id == Cliente.Id);

                clientUpdate.Cidade = Cliente.Cidade;
                clientUpdate.Cnpj = Cliente.Cnpj;
                clientUpdate.Contato = Cliente.Contato;
                clientUpdate.Estado = Cliente.Estado;
                clientUpdate.Endereco = Cliente.Endereco;
                clientUpdate.NomeFantasia = Cliente.NomeFantasia;
                clientUpdate.RazaoSocial = Cliente.RazaoSocial;
                clientUpdate.observacao = Cliente.observacao;
                clientUpdate.Telefone = Cliente.Telefone;
                clientUpdate.telContato = Cliente.telContato;

                db.SaveChanges();

                return true;

            }

        }

        public bool DeletarClienteDAO(ClienteDTO cliente)
        {
            using (var db = new Contexto())
            {
                var ClientToRemove = db.Cliente.FirstOrDefault(s => s.Id == cliente.Id);
                db.Cliente.Remove(ClientToRemove);
                return true;
            }

        }

        public void PesquisarClientesDAO(ClienteDTO cliente)
        {

            using (var db = new Contexto())
            {
           

                var pesquisaClientes = from c in db.Cliente.ToList() where c.NomeFantasia == cliente.NomeFantasia select c;

                MessageBox.Show(pesquisaClientes.ToList().ToString());
            }



        }

        public IQueryable TodosClientes()
        {

            using (var db = new Contexto())
            {

                var todosClientes = db.Cliente.Select(x => x.NomeFantasia);

                return todosClientes;
            }

        }
    }



}
