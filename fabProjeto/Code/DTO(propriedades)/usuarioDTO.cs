using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace fabProjeto.Code.DTO_atributos_
{
    [Table("Usuarios")]
    public class usuarioDTO

    {
        [Key]
        public int IdUsuario { get; set; }
     
        public string nome { get; set; }

        public string Senha { get; set; }

        public bool Administrador { get; set; }



    }
}
