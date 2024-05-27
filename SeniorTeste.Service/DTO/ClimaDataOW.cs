using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeniorTeste.Service.DTO
{
    public class ClimaDataOW
    {
        public decimal lat { get; set; }
        public decimal lon { get; set; }
        public string timezone { get; set; }
        public int timezone_offset { get; set; }
        public List<current> data { get; set; }
    }
}
