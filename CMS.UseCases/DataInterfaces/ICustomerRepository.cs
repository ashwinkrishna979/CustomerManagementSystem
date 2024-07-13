using CMS.CoreBusiness.Models;

namespace CMS.UseCases.DataInterfaces
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetCustomersAsync();
    }
}