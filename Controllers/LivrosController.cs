using BibliotecaAPI.Models;
using BibliotecaAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LivrosController : ControllerBase
{
    private readonly LivrosService _livrosService;

    public LivrosController(LivrosService livrosService) =>
        _livrosService = livrosService;

    [HttpGet]
    public async Task<List<Livro>> Get() =>
        await _livrosService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Livro>> Get(string id)
    {
        var livro = await _livrosService.GetAsync(id);

        if (livro is null)
        {
            return NotFound();
        }

        return livro;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Livro newLivro)
    {
        await _livrosService.CreateAsync(newLivro);

        return CreatedAtAction(nameof(Get), new { id = newLivro.Id }, newLivro);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Livro updatedLivro)
    {
        var livro = await _livrosService.GetAsync(id);

        if (livro is null)
        {
            return NotFound();
        }

        updatedLivro.Id = livro.Id;

        await _livrosService.UpdateAsync(id, updatedLivro);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var livro = await _livrosService.GetAsync(id);

        if (livro is null)
        {
            return NotFound();
        }

        await _livrosService.RemoveAsync(id);

        return NoContent();
    }
}