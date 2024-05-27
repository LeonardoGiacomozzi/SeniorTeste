using SeniorTeste.Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeniorTeste.Service.Interface
{
    public interface ICidadeService
    {
        CidadeDTO Get(string nome);
        CidadeDTO Create(string nome);
    }
}
