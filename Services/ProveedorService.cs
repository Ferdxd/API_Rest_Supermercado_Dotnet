

using API_Rest_Supermercado.Models;
using API_Rest_SuperMercado.Models;

namespace API_Rest_SuperMercado;

public class ProveedorService: IProveedorService {
    SuperMercadoContext context;

    public ProveedorService(SuperMercadoContext dbContext){
        context= dbContext;
    }

    public IEnumerable<Proveedor> Get(){
         return context.Proveedores;
    }

    public async Task Save(Proveedor proveedor){
        proveedor.ProveedorId=Guid.NewGuid();
        await context.AddAsync(proveedor);
        await context.SaveChangesAsync();
    }

    public async Task Update (Guid id, Proveedor proveedor){
        var proveedorActual=context.Proveedores.Find(id);
        if(proveedorActual!=null){
            proveedorActual.Nit=proveedor.Nit;
            proveedorActual.Nombre=proveedor.Nombre;
            proveedorActual.Correo=proveedor.Correo;
            proveedorActual.Descripcion=proveedor.Descripcion;
            await context.SaveChangesAsync();
        }
    }

    public async Task Delete(Guid id){
        var categoriaActual=context.Proveedores.Find(id);
        if(categoriaActual!=null){
            context.Remove(categoriaActual);
            await context.SaveChangesAsync();
        }
    }

}

public interface IProveedorService{
    IEnumerable<Proveedor> Get();

    Task Save(Proveedor proveedor);
    
    Task Update(Guid id, Proveedor proveedor);

    Task Delete(Guid id);
}