using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleFinanceiro.Controle
{
    public class Conexao
    {
        public static NpgsqlConnection getConexao()
        {
            NpgsqlConnection conexao = null;
            try
            {
                conexao = new NpgsqlConnection("server=localhost;port=5432;user id=postgres;password=masterkey;database=financeiro;");
                conexao.Open();
            }
            catch(NpgsqlException erro)
            {
                MessageBox.Show("Erro ao conectar no banco de dados: " + erro.Message);  
            };
            return conexao;
        }


        public static void setFechaConexao(NpgsqlConnection conexao)
        {
            if (conexao != null)
            {
                try
                {
                    conexao.Close();
                }
                catch (NpgsqlException erro)
                {
                    MessageBox.Show("Erro ao fechar conexão com banco de dados: " + erro.Message);
                }
            }
        }
    }
}
