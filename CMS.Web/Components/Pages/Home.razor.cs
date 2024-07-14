using CMS.UseCases.UseCaseInterfaces;
using CMS.CoreBusiness.Models;
namespace CMS.Web.Components.Pages
{
    public partial class Home
    {
        private Customer[]? customers;
        private List<Customer>? customerData;
        private Modal? editModal { get; set; }
        private Modal? addModal { get; set; }
        private Customer selectedCustomer=new Customer
            {
                Name = string.Empty,
                Email = string.Empty,
                Phone = string.Empty,
            };
        
        protected override async Task OnInitializedAsync()
        {        
            await Task.Delay(500);
            customerData=await CustomerUseCase.GetCustomers();
            
            customers = customerData.ToArray();
        }

        private void InitializeDefaultCustomer()
        {
            selectedCustomer= new Customer
            {
                Name = string.Empty,
                Email = string.Empty,
                Phone = string.Empty,
            };

        }
        private void EditCustomer(Customer customer)
        {
            selectedCustomer = new Customer
            {
                Name = customer.Name,
                Email = customer.Email,
                Phone = customer.Phone
            };
            editModal?.Open();
        }

        private void AddCustomer()
        {
            InitializeDefaultCustomer();
            addModal!.Open();
        }

        private void SaveCustomer()
        {

        }
        }
}