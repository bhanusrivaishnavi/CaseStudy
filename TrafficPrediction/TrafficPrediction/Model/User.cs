using System;
using System.ComponentModel.DataAnnotations;
namespace TrafficPrediction.Models
{
    public class User
    {
        public int ID { get; set; }
       
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(12)]
        public string Name { get; set; }
    
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Password is required")]
        [MinLength(8)]
        public string Password { get; set; }
      
       
    }
}