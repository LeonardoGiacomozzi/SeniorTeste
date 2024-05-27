using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SeniorTeste.Service.DTO
{
    public class CidadeOWDTO
    {
        public string name { get; set; }
        public Dictionary<string,string> local_name { get; set; }
        public decimal lat { get; set; }
        public decimal lon { get; set; }
        public string country { get; set; }
        public string state { get; set; }
    }
}
