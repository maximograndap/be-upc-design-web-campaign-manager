using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityBenefitType : EntityBase
    {
        public int idTipoBeneficio { get; set; }
        public string nombreBeneficio { get; set; }
        public string descBeneficio { get; set; }
    }
}
