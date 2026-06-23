
using Microsoft.AspNetCore.Mvc;
namespace FIRSTAPI.Controllers{
    
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase{
        
        private static List<string> _products_ = new List<string>()
        {
            "Kulaklik",
            "Laptop",        
            "Klavye"    
        };
     
        [HttpGet]
        public IActionResult GetAllProducts(){
                return Ok(_products_);
        }
        [HttpGet("{index}")]
        public IActionResult GetByIndex(int index){
            if(index < 0 || index >= _products_.Count){
                return NotFound($"{index} indexx bulunamadı.Toplam ürün {_products_.Count}");
            }
            return Ok(_products_[index]);
        }
        [HttpPost]
        public ActionResult<string> Create([FromBody] string prdouctsName){
            if(string.IsNullOrEmpty(prdouctsName)){
                return BadRequest("Ürün ismi boş olamaz.");
            }
            _products_.Add(prdouctsName);
            return CreatedAtAction(nameof(GetByIndex), new { index = _products_.Count-1 }, prdouctsName);
        }
        [HttpPut("{index}")]
         public IActionResult Update(int index){
            if(index < 0 || index >= _products_.Count){
                return NotFound($"[index] indexx bulunamadı.Toplam ürün {_products_.Count}");
            }
            return NoContent();
        }
        [HttpDelete("{index}")]
         public IActionResult Delete(int index){
            if(index < 0 || index >= _products_.Count){
                return NotFound($"[index] indexx bulunamadı.Toplam ürün {_products_.Count}");
            }
            _products_.RemoveAt(index);
            return NoContent();
        }
    }

} 
