using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Modelo
{
    public class Cidade
    {
        public int cidadeid { get; set; }
        public string nome { get; set; }
        public string estadosigla { get; set; }

        public Cidade(int cidadeid, string nome , string estadosigla) { 
            this.cidadeid = cidadeid;
            this.nome = nome;
            this.estadosigla = estadosigla;
        }
    }
}
