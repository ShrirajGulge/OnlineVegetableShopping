using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BOL
{

    // POCO Object  : Plain Old CLR Object
    //First Step : Apply Data Constraints to POCO

    public class Customer
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Gender { get; set; }

        [Range(18,56,ErrorMessage ="Age must be in between 18 to 56")]
        public int Age { get; set; }

        [Required]
        public string Location { get; set; }
       
        [Required]
        public string PhoneNumber { get; set; }
       
        [Required]
        public string Role { get; set; }
        
        [Display(Name="Email Address")]
        [Required(ErrorMessage ="The email address must be mentioned...")]
        [EmailAddress(ErrorMessage ="Invalid Email Address")]
        public string Email { get; set; }

       public string Password { get; set; }



    }
}
