using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using PortalNegociosBackEnd.Infra.Extensions;
using SeniorTeste.Service.DTO;
using SeniorTeste.Service.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SeniorTeste.Service.Service
{
    public class OpenWeatherService : IOpenWeatherService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public OpenWeatherService(IHttpClientFactory httpClientFactory) =>
            _httpClientFactory = httpClientFactory;

        public async Task<CidadeDTO> GetCordenadas(string prCidade)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, $"http://api.openweathermap.org/geo/1.0/direct?q={prCidade}&limit=5&appid=73c76abbb0cb1fbfa66ac4b7524ed0ae");
                var response = await client.SendAsync(request);

                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    throw new Exception(await response.Content.ReadAsStringAsync());

                string stringRetorno = response.Content.ReadAsStringAsync().Result;
                var retorno = stringRetorno.DeserializeObject<List<CidadeOWDTO>>();
                var cordenadas = new CidadeDTO()
                {
                    Nome = prCidade,
                    Lat = Convert.ToDecimal(retorno.Find(e => e.name.Equals(prCidade))?.lat),
                    Lon = Convert.ToDecimal(retorno.Find(e => e.name.Equals(prCidade))?.lon),
                };

                return cordenadas;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar as cordenadas da cidade {prCidade} | ERRO-> {ex.Message}");
            }
        }

        public async Task<ClimaDTO> GetClima(CidadeDTO prCordenadas)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get,
                    $"https://api.openweathermap.org/data/3.0/onecall?lat={prCordenadas.Lat}&lon={prCordenadas.Lon}&appid=73c76abbb0cb1fbfa66ac4b7524ed0ae&units=metric");
                var response = await client.SendAsync(request);

                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    throw new Exception(await response.Content.ReadAsStringAsync());

                string stringRetorno = response.Content.ReadAsStringAsync().Result;
                var retorno = stringRetorno.DeserializeObject<ClimaOWDTO>();

                var clima = new ClimaDTO()
                {
                    Cidade = prCordenadas.Nome,
                    Temperatura = retorno.current.temp,
                    DataConsulta = DateTime.Now,
                };
                return clima;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar o clima para as cordenadas latitude {prCordenadas.Lat} e longitude {prCordenadas.Lon} | ERRO-> {ex.Message}");
            }

        }
        public async Task<IEnumerable<ClimaDTO>> GetClimaByRange(CidadeDTO prCordenadas, DateTime prData)
        {
            try
            {
                DateTimeOffset dt = new DateTimeOffset(prData, TimeSpan.Zero);
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get,
                    $"https://api.openweathermap.org/data/3.0/onecall/timemachine?lat={prCordenadas.Lat}&lon={prCordenadas.Lon}&dt={dt.ToUnixTimeSeconds()}&appid=73c76abbb0cb1fbfa66ac4b7524ed0ae&units=metric&exclude=minutely,hourly,daily,alerts,rain");
                var response = await client.SendAsync(request);

                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    throw new Exception(await response.Content.ReadAsStringAsync());

                string stringRetorno = response.Content.ReadAsStringAsync().Result;
                var retorno = stringRetorno.DeserializeObject<ClimaDataOW>();
                var climas = new List<ClimaDTO>();
                foreach (var data in retorno.data)
                {
                    var clima = new ClimaDTO()
                    {
                        Cidade = prCordenadas.Nome,
                        Temperatura = data.temp,
                        DataConsulta = DateTime.Now,
                    };
                    climas.Add(clima);
                }
                return climas;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar o clima para as cordenadas latitude {prCordenadas.Lat} e longitude {prCordenadas.Lon} | ERRO-> {ex.Message}"); ;
            }
        }

    }
}
