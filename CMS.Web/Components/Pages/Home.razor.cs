using CMS.UseCases.UseCaseInterfaces;
using CMS.CoreBusiness.Models;
namespace CMS.Web.Components.Pages
{
    public partial class Home
    {
        private Customer[]? customers;
        private List<Customer>? customerData;
        private Customer selectedCustomer=new Customer
            {
                Name = "",
                Email = "",
                Phone = ""
            };

        private Modal modal { get; set; }
        
        protected override async Task OnInitializedAsync()
        {
            // Simulate asynchronous loading to demonstrate streaming rendering
        
            await Task.Delay(500);
            customerData=await CustomerUseCase.GetCustomers();
            
            customers = customerData.ToArray();

        }
        private void EditCustomer(Customer customer)
        {
            // Clone the customer to avoid direct modification
            selectedCustomer = new Customer
            {
                Name = customer.Name,
                Email = customer.Email,
                Phone = customer.Phone
            };
            modal.Open();
        }
        }
}