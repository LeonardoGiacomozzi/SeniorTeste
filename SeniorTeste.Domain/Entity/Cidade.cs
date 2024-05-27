using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeniorTeste.Domain.Entity
{
    public class Cidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Lat { get; set; }
        public decimal Lon { get; set; }
        public ICollection<Clima> Climas { get; set; }
    }
}
