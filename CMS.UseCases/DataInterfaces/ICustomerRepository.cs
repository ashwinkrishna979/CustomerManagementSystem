using CMS.CoreBusiness.Models;

namespace CMS.UseCases.DataInterfaces
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetCustomersAsync();
        Task AddCustomerAsync(Customer customer);
        Task EditCustomerAsync(Customer customer);
        Task DeleteCustomerAsync(int customerId);
    }
}