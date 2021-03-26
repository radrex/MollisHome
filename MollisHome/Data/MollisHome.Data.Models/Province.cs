namespace MollisHome.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Province : BaseModel
    {
        //-------------- PROPERTIES ---------------
        [Required]
        public string Name { get; set; }

        //------------ City [FK] - ONE-TO-MANY -----------
        public virtual ICollection<City> Cities { get; set; }
    }
}
