namespace MollisHome.Data.Models
{
    using System;

    public class PromoCode : BaseModel
    {
        public string Code { get; set; }
        public bool IsUsed { get; set; }
        public byte DiscountPercentage { get; set; }
        public DateTime ExpirationDateStart { get; set; }
        public DateTime ExpirationDateEnd { get; set; }

        //------------ Order [FK] - ONE-TO-ONE -----------
        public virtual Order Order { get; set; }
    }
}
