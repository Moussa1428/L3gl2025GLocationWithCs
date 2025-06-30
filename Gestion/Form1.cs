using Gestion.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gestion.Model;
using Gestion.View;

namespace Gestion
{
    public partial class frmConnexion : Form
    {
        public frmConnexion()
        {
            InitializeComponent();
        }
        BdAppartementContext db=new BdAppartementContext();
        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSeConnecter_Click(object sender, EventArgs e)
        {
            //Helper.WriteLogSystem("frmConnexion-btnSeConnecter_Click", "bienvenu");
            //GMailer.senMail("papisthioye@gmail.com", "test", "test envoie email");
            try
            {
                var leuser = db.Utilisateurs.Where(a => a.Identifiant.ToLower() == txtIdentifiant.Text.ToLower()).FirstOrDefault();
                if (leuser != null)
                {
                    string hash = leuser.MotDePasse;
                    using (MD5 md5Hash = MD5.Create())
                    {
                        if ((CryptApp.VerifyMd5Hash(md5Hash, txtMotDePasse.Text, hash))||(leuser.MotDePasse==null))
                        {
                            if(leuser.Statut==null) 
                            { 
                                frmResetPassword f=new frmResetPassword();
                                f.idUser = leuser.IdPersonne;
                                f.Show();
                                this.Hide();
                            }
                            else if(leuser.Statut=="Enabled")
                            {
                                frmMDI f = new frmMDI();
                                var le = db.admin.Find(leuser.IdPersonne);

                                if(le!=null)
                                {
                                    f.profil = "Admin";
                                }
                                else
                                {
                                   var leGes = db.Gestionnaires.Find(leuser.IdPersonne);
                                    if (le != null)
                                    {
                                        f.profil = "Gestionnaire";
                                    }
                                }

                                f.Show();
                                this.Hide();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Identifiant ou mot de passe incorrect");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Identifiant ou mot de passe incorrect");
                }
            }
            catch(Exception ex)
            {
                //todo: log
            }
           
            
            
        }
    }
}
