using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace BetterLife.Tests
{
    [TestFixture]
    public class CrearRutinaTests
    {
        private IWebDriver driver;
        private const string BaseUrl = "https://localhost:80/CrearRutina.aspx";
        
        [SetUp]
        public void SetUp()
        {
            // Inicializa Microsoft Edge en modo headless (sin UI)
            var options = new EdgeOptions();
            options.AddArgument("headless");       // Ejecutar sin ventana
            options.AddArgument("disable-gpu");     // Recomendado para modo headless
            driver = new EdgeDriver(options);
            driver.Navigate().GoToUrl(BaseUrl);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void Rutina_Válida_Debería_Guardar_Y_Mostrar_Mensaje_Éxito()
        {
            var rutinaBox = driver.FindElement(By.Id("txtRutina"));
            rutinaBox.Clear();
            rutinaBox.SendKeys("Lunes: Cardio 30min");

            var btn = driver.FindElement(By.Id("btnAgregar"));
            btn.Click();

            var alerta = driver.FindElement(By.Id("lblMensaje"));
            Assert.That(alerta.Text, Does.Contain("éxito"), "No se mostró mensaje de éxito.");
        }

        [Test]
        public void Rutina_Vacía_Debería_Mostrar_Error()
        {
            var rutinaBox = driver.FindElement(By.Id("txtRutina"));
            rutinaBox.Clear();
            driver.FindElement(By.Id("btnAgregar")).Click();

            var alerta = driver.FindElement(By.Id("lblMensaje"));
            Assert.That(alerta.Text, Does.Contain("obligatorio"), "No se mostró mensaje de campo obligatorio.");
        }
    }
}
