using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using fabProjeto.Code.DTO_propriedades_;

namespace fabProjeto.Code.BLL_métodos_
{
    class ClienteBLL
    {
        public void AdicionarClienteBLL(ClienteDTO cliente)
        {
            ClienteDTO clienteDTO = new ClienteDTO();

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


            PropertyInfo[] info = typeof(ClienteDTO).GetProperties();

            int haCamposVazios = 0;

            for (int i = 0; i < info.Length; i++)
            {
                if (string.IsNullOrEmpty(clienteDTO.GetType().ToString()))

                    haCamposVazios++;
            }

            MessageBox.Show(info.Length.ToString());

            if (haCamposVazios > 0)
            {
                MessageBox.Show("Há cammpos vazios no formulário!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
    }



}
