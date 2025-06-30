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
        BdAppartementContext db=new BdAppartementContext();
        Helper helper = new Helper();

        private void ResetForm()
        {
            txtAdresse.Text= string.Empty;
            txtCapacite.Text= string.Empty;
            txtNombrePiece.Text= string.Empty;
            txtSurface.Text= string.Empty;
            cbbDisponible.Text = "Selectionnez...";
            cbbProprietaire.DataSource = LoadCbbProprietaire().ToList();
            cbbProprietaire.DisplayMember = "Text";
            cbbProprietaire.ValueMember = "Value";
            dgAppartement.DataSource = service.GetListeAppartement(null, null, null).Select(a => new { a.IdAppartement, a.IdProprietaire, a.Proprietaire.NomPrenom, a.NombrePiece, a.Capacite, a.Surface, a.Disponible }).ToList();//db.appartements.Select(a => new { a.IdAppartement, a.IdProprietaire, a.Proprietaire.NomPrenom, a.NombrePiece, a.Capacite, a.Surface, a.Disponible }).ToList();
            txtAdresse.Focus();
        }

        private List<ListSelectionViewModel> LoadCbbProprietaire()
        {
            var liste = db.proprietaires.ToList();
            
            
            List<ListSelectionViewModel> list = new List<ListSelectionViewModel>();
            ListSelectionViewModel a= new ListSelectionViewModel();
            a.Text = "Selectionnez....";
            a.Value=string.Empty;
            list.Add(a);

            foreach (var item in liste)
            {
                ListSelectionViewModel b = new ListSelectionViewModel();
                b.Text = item.NomPrenom;
                b.Value = item.IdPersonne.ToString();
                list.Add(b);
            }

            return list;
        }

        private void frmAppartement_Load(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
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
                //db.appartements.Add(a);
                //db.SaveChanges();
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
