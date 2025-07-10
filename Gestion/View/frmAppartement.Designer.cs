namespace Gestion.View
{
    partial class frmAppartement
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAppartement));
            this.dgAppartement = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAdresse = new System.Windows.Forms.TextBox();
            this.txtSurface = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombrePiece = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCapacite = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbbDisponible = new System.Windows.Forms.ComboBox();
            this.cbbProprietaire = new System.Windows.Forms.ComboBox();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnModifier = new System.Windows.Forms.Button();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.btnChoisir = new System.Windows.Forms.Button();
            this.btnContrat = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.txtchercher = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgAppartement)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgAppartement
            // 
            this.dgAppartement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAppartement.Location = new System.Drawing.Point(601, 228);
            this.dgAppartement.Margin = new System.Windows.Forms.Padding(2);
            this.dgAppartement.Name = "dgAppartement";
            this.dgAppartement.RowHeadersWidth = 82;
            this.dgAppartement.RowTemplate.Height = 33;
            this.dgAppartement.Size = new System.Drawing.Size(1008, 579);
            this.dgAppartement.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bell MT", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(24, 552);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Adresse";
            // 
            // txtAdresse
            // 
            this.txtAdresse.Font = new System.Drawing.Font("Bell MT", 14F);
            this.txtAdresse.ForeColor = System.Drawing.Color.Black;
            this.txtAdresse.Location = new System.Drawing.Point(28, 601);
            this.txtAdresse.Margin = new System.Windows.Forms.Padding(2);
            this.txtAdresse.Name = "txtAdresse";
            this.txtAdresse.Size = new System.Drawing.Size(552, 39);
            this.txtAdresse.TabIndex = 2;
            // 
            // txtSurface
            // 
            this.txtSurface.Font = new System.Drawing.Font("Bell MT", 14F);
            this.txtSurface.ForeColor = System.Drawing.Color.Black;
            this.txtSurface.Location = new System.Drawing.Point(302, 348);
            this.txtSurface.Margin = new System.Windows.Forms.Padding(2);
            this.txtSurface.Name = "txtSurface";
            this.txtSurface.Size = new System.Drawing.Size(278, 39);
            this.txtSurface.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bell MT", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(297, 296);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "Surface";
            // 
            // txtNombrePiece
            // 
            this.txtNombrePiece.Font = new System.Drawing.Font("Bell MT", 14F);
            this.txtNombrePiece.ForeColor = System.Drawing.Color.Black;
            this.txtNombrePiece.Location = new System.Drawing.Point(26, 348);
            this.txtNombrePiece.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombrePiece.Name = "txtNombrePiece";
            this.txtNombrePiece.Size = new System.Drawing.Size(215, 39);
            this.txtNombrePiece.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bell MT", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(21, 296);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(191, 29);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nombre de piece";
            // 
            // txtCapacite
            // 
            this.txtCapacite.Font = new System.Drawing.Font("Bell MT", 14F);
            this.txtCapacite.ForeColor = System.Drawing.Color.Black;
            this.txtCapacite.Location = new System.Drawing.Point(26, 476);
            this.txtCapacite.Margin = new System.Windows.Forms.Padding(2);
            this.txtCapacite.Name = "txtCapacite";
            this.txtCapacite.Size = new System.Drawing.Size(215, 39);
            this.txtCapacite.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bell MT", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(24, 429);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 29);
            this.label4.TabIndex = 7;
            this.label4.Text = "Capacite";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Bell MT", 12F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(297, 429);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 29);
            this.label5.TabIndex = 9;
            this.label5.Text = "Disponible";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Bell MT", 12F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(24, 178);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 29);
            this.label6.TabIndex = 11;
            this.label6.Text = "Proprietaire";
            // 
            // cbbDisponible
            // 
            this.cbbDisponible.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbbDisponible.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbDisponible.Font = new System.Drawing.Font("Bell MT", 14F);
            this.cbbDisponible.ForeColor = System.Drawing.Color.Black;
            this.cbbDisponible.FormattingEnabled = true;
            this.cbbDisponible.Items.AddRange(new object[] {
            "Selectionnez...",
            "Oui",
            "Non"});
            this.cbbDisponible.Location = new System.Drawing.Point(302, 476);
            this.cbbDisponible.Margin = new System.Windows.Forms.Padding(2);
            this.cbbDisponible.Name = "cbbDisponible";
            this.cbbDisponible.Size = new System.Drawing.Size(278, 39);
            this.cbbDisponible.TabIndex = 13;
            // 
            // cbbProprietaire
            // 
            this.cbbProprietaire.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbbProprietaire.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbProprietaire.Font = new System.Drawing.Font("Bell MT", 14F);
            this.cbbProprietaire.ForeColor = System.Drawing.Color.Black;
            this.cbbProprietaire.FormattingEnabled = true;
            this.cbbProprietaire.Location = new System.Drawing.Point(26, 228);
            this.cbbProprietaire.Margin = new System.Windows.Forms.Padding(2);
            this.cbbProprietaire.Name = "cbbProprietaire";
            this.cbbProprietaire.Size = new System.Drawing.Size(554, 39);
            this.cbbProprietaire.TabIndex = 14;
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.BackColor = System.Drawing.Color.Firebrick;
            this.btnSupprimer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSupprimer.Font = new System.Drawing.Font("Bell MT", 12F, System.Drawing.FontStyle.Bold);
            this.btnSupprimer.ForeColor = System.Drawing.Color.White;
            this.btnSupprimer.Location = new System.Drawing.Point(447, 719);
            this.btnSupprimer.Margin = new System.Windows.Forms.Padding(2);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(133, 58);
            this.btnSupprimer.TabIndex = 18;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = false;
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
            // 
            // btnModifier
            // 
            this.btnModifier.BackColor = System.Drawing.Color.Coral;
            this.btnModifier.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModifier.Font = new System.Drawing.Font("Bell MT", 12F, System.Drawing.FontStyle.Bold);
            this.btnModifier.ForeColor = System.Drawing.Color.White;
            this.btnModifier.Location = new System.Drawing.Point(238, 719);
            this.btnModifier.Margin = new System.Windows.Forms.Padding(2);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(122, 58);
            this.btnModifier.TabIndex = 17;
            this.btnModifier.Text = "Modifier";
            this.btnModifier.UseVisualStyleBackColor = false;
            this.btnModifier.Click += new System.EventHandler(this.btnModifier_Click);
            // 
            // btnAjouter
            // 
            this.btnAjouter.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnAjouter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAjouter.Font = new System.Drawing.Font("Bell MT", 12F, System.Drawing.FontStyle.Bold);
            this.btnAjouter.ForeColor = System.Drawing.Color.White;
            this.btnAjouter.Location = new System.Drawing.Point(29, 719);
            this.btnAjouter.Margin = new System.Windows.Forms.Padding(2);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(122, 58);
            this.btnAjouter.TabIndex = 16;
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.UseVisualStyleBackColor = false;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // btnChoisir
            // 
            this.btnChoisir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChoisir.Font = new System.Drawing.Font("Bell MT", 12F, System.Drawing.FontStyle.Bold);
            this.btnChoisir.Location = new System.Drawing.Point(601, 142);
            this.btnChoisir.Margin = new System.Windows.Forms.Padding(2);
            this.btnChoisir.Name = "btnChoisir";
            this.btnChoisir.Size = new System.Drawing.Size(136, 54);
            this.btnChoisir.TabIndex = 19;
            this.btnChoisir.Text = "Choisir";
            this.btnChoisir.UseVisualStyleBackColor = true;
            this.btnChoisir.Click += new System.EventHandler(this.btnChoisir_Click);
            // 
            // btnContrat
            // 
            this.btnContrat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnContrat.Font = new System.Drawing.Font("Bell MT", 12F, System.Drawing.FontStyle.Bold);
            this.btnContrat.Location = new System.Drawing.Point(788, 142);
            this.btnContrat.Margin = new System.Windows.Forms.Padding(2);
            this.btnContrat.Name = "btnContrat";
            this.btnContrat.Size = new System.Drawing.Size(136, 54);
            this.btnContrat.TabIndex = 20;
            this.btnContrat.Text = "Contrat";
            this.btnContrat.UseVisualStyleBackColor = true;
            this.btnContrat.Click += new System.EventHandler(this.btnContrat_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Bell MT", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(19, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(358, 37);
            this.label7.TabIndex = 47;
            this.label7.Text = "Listes des Appartements";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1608, 84);
            this.panel1.TabIndex = 50;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Bell MT", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(993, 150);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(139, 38);
            this.label8.TabIndex = 53;
            this.label8.Text = "Chercher";
            // 
            // txtchercher
            // 
            this.txtchercher.BackColor = System.Drawing.Color.White;
            this.txtchercher.Font = new System.Drawing.Font("Bell MT", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtchercher.ForeColor = System.Drawing.Color.Black;
            this.txtchercher.Location = new System.Drawing.Point(1165, 150);
            this.txtchercher.Name = "txtchercher";
            this.txtchercher.Size = new System.Drawing.Size(438, 39);
            this.txtchercher.TabIndex = 52;
            // 
            // frmAppartement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1608, 808);
            this.ControlBox = false;
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtchercher);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnContrat);
            this.Controls.Add(this.btnChoisir);
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.btnModifier);
            this.Controls.Add(this.btnAjouter);
            this.Controls.Add(this.cbbProprietaire);
            this.Controls.Add(this.cbbDisponible);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCapacite);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNombrePiece);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSurface);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAdresse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgAppartement);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmAppartement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Appartement";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmAppartement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgAppartement)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgAppartement;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAdresse;
        private System.Windows.Forms.TextBox txtSurface;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombrePiece;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCapacite;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbbDisponible;
        private System.Windows.Forms.ComboBox cbbProprietaire;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnModifier;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Button btnChoisir;
        private System.Windows.Forms.Button btnContrat;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtchercher;
    }
}