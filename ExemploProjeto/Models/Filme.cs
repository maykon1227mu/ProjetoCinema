using System.Security.Cryptography.X509Certificates;

namespace ProjetoCinema.Models
{
    public class Filme
    {
        public int idFilme { get; set; }

        public string tituloFilme { get; set; }

        public string generoFilme { get; set; }

        public Diretor Diretor { get; set; }

        public int IdDiretor { get; set; }

        public ICollection<Premiacao> PremioFilme { get; set; }
    }
}
