using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Services.Interfaces;

namespace App.Controllers.Admin
{
    
    public class CityController : BaseController
    {
        private readonly ICityService _cityService;
        public CityController(ICityService cityservice)
        {
            _cityService = cityservice;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _cityService.GetAll());
        }
    }
}
