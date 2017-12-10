﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chapter6_EssentialTools.Models
{
    public interface IValueCalculator    
    {
        decimal ValueProducts(IEnumerable<Product> products);
    }
}