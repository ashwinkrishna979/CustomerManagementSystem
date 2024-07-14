using CMS.CoreBusiness.Models;
using CMS.UseCases.UseCaseInterfaces;
using CMS.UseCases.DataInterfaces;

namespace CMS.UseCases.UseCases
{
    public class CustomerUseCase: ICustomerUseCase
    {
        private readonly ICustomerRepository customerRepository;
        public CustomerUseCase(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }
        public async Task<List<Customer>> GetCustomers()
        {
            return await customerRepository.GetCustomersAsync();
        }

        public async Task AddCustomer(Customer customer)
        {
            await customerRepository.AddCustomerAsync(customer);
        }

        public async Task EditCustomer(Customer customer)
        {
            await customerRepository.EditCustomerAsync(customer);
        }

        public async Task DeleteCustomer(Customer customer)
        {
            await customerRepository.DeleteCustomerAsync(customer.Id);
        }
    }
}