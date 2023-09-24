using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControleFinanceiro.Controle;
using Npgsql;

namespace ControleFinanceiro
{
    public partial class FrmPrincipal : Form
    {
        public NpgsqlConnection conexao = null;
        public FrmPrincipal()
        {
            conexao = Conexao.getConexao();
            InitializeComponent();
        }

   
        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Conexao.setFechaConexao(conexao);
        }
    }
}
