using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Moq;
using SistemaVendas;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TesteVendas
{
    [TestClass]
    public class TesteCalculoRoyalties
    {
        [TestMethod]
        public void teste_calcula_royalties_sem_venda()
        {
            int mes = 1;
            int ano = 2012;
            decimal royaltiesEsperados = 0.0m;
            List<decimal> vendas = new List<decimal>();

            Mock<IVendasRepository> mockRepository = new Mock<IVendasRepository>();
            mockRepository.Setup(tmp => tmp.GetVendas(mes, ano)).Returns(vendas);

            Mock<CalculadoraComissao> mockCalculadoraComissao = new Mock<CalculadoraComissao>();
            mockCalculadoraComissao.Setup(tmp => tmp.Calcula(It.IsAny<decimal>())).Returns(0);

            CalculadoraRoyalties cr = new CalculadoraRoyalties(mockRepository.Object, mockCalculadoraComissao.Object);
            decimal valorObtido = cr.calcula(mes, ano);

            Assert.AreEqual(royaltiesEsperados, valorObtido);
        }

        [TestMethod]
        public void teste_calcula_royalties_1_venda()
        {
            int mes = 1;
            int ano = 2012;
            decimal royaltiesEsperados = 20.0m;
            List<decimal> vendas=new List<decimal>() { 100 };

            Mock<IVendasRepository> mockRepository = new Mock<IVendasRepository>();
            mockRepository.Setup(tmp => tmp.GetVendas(mes, ano)).Returns(vendas);

            Mock<CalculadoraComissao> mockCalculadoraComissao = new Mock<CalculadoraComissao>();
            mockCalculadoraComissao.Setup(tmp => tmp.Calcula(It.IsAny<decimal>())).Returns(0);

            CalculadoraRoyalties cr = new CalculadoraRoyalties(mockRepository.Object, mockCalculadoraComissao.Object);

            decimal valorObtido = cr.calcula(mes, ano);

            Assert.AreEqual(royaltiesEsperados, valorObtido);
        }

        [TestMethod]
        public void teste_calcula_royalties_1_venda_com_decimal()
        {
            int mes = 1;
            int ano = 2012;
            decimal royaltiesEsperados = 0.2m;
            List<decimal> vendas = new List<decimal>() { 1 };

            Mock<IVendasRepository> mockRepository = new Mock<IVendasRepository>();
            mockRepository.Setup(tmp => tmp.GetVendas(mes, ano)).Returns(vendas);

            Mock<CalculadoraComissao> mockCalculadoraComissao = new Mock<CalculadoraComissao>();
            mockCalculadoraComissao.Setup(tmp => tmp.Calcula(It.IsAny<decimal>())).Returns(0);

            CalculadoraRoyalties cr = new CalculadoraRoyalties(mockRepository.Object, mockCalculadoraComissao.Object);

            decimal valorObtido = cr.calcula(mes, ano);

            Assert.AreEqual(royaltiesEsperados, valorObtido);

            mockCalculadoraComissao.Verify(tmp => tmp.Calcula(It.IsAny<decimal>()), Times.AtLeastOnce());
        }
    }
}





//Mock<IVendasRepository> mockRepository = new Mock<IVendasRepository>();
//mockRepository.Setup(tmp => tmp.GetVendas(0, 0)).Returns(new List<IVenda>;
