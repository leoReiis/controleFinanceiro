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
using ControleFinanceiro.Modelo;
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

        private void btnListar_Click(object sender, EventArgs e)
        {
            List <Estado> lista =EstadoDB.getEstados(conexao);
            richTBLista.Clear();
            for(int i = 0; i < lista.Count; i++)
            {
                Estado estado = lista[i];
                richTBLista.AppendText("Estado " + estado.estadosigla + " - " + estado.nome + "\n");
            }
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            Estado estado = new Estado("BA", "Bahia");
            bool realizou = EstadoDB.setIncluiEstado(conexao, estado);
            if (realizou)
            {
                MessageBox.Show("Estado incluido com sucesso");
            } else
            {
                MessageBox.Show("Erro ao incluir");
            }

        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Estado estado = new Estado("BA", "Bahia");
            bool realizou = EstadoDB.setAlteraEstado(conexao, estado);
            if (realizou) {
                MessageBox.Show("Alterado");
            } else
            {
                MessageBox.Show("Erro ao alterar Estado");
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            bool realizou = EstadoDB.setExcluiEstado(conexao, "BA");
            if (realizou)
            {
                MessageBox.Show("Excluiu com sucesso");
            } else
            {
                MessageBox.Show("Erro ao excluir estado.");
            }
        }
    }
}
