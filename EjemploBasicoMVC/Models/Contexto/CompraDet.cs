namespace EjemploBasicoMVC.Models.Contexto
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CompraDet")]
    public partial class CompraDet
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public int compra_id { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int producto_id { get; set; }

        public decimal costo { get; set; }

        public decimal cantidad { get; set; }

        public decimal subtotal { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string lote { get; set; }

        public bool activo { get; set; }

        public virtual Compra Compra { get; set; }

        public virtual Producto Producto { get; set; }
    }
}
