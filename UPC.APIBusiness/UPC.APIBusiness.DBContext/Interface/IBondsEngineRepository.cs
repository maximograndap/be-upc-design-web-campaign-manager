﻿using System;
using System.Collections.Generic;
using System.Text;
using DBEntity;

namespace DBContext
{
    public interface IBondsEngineRepository
    {
        BaseResponse GetBondsEngine(int idRegla);
    }
}
