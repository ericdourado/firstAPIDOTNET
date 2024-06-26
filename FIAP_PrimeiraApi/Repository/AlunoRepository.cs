using FIAP_PrimeiraApi.Interfaces;
using FIAP_PrimeiraApi.Models;

namespace FIAP_PrimeiraApi.Repository
{
    public class AlunoRepository : IAlunoCadastro
    {
        public List<Aluno> listaAlunos { get; set; }

        public AlunoRepository()
        {
            this.listaAlunos = new List<Aluno>();  
        }
        public Aluno AtutualizaAluno(Aluno dadosAluno)
        {
            Aluno aluno = listaAlunos.FirstOrDefault(a => a.Id == dadosAluno.Id);
            aluno.Name = dadosAluno.Name;
            aluno.Idade = dadosAluno.Idade;
            aluno.Endereco = dadosAluno.Endereco;
            return aluno;
        }

        public Aluno CriarAluno(Aluno dadosAluno)
        {
            dadosAluno.Id = listaAlunos.Select(x => x.Id).Any() ? listaAlunos.Max(m => m.Id) + 1 : 1;
            listaAlunos.Add(dadosAluno);
            return dadosAluno;
            
        }

        public void DeletarAluno(int id)
        {
            Aluno aluno = listaAlunos.FirstOrDefault(x => x.Id == id);
             if (aluno != null)
            {
                listaAlunos.Remove(aluno);
            }

        }

        public IEnumerable<Aluno> ListarAlunos()
        {
            return this.listaAlunos;
        }


    }
}
