using System.ComponentModel.DataAnnotations;

namespace TestStore.Models
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string name { get; set; }
       
    }
}
