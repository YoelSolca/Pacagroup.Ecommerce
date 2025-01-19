using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pacagroup.Ecommerce.Application.Interface;
using Pacagroup.Ecommerce.Application.Main;
using Pacagroup.Ecommerce.Services.WebApi;
using System.IO;


namespace Pacagroup.Ecommerce.Application.Test
{
    [TestClass]
    public class UsersApplicationTest
    {
        private static IConfiguration _configuration;
        private static IServiceScopeFactory _scopeFactory;


        [ClassInitialize]
        public static void Initialize(TestContext _)
        {
           var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();

                _configuration = builder.Build();

            //var startup = new Startup(_configuration);
            var services = new ServiceCollection();
            //startup.ConfigureServices(services);
            _scopeFactory = services.BuildServiceProvider().GetService<IServiceScopeFactory>();
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
