using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Modelo
{
    public class Conta
    {
        public int contaid {  get; set; }
        public string descricao { get; set; }    
        public double valor { get; set; }
        public DateTime dataVencimento { get; set; }
        public DateTime dataPagamento { get; set; }
        public int situacao { get; set; }
        public int tipo {  get; set; }
        public int pessoaid {  get; set; }

        public Conta(int contaid, string descricao, double valor, DateTime dataVencimento, DateTime dataPagamento, int situacao, int tipo, int pessoaid)
        {
            this.contaid = contaid;
            this.descricao = descricao;
            this.valor = valor;
            this.dataVencimento = dataVencimento;
            this.dataPagamento = dataPagamento;
            this.situacao = situacao;
            this.tipo = tipo;
            this.pessoaid = pessoaid;
        }
    }
}
