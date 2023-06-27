﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelPickerApp.Models;
using TravelPickerApp.Models.CityControllerModels;
using TravelPickerApp.Models.GeoSearch;
using TravelPickerApp.Services;

namespace TravelPickerApp.Controllers;
[ApiController]
[Route("api/v1/city")]
public class CityController:Controller
{
    private readonly GeoSearchService _geoSearchService;
    private readonly ILogger<CityController> _logger;
    public CityController(GeoSearchService geoSearchService, ILogger<CityController> logger)
    {
        _geoSearchService = geoSearchService;
        _logger = logger;
    }

    [HttpGet("getRandomCity")]
    [Authorize(policy: AppConstants.AuthPolicies.UserOrAbove)]
    public async Task<IActionResult> GetRandomCity([FromQuery]string countryCode)
    {
        try
        {
            var res = await _geoSearchService.GetRandomCityInCountry(countryCode);
            return Ok(res);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex,"Exception throw in GetRandomCity controller method");
            return StatusCode(500);
        }
    }
}