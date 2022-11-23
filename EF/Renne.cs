using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAspNet.EF
{
    public class Renne
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public Boolean Ativo { get; set; }
        public String Sexo { get; set; }

    }
}
