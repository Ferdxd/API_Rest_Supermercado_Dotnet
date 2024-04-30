using System.Collections.Generic;
using System;
using System.Text.Json.Serialization;
namespace API_Rest_SuperMercado.Models{
    public class Proveedor{
        public Guid ProveedorId { get; set; }

        public string Nit { get; set; }

        public string Nombre { get; set; }

        public string Correo { get; set; }

        public string Descripcion { get; set; }
        [JsonIgnore]
        public virtual ICollection<Producto> Productos { get; set; }

    }
}