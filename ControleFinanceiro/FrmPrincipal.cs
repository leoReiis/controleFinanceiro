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
            List <Cidade> lista =CidadeDB.getCidades(conexao);
            richTBLista.Clear();
            for(int i = 0; i < lista.Count; i++)
            {
                Cidade cidade = lista[i];
                richTBLista.AppendText("Cidade " + cidade.cidadeid + " - " + cidade.nome + " - " + cidade.estadosigla + "\n");
            }
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            Cidade cidade = new Cidade("Barbacena", "MG");
            bool realizou = CidadeDB.setIncluiCidade(conexao, cidade);
            if (realizou)
            {
                MessageBox.Show("Sucesso");
            } else
            {
                MessageBox.Show("Erro ao incluir");
            }

        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Cidade cidade = new Cidade(2, "Barbacena", "MG");
            bool realizou = CidadeDB.setAlteraCidade(conexao, cidade);
            if (realizou) {
                MessageBox.Show("Alterado");
            } else
            {
                MessageBox.Show("Erro ao alterar Estado");
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            bool realizou = CidadeDB.setExcluirCidade(conexao, 2);
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
