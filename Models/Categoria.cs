using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using API_Rest_SuperMercado.Models;

namespace API_Rest_Supermercado.Models{
    public class Categoria{
        public Guid CategoriaId { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        [JsonIgnore]
        public virtual ICollection<Producto> Productos { get; set; }

    }
}