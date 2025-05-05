using System;

namespace Biblioteca_
{
    public class Livro
    {
        private string _titulo;
        private string _autor;
        private int _ano;
        private string _genero;

        public string Titulo
        {
            get { return _titulo; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Título não pode ser vazio.");
                _titulo = value;
            }
        }

        public string Autor
        {
            get { return _autor; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Autor não pode ser vazio.");
                _autor = value;
            }
        }

        public int Ano
        {
            get { return _ano; }
            private set
            {
                if (value < 1450 || value > DateTime.Now.Year)
                    throw new ArgumentOutOfRangeException("Ano deve estar entre 1450 e o ano atual.");
                _ano = value;
            }
        }

        public string Genero
        {
            get { return _genero; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Gênero não pode ser vazio.");
                _genero = value;
            }
        }

        public Livro(string titulo, string autor, int ano, string genero)
        {
            Titulo = titulo;
            Autor = autor;
            Ano = ano;
            Genero = genero;
        }

        public override string ToString()
        {
            return $"{Titulo} - {Autor} ({Ano}) [{Genero}]";
        }
    }
}
