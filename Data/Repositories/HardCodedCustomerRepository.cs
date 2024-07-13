using System.Reflection.Metadata.Ecma335;
using CMS.CoreBusiness.Models;
namespace CMS.Data.Repositories;
public class HardcodedDataRepository
{
    private List<Customer> customerData = new List<Customer>
        {
            new Customer {  Name = "John Doe", Email = "john.doe@example.com", Phone = "123-456-7890" },
            new Customer {  Name = "Jane Smith", Email = "jane.smith@example.com", Phone = "987-654-3210" },
            new Customer {  Name = "Robert Brown", Email = "robert.brown@example.com", Phone = "555-555-5555" },
            new Customer {  Name = "Emily Davis", Email = "emily.davis@example.com", Phone = "111-222-3333" },
            new Customer {  Name = "Michael Wilson", Email = "michael.wilson@example.com", Phone = "444-555-6666" },
            new Customer {  Name = "Sarah Johnson", Email = "sarah.johnson@example.com", Phone = "777-888-9999" },
            new Customer {  Name = "David Lee", Email = "david.lee@example.com", Phone = "000-111-2222" },
            new Customer {  Name = "Laura White", Email = "laura.white@example.com", Phone = "333-444-5555" },
            new Customer {  Name = "James Taylor", Email = "james.taylor@example.com", Phone = "666-777-8888" },
            new Customer {  Name = "Linda Harris", Email = "linda.harris@example.com", Phone = "999-000-1111" }
        };

    public async Task<List<Customer>> GetCustomersAsync()
    {
        return await Task.Run(() =>customerData);
    }
}