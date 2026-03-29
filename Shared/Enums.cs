namespace Sistema_Biblioteca.Shared
{
    public class Enums
    {
        public enum CategoriaLivro
        {
            Ficção,
            NãoFicção,
            Romance,
            Fantasia,
            Aventura,
            Mistério,
            Biografia,
            História,
            Ciência,
            Tecnologia,
            Autoajuda,
            Infantil
        }

        public enum StatusLivro
        {
            Disponivel,
            Emprestado,
            Devolvido,
            Reservado,
            Atrasado,
            Danificado,
        }
    }
}
