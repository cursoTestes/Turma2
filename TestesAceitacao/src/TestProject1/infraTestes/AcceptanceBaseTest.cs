using MbUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using System;

namespace TestProject1
{
    public abstract class AcceptanceBaseTest 
    {

        public IWebDriver driver;
        public string baseURL;
        

        [SetUp]
        public virtual void TestInitialize() 
        {
            driver = new ChromeDriver();
            baseURL = "http://localhost:58034";
        
            OperacoesDeTestes.CarregarBancoDeDados(ConfiguracaoDeTestes.Esquema, ConfiguracaoDeTestes.DadosDeTeste);
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            
        }
    }
    

}