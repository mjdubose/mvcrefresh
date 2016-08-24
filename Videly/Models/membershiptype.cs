using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.Web.Configuration;

namespace Videly.Models
{
    public class Membershiptype
    {   
        public byte Id { get; set; }
        public short SignUpFee { get; set; }
        public short DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }
    }
}