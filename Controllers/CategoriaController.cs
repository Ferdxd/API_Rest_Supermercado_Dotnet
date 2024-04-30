
using API_Rest_Supermercado.Models;
using API_Rest_SuperMercado.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_Rest_SuperMercado.Controllers;

[Route("api/[controller]")]
    public class CategoriaController : ControllerBase{
        ICategoriaService categoriaService;

        public CategoriaController(ICategoriaService service){
            categoriaService=service;
        }

        public IActionResult Get(){
            return Ok(categoriaService.Get());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Categoria categoria){
            await categoriaService.Save(categoria);
            return Ok();
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Put(Guid id, [FromBody] Categoria categoria){
            await categoriaService.Update(id, categoria);
            return Ok();
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(Guid id){
            await categoriaService.Delete(id);
            return Ok();
        }
    }
