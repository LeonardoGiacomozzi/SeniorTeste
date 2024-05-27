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
    public class CidadeService : ICidadeService
    {
        private readonly IOpenWeatherService _openWeatherService;
        private readonly DataContext _context;

        public CidadeService(IOpenWeatherService openWeatherService, DataContext context)
        {
            _openWeatherService = openWeatherService;
            _context = context;
        }

        public CidadeDTO Create(string prNome)
        {
            try
            {
                var cidadeResponse = _openWeatherService.GetCordenadas(prNome);
                if (cidadeResponse.Result == null)
                    throw new Exception("Erro desconhecido ao cadastrar cidade");
                var cidadeDto = cidadeResponse.Result;
                var cidadeDb = new Cidade() { Lat = cidadeDto.Lat, Lon = cidadeDto.Lon, Nome = prNome };
                _context.Cidades.Add(cidadeDb);
                _context.SaveChanges();
                cidadeDto.Id = cidadeDb.Id;
                return cidadeDto;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao cadastrar cidade ->"+e.Message);
            }
        }

        public CidadeDTO Get(string prNome) 
        {
            try
            {
               var cidadeDb= _context.Cidades.FirstOrDefault(e => e.Nome.Equals(prNome));
                if (cidadeDb == null)
                    return null;
                
                return new CidadeDTO() { Lat = cidadeDb.Lat, Lon = cidadeDb.Lon, Nome = prNome,Id=cidadeDb.Id };
            }
            catch (Exception e)
            {

                throw new Exception("Erro ao buscar Cidade ->"+e.Message);
            }
        }
    }
}
