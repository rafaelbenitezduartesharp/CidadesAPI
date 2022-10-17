using CidadeAPI.Context;
using CidadeAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CidadeAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CidadesGeralController : ControllerBase
    {
        private readonly CidadesContext _context;

        public CidadesGeralController(CidadesContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create(Cidades cidades)
        {
            _context.Add(cidades);
            _context.SaveChanges();
            return Ok(cidades);
            //return CreatedAtAction(nameof(ObterPorId), new { id = cidades.Id }, cidades);
        }

        [HttpGet("{id})")]
        public IActionResult ObterPorId(int id)
        {
            var cidades = _context.Cidade.Find(id);

            if (cidades == null)
                return NotFound();

            return Ok(cidades);

        }

        [HttpPut("{id})")]
        public IActionResult Atualizar(int id, Cidades cidades)
        {
            var cidadesBanco = _context.Cidade.Find(id);

            if (cidadesBanco == null)
                return NotFound();

            cidadesBanco.Nome = cidades.Nome;
            cidadesBanco.Telefone = cidades.Telefone;
            cidadesBanco.Ativo = cidades.Ativo;

            _context.Cidade.Update(cidadesBanco);
            _context.SaveChanges();

            return Ok(cidadesBanco);
        }

        [HttpDelete]
        public IActionResult Deletar(int id)
        {

            var cidadesBanco = _context.Cidade.Find(id);

            if (cidadesBanco == null)
                return NotFound();

            _context.Cidade.Remove(cidadesBanco);
            _context.SaveChanges();
            return Ok(cidadesBanco);
        }

        [HttpGet("ObterPorNome")]
        public IActionResult ObterPorNome(string nome)
        {
            var cidades = _context.Cidade.Where(x => x.Nome.Contains(nome));

            return Ok(cidades);
        }
    }
}