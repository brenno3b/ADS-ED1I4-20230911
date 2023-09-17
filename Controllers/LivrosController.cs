using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS_ED1I4_20231109.Controllers
{
    internal class LivrosController
    {
        private readonly List<LivroController> _acervo;

        public List<LivroController> Acervo { get { return _acervo; } }

        public LivrosController()
        {
            _acervo = new List<LivroController>();
        }

        public void Adicionar(LivroController livro)
        {
            _acervo.Add(livro);
        }
        
        public LivroController Pesquisar(LivroController livro)
        {
            int index = _acervo.FindIndex(e => e.Isbn == livro.Isbn);

            if (index == -1) { return new LivroController(); }

            return _acervo.ElementAt(index);
        }
    }
}
