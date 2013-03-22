using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaVendas.Model
{
    public class Usuario
    {
        public virtual int usuario_id { get; set; }
        public virtual String login { get; set; }
        public virtual String senha { get; set; }
    }


}
