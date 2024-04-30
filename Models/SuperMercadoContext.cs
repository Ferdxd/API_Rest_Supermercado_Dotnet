using API_Rest_Supermercado.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Rest_SuperMercado.Models{
    public class SuperMercadoContext: DbContext{
        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Producto> Productos { get; set; }

        public DbSet<Proveedor> Proveedores { get; set; }

        public SuperMercadoContext(DbContextOptions<SuperMercadoContext> options):base(options){

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // List<Producto> productosInit=new List<Producto>();

            modelBuilder.Entity<Producto>(producto=>{
                producto.ToTable("Producto");
                producto.HasKey(p=>p.ProductoId);
                producto.HasOne(p=>p.Categoria).WithMany(p=>p.Productos).HasForeignKey(p=>p.CategoriaId);
                producto.HasOne(p=>p.Proveedor).WithMany(p=>p.Productos).HasForeignKey(p=>p.ProveedorId);
                producto.Property(p=>p.Nombre).IsRequired().HasMaxLength(150);
                producto.Property(p=>p.Precio).IsRequired();
                producto.Property(p=>p.Cantidad).IsRequired();
                producto.Property(p=>p.FechaIngreso);
            });

          //  List<Categoria>categoriasInit = new List<Categoria>();

            modelBuilder.Entity<Categoria>(categoria=>{
                categoria.ToTable("Categoria");
                categoria.HasKey(p=>p.CategoriaId);
                categoria.Property(p=>p.Nombre).IsRequired().HasMaxLength(150);
                categoria.Property(p=>p.Descripcion).HasMaxLength(200);
            });

           // List<Proveedor> proveedoresInit=new List<Proveedor>();

            modelBuilder.Entity<Proveedor>(proveedor=>{
                proveedor.ToTable("Poveedor");
                proveedor.HasKey(p=>p.ProveedorId);
                proveedor.Property(p=>p.Nombre).IsRequired().HasMaxLength(150);
                proveedor.Property(p=>p.Descripcion).IsRequired(false);
                proveedor.Property(p=>p.Nit).IsRequired().HasMaxLength(25);
               // proveedor.HasAlternateKey(p=>p.Nit);
                proveedor.Property(p=>p.Correo).IsRequired().HasMaxLength(150);
            });

        }
    }

}