namespace EjemploBasicoMVC.Models.Contexto
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Venta")]
    public partial class Venta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Venta()
        {
            VentaDet = new HashSet<VentaDet>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(20)]
        public string noVenta { get; set; }

        public int usuario_id { get; set; }

        public int cliente_id { get; set; }

        public decimal total { get; set; }

        [Column(TypeName = "date")]
        public DateTime fechaVenta { get; set; }

        public TimeSpan horaVenta { get; set; }

        public bool cancelado { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fechaCancelacionVenta { get; set; }

        public TimeSpan? horaCancelacionVenta { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual Usuario Usuario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VentaDet> VentaDet { get; set; }
    }
}
