namespace EjemploBasicoMVC.Models.Contexto
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Producto")]
    public partial class Producto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Producto()
        {
            CompraDet = new HashSet<CompraDet>();
            Rel_ProductoProveedor = new HashSet<Rel_ProductoProveedor>();
            VentaDet = new HashSet<VentaDet>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(10)]
        public string clave { get; set; }

        [Required]
        [StringLength(25)]
        public string descripcion { get; set; }

        public decimal existencia { get; set; }

        public int unidad_id { get; set; }

        public bool activo { get; set; }

        [Column(TypeName = "date")]
        public DateTime fechaAlta { get; set; }

        public TimeSpan horaAlta { get; set; }

        [Column(TypeName = "date")]
        public DateTime fechaCambio { get; set; }

        public TimeSpan horaCambio { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fechaBaja { get; set; }

        public TimeSpan? horaBaja { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CompraDet> CompraDet { get; set; }

        public virtual Unidad Unidad { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rel_ProductoProveedor> Rel_ProductoProveedor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VentaDet> VentaDet { get; set; }
    }
}
