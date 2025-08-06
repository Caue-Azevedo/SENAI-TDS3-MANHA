using System.Windows.Forms;

namespace TCC_SENAI_CAUE_GUEDES
{
    partial class MapaRastreamento
    {
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button btnVoltar;

        private void InitializeComponent()
        {
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(0, 50);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Dock = DockStyle.Fill;
            this.webBrowser1.TabIndex = 0;
            // 
            // btnVoltar
            // 
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnVoltar.Size = new System.Drawing.Size(100, 40);
            this.btnVoltar.Location = new System.Drawing.Point(10, 10);
            this.btnVoltar.BackColor = System.Drawing.Color.LightGray;
            this.btnVoltar.FlatStyle = FlatStyle.Flat;
            this.btnVoltar.FlatAppearance.BorderSize = 0;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            this.btnVoltar.BringToFront();
            //
            // MapaRastreamento
            //
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.webBrowser1);
            this.Name = "MapaRastreamento";
            this.Size = new System.Drawing.Size(800, 500);
            this.ResumeLayout(false);
        }
    }
}
