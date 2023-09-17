using ADS_ED1I4_20231109.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS_ED1I4_20231109.Controllers
{
    internal class ExemplarController
    {
        private readonly int _tombo;
        private readonly List<EmprestimoModel> _emprestimos;

        public int Tombo { get { return _tombo; } }
        public List<EmprestimoModel> Emprestimos { get { return _emprestimos; } }

        public ExemplarController(int tombo)
        {
            _tombo = tombo;
            _emprestimos = new List<EmprestimoModel>();
        }

        public bool Emprestar()
        {
            int lastElementIndex = _emprestimos.Count - 1;
            if (lastElementIndex > -1)
            {
                if (_emprestimos[lastElementIndex].DtDevolucao == null) return false;
            }

            EmprestimoModel newEmprestimo = new(DateTime.Now, null);

            _emprestimos.Add(newEmprestimo);

            return true;
        }

        public bool Devolver()
        {
            int lastElementIndex = _emprestimos.Count - 1;

            if (lastElementIndex == -1) return false;
            if (_emprestimos[lastElementIndex].DtDevolucao != null) return false;

            EmprestimoModel newEmprestimo = new(
                _emprestimos[lastElementIndex].DtEmprestimo,
                DateTime.Now
                );

            _emprestimos[lastElementIndex] = newEmprestimo;

            return true;
        }

        public bool Disponivel() 
        {
            int lastElementIndex = _emprestimos.Count - 1;

            if (lastElementIndex == -1) return true;
            if (_emprestimos[lastElementIndex].DtDevolucao == null) return false;

            return true;
        }

        public int QtdeEmprestimos() { return _emprestimos.Count;}
    }
}
