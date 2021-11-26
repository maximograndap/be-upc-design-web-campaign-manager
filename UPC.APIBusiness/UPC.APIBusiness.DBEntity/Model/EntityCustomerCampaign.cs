using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityCustomerCampaign
    {
        public int idCampania { get; set; }
        public string nombreCampania { get; set; }
        public DateTime fechaInicio { get; set; }
        public int cantidadBonos { get; set; }
        public int cantidadObsequios { get; set; }
    }
}
