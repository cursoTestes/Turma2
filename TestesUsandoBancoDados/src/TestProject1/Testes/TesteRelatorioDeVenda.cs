using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using MbUnit.Framework;
using SistemaVendas.Negocio;
using NHibernate;

namespace TestProject1.Testes
{
    [TestFixture]
    public class TesteRelatorioDeVenda : TesteBase
    {

        [Test]
        public void teste_consulta_vendedor_inexistente()
        {
            ISession session = Contexto.SessionFactory.OpenSession();
            RelatorioVendasRepository relatorioVendas = new RelatorioVendasRepository(session);

            decimal valorEsperado = 0;
            int idVendedor = 9999;
            int ano = 2011;

            decimal valorAnual = relatorioVendas.ObterVendaAnualVendedor(idVendedor, ano);

            Assert.AreEqual(valorEsperado, valorAnual);
        }

        [Test]
        public void teste_consulta_vendedor_com_1_venda()
        {
            ISession session = Contexto.SessionFactory.OpenSession();
            RelatorioVendasRepository relatorioVendas = new RelatorioVendasRepository(session);

            decimal valorEsperado = 100;
            int idVendedor = 1;
            int ano = 2011;

            decimal valorAnual = relatorioVendas.ObterVendaAnualVendedor(idVendedor, ano);

            Assert.AreEqual(valorEsperado, valorAnual);
        }

        [Test]
        public void teste_consulta_vendedor_com_n_vendas_ano()
        {
            ISession session = Contexto.SessionFactory.OpenSession();
            RelatorioVendasRepository relatorioVendas = new RelatorioVendasRepository(session);

            decimal valorEsperado = 210;
            int idVendedor = 2;
            int ano = 2011;

            decimal valorAnual = relatorioVendas.ObterVendaAnualVendedor(idVendedor, ano);

            Assert.AreEqual(valorEsperado, valorAnual);
        }

        [Test]
        public void teste_consulta_vendedor_com_vendas_mais_de_1_ano()
        {
            ISession session = Contexto.SessionFactory.OpenSession();
            RelatorioVendasRepository relatorioVendas = new RelatorioVendasRepository(session);

            decimal valorEsperado = 400;
            int idVendedor = 3;
            int ano = 2013;

            decimal valorAnual = relatorioVendas.ObterVendaAnualVendedor(idVendedor, ano);

            Assert.AreEqual(valorEsperado, valorAnual);
        }

        [Test]
        public void teste_consulta_vendedor_com_1_venda_compartilhada()
        {
            ISession session = Contexto.SessionFactory.OpenSession();
            RelatorioVendasRepository relatorioVendas = new RelatorioVendasRepository(session);

            decimal valorEsperado = 400;
            int idVendedor = 4;
            int ano = 2013;

            decimal valorAnual = relatorioVendas.ObterVendaAnualVendedor(idVendedor, ano);

            Assert.AreEqual(valorEsperado, valorAnual);
        }

        [Test]
        public void teste_consulta__vendedor_com_1_venda_compartilhada_sozinha()
        {
            ISession session = Contexto.SessionFactory.OpenSession();
            RelatorioVendasRepository relatorioVendas = new RelatorioVendasRepository(session);

            decimal valorEsperado = 1100;
            int idVendedor = 5;
            int ano = 2013;

            decimal valorAnual = relatorioVendas.ObterVendaAnualVendedor(idVendedor, ano);

            Assert.AreEqual(valorEsperado, valorAnual);
        }
    }
}
