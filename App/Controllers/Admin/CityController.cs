﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Admin.Cities;
using Service.Services.Interfaces;

namespace App.Controllers.Admin
{
    
    public class CityController : BaseController
    {
        private readonly ICityService _cityService;
        private readonly ILogger<CityController> _logger;
        public CityController(ICityService cityservice, ILogger<CityController> logger)
        {
            _cityService = cityservice;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            _logger.LogInformation("GetAll method is working");
            return Ok(await _cityService.GetAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            return Ok(await _cityService.GetByIdAsync(id));
        }
        [HttpGet]
        public async Task<IActionResult> GetByName([FromQuery] string name)
        {
            return Ok(await _cityService.GetByNameAsync( name));
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CityCreateDto request)
        {
            
                await _cityService.CreateAsync(request);
                return CreatedAtAction(nameof(Create), new { response = "Data successfully created" });
            
            
            
        }
    }
}
