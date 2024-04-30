

using API_Rest_SuperMercado.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_Rest_SuperMercado;

[Route("api/[controller]")]
public class ProductoController: ControllerBase{
    IProductoService productoService;

    public ProductoController(IProductoService service){
        productoService = service;
    }

    public IActionResult Get(){
        return Ok(productoService.Get());
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Producto producto){
        await productoService.Save(producto);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] Producto producto){
        await productoService.Update(id,producto);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id){
        await productoService.Delete(id);
        return Ok();
    }
}