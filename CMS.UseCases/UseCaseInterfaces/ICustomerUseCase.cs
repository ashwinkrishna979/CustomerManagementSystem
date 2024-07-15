using CMS.CoreBusiness.Models;
namespace CMS.UseCases.UseCaseInterfaces
{
    public interface ICustomerUseCase
    {
        Task<List<Customer>> GetCustomers();
        Task AddCustomer(Customer customer);
        Task EditCustomer(Customer customer);
        Task DeleteCustomer(Customer customer);
        
    }
}