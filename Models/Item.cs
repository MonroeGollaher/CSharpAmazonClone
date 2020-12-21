namespace Amazen.Models
{
    public class Item
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public decimal SalePrice { get; set; }
        public int Quantity { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsPublished { get; set; }
        public int Id { get; set; }
        public string CreatorId { get; set; }
        public Profile Creator { get; set; }
    }
    public class ListItemViewModel : Item
    {
        public int ListItemId { get; set; }
    }
}