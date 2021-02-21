﻿namespace MollisHome.Data.Models
{
    using System;

    public interface IAuditable
    {
        DateTime CreatedOn { get; set; }
        DateTime? ModifiedOn { get; set; }
    }
}
