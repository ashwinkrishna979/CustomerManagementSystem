using CMS.UseCases.UseCaseInterfaces;
using CMS.CoreBusiness.Models;
using System.Runtime.CompilerServices;
using CMS.UseCases.UseCases;
namespace CMS.Web.Components.Pages
{
    public partial class Home
    {
        private Customer[]? customers;
        private List<Customer>? customerData;
        private Modal? editModal { get; set; }
        private Modal? addModal { get; set; }

        private Modal? deleteModal { get; set; }
        private string alert="";

        // Pagination variables
        private int PageSize = 5;
        private int CurrentPage = 1;

        private List<Customer> CurrentPageItems => customers!.OrderBy(customer => customer.Id).Skip
        ((CurrentPage - 1) * PageSize).Take(PageSize).ToList();
        private bool IsFirstPage => CurrentPage == 1;
        private bool IsLastPage => CurrentPage >= TotalPages;
        private int TotalPages => (int)Math.Ceiling((double)customers!.Count() / PageSize);

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
        private void InitialiseAlert()
        {
            alert=string.Empty;
            StateHasChanged();
        }
        private async void EditCustomer(Customer customer)
        {
            InitialiseAlert();
            SetSelectedCustomer(customer);
            editModal?.Open();
        }

        private void AddCustomer()
        {
            InitialiseAlert();
            SetSelectedCustomer();
            addModal!.Open();
        }

        private void DeleteCustomer(Customer customer)
        {
            SetSelectedCustomer(customer);
            deleteModal?.Open();
        }

        private async void SaveCustomerChange(Customer customer)
        {
            try
            {
                string validationIssue=await CustomerValidator.ValidateCustomerData(customer);
                if (validationIssue==string.Empty)
                {
                    await CustomerUseCase.EditCustomer(selectedCustomer);
                    editModal!.Close();
                    await FetchCustomerData();
                    StateHasChanged();
                }
                else
                {
                    alert=validationIssue;
                    StateHasChanged();
                }

            }
            catch (Exception SaveCustomerChangeErr){
                Console.WriteLine($"Error in saving customer change: {SaveCustomerChangeErr.Message}");
            }
        }

        private async void SaveNewCustomer(Customer customer)
        {
            try
            {
                String validationIssue=await CustomerValidator.ValidateCustomerData(customer);
                if (validationIssue==string.Empty)
                {
                    await CustomerUseCase.AddCustomer(selectedCustomer);
                    addModal!.Close();
                    await FetchCustomerData();
                    StateHasChanged();
                }
                else
                {
                    alert=validationIssue;
                    StateHasChanged();
                }

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

        private void GoToPreviousPage()
        {
            if (!IsFirstPage)
            {
                CurrentPage--;
            }
        }

        private void GoToNextPage()
        {
            if (!IsLastPage)
            {
                CurrentPage++;
            }
        }

    }
}