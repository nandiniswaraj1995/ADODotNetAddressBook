using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ADODotNetAddressBook.Model
{
    class ContactModel
    {
        [Required]
        [StringLength(3)]
        [RegularExpression(@"^[a-zA-Z]$")]
        public string firstName { get; set; }
        [Required]
        [StringLength(3)]
        [RegularExpression(@"^[a-zA-Z]$")]
        public string lastName { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        [RegularExpression(@"^[1-9][0-9]{5}$")]
        public string zip { get; set; }
        [RegularExpression(@"^(0|91[ ])?[7-9][0-9]{9}$")]
        public string phoneNumber { get; set; }
       
        [Required]
        [RegularExpression(@"^[a-z0-9A-Z]+([._+-][a-z0-9A-Z]+)*[@][a-z0-9A-Z]+[.][a-zA-Z]{2,3}(.[a-zA-Z]{2,3})?$")]
        public string email { get; set; }
       
    }
}
