using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CMS.UseCases.UseCaseInterfaces;
using CMS.CoreBusiness.Models;

public class CustomerValidator:ICustomerValidator
{
    public async Task<string> ValidateCustomerData(Customer customer)
    {
        await Task.Delay(0);
        if (customer == null)
            throw new ArgumentNullException(nameof(customer), "Customer object cannot be null.");

        // Check Email
        if (string.IsNullOrWhiteSpace(customer.Email))
            return "Email is required.";
        else if (!IsValidEmail(customer.Email))
            return "Email is not in a valid format.";

        // Check Name
        if (string.IsNullOrWhiteSpace(customer.Name))
            return "Name is required.";

        // Check Phone
        if (string.IsNullOrWhiteSpace(customer.Phone))
            return "Phone number is required.";
        else if (!IsValidPhoneNumber(customer.Phone))
            return "Phone number is not in a valid format (10 digit).";

        return string.Empty;
    }

    private bool IsValidEmail(string email)
    {
        string emailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                            + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!"
                            + @"\.)@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
        return Regex.IsMatch(email, emailPattern, RegexOptions.IgnoreCase);
    }

    private bool IsValidPhoneNumber(string phone)
    {
        string phonePattern = @"^[0-9]{10}$"; // Assuming a 10-digit phone number format
        return Regex.IsMatch(phone, phonePattern);
    }
}
