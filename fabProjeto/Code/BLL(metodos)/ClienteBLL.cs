using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using fabProjeto.Code.DTO_propriedades_;
using fabProjeto.Context;

namespace fabProjeto.Code.BLL_métodos_
{
    class ClienteBLL
    {
        public void AdicionarClienteBLL(ClienteDTO cliente)
        {
            int camposVazios = 0;

            ClienteDTO clienteDTO = new ClienteDTO();

            clienteDTO.Id = cliente.Id;
            clienteDTO.Cidade = cliente.Cidade;
            clienteDTO.Cnpj = cliente.Cnpj;
            clienteDTO.Contato = cliente.Contato;
            clienteDTO.Endereco = cliente.Endereco;
            clienteDTO.Estado = cliente.Estado;
            clienteDTO.Email = cliente.Email;
            clienteDTO.Email2 = cliente.Email2;
            clienteDTO.NomeFantasia = cliente.NomeFantasia;
            clienteDTO.RazaoSocial = cliente.RazaoSocial;
            clienteDTO.telContato = cliente.telContato;
            clienteDTO.Telefone = cliente.Telefone;
            clienteDTO.observacao = cliente.observacao;


            PropertyInfo[] propiedades = clienteDTO.GetType().GetProperties();


            for (int i = 0; i < propiedades.Length; i++)
            {
                PropertyInfo property = propiedades[i];
                object propertyValue = property.GetValue(clienteDTO);


                if (string.IsNullOrEmpty(propertyValue as string))
                {
                    camposVazios++;
                }
            }

            if (camposVazios < 2)
            {

                using (var db = new Contexto())
                {
                    db.Cliente.Add(cliente);
                    db.SaveChanges();

                    MessageBox.Show("Cliente adicionado com sucesso", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

            }

            else
            {
                MessageBox.Show("Há campos vazios no formulário!", "Atenção", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }



        }


        public void ModificarUsuario(ClienteDTO cliente)
        {

            int campoVazios = 0;


           ClienteDTO clienteDTO= new ClienteDTO();

            clienteDTO.Id = cliente.Id;
            clienteDTO.Cidade = cliente.Cidade;
            clienteDTO.Cnpj = cliente.Cnpj;
            clienteDTO.Contato = cliente.Contato;
            clienteDTO.Endereco = cliente.Endereco;
            clienteDTO.Estado = cliente.Estado;
            clienteDTO.Email = cliente.Email;
            clienteDTO.Email2 = cliente.Email2;
            clienteDTO.NomeFantasia = cliente.NomeFantasia;
            clienteDTO.RazaoSocial = cliente.RazaoSocial;
            clienteDTO.telContato = cliente.telContato;
            clienteDTO.Telefone = cliente.Telefone;
            clienteDTO.observacao = cliente.observacao;



            PropertyInfo[] propriedades = clienteDTO.GetType().GetProperties();



        }

    }
}




