using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Gestion.APIPHP;
using Gestion.Model;
using Gestion.Utils;

namespace Gestion.View
{
    public partial class frmUtilisateur : Form
    {
        public frmUtilisateur()
        {
            InitializeComponent();
        }
        ServiceApiPhp serviceApiPhp = new ServiceApiPhp();
        MetierGestion.Service1Client metierGestionService1 = new MetierGestion.Service1Client();
        BdAppartementContext db = new BdAppartementContext();
        //public FormUrlEncodedContent Content { get; private set; }
        private void ResetForm()
        {
            txtEmail.Text = string.Empty;
            txtIdentifiant.Text = string.Empty;
            txtNomPrenom.Text = string.Empty;
            txtTel.Text = string.Empty;
            dgUtilisateur.DataSource = metierGestionService1.
                GetListUtilisateurs(string.Empty, string.Empty, string.Empty, string.Empty).
                Select(a => new {
                    a.IdPersonne,
                    Matricule = $"MAT-{a.IdPersonne.ToString().PadLeft(5, '0')}",
                    NomComplet = a.NomPrenom,
                    Username = a.Identifiant,
                    Email = a.Email,
                    Contact = a.Telephone
                })
                .ToList();
            if (dgUtilisateur.Columns.Contains("IdPersonne"))
            {
                dgUtilisateur.Columns["IdPersonne"].Visible = false;
            }
            txtNomPrenom.Focus();
            btnModifier.Enabled = false;
            btnSupprimer.Enabled = false;
            btnAjouter.Enabled = true;
            PersonnaliserHeaderDgUtilisateur();
        }
        #region api
        public List<Utilisateur> serviceApiGetUtilisateur()
        {
            HttpClient client;
            client = new HttpClient();
            var services = new List<Utilisateur>();
#pragma warning disable CS0618 // Le type ou le membre est obsolète
            client.BaseAddress = new Uri(System.Configuration.ConfigurationSettings.AppSettings["ServeruApiURL"]);
#pragma warning restore CS0618 // Le type ou le membre est obsolète
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var responseTask = client.GetAsync("api/Utilisateur/GetAllUtilisateurs").Result;
            if (responseTask.IsSuccessStatusCode)
            {
                var readTask = responseTask.Content.ReadAsStringAsync();
                services = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Utilisateur>>(readTask.Result);
            }
            else
            {
                MessageBox.Show("Erreur de connexion au serveur API");
            }
            return services;
        }
        public bool AjouterParApiUtilisateur(Utilisateur utilisateur)
        {
            bool rep = false;
            string Id = utilisateur.IdPersonne > 0 ? utilisateur.IdPersonne.ToString() : "0";
            var values = new Dictionary<string, string>
            {
                {"IdPersonne", Id },
                {"NomPrenom",utilisateur.NomPrenom },
                {"Telephone",utilisateur.Telephone },
                {"Email",utilisateur.Email },
                {"Identifiant",utilisateur.Identifiant },
                {"MotDePasse",utilisateur.MotDePasse },
                { "Statut", utilisateur.Statut }
            };
            var content = new FormUrlEncodedContent(values);
            try
            {
                using (var client = new HttpClient())
                {
#pragma warning disable CS0618 // Le type ou le membre est obsolète
                    client.BaseAddress = new Uri(System.Configuration.ConfigurationSettings.AppSettings["ServeruApiURL"]);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
#pragma warning restore CS0618 // Le type ou le membre est obsolète
                    var response = client.PostAsync("api/Utilisateur/AjouterUtilisateur", content).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        rep = true;
                    }
                    else
                    {
                        MessageBox.Show("Erreur lors de l'ajout de l'utilisateur via API");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur: " + ex.Message);
            }
            return rep;
        }
        public bool ModifierParApiUtilisateur(Utilisateur utilisateur)
        {
            bool rep = false;

            var values = new Dictionary<string, string>
                    {
                        { "IdPersonne", utilisateur.IdPersonne.ToString() },
                        { "NomPrenom", utilisateur.NomPrenom },
                        { "Telephone", utilisateur.Telephone },
                        { "Email", utilisateur.Email },
                        { "Identifiant", utilisateur.Identifiant },
                        { "MotDePasse", utilisateur.MotDePasse },
                        { "Statut", utilisateur.Statut }
                    };
            var content = new FormUrlEncodedContent(values);
            try
            {
                using (var client = new HttpClient())
                {
#pragma warning disable CS0618 // Le type ou le membre est obsolète
                    client.BaseAddress = new Uri(System.Configuration.ConfigurationSettings.AppSettings["ServeruApiURL"]);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
#pragma warning restore CS0618 // Le type ou le membre est obsolète
                    var response = client.PutAsync("api/Utilisateur/ModifierUtilisateur", content).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        rep = true;
                    }
                    else
                    {
                        MessageBox.Show("Erreur lors de la modification de l'utilisateur via API");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur: " + ex.Message);
            }
            return rep;
        }
        public bool SupprimerParApiUtilisateur(int id)
        {
            bool rep = false;
            try
            {
                using (var client = new HttpClient())
                {
#pragma warning disable CS0618 // Le type ou le membre est obsolète
                    client.BaseAddress = new Uri(System.Configuration.ConfigurationSettings.AppSettings["ServeruApiURL"]);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
#pragma warning restore CS0618 // Le type ou le membre est obsolète
                    var response = client.DeleteAsync($"api/Utilisateur/SupprimerUtilisateur/{id}").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        rep = true;
                    }
                    else
                    {
                        MessageBox.Show("Erreur lors de la suppression de l'utilisateur via API");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur: " + ex.Message);
            }
            return rep;
        }
        #endregion api

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                
                if (string.IsNullOrWhiteSpace(txtNomPrenom.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtIdentifiant.Text) || string.IsNullOrWhiteSpace(txtTel.Text))
                {
                    MessageBox.Show("Veuillez remplir tous les champs obligatoires");
                    return;
                }
                //ajouter un utilisateur par l'api php
                UtilisateurApi utilisateurApi = new UtilisateurApi();
                utilisateurApi.NomPrenom = txtNomPrenom.Text;
                utilisateurApi.Email = txtEmail.Text;
                utilisateurApi.Identifiant = txtIdentifiant.Text;
                utilisateurApi.Telephone = txtTel.Text;
                utilisateurApi.MotDePasse = CryptApp.GetMd5Hash(md5Hash, "P@sser123");
                utilisateurApi.Statut = "Actif";
                if (!serviceApiPhp.AjouterUtilisateur(utilisateurApi))
                {
                    MessageBox.Show("Echec de l'ajout de l'utilisateur via API PHP");
                    return;
                }
                MessageBox.Show("Utilisateur ajoute avec succes via API PHP");

                //Ajouter un utilisateur par l'api ASP.NET Web API
                //Utilisateur apiutilisateur = new Utilisateur();
                //apiutilisateur.NomPrenom = txtNomPrenom.Text;
                //apiutilisateur.Email = txtEmail.Text;
                //apiutilisateur.Identifiant = txtIdentifiant.Text;
                //apiutilisateur.Telephone = txtTel.Text;
                //apiutilisateur.MotDePasse = CryptApp.GetMd5Hash(md5Hash, "P@sser123");
                //apiutilisateur.Statut = "Actif";
                //if (!AjouterParApiUtilisateur(apiutilisateur))
                //{
                //    MessageBox.Show("Echec de l'ajout de l'utilisateur via API ASP.NET");
                //    return;
                //}
                //MessageBox.Show("Utilisateur ajoute avec succes via API ASP.NET");

                // Ajouter un utilisateur par le service SOAP
                MetierGestion.Utilisateur ut = new MetierGestion.Utilisateur();
                ut.Email = txtEmail.Text;
                ut.MotDePasse = CryptApp.GetMd5Hash(md5Hash, "P@sser123");
                ut.NomPrenom = txtNomPrenom.Text;
                ut.Identifiant = txtIdentifiant.Text;
                ut.Telephone = txtTel.Text;
                if(metierGestionService1.AddUtilisateur(ut))
                {
                    MessageBox.Show("Utilisateur ajoute avec succes");
                }
                else
                {
                    MessageBox.Show("Echec de l'ajout de l'utilisateur");
                    return;
                }
                ResetForm();
                //GMailer.senMail(ut.Email, "Creation compte", string.Format("Bonjour /n Votre compte est bien cree avec identifiant {0} et mot de passe {1}", ut.Identifiant, "P@sser123"));
            }
        }
        private void txtEmail_MouseLeave(object sender, EventArgs e)
        {
            txtIdentifiant.Text = txtEmail.Text;
        }

        private void frmUtilisateur_Load(object sender, EventArgs e)
        {
            //dgUtilisateur.DataSource = dgUtilisateur.DataSource;
            ResetForm();
        }

        private void btnChoisir_Click(object sender, EventArgs e)
        {
            if (dgUtilisateur.CurrentRow == null)
            {
                MessageBox.Show("Veuillez selectionner un utilisateur");
                return;
            }
            int? id = int.Parse(dgUtilisateur.CurrentRow.Cells[0].Value.ToString());
            var a = metierGestionService1.GetUtilisateurById((int)id);
            txtEmail.Text = a.Email;
            txtIdentifiant.Text = a.Identifiant;
            txtNomPrenom.Text = a.NomPrenom;
            txtTel.Text = a.Telephone;
            txtNomPrenom.Focus();
            btnModifier.Enabled = true;
            btnSupprimer.Enabled = true;
            btnAjouter.Enabled = false;
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                int? id = int.Parse(dgUtilisateur.CurrentRow.Cells[0].Value.ToString());
                var a = metierGestionService1.GetUtilisateurById((int)id);

                if (string.IsNullOrWhiteSpace(txtNomPrenom.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtIdentifiant.Text) || string.IsNullOrWhiteSpace(txtTel.Text))
                {
                    MessageBox.Show("Veuillez remplir tous les champs obligatoires");
                    return;
                }
                if (a == null)
                {
                    MessageBox.Show("Utilisateur introuvable");
                    return;
                }
                // Mettre à jour l'utilisateur dans service soap 
                a.Email = txtEmail.Text;
                a.MotDePasse = CryptApp.GetMd5Hash(md5Hash, "P@sser123");
                a.NomPrenom = txtNomPrenom.Text;
                a.Identifiant = txtIdentifiant.Text;
                a.Telephone = txtTel.Text;
                if (metierGestionService1.UpdateUtilisateur(a))
                {
                    MessageBox.Show("Utilisateur modifie avec succes");
                }
                else
                {
                    MessageBox.Show("Echec de la modification de l'utilisateur");
                    return;
                }

               //var utilisateurapiphp = serviceApiPhp.getUtilisateurByID((int)id);
               // if (utilisateurapiphp == null)
               // {
               //     MessageBox.Show("Utilisateur introuvable dans l'API PHP");
               //     return;
               // }
               // // Mettre à jour l'utilisateur dans l'API PHP
               // utilisateurapiphp.Email = txtEmail.Text;
               // utilisateurapiphp.MotDePasse = CryptApp.GetMd5Hash(md5Hash, "P@sser123");
               // utilisateurapiphp.NomPrenom = txtNomPrenom.Text;
               // utilisateurapiphp.Identifiant = txtIdentifiant.Text;
               // utilisateurapiphp.Telephone = txtTel.Text;
               // utilisateurapiphp.Statut = "Actif"; 
               // if (!serviceApiPhp.ModifierUtilisateur(utilisateurapiphp))
               // {
               //     MessageBox.Show("Echec de la modification de l'utilisateur via API PHP");
               //     return;
               // }
               // MessageBox.Show("Utilisateur modifie avec succes via API PHP");

                //var apiutilisateur = db.Utilisateurs.Find(id);
                //if (apiutilisateur == null)
                //{
                //    MessageBox.Show("Utilisateur introuvable");
                //    return;
                //}
                //// Mettre à jour l'utilisateur dans l'API ASP.NET Web API
                //apiutilisateur.Email = txtEmail.Text;
                //apiutilisateur.MotDePasse = CryptApp.GetMd5Hash(md5Hash, "P@sser123");
                //apiutilisateur.NomPrenom = txtNomPrenom.Text;
                //apiutilisateur.Identifiant = txtIdentifiant.Text;
                //apiutilisateur.Telephone = txtTel.Text;
                //if (!ModifierParApiUtilisateur(apiutilisateur))
                //{
                //    MessageBox.Show("Echec de la modification de l'utilisateur via API");
                //    return;
                //}
                //MessageBox.Show("Utilisateur modifie avec succes via API");

                //GMailer.senMail(a.Email, "Modification compte", string.Format("Bonjour /n Votre compte est bien modifie avec identifiant {0} et mot de passe {1}", a.Identifiant, "P@sser123"));
                btnAjouter.Enabled = true;
                btnModifier.Enabled = false;
                btnSupprimer.Enabled = false;
                ResetForm();
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            string message = "Voulez-Vous supprimer ?";
            string title = "Fermer";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                int? id = int.Parse(dgUtilisateur.CurrentRow.Cells[0].Value.ToString());
                //var utilisateurapiphp = serviceApiPhp.getUtilisateurByID((int)id);
                //if (utilisateurapiphp == null)
                //{
                //    MessageBox.Show("Utilisateur introuvable dans l'API PHP");
                //    return;
                //}
                //// Supprimer l'utilisateur dans l'API PHP
                //if (!serviceApiPhp.SupprimerUtilisateur((int)id))
                //{
                //    MessageBox.Show("Echec de la suppression de l'utilisateur via API PHP");
                //    return;
                //}
                //MessageBox.Show("Utilisateur supprime avec succes via API PHP");

                // Supprimer l'utilisateur dans le service l'API ASP.NET Web API
                //var apiutilisateur = db.Utilisateurs.Find(id);
                //if (apiutilisateur == null)
                //{
                //    MessageBox.Show("Utilisateur introuvable");
                //    return;
                //}
                //SupprimerParApiUtilisateur(apiutilisateur.IdPersonne);
                // Supprimer l'utilisateur dans le service SOAP
                var a = metierGestionService1.GetUtilisateurById((int)id);
                if (a == null)
                {
                    MessageBox.Show("Utilisateur introuvable");
                    return;
                }
                if (metierGestionService1.DeleteUtilisateur(a))
                {
                    MessageBox.Show("Utilisateur supprime avec succes");
                }
                else
                {
                    MessageBox.Show("Echec de la suppression de l'utilisateur");
                    return;
                }
                ResetForm();
            }
        }

