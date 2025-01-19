using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pacagroup.Ecommerce.Application.Interface;


namespace Pacagroup.Ecommerce.Application.Test
{
    [TestClass]
    public class UsersApplicationTest
    {
        private static WebApplicationFactory<Program> _factory = null;
        private static IServiceScopeFactory _scopeFactory = null;


        [ClassInitialize]
        public static void Initialize(TestContext _)
        {
            _factory = new CustomWebApplicationFactory();
            _scopeFactory = _factory.Services.GetRequiredService<IServiceScopeFactory>();
        }


        [TestMethod]
        public void Authenticate_CuandoNoSeEnvianParametros_RetornoMensajeErrorValidacion()
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<IUsersApplication>();

            //Arrange: Donde se inicializan los objetos necesarios para la ejecución del codigo
            var userName = string.Empty;
            var password = string.Empty;
            var expected = "Errores de Validación";

            //Act: Don de se ejecuta el metodo y se obtiene el resultado
            var result = context.Authenticate(userName, password);
            var actual = result.Message;


            //Assert: Donde se verifica que el resultado sea el esperado
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void Authenticate_CuandoNoSeEnvianParametrosCorrectos_RetornoMensajeExitoso()
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<IUsersApplication>();

            //Arrange: Donde se inicializan los objetos necesarios para la ejecución del codigo
            var userName = "johndoe";
            var password = "password123";
            var expected = "Autenticación Exitosa!!!";

            //Act: Don de se ejecuta el metodo y se obtiene el resultado
            var result = context.Authenticate(userName, password);
            var actual = result.Message;


            //Assert: Donde se verifica que el resultado sea el esperado
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void Authenticate_CuandoNoSeEnvianParametrosIncorrectos_RetornoMensajeNoExiste()
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<IUsersApplication>();

            //Arrange: Donde se inicializan los objetos necesarios para la ejecución del codigo
            var userName = "johndoe";
            var password = "2123123";
            var expected = "Usuario no existe";

            //Act: Don de se ejecuta el metodo y se obtiene el resultado
            var result = context.Authenticate(userName, password);
            var actual = result.Message;


            //Assert: Donde se verifica que el resultado sea el esperado
            Assert.AreEqual(expected, actual);

        }
    }
}
