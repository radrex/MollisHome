namespace MollisHome.Data.Models
{
    using System;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser, IAuditable
    {
        //---------------- FIELDS -----------------
        private readonly DateTime now = DateTime.UtcNow;

        //------------- CONSTRUCTORS --------------
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedOn = this.now;
            this.ModifiedOn = this.now;
        }

        public ApplicationUser(string email, string username) : this()
        {
            this.Email = email;
            this.UserName = username;
        }

        //-------------- PROPERTIES ---------------
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        //------------ Cart [FK] - ONE-TO-ONE -----------
        public virtual Cart Cart { get; set; }

        //------------ Order [FK] - ONE-TO-MANY -----------
        public virtual ICollection<Order> Orders { get; set; }
    }
}
