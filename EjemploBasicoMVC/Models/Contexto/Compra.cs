namespace EjemploBasicoMVC.Models.Contexto
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Compra")]
    public partial class Compra
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Compra()
        {
            CompraDet = new HashSet<CompraDet>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(20)]
        public string noCompra { get; set; }

        public int usuario_id { get; set; }

        public int proveedor_id { get; set; }

        public decimal total { get; set; }

        [Column(TypeName = "date")]
        public DateTime fechaCompra { get; set; }

        public TimeSpan horaCompra { get; set; }

        public bool cancelado { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fechaCancelacionCompra { get; set; }

        public TimeSpan? horaCancelacionCompra { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CompraDet> CompraDet { get; set; }

        public virtual Proveedor Proveedor { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
