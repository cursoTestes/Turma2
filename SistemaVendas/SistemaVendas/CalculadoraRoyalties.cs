using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaVendas
{
    public class CalculadoraRoyalties
    {
        private IVendasRepository vendasRepo;
        private CalculadoraComissao calc;
        public CalculadoraRoyalties( IVendasRepository vendasRepo, CalculadoraComissao calc)
        {
            this.vendasRepo = vendasRepo;
            this.calc = calc;
        }

        public decimal calcula(int mes, int ano)
        {
            List<decimal> vendas = vendasRepo.GetVendas(mes, ano);
            if(!vendas.Any())
            return 0;

            decimal retorno = 0;

            retorno = (vendas[0]-calc.Calcula(vendas[0])) * 0.2m;

            return retorno;

        }
    }
}
