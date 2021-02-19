using Microsoft.Extensions.Configuration;
using SaleADONet_Chapter5.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SaleADONet_Chapter5.Services.CustomerService
{
    public class ADO_CustomerService
    {
        List<Customer> customers;
        string connectionString;
        public IConfiguration Configuration { get; }
        public ADO_CustomerService(IConfiguration configuration)
        {
            Configuration = configuration;
            connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            customers = new List<Customer>();
        }
        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            string sql = "Select * From Customers ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand(sql, connection);
                using (SqlDataReader dataReader = await command.ExecuteReaderAsync())
                {
                    while (await dataReader.ReadAsync())
                    {
                        Customer @cust = new Customer();
                        @cust.CustomerId = Convert.ToInt32(dataReader["CustomerId"]);
                        @cust.Name = Convert.ToString(dataReader["Name"]);
                        @cust.Address = Convert.ToString(dataReader["Address"]);
                        @cust.Age = Convert.ToInt32(dataReader["Age"]);
                        customers.Add(@cust);
                    }
                }
            }
            return customers;
        }
       
        public async Task NewCustomerAsync(Customer customer)
        {
             string sql = $"Insert Into Customers (Name, Address, Age) Values (@Name,@Address,@Age)";
             using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Name", customer.Name);
                    command.Parameters.AddWithValue("@Address", customer.Address);
                    command.Parameters.AddWithValue("@Age", customer.Age);
                    int affectedRows = await command.ExecuteNonQueryAsync();
                }
            }
        }
         public void UpdateCustomer(Customer @customer)
        {
            string sql = $"Update Customers SET (Name, Address, Age) Values (@Name,@Address,@Age)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", @customer.CustomerId);
                    command.Parameters.AddWithValue("@Name", @customer.Name);
                    command.Parameters.AddWithValue("@Address", @customer.Address);
                    command.Parameters.AddWithValue("@Age", @customer.Age);                    
                    int affectedRows = command.ExecuteNonQuery();
                }
            }
        }

        public async Task<Customer> GetCustomerAsync(int id)
        {
            Customer @customer = new Customer();
            string sql = $"Select * From Customers  Where CustomerId=@id ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();             
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    SqlDataReader dataReader = await command.ExecuteReaderAsync();

                    while (dataReader.Read())
                    {
                        @customer.CustomerId = Convert.ToInt32(dataReader["CustomerId"]);
                        @customer.Name = Convert.ToString(dataReader["Name"]);
                        @customer.Address = Convert.ToString(dataReader["Address"]);
                        @customer.Age = Convert.ToInt32(dataReader["Age"]);

                    }
                }
            }
            return @customer;
        }

        
        public async Task DeleteThisCustomerAsync(Customer customer)
        {
            string sql = $"Delete From Customers  Where CustomerId=@id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", customer.CustomerId);
                    int affectedRows = await command.ExecuteNonQueryAsync();
                }                                
            }
        }
        public async Task<List<Customer>> CustomersByNameAsync(string name)
        {
            string sql = "Select * From Customers  where Name LIKE'" + @name + "%" + "'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@name", name);
                using (SqlDataReader dataReader = await command.ExecuteReaderAsync())
                {
                    while (await dataReader.ReadAsync())
                    {
                        Customer @customer = new Customer();
                        @customer.CustomerId = Convert.ToInt32(dataReader["CustomerId"]);
                        @customer.Name = Convert.ToString(dataReader["Name"]);
                        @customer.Address = Convert.ToString(dataReader["Address"]);
                        @customer.Age = Convert.ToInt32(dataReader["Age"]);
                        customers.Add(@customer);
                    }
                }
            }
            return customers;
        }

    }
}
