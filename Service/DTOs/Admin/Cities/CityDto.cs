﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.Admin.Cities
{
    public class CityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Population { get; set; }
        public string CountryName { get; set; }
    }
}
