using System;
using System.Windows.Forms;
using System.Drawing;

namespace TCC_SENAI_CAUE_GUEDES
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnCadastrar;
        private Button btnEntrar;
        private Label lblTitulo;
        private Label lblSubtitulo;
        private Label lblRodape;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnCadastrar = new Button();
            this.btnEntrar = new Button();
            this.lblTitulo = new Label();
            this.lblSubtitulo = new Label();
            this.lblRodape = new Label();

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new SizeF(9F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(800, 600);
            this.BackColor = Color.LightBlue;
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblSubtitulo);
            this.Controls.Add(this.btnEntrar);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.lblRodape);
            this.Name = "Form1";
            this.Text = "Transporte Curitiba";

            // 
            // lblTitulo
            // 
            this.lblTitulo.Text = "Transporte Curitiba";
            this.lblTitulo.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            this.lblTitulo.ForeColor = Color.Teal;
            this.lblTitulo.Size = new Size(400, 50);
            this.lblTitulo.Location = new Point((800 - 400) / 2, 80);
            this.lblTitulo.TextAlign = ContentAlignment.MiddleCenter;

            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.Text = "Sistema Integrado de Transporte Público";
            this.lblSubtitulo.Font = new Font("Segoe UI", 12F);
            this.lblSubtitulo.ForeColor = Color.Teal;
            this.lblSubtitulo.Size = new Size(400, 30);
            this.lblSubtitulo.Location = new Point((800 - 400) / 2, 140);
            this.lblSubtitulo.TextAlign = ContentAlignment.MiddleCenter;

            // 
            // btnEntrar
            // 
            this.btnEntrar.Text = "Entrar";
            this.btnEntrar.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.btnEntrar.Size = new Size(250, 50);
            this.btnEntrar.Location = new Point((800 - 250) / 2, 250);
            this.btnEntrar.BackColor = Color.SteelBlue;
            this.btnEntrar.ForeColor = Color.White;
            this.btnEntrar.FlatStyle = FlatStyle.Flat;
            this.btnEntrar.FlatAppearance.BorderSize = 0;
            this.btnEntrar.Cursor = Cursors.Hand;

            // 
            // btnCadastrar
            // 
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.btnCadastrar.Size = new Size(250, 50);
            this.btnCadastrar.Location = new Point((800 - 250) / 2, 320);
            this.btnCadastrar.BackColor = Color.SeaGreen;
            this.btnCadastrar.ForeColor = Color.White;
            this.btnCadastrar.FlatStyle = FlatStyle.Flat;
            this.btnCadastrar.FlatAppearance.BorderSize = 0;
            this.btnCadastrar.Cursor = Cursors.Hand;

            // 
            // lblRodape
            // 
            this.lblRodape.Text = "© 2023 Transporte Curitiba - Todos os direitos reservados";
            this.lblRodape.Font = new Font("Segoe UI", 9F);
            this.lblRodape.ForeColor = Color.Gray;
            this.lblRodape.Size = new Size(400, 20);
            this.lblRodape.Location = new Point((800 - 400) / 2, 500);
            this.lblRodape.TextAlign = ContentAlignment.MiddleCenter;

            this.ResumeLayout(false);
        }
    }
}
