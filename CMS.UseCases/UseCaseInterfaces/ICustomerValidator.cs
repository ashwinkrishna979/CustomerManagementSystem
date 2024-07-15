using CMS.CoreBusiness.Models;
namespace CMS.UseCases.UseCaseInterfaces
{
    public interface ICustomerValidator
    {
    Task<string> ValidateCustomerData(Customer customer);     
    }
}