using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS_ED1I4_20231109.Models
{
    internal class EmprestimoModel
    {
        private readonly DateTime? _dtEmprestimo;
        private readonly DateTime? _dtDevolucao;

        public DateTime? DtEmprestimo { get { return _dtEmprestimo;} }
        public DateTime? DtDevolucao { get {  return _dtDevolucao;} }

        public EmprestimoModel(DateTime? dtEmprestimo, DateTime? dtDevolucao)
        {
            _dtEmprestimo = dtEmprestimo;
            _dtDevolucao = dtDevolucao;
        }
    }
}
