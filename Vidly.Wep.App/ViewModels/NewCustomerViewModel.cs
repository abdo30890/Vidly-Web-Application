using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Wep.App.Models;

namespace Vidly.Wep.App.ViewModels
{
    public class NewCustomerViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }

        public Customer Customer { get; set; }
    }
}