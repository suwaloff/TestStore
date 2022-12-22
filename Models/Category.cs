using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace TestStore.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(1,int.MaxValue, ErrorMessage = "Вы ввели неккоректные данные")]
        public int DisplayOrder { get; set; }
    }
}
