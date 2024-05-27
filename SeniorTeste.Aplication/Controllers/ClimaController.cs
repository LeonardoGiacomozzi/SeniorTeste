using Microsoft.AspNetCore.Mvc;
using SeniorTeste.Service.DTO;
using SeniorTeste.Service.Interface;

namespace SeniorTeste.Aplication.Controllers
{
    /// <summary>
    /// Controler de Clima
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ClimaController : Controller
    {
        private readonly IClimaService _climaService;

        /// <summary>
        /// Construtor
        /// </summary>
        public ClimaController(IClimaService climaService)
        {
            _climaService = climaService;
        }

        /// <summary>
        /// Retorna o clima das cidades informadas no periodo informado que estão salvos no banco de dados
        /// </summary>
        [HttpGet("GetClimas", Name = "GetClimas")]
        public IActionResult GetClimas([FromQuery] List<string> prCidades, [FromQuery] DateTime prDataInicio, [FromQuery] DateTime prDataFim)
        {
            try
            {
                List<ClimaDTO> climas = new List<ClimaDTO>();
                foreach (var cidade in prCidades)
                    climas.AddRange(_climaService.GetClimasCidadeByRange(cidade, prDataInicio, prDataFim));

                return Ok(climas);
            }
            catch (Exception e)
            {
                return BadRequest("Erro ao buscar clima para as cidades informadas no periodo solicitado | Erro ->" + e.Message);
            }
        }
        /// <summary>
        /// Retorna o clima das cidades informadas no periodo informado diretamente da api da OpenWeather
        /// </summary>
        [HttpGet("GetClimasRange", Name = "GetClimasRange")]
        public IActionResult GetClimasRange( [FromQuery] DateTime prInicio, [FromQuery] DateTime prDataFim, [FromQuery] List<string> prCidades)
        {
            try
            {
                List<ClimaDTO> climas = new List<ClimaDTO>();
                foreach (var cidade in prCidades)
                    climas.AddRange(_climaService.GetClimasCidadesOWByRange(cidade, prInicio, prDataFim));

                return Ok(climas);
            }
            catch (Exception e)
            {
                return BadRequest("Erro ao buscar clima para as cidades informadas no periodo solicitado | Erro ->" + e.Message);
            }
        }
    }
}
