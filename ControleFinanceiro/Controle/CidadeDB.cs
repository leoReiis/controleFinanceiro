using ControleFinanceiro.Modelo;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleFinanceiro.Controle
{
    public class CidadeDB
    {
        public static List<Cidade> getCidades(NpgsqlConnection conexao)
        {
            List<Cidade> lista = new List<Cidade>();

            try
            {
                string sql = "select * from cidade order by nome";                
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao); 
                NpgsqlDataReader rd =  cmd.ExecuteReader();
                while (rd.Read())
                {
                   int cidadeid = int.Parse(rd["cidade_id"].ToString());
                    string nome = rd["nome"].ToString();
                    string estadosigla = rd["estadosigla"].ToString();
                    Cidade cidade = new Cidade(cidadeid, nome, estadosigla);
                    lista.Add(cidade);
                }
                rd.Close();
            }catch (NpgsqlException erro) {
                MessageBox.Show("Erro ao retornar lista de cidades: " + erro.Message);
            }
            return lista;
        }

        public static bool setIncluiCidade(NpgsqlConnection conexao, Cidade cidade)
        {
            bool realizou = false;
            try
            {
                string sql = "insert into cidade(nome,estadosigla) " +
                             "values (@nome, @estadosigla)";
                NpgsqlCommand cmd = new NpgsqlCommand( sql, conexao );
              //  cmd.Parameters.Add("@cidade_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = cidade.cidadeid;
                cmd.Parameters.Add("@nome", NpgsqlTypes.NpgsqlDbType.Varchar).Value = cidade.nome;
                cmd.Parameters.Add("@estadosigla", NpgsqlTypes.NpgsqlDbType.Varchar).Value = cidade.estadosigla;
                int valor = cmd.ExecuteNonQuery();
                realizou = (valor == 1);

            } catch(NpgsqlException erro)
            {
                MessageBox.Show("Erro de sql:" + erro.Message);
            }
            return realizou;
        }

        public static bool setAlteraCidade(NpgsqlConnection conexao, Cidade cidade)
        {
            bool realizou = false;
            try
            {
                string sql = "update cidade set nome = @nome, estadosigla = @estadosigla " +
                             "where cidade_id = @cidadeid";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao );
                cmd.Parameters.Add("@cidadeid", NpgsqlTypes.NpgsqlDbType.Integer).Value = cidade.cidadeid;
                cmd.Parameters.Add("@nome", NpgsqlTypes.NpgsqlDbType.Varchar).Value = cidade.nome;
                cmd.Parameters.Add("@estadosigla", NpgsqlTypes.NpgsqlDbType.Varchar).Value = cidade.estadosigla;
                int valor = cmd.ExecuteNonQuery();
                realizou = (valor == 1);
            }
            catch (NpgsqlException erro)
            {
                MessageBox.Show("Errod de SQL: " + erro.Message);
            }
            return realizou;
        }

        public static bool setExcluirCidade(NpgsqlConnection conexao, int cidadeid)
        {
            bool realizou = false;
            try
            {
                string sql = "DELETE FROM CIDADE WHERE CIDADE_ID = @CIDADEID";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.Add("@CIDADEID", NpgsqlTypes.NpgsqlDbType.Integer).Value = cidadeid;
                int valor = cmd.ExecuteNonQuery();
                realizou = (valor == 1);
            }
            catch (NpgsqlException erro)
            {
                MessageBox.Show("Erro de sql:" + erro.Message);
            }
            return realizou;
        }
    }
}
