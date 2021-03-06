namespace MollisHome.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class PromoCode : BaseModel
    {
        public string Code { get; set; }
        public bool IsUsed { get; set; }
        public int DiscountPercentage { get; set; }
        public DateTime ExpirationDateStart { get; set; }
        public DateTime ExpirationDateEnd { get; set; }

        //------------ Order [FK] - ONE-TO-ONE -----------
        [Required]
        public int? OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}
