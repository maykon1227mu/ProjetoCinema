namespace ProjetoCinema.Models
{
    public class Diretor
    {
        public int idDiretor { get; set; }   

        public string nomeDiretor { get; set; }

        public string paisDiretor { get; set; }

        public int IdFilme { get; set; }

        public ICollection<Filme> FilmeDiretor { get; set; }

    }
}
