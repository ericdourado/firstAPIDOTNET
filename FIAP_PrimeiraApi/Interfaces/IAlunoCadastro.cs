using FIAP_PrimeiraApi.Models;

namespace FIAP_PrimeiraApi.Interfaces
{
    public interface IAlunoCadastro
    {
        //propriedades
        List<Aluno> listaAlunos { get; set; }

        //todas classes herdades devem conter esses metodos
        public IEnumerable<Aluno> ListarAlunos();
        public Aluno CriarAluno(Aluno dadosAluno);
        public Aluno AtutualizaAluno(Aluno dadosAluno);
        public void DeletarAluno(int Id);


    }
}
