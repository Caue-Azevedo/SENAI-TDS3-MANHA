using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteca_
{
    public partial class CadastroLivro : UserControl
    {
        public CadastroLivro()
        {
            InitializeComponent();
            lblOpcaoAdicionar.Font = new Font("Arial", 12, FontStyle.Regular);

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {

        }
    }
}
