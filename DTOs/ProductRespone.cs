using System.ComponentModel.DataAnnotations;

namespace FIRSTAPI.DTOs
{
    public class ProductResponse
    {
        public int Id{get;set;}     
        public string Name{get;set;} = string.Empty;  

        public string Description{get; set;} = string.Empty;

        public decimal Price{get;set;}
    }

}