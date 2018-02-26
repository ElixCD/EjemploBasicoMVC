namespace EjemploBasicoMVC.Models.Contexto
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Proveedor")]
    public partial class Proveedor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Proveedor()
        {
            Compra = new HashSet<Compra>();
            Rel_ProductoProveedor = new HashSet<Rel_ProductoProveedor>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(15)]
        public string clave { get; set; }

        [Required]
        [StringLength(50)]
        public string nombre { get; set; }

        public bool activo { get; set; }

        [Column(TypeName = "date")]
        public DateTime fechaAlta { get; set; }

        public TimeSpan horaAlta { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fechaBaja { get; set; }

        public TimeSpan? horaBaja { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Compra> Compra { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rel_ProductoProveedor> Rel_ProductoProveedor { get; set; }
    }
}
