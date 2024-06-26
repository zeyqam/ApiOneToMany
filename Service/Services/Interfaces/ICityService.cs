﻿using Domain.Entities;
using Service.DTOs.Admin.Cities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface ICityService
    {
        Task<IEnumerable<CityDto>> GetAll();
    }
}
