using CMS.UseCases.UseCaseInterfaces;
using CMS.CoreBusiness.Models;
using System.Runtime.CompilerServices;
namespace CMS.Web.Components.Pages
{
    public partial class Home
    {
        private Customer[]? customers;
        private List<Customer>? customerData;
        private Modal? editModal { get; set; }
        private Modal? addModal { get; set; }

         private Modal? deleteModal { get; set; }
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

        private void SetSelectedCustomer(Customer? customer=null)
        {
            if (customer == null)
            {
                selectedCustomer= new Customer
                {
                    Id=0,
                    Name = string.Empty,
                    Email = string.Empty,
                    Phone = string.Empty,
                };
            }
            else
            {
                selectedCustomer = new Customer
                {
                    Id = customer.Id,
                    Name = customer.Name,
                    Email = customer.Email,
                    Phone = customer.Phone
                };
            }

        }

        private async Task FetchCustomerData()
        {
            customerData=await CustomerUseCase.GetCustomers();
            customers = customerData.ToArray();

        }
        private void EditCustomer(Customer customer)
        {
            SetSelectedCustomer(customer);
            editModal?.Open();
        }

        private void AddCustomer()
        {
            SetSelectedCustomer();
            addModal!.Open();
        }

        private void DeleteCustomer(Customer customer)
        {
            SetSelectedCustomer(customer);
            deleteModal?.Open();
        }

        private async void SaveCustomerChange()
        {
            try
            {
                await CustomerUseCase.EditCustomer(selectedCustomer);
                editModal!.Close();
                await FetchCustomerData();
                StateHasChanged();

            }
            catch (Exception SaveCustomerChangeErr){
                Console.WriteLine($"Error in saving customer change: {SaveCustomerChangeErr.Message}");
            }
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

        private async void SaveCustomerDeletion()
        {
            try 
            {
                await CustomerUseCase.DeleteCustomer(selectedCustomer);
                deleteModal!.Close();
                await FetchCustomerData();
                StateHasChanged();
            }
            catch(Exception SaveCustomerDeletionErr)
            {
                Console.WriteLine($"Error in saving customer deletion: {SaveCustomerDeletionErr.Message}");
            }

        }

    }
}