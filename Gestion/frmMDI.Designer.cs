﻿namespace Gestion
{
    partial class frmMDI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMDI));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.actionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seDeconnecterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parametreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proprietaireToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.appartementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.securiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.utilisateurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actionToolStripMenuItem,
            this.parametreToolStripMenuItem,
            this.securiteToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1603, 33);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.UseWaitCursor = true;
            // 
            // actionToolStripMenuItem
            // 
            this.actionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.seDeconnecterToolStripMenuItem,
            this.quitterToolStripMenuItem});
            this.actionToolStripMenuItem.Name = "actionToolStripMenuItem";
            this.actionToolStripMenuItem.Size = new System.Drawing.Size(79, 29);
            this.actionToolStripMenuItem.Text = "&Action";
            // 
            // seDeconnecterToolStripMenuItem
            // 
            this.seDeconnecterToolStripMenuItem.Name = "seDeconnecterToolStripMenuItem";
            this.seDeconnecterToolStripMenuItem.Size = new System.Drawing.Size(237, 34);
            this.seDeconnecterToolStripMenuItem.Text = "Se Deconnecter";
            this.seDeconnecterToolStripMenuItem.Click += new System.EventHandler(this.seDeconnecterToolStripMenuItem_Click);
            // 
            // quitterToolStripMenuItem
            // 
            this.quitterToolStripMenuItem.Name = "quitterToolStripMenuItem";
            this.quitterToolStripMenuItem.Size = new System.Drawing.Size(237, 34);
            this.quitterToolStripMenuItem.Text = "Quitter";
            this.quitterToolStripMenuItem.Click += new System.EventHandler(this.quitterToolStripMenuItem_Click);
            // 
            // parametreToolStripMenuItem
            // 
            this.parametreToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.proprietaireToolStripMenuItem,
            this.appartementToolStripMenuItem});
            this.parametreToolStripMenuItem.Name = "parametreToolStripMenuItem";
            this.parametreToolStripMenuItem.Size = new System.Drawing.Size(107, 29);
            this.parametreToolStripMenuItem.Text = "Parametre";
            // 
            // proprietaireToolStripMenuItem
            // 
            this.proprietaireToolStripMenuItem.Name = "proprietaireToolStripMenuItem";
            this.proprietaireToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.proprietaireToolStripMenuItem.Text = "Proprietaire";
            this.proprietaireToolStripMenuItem.Click += new System.EventHandler(this.proprietaireToolStripMenuItem_Click);
            // 
            // appartementToolStripMenuItem
            // 
            this.appartementToolStripMenuItem.Enabled = false;
            this.appartementToolStripMenuItem.Name = "appartementToolStripMenuItem";
            this.appartementToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.appartementToolStripMenuItem.Text = "Appartement";
            this.appartementToolStripMenuItem.Click += new System.EventHandler(this.appartementToolStripMenuItem_Click);
            // 
            // securiteToolStripMenuItem
            // 
            this.securiteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.utilisateurToolStripMenuItem});
            this.securiteToolStripMenuItem.Name = "securiteToolStripMenuItem";
            this.securiteToolStripMenuItem.Size = new System.Drawing.Size(90, 29);
            this.securiteToolStripMenuItem.Text = "Securite";
            this.securiteToolStripMenuItem.Click += new System.EventHandler(this.securiteToolStripMenuItem_Click);
            // 
            // utilisateurToolStripMenuItem
            // 
            this.utilisateurToolStripMenuItem.Name = "utilisateurToolStripMenuItem";
            this.utilisateurToolStripMenuItem.Size = new System.Drawing.Size(192, 34);
            this.utilisateurToolStripMenuItem.Text = "Utilisateur";
            this.utilisateurToolStripMenuItem.Click += new System.EventHandler(this.utilisateurToolStripMenuItem_Click);
            // 
            // frmMDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1603, 840);
            this.ControlBox = false;
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmMDI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Application de gestion";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMDI_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem actionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seDeconnecterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parametreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem proprietaireToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem appartementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem securiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem utilisateurToolStripMenuItem;
    }
}