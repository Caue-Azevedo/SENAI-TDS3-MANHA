namespace TCC_SENAI_CAUE_GUEDES
{
    partial class Rastreamento
    {
        #region campos de interface

        // necessário para gerenciamento de recursos do designer //
        private System.ComponentModel.IContainer components = null;

        // painel onde será exibido o mapa //
        private System.Windows.Forms.Panel panelMapa;

        // rótulo com informações do veículo //
        private System.Windows.Forms.Label lblInfo;

        #endregion

        #region descarte de recursos

        // descarta recursos utilizados pelo controle //
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose(); // libera os componentes //
            }
            base.Dispose(disposing);
        }

        #endregion

        #region método de inicialização

        // método responsável por configurar a interface gráfica //
        private void InitializeComponent()
        {
            this.panelMapa = new System.Windows.Forms.Panel();
            this.lblInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // 
            // panelMapa
            // 
            this.panelMapa.BackColor = System.Drawing.Color.Cornsilk; // define cor de fundo //
            this.panelMapa.Dock = System.Windows.Forms.DockStyle.Fill; // ocupa toda a área restante //
            this.panelMapa.Location = new System.Drawing.Point(0, 40);
            this.panelMapa.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelMapa.Name = "panelMapa";
            this.panelMapa.Size = new System.Drawing.Size(1029, 560);
            this.panelMapa.TabIndex = 1;

            // 
            // lblInfo
            // 
            this.lblInfo.Dock = System.Windows.Forms.DockStyle.Top; // fixa no topo do controle //
            this.lblInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblInfo.Location = new System.Drawing.Point(0, 0);
            this.lblInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(1029, 40);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "Carregando veículo...";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter; // centraliza texto //

            // 
            // Rastreamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMapa); // adiciona painel no controle //
            this.Controls.Add(this.lblInfo);   // adiciona rótulo no controle //
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Rastreamento";
            this.Size = new System.Drawing.Size(1029, 600);
            this.ResumeLayout(false);
        }

        #endregion
    }
}