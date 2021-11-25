using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityCustomerBenefit
    {
        public int idCliente { get; set; }
        public string nombrePersona { get; set; }
        public string apellidoPersona { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string numeroDocumento { get; set; }
        public string numeroTelefono { get; set; }
        public string correo { get; set; }
        public List<EntityBonds> bonos { get; set; }
        public List<EntityGifts> obsequios { get; set; }
    }
}
