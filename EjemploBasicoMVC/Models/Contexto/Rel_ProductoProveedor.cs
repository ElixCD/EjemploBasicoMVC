namespace EjemploBasicoMVC.Models.Contexto
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Rel_ProductoProveedor
    {
        public int id { get; set; }

        public int producto_id { get; set; }

        public int proveedor_id { get; set; }

        public bool activo { get; set; }

        [Column(TypeName = "date")]
        public DateTime fechaAlta { get; set; }

        public TimeSpan horaAlta { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fechaBaja { get; set; }

        public TimeSpan? horaBaja { get; set; }

        public virtual Producto Producto { get; set; }

        public virtual Proveedor Proveedor { get; set; }
    }
}
