namespace Gestion.View
{
    partial class frmContratLocation
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
            this.btnChoisir = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnModifier = new System.Windows.Forms.Button();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.txtCNI = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgLocataire = new System.Windows.Forms.DataGridView();
            this.lblAppartement = new System.Windows.Forms.Label();
            this.txtDateDebut = new System.Windows.Forms.DateTimePicker();
            this.txtDateFin = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.cbbModePaiement = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgLocataire)).BeginInit();
            this.SuspendLayout();
            // 
            // btnChoisir
            // 
            this.btnChoisir.Location = new System.Drawing.Point(351, 111);
            this.btnChoisir.Name = "btnChoisir";
            this.btnChoisir.Size = new System.Drawing.Size(156, 43);
            this.btnChoisir.TabIndex = 44;
            this.btnChoisir.Text = "Choisir";
            this.btnChoisir.UseVisualStyleBackColor = true;
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.Location = new System.Drawing.Point(409, 754);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(156, 43);
            this.btnSupprimer.TabIndex = 43;
            this.btnSupprimer.Text = "Revoquer";
            this.btnSupprimer.UseVisualStyleBackColor = true;
            // 
            // btnModifier
            // 
            this.btnModifier.Location = new System.Drawing.Point(228, 754);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(156, 43);
            this.btnModifier.TabIndex = 42;
            this.btnModifier.Text = "Valider";
            this.btnModifier.UseVisualStyleBackColor = true;
            // 
            // btnAjouter
            // 
            this.btnAjouter.Location = new System.Drawing.Point(30, 754);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(156, 43);
            this.btnAjouter.TabIndex = 41;
            this.btnAjouter.Text = "Enregistrer";
            this.btnAjouter.UseVisualStyleBackColor = true;
            // 
            // txtCNI
            // 
            this.txtCNI.Location = new System.Drawing.Point(41, 564);
            this.txtCNI.Name = "txtCNI";
            this.txtCNI.Size = new System.Drawing.Size(466, 31);
            this.txtCNI.TabIndex = 40;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 535);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 25);
            this.label5.TabIndex = 39;
            this.label5.Text = "Montant";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 410);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 25);
            this.label3.TabIndex = 37;
            this.label3.Text = "Date de fin";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 285);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 25);
            this.label2.TabIndex = 35;
            this.label2.Text = "Date de Debut";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(41, 189);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(466, 31);
            this.txtNumero.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 25);
            this.label1.TabIndex = 33;
            this.label1.Text = "Numero";
            // 
            // dgLocataire
            // 
            this.dgLocataire.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgLocataire.Location = new System.Drawing.Point(584, 12);
            this.dgLocataire.Name = "dgLocataire";
            this.dgLocataire.RowHeadersWidth = 82;
            this.dgLocataire.RowTemplate.Height = 33;
            this.dgLocataire.Size = new System.Drawing.Size(650, 1121);
            this.dgLocataire.TabIndex = 32;
            // 
            // lblAppartement
            // 
            this.lblAppartement.AutoSize = true;
            this.lblAppartement.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppartement.Location = new System.Drawing.Point(41, 31);
            this.lblAppartement.Name = "lblAppartement";
            this.lblAppartement.Size = new System.Drawing.Size(0, 37);
            this.lblAppartement.TabIndex = 45;
            // 
            // txtDateDebut
            // 
            this.txtDateDebut.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDateDebut.Location = new System.Drawing.Point(46, 314);
            this.txtDateDebut.Name = "txtDateDebut";
            this.txtDateDebut.Size = new System.Drawing.Size(461, 31);
            this.txtDateDebut.TabIndex = 46;
            // 
            // txtDateFin
            // 
            this.txtDateFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDateFin.Location = new System.Drawing.Point(48, 439);
            this.txtDateFin.Name = "txtDateFin";
            this.txtDateFin.Size = new System.Drawing.Size(459, 31);
            this.txtDateFin.TabIndex = 47;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 636);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(190, 25);
            this.label4.TabIndex = 48;
            this.label4.Text = "Mode de paiement";
            // 
            // cbbModePaiement
            // 
            this.cbbModePaiement.FormattingEnabled = true;
            this.cbbModePaiement.Location = new System.Drawing.Point(46, 665);
            this.cbbModePaiement.Name = "cbbModePaiement";
            this.cbbModePaiement.Size = new System.Drawing.Size(461, 33);
            this.cbbModePaiement.TabIndex = 49;
            // 
            // frmContratLocation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2003, 1156);
            this.ControlBox = false;
            this.Controls.Add(this.cbbModePaiement);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDateFin);
            this.Controls.Add(this.txtDateDebut);
            this.Controls.Add(this.lblAppartement);
            this.Controls.Add(this.btnChoisir);
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.btnModifier);
            this.Controls.Add(this.btnAjouter);
            this.Controls.Add(this.txtCNI);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgLocataire);
            this.Name = "frmContratLocation";
            this.Text = "Contrat de location";
            this.Load += new System.EventHandler(this.frmContratLocation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgLocataire)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnChoisir;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnModifier;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.TextBox txtCNI;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgLocataire;
        private System.Windows.Forms.Label lblAppartement;
        private System.Windows.Forms.DateTimePicker txtDateDebut;
        private System.Windows.Forms.DateTimePicker txtDateFin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbbModePaiement;
    }
}