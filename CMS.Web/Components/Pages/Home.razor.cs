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
            await FetchCustomerData();

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

        private async Task FetchCustomerData()
        {
            customerData=await CustomerUseCase.GetCustomers();
            customers = customerData.ToArray();

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

        private async void SaveNewCustomer()
        {
            try
            {
                await CustomerUseCase.AddCustomer(selectedCustomer);
                addModal!.Close();
                await FetchCustomerData();
                StateHasChanged();

            }
            catch (Exception SaveNewCustomerErr){
                Console.WriteLine($"Error in saving new customer: {SaveNewCustomerErr.Message}");
            }
        }

    }
}