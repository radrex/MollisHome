namespace MollisHome.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class City : BaseModel
    {
        //-------------- PROPERTIES ---------------
        [Required]
        public string Name { get; set; }

        [Required]
        public string PostCode { get; set; }

        //------------ District [FK] - ONE-TO-MANY -----------
        [Required]
        public int ProvinceId { get; set; }
        public virtual Province Province { get; set; }

        //------------ Address [FK] - ONE-TO-MANY -----------
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
