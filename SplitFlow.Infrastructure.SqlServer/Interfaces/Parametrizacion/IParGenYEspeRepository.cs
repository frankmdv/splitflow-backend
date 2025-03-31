using SplitFlow.Domain.Entities.Parametrizacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Infrastructure.SqlServer.Interfaces.Parametrizacion
{
    public interface IParGenYEspeRepository
    {
        Task AddParGeneral(ParametroGeneral pGeneral);
        Task AddParEspecifico(ParametroEspecifico pEspecifico);
        Task UpdateParGeneral(ParametroGeneral pGeneral);
        Task UpdateParEspecifico(ParametroEspecifico pEspecifico);
    }
}
