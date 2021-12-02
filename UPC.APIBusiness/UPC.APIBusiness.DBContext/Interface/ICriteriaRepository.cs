using System;
using System.Collections.Generic;
using System.Text;
using DBEntity;

namespace DBContext
{
    public interface ICriteriaRepository
    {
        BaseResponse InsertCriteria(List<EntityCriteria> ListCriteria, int idRegla, int idCampania);
    }
}
