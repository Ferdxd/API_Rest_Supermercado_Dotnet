

using API_Rest_SuperMercado.Models;

namespace API_Rest_SuperMercado;

public class ProductoService:IProductoService{
    SuperMercadoContext context;

    public ProductoService(SuperMercadoContext dbcontext){
        context=dbcontext;
    }

    public IEnumerable<Producto> Get(){
        return context.Productos;
    }

    public async Task Save(Producto producto){
        producto.ProductoId=Guid.NewGuid();
        producto.FechaIngreso=DateTime.Now;
        await context.AddAsync(producto);
        await context.SaveChangesAsync();
    }

    public async Task Update(Guid id, Producto producto){
        var productoActual= context.Productos.Find(id);
        if(productoActual!=null){
            productoActual.Nombre=producto.Nombre;
            productoActual.Precio=producto.Precio;
            productoActual.Cantidad=producto.Cantidad;
            await context.SaveChangesAsync();
        }
        
    }

    public async Task Delete(Guid id){
        var productoActual =context.Productos.Find(id);
        if(productoActual!=null){
            context.Remove(productoActual);
            await context.SaveChangesAsync();
        }
    }
}

public interface IProductoService{
    IEnumerable<Producto> Get();

    Task Save (Producto producto);

    Task Update (Guid id, Producto producto);

    Task Delete (Guid id);
}