using Microsoft.AspNetCore.Mvc;

namespace CidadeAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CidadesmsController : ControllerBase
    {
        [HttpGet("HoraAtualdeMS")]
        public IActionResult ObterDataHora()
        {
            var obj = new
            {
                Data = DateTime.Now.ToLongDateString(),
                Hora = DateTime.Now.ToShortTimeString()
            };
            return Ok(obj);
        }

        [HttpGet("Apresentar/{nome}")]
        public IActionResult Apresentar(string nome)
        {
            var mensagem = $"Olá {nome}, seja bem vindo em AQUIDAUANA MS";
            return Ok(new { mensagem });
        }
    }
}