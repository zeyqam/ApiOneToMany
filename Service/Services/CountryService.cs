﻿using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Repository.Repositories.Interfaces;
using Service.DTOs.Admin.Countries;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepoSitory _countryRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<CountryService> _logger;
        public CountryService(ICountryRepoSitory countryRepo, IMapper mapper,ILogger<CountryService> logger)
        {
            _countryRepo = countryRepo;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task CreateAsync(CountryCreateDto model)
        {
            if (model == null) throw new ArgumentNullException();

            await _countryRepo.CreateAsync(_mapper.Map<Country>(model));


        }

        public async Task DeleteAsync(int? id)
        {
            if (id is null)
            {
                _logger.LogWarning("Id is null");
                throw new ArgumentNullException();
            }
            var existCountry = await _countryRepo.GetByIdAsync((int)id);
            if (existCountry == null)
            {
                _logger.LogWarning("Data not found ");
                throw new NullReferenceException();
            }
            await _countryRepo.DeleteAsync(existCountry);

        }

        public async Task EditAsync(int? id, CountryEditDto model)
        {
            ArgumentNullException.ThrowIfNull(nameof(id));
            var existCountry = await _countryRepo.GetByIdAsync((int)id);
            if (existCountry == null) throw new KeyNotFoundException("Country not found");

            _mapper.Map(model, existCountry);
            await _countryRepo.UpdateAsync(existCountry);
        }

        public async Task<IEnumerable<CountryDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<CountryDto>>(await _countryRepo.GetAllAsync());
        }

        public async Task<CountryDto> GetByIdAsync(int? id)
        {
            if(id is null) throw new ArgumentNullException();
            var existCountry=await _countryRepo.GetByIdAsync((int)id);
            if (existCountry == null) throw new NullReferenceException();
            return _mapper.Map<CountryDto>(existCountry);
        }
    }
}
