namespace Amazen.Models
{
    public class ListItem
    {
        public int ListId { get; set; }
        public int ItemId { get; set; }
        public int Id { get; set; }
        public string CreatorId { get; set; }
        public Profile Creator { get; set; }
    }
}