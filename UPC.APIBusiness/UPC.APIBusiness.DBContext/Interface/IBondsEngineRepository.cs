using System;
using System.Collections.Generic;
using System.Text;
using DBEntity;

namespace DBContext
{
    public interface IBondsEngineRepository
    {
        List<EntityBondsEngine> GetBondsEngine(int idRegla);
    }
}
