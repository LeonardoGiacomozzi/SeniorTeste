using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeniorTeste.Service.DTO
{
    public class ClimaOWDTO
    {
        public decimal lat { get; set; }
        public decimal lon { get; set; }
        public string timezone { get; set; }
        public int timezone_offset { get; set; }
        public current current { get; set; }
    }

    public class current 
    {
        public int dt { get; set; }
        public int sunrise{ get; set; }
        public int sunset{ get; set; }
        public decimal temp { get; set; }
        public decimal feels_like { get; set; }
        public int pressure { get; set; }
        public int humidity { get; set; }
        public decimal dew_point { get; set; }
        public int uvi{ get; set; }
        public int clouds{ get; set; }
        public int visibility { get; set; }
        public decimal wind_speed { get; set; }
        public int wind_deg { get; set; }
        public decimal wind_gust { get; set; }
        public List<weather> weather { get; set; }
    }
    public class weather 
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }
}
