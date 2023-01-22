
using GundamApi.Models;
using GundamApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace GundamApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GundamsController : ControllerBase
{
    private readonly GundamsService _gundamsService;

    public GundamsController(GundamsService gundamsService) =>
        _gundamsService = gundamsService;

    [HttpGet]
    public async Task<List<Gundam>> Get() =>
        await _gundamsService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Gundam>> Get(string id)
    {
        var gundam = await _gundamsService.GetAsync(id);

        if (gundam is null)
        {
            return NotFound();
        }

        return gundam;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Gundam newGundam)
    {
        await _gundamsService.CreateAsync(newGundam);

        return CreatedAtAction(nameof(Get), new { id = newGundam.Id }, newGundam);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Gundam updatedGundam)
    {
        var gundam = await _gundamsService.GetAsync(id);

        if (gundam is null)
        {
            return NotFound();
        }

        updatedGundam.Id = gundam.Id;

        await _gundamsService.UpdateAsync(id, updatedGundam);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var gundam = await _gundamsService.GetAsync(id);

        if (gundam is null)
        {
            return NotFound();
        }

        await _gundamsService.RemoveAsync(id);

        return NoContent();
    }
}