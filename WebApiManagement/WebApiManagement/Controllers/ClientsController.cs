using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using WebApiManagement.Data;
using WebApiManagement.Models;

namespace WebApiManagement.Controllers
{
    [Route("api/client")]
    [ApiController]
    [EnableCors]
    public class ClientsController : ControllerBase
    {
        /* DESCOMENTAR PARA LOS TEST
        List<Client> clients = new List<Client>();
        public ClientsController(List<Client> clients)
        {
            this.clients = clients;
        }
        */

        // GET: api/Clients
        [HttpGet]
        public List<Client> GetAllCLients()
        {
            try
            {
                var response = new HttpRequestMessage();
                List<Client> clients = ClientDB.GetClients();
                return clients;

            }
            catch (Exception e)
            {
                throw new Exception("Error");
            }
        }
        // GET findById
        [HttpGet]
        [Route("getById")]
        public Client FindById(int id)
         {
             try
             {
                 var response = new HttpRequestMessage();
                 Client client = ClientDB.GetClient(id);
                 return client;

             }
             catch (Exception e)
             {
                throw new Exception("Error");
            }
         }

        // POST save clients
        [HttpPost]
        public HttpResponseMessage SaveClient([FromBody] Client client)
        {
            try
            {
                ClientDB.SaveClient(client);
                return new HttpResponseMessage(HttpStatusCode.Created);
            }
            catch (Exception e)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        // PUT update client
        [HttpPut]
        public HttpResponseMessage UpdateClient([FromBody] Client client)
        {
            try
            {
                ClientDB.UpdateClient(client);
                return new HttpResponseMessage(HttpStatusCode.Accepted);
            }
            catch (Exception e)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        // DELETE client
        [HttpDelete]
        public HttpResponseMessage DeleteClient(int id)
        {
            try
            {
                ClientDB.DeleteClient(id);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
    }
}
