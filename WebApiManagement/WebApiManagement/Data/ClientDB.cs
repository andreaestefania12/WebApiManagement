using Microsoft.Data.SqlClient;
using System.Data;
using WebApiManagement.Models;

namespace WebApiManagement.Data
{
    public class ClientDB
    {
        public static void SaveClient(Client client)
        {
            SqlConnection conn = new SqlConnection(ConnectionDataBase.connection);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("saveClient", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@firstName", client.FirstName);
                cmd.Parameters.AddWithValue("@lastName", client.LastName);
                cmd.Parameters.AddWithValue("@emailAddress", client.EmailAddress);
                cmd.Parameters.AddWithValue("@phoneNumber", client.PhoneNumber);
                cmd.Parameters.AddWithValue("@status", client.Status);
                cmd.Parameters.AddWithValue("@registrationDate", client.RegistrationDate);
                cmd.ExecuteNonQuery();
                conn.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception("Error al guardar");
            }
        }

        public static void DeleteClient(int id)
        {

            SqlConnection conn = new SqlConnection(ConnectionDataBase.connection);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("deleteClient", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                conn.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception("Error al borrar");
            }
        }

        public static void UpdateClient(Client client)
        {

            SqlConnection conn = new SqlConnection(ConnectionDataBase.connection);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("updateClient", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", client.Id);
                cmd.Parameters.AddWithValue("@firstName", client.FirstName);
                cmd.Parameters.AddWithValue("@lastName", client.LastName);
                cmd.Parameters.AddWithValue("@emailAddress", client.EmailAddress);
                cmd.Parameters.AddWithValue("@phoneNumber", client.PhoneNumber);
                cmd.Parameters.AddWithValue("@status", client.Status);
                cmd.ExecuteNonQuery();
                conn.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static Client GetClient(int id)
        {
            SqlConnection conn = new SqlConnection(ConnectionDataBase.connection);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("getClientById", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader data = cmd.ExecuteReader();
                Client client = new Client();

                while (data.Read())
                {
                    client = new Client()
                    {
                        Id = (int)data["id"],
                        FirstName = data["firstName"].ToString(),
                        LastName = data["lastName"].ToString(),
                        EmailAddress = data["emailAddress"].ToString(),
                        PhoneNumber = data["phoneNumber"].ToString(),
                        Status = data["status"].ToString(),
                        RegistrationDate = data["registrationDate"].ToString()
                    };
                }
                conn.Close();
                if(client.FirstName != null)
                {
                    return client;
                }
                throw new Exception("Not Found");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception("Error");
            }
        }

        public static List<Client> GetClients()
        {
            SqlConnection conn = new SqlConnection(ConnectionDataBase.connection);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("getAllClients", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader data = cmd.ExecuteReader();
                List<Client> clients = new List<Client>();

                while (data.Read())
                {
                    clients.Add(new Client()
                    {
                        Id = (int)data["id"],
                        FirstName = data["firstName"].ToString(),
                        LastName = data["lastName"].ToString(),
                        EmailAddress = data["emailAddress"].ToString(),
                        PhoneNumber = data["phoneNumber"].ToString(),
                        Status = data["status"].ToString(),
                        RegistrationDate = data["registrationDate"].ToString()
                    });
                }
                conn.Close();
                return clients;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception("Error");
            }
        }
    }
}
