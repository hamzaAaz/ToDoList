using System.ComponentModel.DataAnnotations;

namespace ToDoListWeb.Models
{
    public class Category
    {
        [Key]
        public int id { get; set; }
        [Required]  
        public string Name { get; set; }
      
        public DateTime CreateDateTime1 { get; set; }
        public DateTime CreateDateTime { get; set; }

        public Category()
        {

        }
    }
}
