namespace EjemploBasicoMVC.Models.Contexto
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Core.Objects;
    using System.Data.Entity.Spatial;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Threading.Tasks;

    [Table("Unidad")]
    public partial class Unidad
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Unidad()
        {
            Producto = new HashSet<Producto>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(20)]
        public string descripcion { get; set; }

        [Required]
        [StringLength(10)]
        public string simbolo { get; set; }

        public bool activo { get; set; }

        [Column(TypeName = "date")]
        public DateTime fechaAlta { get; set; }

        public TimeSpan horaAlta { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fechaBaja { get; set; }

        public TimeSpan? horaBaja { get; set; }

        [NotMapped]
        public int TotalPages { get; private set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Producto> Producto { get; set; }

        public List<Unidad> Listar()
        {
            var ListaUnidades = new List<Unidad>();
            try
            {
                using (var contexto = new ContextModel() )
                {
                    ListaUnidades = contexto.Unidad.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return ListaUnidades;
        }

        private const int RecordsPerPage = 10;

        

        public List<Unidad> GetUnidades(int page = 1, int? regPagina = 10)
        {
            var ListarUnidades = new List<Unidad>();
            try
            {
                using (var contexto = new ContextModel())
                {

                    TotalPages = (int) Math.Ceiling((decimal)contexto.Unidad.ToList().Count() / regPagina ?? 1);
                    
                    SqlParameter pagina = new SqlParameter("@pagenum", page);
                    SqlParameter noRegistros = new SqlParameter("@pagesize", regPagina);

                    ListarUnidades = contexto.Unidad.SqlQuery("UnidadListar @pagenum, @pagesize", pagina, noRegistros).ToList();
                    foreach (var item in ListarUnidades)
                    {
                        item.TotalPages = this.TotalPages;
                    }
                    return ListarUnidades;                    
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex.InnerException);
            }
            
        }
    }
}
