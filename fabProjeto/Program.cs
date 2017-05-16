using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using fabProjeto.Code.BLL_métodos_;
using fabProjeto.Telas;

namespace fabProjeto
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            frmlogin login = new frmlogin();
            login.ShowDialog();
            
            
            

            if (login.DialogResult == DialogResult.OK)
            {
                frmMenu menu = new frmMenu(login.NomeDeUsuario, login.EAdministrador);
                Application.Run(menu);

            }
         

            



        }
    }
}
