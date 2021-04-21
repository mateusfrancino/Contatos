using System;
using System.Collections.Generic;
using System.Text;

namespace teste
{  
    public class Contato
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Numero { get; set; }
        public TipoRelacionamento TipoRelacionamento { get; set; }
    }
}
