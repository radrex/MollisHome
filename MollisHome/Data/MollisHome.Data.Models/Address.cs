namespace MollisHome.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Address : BaseModel
    {
        //-------------- PROPERTIES ---------------
        [Required]
        public string Name { get; set; }

        public bool IsCourierAddress { get; set; }

        //------------ City [FK] - ONE-TO-MANY -----------
        [Required]
        public int CityId { get; set; }
        public virtual City City { get; set; }

        //------------ Order [FK] - ONE-TO-MANY -----------
        public virtual ICollection<Order> Orders { get; set; }
    }
}
