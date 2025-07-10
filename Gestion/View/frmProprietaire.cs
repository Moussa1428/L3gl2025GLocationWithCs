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

namespace Gestion.View
{
    public partial class frmProprietaire : Form
    {
        public frmProprietaire()
        {
            InitializeComponent();
        }

        MetierGestion.Service1Client metierGestionService1 = new MetierGestion.Service1Client();
        private void ResetForm()
        {
            txtEmail.Text=string.Empty;
            txtNinea.Text=string.Empty;
            txtNomPrenom.Text=string.Empty;
            txtRccm.Text=string.Empty;
            txtTel.Text=string.Empty;
            dgProprietaire.DataSource = metierGestionService1.
                GetListeProprietaires(
                string.Empty,
                string.Empty, 
                string.Empty, 
                string.Empty, 
                string.Empty
                )
                .Select(a => new {
                    a.IdPersonne,
                    Matricule = $"MAT-{a.IdPersonne.ToString().PadLeft(5, '0')}",
                    Nomcomplet = a.NomPrenom,
                    Contact= a.Telephone, 
                    Email =a.Email,
                    Ninea =a.Ninea,
                    Rccm = a.Rccm 
                }).ToList();
                if (dgProprietaire.Columns.Contains("IdPersonne"))
                {
                    dgProprietaire.Columns["IdPersonne"].Visible = false;
                }
            txtNomPrenom.Focus();
            btnAjouter.Enabled  = true;
            btnModifier.Enabled = false;
            btnSupprimer.Enabled = false;
            PersonnaliserHeaderdgProprietaire();
        }

        private void frmProprietaire_Load(object sender, EventArgs e)
        {
            ResetForm();
        }
        private void btnAjouter_Click(object sender, EventArgs e)
        {
            MetierGestion.Proprietaire p = new MetierGestion.Proprietaire();
            p.NomPrenom = txtNomPrenom.Text;
            p.Rccm = txtRccm.Text;
            p.Telephone = txtTel.Text;
            p.Email = txtEmail.Text;
            p.Ninea= txtNinea.Text;
            if (metierGestionService1.AddProprietaire(p))
            {
                MessageBox.Show("Proprietaire ajoute avec succes");
            }
            else
            {
                MessageBox.Show("Erreur lors de l'ajout du proprietaire");
            }
            ResetForm();
        }

