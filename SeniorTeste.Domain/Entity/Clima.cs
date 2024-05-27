using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeniorTeste.Domain.Entity
{
    public class Clima
    {
        public int Id { get; set; }
        public int CidadeId { get; set; }
        public Cidade Cidade { get; set; }
        public decimal Temperatura { get; set; }
        public DateTime DataColeta { get; set; }
    }
}
