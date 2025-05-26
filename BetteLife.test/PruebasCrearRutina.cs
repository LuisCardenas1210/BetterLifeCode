using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using System;

namespace BetterLife.Tests
{
    [TestFixture]
    public class CrearRutinaTests
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private const string BaseUrl = "http://localhost/Views/CrearRutina.aspx?id=1";

        [SetUp]
        public void SetUp()
        {
            var options = new EdgeOptions();
            options.AddArgument("headless");
            options.AddArgument("disable-gpu");
            driver = new EdgeDriver(options);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10)); // Espera hasta 10 segundos

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
            rutinaBox.SendKeys("Rutina de Ejercicio  Lunes: Pierna, hacer press banca 3x15 " +
                " Martes: Pecho, Barra con 20Lb  Miercoles: hombro, ejercicio de hombro  " +
                "Jueves: Brazo, ejercicio de brazo  Viernes: Espalda, ejercicio de espalda");

            var btn = driver.FindElement(By.Id("btnAgregar"));
            btn.Click();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var alerta = wait.Until(drv =>
            {
                var element = drv.FindElement(By.Id("lblMensaje"));
                return !string.IsNullOrEmpty(element.Text) ? element : null;
            });
            Assert.That(alerta.Text, Does.Contain("Rutina ingresada"), "No se mostró mensaje de éxito.");

        }

        [Test]
        public void Rutina_Vacía_Debería_Mostrar_Error()
        {
            var rutinaBox = driver.FindElement(By.Id("txtRutina"));
            rutinaBox.Clear();

            driver.FindElement(By.Id("btnAgregar")).Click();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var alertaValidador = wait.Until(drv =>
            {
                var element = drv.FindElement(By.Id("rfvRutina"));
                return element.Displayed && !string.IsNullOrEmpty(element.Text) ? element : null;
            });
            Assert.That(alertaValidador.Text, Does.Contain("El campo rutina es obligatorio"), "No se mostró mensaje de campo obligatorio.");
        }

        [Test]
        public void Rutina_Con_Menos_De_35_Caracteres_Debería_Mostrar_Error()
        {
            var rutinaBox = driver.FindElement(By.Id("txtRutina"));
            rutinaBox.Clear();
            rutinaBox.SendKeys("Rutina Lunes: Pierna");

            driver.FindElement(By.Id("btnAgregar")).Click();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var alertaValidador = wait.Until(drv =>
            {
                var element = drv.FindElement(By.Id("cvRutina"));
                return element.Displayed && !string.IsNullOrEmpty(element.Text) ? element : null;
            });
            Assert.That(alertaValidador.Text, Does.Contain("La rutina debe tener entre 35 y 4000 caracteres"), "No se mostró mensaje de campo obligatorio.");
        }
    }
}
