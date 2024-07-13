using CMS.CoreBusiness.Models;
namespace CMS.UseCases.UseCaseInterfaces
{
    public interface ICustomerUseCase
    {
        Task<List<Customer>> GetCustomers();
    }
}