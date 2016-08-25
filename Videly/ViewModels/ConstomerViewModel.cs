﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Videly.Models;

namespace Videly.ViewModels
{
    public class ConstomerViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}