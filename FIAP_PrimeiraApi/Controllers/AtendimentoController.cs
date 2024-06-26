using FIAP_PrimeiraApi.Interfaces;
using FIAP_PrimeiraApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FIAP_PrimeiraApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtendimentoController : ControllerBase
    {
        private readonly IAlunoCadastro _alunoCadastro;

        public AtendimentoController(IAlunoCadastro alunoCadastro)
        {
            _alunoCadastro = alunoCadastro;
        }

        [HttpGet("aluno")]
        public IActionResult GetAlunos() {
            return Ok(_alunoCadastro.ListarAlunos());
        }
        [HttpPost("insereAluno")]
        public IActionResult CriarAluno([FromBody] Aluno aluno)
        {

            Aluno novoAluno = new Aluno
            {
                Name = aluno.Name,
                Idade = aluno.Idade,
                Endereco = aluno.Endereco,
            };

            _alunoCadastro.CriarAluno(novoAluno);

            return Ok(_alunoCadastro.ListarAlunos());

        }
        [HttpPut("atualizaAluno")]
        public IActionResult AtualizaAluno([FromBody] Aluno aluno)
        {
            Aluno alunoAtualizado = new Aluno
            {
                Id = aluno.Id,  
                Name = aluno.Name,
                Idade = aluno.Idade,
                Endereco = aluno.Endereco,
            };
            Aluno alunoParaAtualizar = _alunoCadastro.AtutualizaAluno(alunoAtualizado);



            return Ok(alunoParaAtualizar);
        }

        [HttpDelete("deleteAluno/{id}")]
        public IActionResult DeletarAluno([FromRoute] int id)
        {
            _alunoCadastro.DeletarAluno(id);
            return NoContent();
        }
    }
}
