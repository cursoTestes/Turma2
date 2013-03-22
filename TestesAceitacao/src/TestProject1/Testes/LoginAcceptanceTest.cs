using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using MbUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SistemaVendas.Negocio;

namespace TestProject1.Testes
{
    [TestFixture]
    public class LoginAcceptanceTest: AcceptanceBaseTest
    {
        [Test]
        public void teste_login_com_sucesso_gera_entrada_na_tabela_sucessoLogin()
        {
            int entradasEsperadasNaTabela = 1 ;
		    String texto_mensagem_logado_com_sucesso = "Welcome, cfc!";
            
		    //act
            driver.Navigate().GoToUrl("http://localhost:8080/AceitacaoComJava/login.seam");

            driver.FindElement(By.Id("loginForm:username")).SendKeys("cfc");
            driver.FindElement(By.Id("loginForm:password")).SendKeys("123456");
            driver.FindElement(By.Id("loginForm:submit")).Click();

            String resultado = driver.FindElement(By.XPath("id('messages')/li[2]")).Text;
            Boolean acheiTextoLogadoSucesso = resultado.Equals(texto_mensagem_logado_com_sucesso);
		   
		    Assert.IsTrue(acheiTextoLogadoSucesso);

            int resultadoEntradasSucessoLog = Contexto.SessionFactory.OpenSession().CreateSQLQuery("select count(*) from SucessoLogin").UniqueResult<int>();
         
		    Assert.AreEqual(entradasEsperadasNaTabela,resultadoEntradasSucessoLog);
        }
        [Test]
        public void teste_login_com_falha_gera_entrada_na_tabela_falhaLogin()
        {
            int entradasEsperadasNaTabela = 1;
            String texto_mensagem_logado_com_falha = "Login failed";

            //act
            driver.Navigate().GoToUrl("http://localhost:8080/AceitacaoComJava/login.seam");

            driver.FindElement(By.Id("loginForm:username")).SendKeys("cfc");
            driver.FindElement(By.Id("loginForm:password")).SendKeys("abc");
            driver.FindElement(By.Id("loginForm:submit")).Click();

            String resultado = driver.FindElement(By.XPath("id('messages')/li[2]")).Text;
            Assert.AreEqual( texto_mensagem_logado_com_falha, resultado);
           
            int resultadoEntradasFalhaLog = Contexto.SessionFactory.OpenSession().CreateSQLQuery("select count(*) from falhaLogin").UniqueResult<int>();

            Assert.AreEqual(entradasEsperadasNaTabela, resultadoEntradasFalhaLog);
        }
    }
}
