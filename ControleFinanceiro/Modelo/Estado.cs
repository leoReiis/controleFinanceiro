using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Modelo
{
    public class Estado
    {
        public string estadosigla { get; set; }
        public string nome { get; set; }

        public Estado(string estadosigla, string nome) {
            this.estadosigla = estadosigla;
            this.nome = nome;
        }

    }
}
