﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcCRUD1.Models
{
    public class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }
    }
}