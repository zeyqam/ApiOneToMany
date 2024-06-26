using AutoMapper;
using Domain.Entities;
using Repository.Repositories.Interfaces;
using Service.DTOs.Admin.Cities;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CityService:ICityService
    {
        private readonly ICityRepository _cityRepo;
        private readonly IMapper _mapper;
        public CityService(ICityRepository cityRepo, IMapper mapper)
        {
            _cityRepo = cityRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CityDto>> GetAll()
        {
            return _mapper.Map<IEnumerable<CityDto>>(await _cityRepo.GetAllWithCountry());
        }
    }
}
