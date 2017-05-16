using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fabProjeto.Code.DTO_propriedades_
{

    [Table("Clientes")]
    public class ClienteDTO
    {

        [Key]
        public int Id { get; set; }

        //[Column("Razão social")]
        public string RazaoSocial { get; set; }

        //[Column("Nome fantasia")]
        public  string NomeFantasia { get; set; }

        //[Column("CNPJ")] 
        public  string Cnpj { get; set; }

        //[Column("Endereço")]

        public  string Endereco { get; set; }
        
        //[Column("Telefone")]
        public  string Telefone { get; set; }

        //[Column("Cidade")]

        public string Cidade { get; set; }

        //[Column("UF")]

        public string Estado { get; set; }

        //[Column("Nome do contato")]

        public string Contato { get; set; }

        //[Column("Tel contato")]

        public string telContato { get; set; }

        //[Column("Observações")]

        public string observacao { get; set; }
    }
}
