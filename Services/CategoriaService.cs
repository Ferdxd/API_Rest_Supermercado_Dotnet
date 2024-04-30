
using API_Rest_Supermercado.Models;
using API_Rest_SuperMercado.Models;

namespace API_Rest_SuperMercado.Services;
    public class CategoriaService: ICategoriaService{
        SuperMercadoContext context;

        public CategoriaService(SuperMercadoContext dbcontext){
            context=dbcontext;
        }

        public IEnumerable<Categoria> Get(){
            return context.Categorias;
        }

        public async Task Save (Categoria categoria){
            categoria.CategoriaId=Guid.NewGuid();
            await context.AddAsync(categoria);
            await context.SaveChangesAsync();
        }

        public async Task Update (Guid id, Categoria categoria){
            var categoriaActual=context.Categorias.Find(id);
            if(categoriaActual!=null){
                categoriaActual.Nombre=categoria.Nombre;
                categoriaActual.Descripcion=categoria.Descripcion;
                await context.SaveChangesAsync();
            }
        }

        public async Task Delete(Guid id){
            var categoriaActual=context.Categorias.Find(id);

            if(categoriaActual!=null){
                context.Remove(categoriaActual);
                await context.SaveChangesAsync();
            }
        }
    }


    public interface ICategoriaService{
        IEnumerable<Categoria> Get();
        Task Save(Categoria categoria);

        Task Update(Guid id, Categoria categoria);

        Task Delete (Guid id);
    }
