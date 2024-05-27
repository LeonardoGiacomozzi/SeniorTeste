using SeniorTeste.Service.DTO;
using SeniorTeste.Service.Service;
using SeniorTeste.Service.UnitTest.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeniorTeste.Service.UnitTest
{
    public class CidadeServiceTest
    {
        [Fact]
        public void Create_Deve_Retornar_DTO_Completo() 
        {
            var service = new CidadeService(new OpenWeatherServiceMock(), new DataContextMock(null));
            var result = service.Create("Blumenau");
            Assert.NotNull(result);
        }
    }
}
