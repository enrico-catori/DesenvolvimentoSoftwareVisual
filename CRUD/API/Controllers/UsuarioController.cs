using Microsoft.AspNetCore.Mvc;
using API.Models;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("api/funcionario")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private static List<Funcionario> funcionarios  = new List<Funcionario>();

        //GET: /api/funcionario/listar
        [HttpGet]
        [Route("listar")]
        public IActionResult Listar()
        {
            return Ok(funcionarios);
        }

        // POST: /api/funcionario/cadastrar
        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar(
            [FromBody] Funcionario funcionario)
        {
            funcionarios.Add(funcionario);
            return Created("", funcionario);
        }

        //GET: /api/funcionario/buscar/{nome}
        [HttpGet]
        [Route("buscar/{nome}")]
        public IActionResult Buscar([FromRoute] string nome)
        {
            for (int i = 0; i < funcionarios.Count; i++)
            {
                if(funcionarios[i].Nome.Equals(nome))
                {
                    return Ok(funcionarios[i]);
                }
            }
            return NotFound();
        }

        //Post: /api/funcionario/excluir/{cpf}
        [HttpPost]
        [Route("excluir/{cpf}")]
        public bool Excluir([FromRoute] int cpf) 
        {
            for (int i = 0; i < funcionarios.Count; i++)
            {
                if(funcionarios[i].Cpf == cpf)
                {
                    funcionarios.Remove(funcionarios[i]);
                    return true;
                }
            }
            return false;
        }

        [HttpPost]
        [Route("editar/{cpf}")]
        public bool Editar([FromRoute] int cpf, [FromBody] Funcionario funcionario)
        {
            for (int i = 0; i < funcionarios.Count; i++)
            {
                if(funcionarios[i].Cpf == cpf)
                {
                    funcionarios[i].Nome = funcionario.Nome;
                    funcionarios[i].DataNascimento = funcionario.DataNascimento;
                    return true;
                }
            }
            return false;
        }
    }
}