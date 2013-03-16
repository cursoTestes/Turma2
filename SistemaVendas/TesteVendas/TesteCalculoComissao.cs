using Microsoft.VisualStudio.TestTools.UnitTesting;
using SistemaVendas;

namespace TesteVendas
{
    
    [TestClass]
    public class TesteCalculoComissao
    {

        [TestMethod]
        public void teste_venda_de_100_retorna_5()
        {
            decimal venda = 100;
            decimal comissao_esperada = 5;

            decimal comissao = new CalculadoraComissao().Calcula(venda);

            Assert.AreEqual(comissao_esperada, comissao);
        }
        [TestMethod]
        public void teste_venda_de_10000_retorna_500()
        {
            decimal venda = 10000;
            decimal comissao_esperada = 500;

            decimal comissao = new CalculadoraComissao().Calcula(venda);

            Assert.AreEqual(comissao_esperada, comissao);
        }
        [TestMethod]
        public void teste_venda_de_10_retorna_0_reais_50_centavos()
        {
            decimal venda = 10;
            decimal comissao_esperada = 0.5m;

            decimal comissao = new CalculadoraComissao().Calcula(venda);

            Assert.AreEqual(comissao_esperada, comissao);
        }
        [TestMethod]
        public void teste_venda_de_100000_retorna_6000()
        {
            decimal venda = 100000;
            decimal comissao_esperada = 6000;

            decimal comissao = new CalculadoraComissao().Calcula(venda);

            Assert.AreEqual(comissao_esperada, comissao);
        }
        [TestMethod]
        public void teste_venda_de_10001_retorna_600_e_6_centavos()
        {
            decimal venda = 10001;
            decimal comissao_esperada = 600.06m;

            decimal comissao = new CalculadoraComissao().Calcula(venda);

            Assert.AreEqual(comissao_esperada, comissao);
        }
        [TestMethod]
        public void teste_venda_com_comissao_truncando_centavos_para_baixo()
        {
            decimal venda = 55.59m;
            decimal comissao_esperada = 2.77m;

            decimal comissao = new CalculadoraComissao().Calcula(venda);

            Assert.AreEqual(comissao_esperada, comissao);
        }
    }
}
