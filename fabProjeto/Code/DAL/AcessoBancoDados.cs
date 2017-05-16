using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using fabProjeto.Code.BLL_métodos_;
using fabProjeto.Context;
using fabProjeto.Code.DTO_atributos_;


namespace fabProjeto.Code.DAL
{
    class AcessoBancoDados
    {



        public void CriarBanco()
        {
            using (var db = new Contexto())
            {
                if (!db.Database.Exists())
                {
                  db.Database.CreateIfNotExists();

                }


            }

        }

        public bool VerificarSeExistemRegistros()
        {
            using (var db = new Contexto())
            {

                if (!db.Usuario.Any())
                {
                    return true;
                }

                else
                {
                     return false;
                }


               




            }
        }
    }

}

