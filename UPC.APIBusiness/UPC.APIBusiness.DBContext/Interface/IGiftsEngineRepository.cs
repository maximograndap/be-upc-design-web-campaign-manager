using System;
using System.Collections.Generic;
using System.Text;
using DBEntity;

namespace DBContext
{
    public interface IGiftsEngineRepository
    {
        BaseResponse GetGiftsEngine(int idRegla);
    }
}
