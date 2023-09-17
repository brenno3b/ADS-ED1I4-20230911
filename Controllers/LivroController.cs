using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS_ED1I4_20231109.Controllers
{
    internal class LivroController
    {
        private readonly int _isbn;
        private readonly string _titulo;
        private readonly string _autor;
        private readonly string _editora;
        private readonly List<ExemplarController> _exemplares;

        public int Isbn { get { return _isbn; } }
        public string Titulo { get { return _titulo; } }
        public string Autor { get { return _autor; } }
        public string Editora { get { return _editora; } }
        public List<ExemplarController> Exemplares { get { return _exemplares; } }

        public LivroController(int isbn, string titulo, string autor, string editora)
        {
            _isbn = isbn;
            _titulo = titulo;
            _autor = autor;
            _editora = editora;
            _exemplares = new List<ExemplarController>();
        }

        public LivroController(int isbn)
        {
            _isbn = isbn;
            _titulo = "";
            _autor = "";
            _editora = "";
            _exemplares = new List<ExemplarController>();
        }

        public LivroController()
        {
            _isbn = -1;
            _titulo = "";
            _autor = "";
            _editora = "";
            _exemplares = new List<ExemplarController>();
        }

        public void AdicionarExemplar(ExemplarController exemplar) { 
            _exemplares.Add(exemplar);
        }

        public int QtdeExemplares() { return _exemplares.Count;}
        public int QtdeDisponiveis()
        {
            int total = 0;

            if (_exemplares.Count == 0) return total;

            foreach (ExemplarController element in _exemplares)
            {
                if (element.Disponivel()) total++;
            }

            return total;
        }

        public double PercDisponibilidade()
        {
            if (_exemplares.Count < 1) return 0;

            return QtdeDisponiveis() / _exemplares.Count;
        }
    }
}
