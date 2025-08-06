using System;
using System.IO;
using System.Windows.Forms;

namespace TCC_SENAI_CAUE_GUEDES
{
    public partial class MapaRastreamento : UserControl
    {
        #region campos privados e construtor

        private readonly Form1 formularioPrincipal;                      // referência para o formulário principal //

        public MapaRastreamento(Form1 form, double latitude, double longitude)
        {
            formularioPrincipal = form;
            InitializeComponent();                                        // inicializa componentes visuais //

            // monta caminho do arquivo HTML do mapa //
            string caminhoHtml = Path.Combine(Application.StartupPath, "Html", "mapa.html");

            // cria url local para navegar no WebBrowser com parâmetros de latitude e longitude //
            string url = $"file:///{caminhoHtml.Replace("\\", "/")}?lat={latitude}&lon={longitude}";

            webBrowser1.ScriptErrorsSuppressed = true;                   // suprime erros de script no WebBrowser //
            webBrowser1.Navigate(url);                                    // navega para o arquivo HTML com coordenadas //
        }

        #endregion

        #region eventos

        // evento para botão voltar para o menu inicial //
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            formularioPrincipal.TrocarControle(new MenuInicial(formularioPrincipal, "usuário"));
        }

        #endregion
    }
}
