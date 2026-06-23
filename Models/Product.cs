namespace FIRSTAPI.Models
{
    public class Product
    {
        public int No{get; set;}
        public string Name{get; set;} = string.Empty;
        public string Description{get; set;} = string.Empty;
        public int  Price{get;set;} 
        public int stock{get;set;}
        public DateTime createdDate{get;set;} = DateTime.UtcNow;
    }
}