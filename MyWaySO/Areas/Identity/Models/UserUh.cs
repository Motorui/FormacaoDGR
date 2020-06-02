using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MyWaySO.Areas.Identity.Models
{
    public class UserUh
    {
        [Key]
        public Guid UserUhID { get; set; }
        public Guid UhID { get; set; }
        public Uh Uh { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
