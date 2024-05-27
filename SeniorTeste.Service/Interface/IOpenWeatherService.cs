using SeniorTeste.Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeniorTeste.Service.Interface
{
    public interface IOpenWeatherService
    {
        Task<CidadeDTO> GetCordenadas(string cidade);
        Task<ClimaDTO> GetClima(CidadeDTO cordenadas);
        Task<IEnumerable<ClimaDTO>> GetClimaByRange(CidadeDTO prCordenadas, DateTime prData);
    }
}
