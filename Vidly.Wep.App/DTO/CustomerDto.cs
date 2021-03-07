using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Wep.App.Models;

namespace Vidly.Wep.App.DTO
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToCustomer { get; set; }

        [AgeValidation18YearOld]
        public DateTime? BirthDate { get; set; }

        public byte MembershipTypeId { get; set; }
    }
}