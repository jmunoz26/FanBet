using System;
using FanBet.Backend.Data;
using FanBet.Shared.Entites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FanBet.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CountriesController(DataContext context) : ControllerBase
{
  private readonly DataContext _context = context;

  [HttpGet]
  public async Task<IActionResult> GetAsync()
  {
    return Ok(await _context.Countries.ToListAsync());
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetAsync(int id)
  {
    var country = await _context.Countries.FindAsync(id);
    if (country == null)
    {
      return NotFound();
    }
    return Ok(country);
  }

  [HttpPut]
  public async Task<IActionResult> PutAsync(Country country)
  {

    var currentCountry = await _context.Countries.FindAsync(country.Id);
    if (currentCountry == null)
    {
      return NotFound();
    }
    currentCountry.Name = country.Name;
    _context.Update(currentCountry);
    await _context.SaveChangesAsync();
    return NoContent();
  }

  [HttpDelete("id")]
  public async Task<IActionResult> DeleteAsync(int id)
  {

    var Country = await _context.Countries.FindAsync(id);
    if (Country == null)
    {
      return NotFound();
    }
    _context.Remove(Country);
    await _context.SaveChangesAsync();
    return NoContent();
  }

  [HttpPost]
  public async Task<IActionResult> PostAsync(Country country)
  {
    _context.Add(country);
    await _context.SaveChangesAsync();
    return Ok(country);
  }
}
