using SeniorTeste.Service.DTO;
using SeniorTeste.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeniorTeste.Service.UnitTest.Mocks
{
    public class OpenWeatherServiceMock : IOpenWeatherService
    {
        public async Task<ClimaDTO> GetClima(CidadeDTO cordenadas)
        {
            return new ClimaDTO() { DataConsulta = DateTime.Now, Temperatura = 15, Cidade = "Blumenau" };
        }

        public async Task<CidadeDTO> GetCordenadas(string cidade)
        {
            return  new CidadeDTO() { Id = 1, Lat = 25, Lon = 15, Nome = "Blumenau" };
         
        }
    }
}
