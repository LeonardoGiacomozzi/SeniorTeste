using Microsoft.Extensions.Configuration;
using SeniorTeste.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeniorTeste.Service.UnitTest.Mocks
{
    public class DataContextMock : DataContext
    {
        public DataContextMock(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
