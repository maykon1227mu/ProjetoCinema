using System.Security.Cryptography.X509Certificates;

namespace ProjetoCinema.Models
{
    public class Premiacao
    {
        public int idPremiacao { get; set; }

        public int idFilme { get; set; }

        public string tituloFilme { get; set; }


        public Filme Filme { get; set; }



    }
}
