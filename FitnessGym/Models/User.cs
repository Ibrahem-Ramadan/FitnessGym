using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable enable
namespace FitnessGym.Models
{
    public class User : IdentityUser
    {
        [Required]
        public string FullName { get; set; }
        public string ? Location { get; set; }
        [Required]
        public char Gender { get; set; }    

        [ForeignKey("program")]
        public int? programId { get; set; }
        public Programs? program { get; set; }

        [ForeignKey("subscription")]
        public int? subscriptionId { get; set; }
        public Subscription ?subscription { get; set; }
    }
}
