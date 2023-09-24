using ControleFinanceiro.Modelo;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleFinanceiro.Controle
{
    public class EstadoDB
    {
        public static List<Estado> getEstados(NpgsqlConnection conexao)
        {
            List<Estado> lista = new List<Estado>();
            try
            {
                string sql = "select * from estado order by estadosigla";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                NpgsqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    string sigla = rd["estadosigla"].ToString();
                    string nome  = rd["nome"].ToString() ;
                    Estado estado = new Estado(sigla, nome);
                    lista.Add(estado);
                }
                rd.Close();
            }
            catch (NpgsqlException erro) {
                MessageBox.Show("Erro de SQL: " + erro.Message);
            }

            return lista;
        }

        public static bool setIncluiEstado(NpgsqlConnection conexao , Estado estado)
        {
            bool realizou = false;
            try
            {
                string sql = "insert into estado(estadosigla, nome)" +
                             " values(@estadosigla, @nome)";
                NpgsqlCommand cmd = new NpgsqlCommand( sql, conexao);
                cmd.Parameters.Add("@estadosigla", NpgsqlTypes.NpgsqlDbType.Varchar).Value = estado.estadosigla;
                cmd.Parameters.Add("@nome", NpgsqlTypes.NpgsqlDbType.Varchar).Value = estado.nome;
                int valor = cmd.ExecuteNonQuery();    
                realizou = (valor == 1);
            }
            catch (NpgsqlException erro)
            {
                MessageBox.Show("Erro de sql: " + erro.Message);
            }
            return realizou;
        }

        public static bool setAlteraEstado(NpgsqlConnection conexao, Estado estado)
        {
            bool realizou = false;
            try
            {
                string sql = "UPDATE ESTADO SET NOME = @NOME WHERE ESTADOSIGLA = @ESTADOSIGLA";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.Add("@NOME", NpgsqlTypes.NpgsqlDbType.Varchar).Value = estado.nome;
                cmd.Parameters.Add("@ESTADOSIGLA", NpgsqlTypes.NpgsqlDbType.Varchar).Value =estado.estadosigla;
                int valor = cmd.ExecuteNonQuery();
                realizou = ( valor == 1);
            }catch (NpgsqlException erro)
            {
                MessageBox.Show("Erro de sql: " + erro.Message);
            }

            return realizou;
        }

        public static bool setExcluiEstado(NpgsqlConnection conexao, string estadosigla)
        {
            bool realizou = false;
            try
            {
                string sql = "DELETE FROM ESTADO WHERE ESTADOSIGLA = @ESTADOSIGLA";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.Add("@ESTADOSIGLA", NpgsqlTypes.NpgsqlDbType.Varchar).Value = estadosigla;
                int valor = cmd.ExecuteNonQuery();
                realizou = ( valor == 1);
            }
            catch(NpgsqlException erro)
            {
                MessageBox.Show("Erro de sql:" + erro.Message);
            }
            return realizou;
        }
    }
}
