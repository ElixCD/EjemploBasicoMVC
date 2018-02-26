namespace EjemploBasicoMVC.Models.Contexto
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.SqlClient;
    using System.Threading.Tasks;

    [Table("Usuario")]
    public partial class Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuario()
        {
            Compra = new HashSet<Compra>();
            Venta = new HashSet<Venta>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(15)]
        public string clave { get; set; }

        [Required]
        [StringLength(50)]
        public string nombre { get; set; }

        [Required]
        [StringLength(20)]
        public string contrasena { get; set; }

        public bool activo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fechaAlta { get; set; }

        public TimeSpan? horaAlta { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fechaBaja { get; set; }

        public TimeSpan? horaBaja { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Compra> Compra { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Venta> Venta { get; set; }

        public async Task Salvar()
        {
            await Task.Run(() =>
            {
                using (var contexto = new ContextModel())
                {
                    using (var trn = contexto.Database.BeginTransaction())
                    {
                        SqlParameter clave = new SqlParameter("@clave", this.clave);
                        SqlParameter nombre = new SqlParameter("@nombre", this.nombre);
                        SqlParameter contrasena = new SqlParameter("@contrasena", this.contrasena);
                        try
                        {
                            contexto.Database.ExecuteSqlCommand("UsuarioAlta @clave, @nombre, @contrasena", clave, nombre, contrasena);
                            trn.Commit();
                        }
                        catch
                        {
                            trn.Rollback();
                        }
                    }
                }
            });
        }

        public async Task Editar()
        {
            await Task.Run(() =>
            {
                using (var contexto = new ContextModel())
                {
                    using (var trn = contexto.Database.BeginTransaction())
                    {
                        SqlParameter clave = new SqlParameter("@clave", this.clave);
                        SqlParameter nombre = new SqlParameter("@nombre", this.nombre);
                        SqlParameter contrasena = new SqlParameter("@contrasena", this.contrasena);
                        try
                        {
                            contexto.Database.ExecuteSqlCommand("UsuarioAlta @clave @nombre @contrasena", clave, nombre, contrasena);
                            trn.Commit();                            
                        }
                        catch (Exception)
                        {

                            trn.Rollback();
                        }
                        
                    }
                }
            });
        }
    }
}
