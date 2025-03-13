

using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace PlatfromService.Models
{
    public class Platform
    {
        [Key]
        [Required]
        public  int Id { get; set; }
        public required string Name { get; set; }
        public required string Publisher { get; set; }

        public required string Cost { get; set; }
    }
}