namespace Amazen.Models
{
    public class List
    {
      public string Title { get; set; }
      public bool IsPublished { get; set; }
      public int Id { get; set; }
      public string CreatorId { get; set; }  
      public Profile Creator { get; set; }
    }
}