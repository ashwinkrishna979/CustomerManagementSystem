using CMS.UseCases.UseCaseInterfaces;
using CMS.CoreBusiness.Models;
namespace CMS.Web.Components.Pages
{
    public partial class Home
    {
        private Customer[]? customers;
        private List<Customer>? customerData;
        protected override async Task OnInitializedAsync()
        {
            // Simulate asynchronous loading to demonstrate streaming rendering
        
            await Task.Delay(500);
            customerData=await CustomerUseCase.GetCustomers();
            
            customers = customerData.ToArray();

        }
        }
}