using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contract
{
    public interface ICustomerServices
    {

        IEnumerable<Customer> GetAllCustomers(bool trackChanges);
        Customer GetOneCustomerById(int id, bool trackChanges);
        Customer CreateOneCustomer(Customer customer);
        void UpdateOneCustomer(int id, Customer customer, bool trackChanges);
        void DeleteCustomer(int id,bool trackChanges);
    }
}
