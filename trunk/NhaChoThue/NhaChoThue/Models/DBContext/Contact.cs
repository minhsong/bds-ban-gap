using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NhaChoThue.Models.DBContext
{
    public class Contact:BaseModel
    {
        public int ContactID { get; set; }
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }
        [Required]
        [MaxLength(50)]
        public string Phone { get; set; }
        [DataType(System.ComponentModel.DataAnnotations.DataType.EmailAddress)]
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(200)]
        public string Address { get; set; }
    }
}