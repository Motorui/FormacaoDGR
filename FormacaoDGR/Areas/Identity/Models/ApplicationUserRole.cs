﻿using Microsoft.AspNetCore.Identity;

namespace FormacaoDGR.Areas.Identity.Models
{
    public class ApplicationUserRole : IdentityUserRole<string>
    {
        public ApplicationUserRole() : base() { }
        public virtual ApplicationUser User { get; set; }
        public virtual ApplicationRole Role { get; set; }
    }
}
