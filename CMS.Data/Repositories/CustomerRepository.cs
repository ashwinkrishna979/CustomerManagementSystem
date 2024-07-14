using CMS.CoreBusiness.Models;
using CMS.UseCases.DataInterfaces;
using Microsoft.EntityFrameworkCore;
using CMS.Data.Context;

namespace CMS.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CMSDBContext _context;

        public CustomerRepository(CMSDBContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> GetCustomersAsync()
        {
            return await _context.Customers.ToListAsync();
        }
 
        public async Task AddCustomerAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task EditCustomerAsync(Customer customer)
        {
            var existingCustomer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == customer.Id);
            if (existingCustomer != null)
            {
                existingCustomer.Name = customer.Name;
                existingCustomer.Email = customer.Email;
                existingCustomer.Phone = customer.Phone;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteCustomerAsync(int customerId)
        {
            var customerToRemove = await _context.Customers.FirstOrDefaultAsync(c => c.Id == customerId);
            if (customerToRemove != null)
            {
                _context.Customers.Remove(customerToRemove);
                await _context.SaveChangesAsync();
            }
        }
    }
}
