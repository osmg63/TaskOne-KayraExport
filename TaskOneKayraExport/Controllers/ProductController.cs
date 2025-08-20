using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskOneKayraExport.Dto;
using TaskOneKayraExport.Service;

namespace TaskOneKayraExport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;


        public ProductController(ProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("{id}")]
        public  async Task<IActionResult> GetById(int id) { 
            var data= await _productService.GetById(id);
            return Ok(data);

        }
        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            var data = await _productService.GetAll();
            return Ok(data);

        }
        [HttpPost]
        public async Task<IActionResult> Add(ProductRequestDto dto)
        {
            var data= await _productService.AddAsync(dto);
            return Ok(data);
        }
        [HttpPut]
        public async Task<IActionResult> Update(int id,ProductRequestDto dto)
        {
            var data = await _productService.Update(id,dto);
            return Ok(data);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
           var data= await _productService.Delete(id);
            return Ok(data);

        }


    }
}
