using System.ComponentModel.DataAnnotations;

namespace FIRSTAPI.DTOs
{
    public class UpdateProductRequest
    {
        [Required(ErrorMessage="Product name is required.")]
        [StringLength(100, ErrorMessage="Product name cannot exceed 100 characters.")]        
        public string Name{get;set;} = string.Empty;  

        [StringLength(500, ErrorMessage="Product description cannot exceed 500 characters.")]
        public string Description{get; set;} = string.Empty;

        [Range(0.01,5000, ErrorMessage ="Price must be between 0.01 and 5000")]
        public decimal Price{get;set;}
    }

}