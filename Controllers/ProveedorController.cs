using System.Runtime.InteropServices;
using API_Rest_SuperMercado.Models;
using API_Rest_SuperMercado.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_Rest_SuperMercado.Controllers{
    [Route("api/[controller]")]

    public class ProveedorController: ControllerBase{
        IProveedorService proveedorService;

        public ProveedorController(IProveedorService service){
            proveedorService=service;
        }

        public IActionResult Get(){
            return Ok(proveedorService.Get());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Proveedor proveedor){
            await proveedorService.Save(proveedor);
            return Ok();
        }

        [HttpPost("{id}")]

        public async Task<IActionResult> Put(Guid id, [FromBody] Proveedor proveedor){
            await proveedorService.Update(id,proveedor);
            return Ok();
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(Guid id){
            await proveedorService.Delete(id);
            return Ok();
        }
    }
}