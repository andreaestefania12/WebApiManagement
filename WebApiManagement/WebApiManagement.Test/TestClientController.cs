using WebApiManagement.Controllers;
using WebApiManagement.Models;

namespace WebApiManagement.Test
{
    public class TestClientController
    {
        [Test]
        public void GetAllClients_ShouldReturnAllClients()
        {
            var testClients = GettestClients();
            var controller = new ClientsController(testClients);
            var result = controller.GetAllCLients() as List<Client>;
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetProduct_ShouldReturnCorrectProduct()
        {
            var testClients = GettestClients();
            var controller = new ClientsController(testClients);

            Exception ex = Assert.Throws<Exception>(() => controller.FindById(1));
        }

        [Test]
        public void GetProduct_ShouldReturnNotFound()
        {
            var testClients = GettestClients();
            var controller = new ClientsController(testClients);

            Exception ex = Assert.Throws<Exception>(()=> controller.FindById(36));
        }




        private List<Client> GettestClients()
        {
            var testClients = new List<Client>();
            testClients.Add(new Client { Id = 1, FirstName = "Andrea", LastName = "Timaran", EmailAddress = "andestibu@gmail.com", PhoneNumber = "3006271173", RegistrationDate = "2023-01-01" , Status = "Activo"});
            testClients.Add(new Client { Id = 2, FirstName = "Maria", LastName = "Lopez", EmailAddress = "maria@gmail.com", PhoneNumber = "3026271173", RegistrationDate = "2023-01-01", Status = "Inactivo" });
            testClients.Add(new Client { Id = 3, FirstName = "Estefania", LastName = "Buchely", EmailAddress = "estafania@gmail.com", PhoneNumber = "3429618834", RegistrationDate = "2023-01-01", Status = "Activo" });
            testClients.Add(new Client { Id = 4, FirstName = "Daniela", LastName = "Gomez", EmailAddress = "daniela@gmail.com", PhoneNumber = "3997255372", RegistrationDate = "2023-01-01", Status = "Activo" });
            testClients.Add(new Client { Id = 5, FirstName = "Sofia", LastName = "Granja", EmailAddress = "sofia@gmail.com", PhoneNumber = "387651126", RegistrationDate = "2023-01-01", Status = "Activo" });
            testClients.Add(new Client { Id = 6, FirstName = "Luna", LastName = "Salazar", EmailAddress = "luna@gmail.com", PhoneNumber = "3975791174", RegistrationDate = "2023-01-01", Status = "Activo" });

            return testClients;
        }
    }
}
