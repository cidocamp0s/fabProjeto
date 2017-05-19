using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using fabProjeto.Code.DTO_propriedades_;

namespace fabProjeto.Code.BLL_métodos_
{
    class ClienteBLL
    {
        public void AdicionarClienteBLL( ClienteDTO cliente)
        {
            ClienteDTO clienteDTO= new ClienteDTO();

            clienteDTO.Cidade = cliente.Cidade;
            clienteDTO.Cnpj = cliente.Cnpj;
            clienteDTO.Contato = cliente.Contato;
            clienteDTO.Endereco = cliente.Endereco;
            clienteDTO.Estado = cliente.Estado;
            cliente.Id = cliente.Id;
            clienteDTO.NomeFantasia = cliente.NomeFantasia;
            clienteDTO.RazaoSocial = cliente.RazaoSocial;
            clienteDTO.telContato = cliente.telContato;
            clienteDTO.observacao = cliente.observacao;



        }


    }



}
