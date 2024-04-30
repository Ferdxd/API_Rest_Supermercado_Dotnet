using System.Collections.Generic;
using API_Rest_Supermercado.Models;
using System;
using System.Text.Json.Serialization;

namespace API_Rest_SuperMercado.Models{
    public class Producto{
        public Guid ProductoId { get; set; }

        public Guid CategoriaId { get; set; }
        //cada producto tiene una categoria relacionada

        public Guid ProveedorId { get; set; }
        //cada producto tiene una persona que lo provee

        public string Nombre { get; set; }

        public float Precio {get; set;}

        public DateTime FechaIngreso {get; set;}

        public int Cantidad {get; set; }

        [JsonIgnore]

        public virtual Categoria Categoria {get; set; }

        public virtual Proveedor Proveedor {get; set; }


    }
}