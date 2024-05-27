using SeniorTeste.Domain.Entity;
using SeniorTeste.Infra.Data;
using SeniorTeste.Service.DTO;
using SeniorTeste.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeniorTeste.Service.Service
{
    public class ClimaService : IClimaService
    {
        private readonly ICidadeService _cidadeService;
        private readonly IOpenWeatherService _openWeatherService;
        private readonly DataContext _context;

        public ClimaService(ICidadeService cidadeService, IOpenWeatherService openWeatherService, DataContext context)
        {
            _cidadeService = cidadeService;
            _openWeatherService = openWeatherService;
            _context = context;
        }

        public ClimaDTO Create(string prCidade)
        {
            try
            {
                var cidade = _cidadeService.Get(prCidade);
                if (cidade == null)
                    cidade = _cidadeService.Create(prCidade);


                var climaResponse = _openWeatherService.GetClima(cidade);
                if (climaResponse.Result == null)
                    throw new Exception("Clima atual não encontrado");

                var clima = climaResponse.Result;

                _context.Climas.Add(new Clima() { CidadeId = cidade.Id, Temperatura = clima.Temperatura, DataColeta = clima.DataConsulta.ToUniversalTime() });
                _context.SaveChanges();

                return clima;

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao buscar informações do clima salvas no banco ->" + e.Message);
            }
        }

        public IEnumerable<ClimaDTO> GetClimasCidadeByRange(string prCidade, DateTime prInicio, DateTime prFim)
        {
            try
            {
                var cidade = _cidadeService.Get(prCidade);
                if (cidade == null)
                    throw new Exception("Cidade não encontrada ");
                var clima = _context.Climas.Where(e => e.CidadeId == cidade.Id && e.DataColeta >= prInicio && e.DataColeta <= prFim)
                    .Select(c => new ClimaDTO() { Cidade = cidade.Nome, Temperatura = c.Temperatura, DataConsulta = c.DataColeta });
                return clima;
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao buscar dados da cidade {prCidade} no periodo de: {prInicio.ToString("dd/MM/yyyy t hh:mm")} até:{prInicio.ToString("dd/MM/yyyy t hh:mm")} | Erro -> {e.Message}");
            }
        }

        public IEnumerable<ClimaDTO> GetClimasCidadesOWByRange(string prCidade, DateTime prInicio, DateTime prFim)
        {
            try
            {
                var datacont = prInicio;
                var listResult = new List<ClimaDTO>();
                while (datacont < prFim)
                {
                    var cidade = _cidadeService.Get(prCidade);
                    if (cidade == null)
                        cidade = _cidadeService.Create(prCidade);

                    var climaResponse = _openWeatherService.GetClimaByRange(cidade, datacont);
                    listResult.AddRange(climaResponse.Result);
                    datacont = datacont.AddDays(1);
                }
                return listResult;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao buscar informações atual do clima ->" + e.Message);
            }
        }
    }
}
