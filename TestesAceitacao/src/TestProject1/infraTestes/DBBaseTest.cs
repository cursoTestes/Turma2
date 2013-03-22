using MbUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using System;

namespace TestProject1
{
    public abstract class DBBaseTest 
    {

        [SetUp]
        public virtual void TestInitialize() 
        {
            OperacoesDeTestes.CarregarBancoDeDados(ConfiguracaoDeTestes.Esquema, ConfiguracaoDeTestes.DadosDeTeste);
        }

    }
    

}