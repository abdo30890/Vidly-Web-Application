using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Wep.App.Models;

namespace Vidly.Wep.App.DTO
{
    public class NewRentalDto
    {
       
        public int CustomerId { get; set; }
       
        public List<int> MovieIds { get; set; }
        
    }
}