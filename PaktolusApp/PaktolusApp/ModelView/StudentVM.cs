using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using PaktolusApp.Models;

namespace PaktolusApp.ModelView
{
	public class StudentVM
	{
        public int Id { get; set; }

        [Required]
        [DisplayName("Full Name")]
        [MaxLength(50)]
        public string Name { get; set; } = null!;
        [Required]
        [DisplayName("E-mail")]
        [MaxLength(50)]
        public string Email { get; set; } = null!;
        [Required]
        [DisplayName("Phone")]
        [MaxLength(10, ErrorMessage = "Phone must be a number of 10 digits")]
        [MinLength(10, ErrorMessage = "Phone must be a number of 10 digits")]
        public string Phone { get; set; } = null!;
        [Required]
        [DisplayName("ZipCode")]
        [MinLength(5, ErrorMessage = "ZipCode must be a number of 5 digits")]
        [MaxLength(5, ErrorMessage = "ZipCode must be a number of 5 digits")]
        public string ZipCode { get; set; } = null!;
        [Required]
        [DisplayName("Hobbies")]
        public string hobbiesName { get; set; } = null!;

        public List<int> HobbiesId { get; set; } = new List<int>();

        public virtual List<Hobby> Hobbies { get; set; } = new List<Hobby>();

    }
}

