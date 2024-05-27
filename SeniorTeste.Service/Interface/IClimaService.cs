using SeniorTeste.Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeniorTeste.Service.Interface
{
    public interface IClimaService
    {
        ClimaDTO Create(string prCidade);
        IEnumerable<ClimaDTO> GetClimasCidadeByRange(string prCidade, DateTime prInicio, DateTime prFim);
        IEnumerable<ClimaDTO> GetClimasCidadesOWByRange(string prCidade, DateTime prInicio, DateTime prFim);
    }
}
