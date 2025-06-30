using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gestion.Model;

namespace Gestion
{
    internal static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            CreateAdmin();
            Application.Run(new frmConnexion());
        }

        static void CreateAdmin()
        {
            BdAppartementContext db = new BdAppartementContext();
            var admin = db.admin.FirstOrDefault();
            if(admin==null)
            {
                admin = new Admin();
                admin.NomPrenom = "Administrateur";
                admin.Telephone = "7700000000";
                admin.Identifiant = "Admin";
                admin.Email = "admin@yopmail.com";
                db.admin.Add(admin);
                db.SaveChanges();

            }
        }
    }
}
