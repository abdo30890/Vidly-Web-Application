﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Wep.App.Models;

namespace Vidly.Wep.App.ViewModels
{
    public class RandomMovieViewModel
    {
        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}