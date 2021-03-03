namespace MollisHome.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public abstract class BaseModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
