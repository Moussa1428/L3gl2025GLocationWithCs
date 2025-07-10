using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gestion.Model;
using Gestion.Utils;

namespace Gestion.View
{
    public partial class frmAppartement : Form
    {
        public frmAppartement()
        {
            InitializeComponent();
        }

        MetierGestion.Service1Client service = new MetierGestion.Service1Client();
        MetierGestion.Service1Client service2 = new MetierGestion.Service1Client();
        BdAppartementContext db=new BdAppartementContext();
        Helper helper = new Helper();

        private void ChargerComboBoxProprietaires()
        {
            var proprietaires = service2.GetListeProprietaires(
                string.Empty, string.Empty, string.Empty, string.Empty, string.Empty
            );

            cbbProprietaire.DataSource = proprietaires;
            cbbProprietaire.DisplayMember = "NomPrenom";  
            cbbProprietaire.ValueMember = "IdPersonne";    
        }
        private void ResetForm()
        {
            txtAdresse.Text= string.Empty;
            txtCapacite.Text= string.Empty;
            txtNombrePiece.Text= string.Empty;
            txtSurface.Text= string.Empty;
            cbbDisponible.Text = "-- Sélectionnez un propriétaire --";
            cbbProprietaire.DataSource = LoadCbbProprietaire().ToList();
            cbbProprietaire.DisplayMember = "Text";
            cbbProprietaire.ValueMember = "Value";

            dgAppartement.DataSource = service.GetListeAppartement(string.Empty, null, null)
                .Select(a => new
                {
                    a.IdAppartement,
                    Adresse = a.AdresseAppartement,
                    Proprietaire = a.Proprietaire.NomPrenom,
                    a.Capacite,
                    a.NombrePiece,
                    a.Surface,
                    Disponible = a.Disponible ? "Oui" : "Non"
                })
                .ToList();


            if (dgAppartement.Columns.Contains("IdAppartement"))
            {
                dgAppartement.Columns["IdAppartement"].Visible = false;
            }
            txtAdresse.Focus();
        }

        private List<ListSelectionViewModel> LoadCbbProprietaire()
        {
            var liste = service2.GetListeProprietaires(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty).ToList();

            var list = new List<ListSelectionViewModel>
                {
                    new ListSelectionViewModel
                    {
                        Text = "-- Sélectionnez un propriétaire --",
                        Value = string.Empty
                    }
                };

                list.AddRange(liste.Select(p => new ListSelectionViewModel
                {
                    Text = $"{p.NomPrenom}-Tel  {p.Telephone} ",
                    Value = p.IdPersonne.ToString()
                }));
            return list;
        }

        private void frmAppartement_Load(object sender, EventArgs e)
        {
            ChargerComboBoxProprietaires();
            ResetForm();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbbProprietaire.SelectedValue?.ToString()) || cbbProprietaire.SelectedValue.ToString() == "0")
            {
                MessageBox.Show("Veuillez sélectionner un propriétaire.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                MetierGestion.Appartement a = new MetierGestion.Appartement();
                a.Capacite = float.Parse(txtCapacite.Text);
                a.Disponible = cbbDisponible.SelectedText == "Oui" ? true : false;
                a.Surface = float.Parse(txtSurface.Text);
                a.NombrePiece = int.Parse(txtNombrePiece.Text);
                a.AdresseAppartement = txtAdresse.Text;
                a.IdProprietaire = int.Parse(cbbProprietaire.SelectedValue.ToString());
                service.AddAppartement(a);
                MessageBox.Show("Appartement ajouté avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                helper.WriteDataError("frmAppartement-btnAjouter_Click", ex.ToString());
            }
            finally
            {
                ResetForm();
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            int? id = int.Parse(dgAppartement.CurrentRow.Cells[0].Value.ToString());
            var a = service.GetAppartementById(id); //db.appartements.Find(id);
            a.Capacite = float.Parse(txtCapacite.Text);
            a.Disponible = cbbDisponible.SelectedText == "Oui" ? true : false;
            a.Surface = float.Parse(txtSurface.Text);
            a.NombrePiece = int.Parse(txtNombrePiece.Text);
            a.AdresseAppartement = txtAdresse.Text;
            a.IdProprietaire = int.Parse(cbbProprietaire.SelectedValue.ToString());
            //db.SaveChanges();
            service.UpdateAppartement(a);
            ResetForm();
        }

        private void btnChoisir_Click(object sender, EventArgs e)
        {
            int? id = int.Parse(dgAppartement.CurrentRow.Cells[0].Value.ToString());
            var a = service.GetAppartementById(id);//db.appartements.Find(id);
            txtAdresse.Text = a.AdresseAppartement;
            cbbProprietaire.SelectedValue = a.Proprietaire.IdPersonne;
            txtCapacite.Text = a.Capacite!=null? a.Capacite.ToString():string.Empty;
            txtNombrePiece.Text=a.NombrePiece!=null ? a.NombrePiece.ToString():string.Empty;
            txtSurface.Text=a.Surface.ToString();
            cbbDisponible.SelectedValue = a.Disponible;

        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            string message = "Voulez-Vous supprimer ?";
            string title = "Fermer";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                int? id = int.Parse(dgAppartement.CurrentRow.Cells[0].Value.ToString());
                var a = service.GetAppartementById(id);
                service.DeleteAppartement(a);
                //db.appartements.Remove(a);
                //db.SaveChanges();
                ResetForm();
            }
            
        }

        private void btnContrat_Click(object sender, EventArgs e)
        {
            frmContratLocation frm = new frmContratLocation();
            frm.Appartement = string.Format("Adresse");
            frm.Show();
        }
       
    }
}
