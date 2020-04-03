namespace EjemploBasicoMVC.Models.Contexto
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("VentaDet")]
    public partial class VentaDet
    {
        public int id { get; set; }

        public int venta_id { get; set; }

        public int producto_id { get; set; }

        public decimal precio { get; set; }

        public decimal cantidad { get; set; }

        public decimal subtotal { get; set; }

        public bool activo { get; set; }

        public virtual Producto Producto { get; set; }

        public virtual Venta Venta { get; set; }
    }
}