        private void btnChoisir_Click(object sender, EventArgs e)
        {
            if (dgProprietaire.CurrentRow == null)
            {
                MessageBox.Show("Veuillez selectionner un proprietaire");
                return;
            }
            int? id = int.Parse(dgProprietaire.CurrentRow.Cells[0].Value.ToString());
            var p = metierGestionService1.GetProprietaireById(id);
            if (p == null)
            {
                MessageBox.Show("Veuillez selectionner un proprietaire a modifier");
                return;
            }
            txtNomPrenom.Text = p.NomPrenom;
            txtTel.Text = p.Telephone;
            txtEmail.Text = p.Email;
            txtNinea.Text = p.Ninea;
            txtRccm.Text = p.Rccm;
            txtNomPrenom.Focus();
            btnAjouter.Enabled = false;
            btnModifier.Enabled = true;
            btnSupprimer.Enabled = true;
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            int? id =int.Parse(dgProprietaire.CurrentRow.Cells[0].Value.ToString());
            if (id == null)
            {
                MessageBox.Show("Veuillez selectionner un proprietaire a modifier");
                return;
            }
            if (string.IsNullOrEmpty(txtNomPrenom.Text) || string.IsNullOrEmpty(txtTel.Text) || string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtNinea.Text) || string.IsNullOrEmpty(txtRccm.Text))
            {
                MessageBox.Show("Veuillez remplir tous les champs");
                return;
            }
            var  p = metierGestionService1.GetProprietaireById(id);
            p.NomPrenom = txtNomPrenom.Text;
            p.Rccm = txtRccm.Text;
            p.Telephone = txtTel.Text;
            p.Email = txtEmail.Text;
            p.Ninea = txtNinea.Text;
            if(metierGestionService1.UpdateProprietaire(p))
            {
                MessageBox.Show("Proprietaire modifie avec succes");
            }
            else
            {
                MessageBox.Show("Erreur lors de la modification du proprietaire");
            }
            btnAjouter.Enabled = true;
            btnModifier.Enabled = false;
            btnSupprimer.Enabled = false;
            ResetForm();
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            int? id = int.Parse(dgProprietaire.CurrentRow.Cells[0].Value.ToString());
            //var p = db.proprietaires.Find(id);
            var p = metierGestionService1.GetProprietaireById(id);
            if (p == null)
            {
                MessageBox.Show("Veuillez selectionner un proprietaire a supprimer");
                return;
            }
            string message = "Voulez-vous vraiment supprimer ce proprietaire ?";
            DialogResult result = MessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }
            if (metierGestionService1.DeleteProprietaire(p))
            {
                MessageBox.Show("Proprietaire supprime avec succes");
            }
            else
            {
                MessageBox.Show("Erreur lors de la suppression du proprietaire");
            }
            btnAjouter.Enabled = true;
            btnModifier.Enabled = false;
            btnSupprimer.Enabled = false;
            ResetForm();
        }

        private void btnImprimer_Click(object sender, EventArgs e)
        {
            frmPrintListeProprietaire f= new frmPrintListeProprietaire();
            f.Show();
            this.Enabled= false;
        }
        public void Activer()
        {
            this.Enabled = true;
        }


        private void PersonnaliserHeaderdgProprietaire()
        {
            DataGridViewCellStyle styleHeader = new DataGridViewCellStyle();
            styleHeader.BackColor = Color.DarkSlateBlue;
            styleHeader.ForeColor = Color.White;
            styleHeader.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            styleHeader.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgProprietaire.EnableHeadersVisualStyles = false;
            dgProprietaire.ColumnHeadersDefaultCellStyle = styleHeader;

            dgProprietaire.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            dgProprietaire.DefaultCellStyle.BackColor = Color.White;
            dgProprietaire.DefaultCellStyle.ForeColor = Color.Black;
            dgProprietaire.DefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
            dgProprietaire.DefaultCellStyle.SelectionForeColor = Color.White;
            dgProprietaire.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            dgProprietaire.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgProprietaire.RowTemplate.Height = 28;
            dgProprietaire.GridColor = Color.LightSteelBlue;
            dgProprietaire.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgProprietaire.RowHeadersVisible = false;
            dgProprietaire.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgProprietaire.AllowUserToAddRows = false;
            dgProprietaire.ReadOnly = true;


        }

        private void txtchercher_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtchercher.Text.Trim().ToLower();
            var proprietaires = metierGestionService1
                .GetListeProprietaires(
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    string.Empty
                )
                .Where(p =>
                    p.NomPrenom.ToLower().Contains(searchText) ||
                    p.Telephone.ToLower().Contains(searchText) ||
                    p.Email.ToLower().Contains(searchText) ||
                    p.Ninea.ToLower().Contains(searchText) ||
                    p.Rccm.ToLower().Contains(searchText)
                )
                .Select(p => new
                {
                    p.IdPersonne,
                    Matricule = $"MAT-{p.IdPersonne.ToString().PadLeft(5, '0')}",
                    Nomcomplet = p.NomPrenom,
                    Contact = p.Telephone,
                    Email = p.Email,
                    Ninea = p.Ninea,
                    Rccm = p.Rccm
                })
                .ToList();
            dgProprietaire.DataSource = proprietaires;
            if (dgProprietaire.Rows.Count > 0)
            {
                dgProprietaire.Rows[0].Selected = true;
                //dgProprietaire.CurrentCell = dgProprietaire.Rows[0].Cells[0];
            }
            else
            {
                btnModifier.Enabled = false;
                btnSupprimer.Enabled = false;
                btnAjouter.Enabled = true;
            }
        }
    }
}
