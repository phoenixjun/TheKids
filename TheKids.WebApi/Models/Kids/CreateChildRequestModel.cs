
using System;
using System.ComponentModel.DataAnnotations;

namespace TheKids.WebApi.Models.Kids
{
    public class CreateChildRequestModel
    {
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]        
        public string LastName { get; set; }

        [Required]
        [MaxLength(100)]        
        public string MiddleName { get; set; }
        

        public DateTime BirthDay { get; set; }    
        
    }
}