        private void txtchercher_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void txtchercher_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtchercher.Text.Trim().ToLower();
            var listes = metierGestionService1.GetListUtilisateurs(string.Empty, string.Empty, string.Empty, string.Empty)
                .Where(a => 
                a.NomPrenom.ToLower().Contains(searchText) ||
                a.Email.ToLower().Contains(searchText) ||
                a.Telephone.ToLower().Contains(searchText))
                .Select(a => new {
                    a.IdPersonne,
                    Matricule = $"MAT-{a.IdPersonne.ToString().PadLeft(5, '0')}",
                    NomComplet = a.NomPrenom,
                    Username = a.Identifiant,
                    Email = a.Email,
                    Contact = a.Telephone
                })
                .ToList();
            dgUtilisateur.DataSource = listes;
            if (dgUtilisateur.Columns.Contains("IdPersonne"))
            {
                dgUtilisateur.Columns["IdPersonne"].Visible = false;
            }
            if (dgUtilisateur.Rows.Count > 0)
            {
                DataGridViewCell firstVisibleCell = null;
                foreach (DataGridViewCell cell in dgUtilisateur.Rows[0].Cells)
                {
                    if (cell.Visible)
                    {
                        firstVisibleCell = cell;
                        break;
                    }
                }

                if (firstVisibleCell != null)
                {
                    dgUtilisateur.Rows[0].Selected = true;
                    dgUtilisateur.CurrentCell = firstVisibleCell;
                    btnModifier.Enabled = true;
                    btnSupprimer.Enabled = true;
                    btnAjouter.Enabled = false;
                }
            }
            else
            {
                btnModifier.Enabled = false;
                btnSupprimer.Enabled = false;
                btnAjouter.Enabled = true;
            }

        }

        private void dgUtilisateur_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void PersonnaliserHeaderDgUtilisateur()
        {
            DataGridViewCellStyle styleHeader = new DataGridViewCellStyle();
            styleHeader.BackColor = Color.DarkSlateBlue;
            styleHeader.ForeColor = Color.White;
            styleHeader.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            styleHeader.Alignment = DataGridViewContentAlignment.MiddleCenter; 

            dgUtilisateur.EnableHeadersVisualStyles = false;
            dgUtilisateur.ColumnHeadersDefaultCellStyle = styleHeader;

            dgUtilisateur.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            dgUtilisateur.DefaultCellStyle.BackColor = Color.White;
            dgUtilisateur.DefaultCellStyle.ForeColor = Color.Black;
            dgUtilisateur.DefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
            dgUtilisateur.DefaultCellStyle.SelectionForeColor = Color.White;
            dgUtilisateur.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            dgUtilisateur.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgUtilisateur.RowTemplate.Height = 28;
            dgUtilisateur.GridColor = Color.LightSteelBlue;
            dgUtilisateur.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgUtilisateur.RowHeadersVisible = false;
            dgUtilisateur.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgUtilisateur.AllowUserToAddRows = false;
            dgUtilisateur.ReadOnly = true;
        }


    }
}
