using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaVendas
{
    public class CalculadoraComissao
    {
        public static decimal Calcula(decimal venda)
        {
            decimal comissao;

            if (venda > 10000)
            {
                comissao = venda * 0.06m;
            }
            else
            {
                comissao = venda * 0.05m;
            }

            comissao = (Math.Floor(comissao * 100.0m))/100.0m;
            return comissao;
        }
    }
}
