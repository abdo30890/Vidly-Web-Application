using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace Vidly.Wep.App.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public short SingUpFree { get; set; }
        public byte DurationInMonth { get; set; }
        public byte DiscountRate { get; set; }

    }
}