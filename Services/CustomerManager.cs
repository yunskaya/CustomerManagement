using Entities.Models;
using Repositories.Contracts;
using Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CustomerManager : ICustomerServices
    {
        private readonly IRepositoryManager _manager;

        public CustomerManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public Customer CreateOneCustomer(Customer customer)
        {
            if (customer is null)
                throw new ArgumentNullException(nameof(customer));

            _manager.customer.CreateOneCustomer(customer);
            _manager.Save();

            return customer;
        }

        public void DeleteCustomer(int id, bool trackChanges)
        {
            var customer = _manager.customer.GetOneCustomerById(id, trackChanges);

            if (customer is null)
                throw new Exception($"Customer with id:{id} could not found.");

            _manager.customer.DeleteOneCustomer(customer);
            _manager.Save();

        }

        public IEnumerable<Customer> GetAllCustomers(bool trackChanges)
        {
            return _manager.customer.GetAllCustomers(trackChanges);
        }

        public Customer GetOneCustomerById(int id, bool trackChanges)
        {
            return _manager.customer.GetOneCustomerById(id, trackChanges);
        }

        public void UpdateOneCustomer(int id, Customer customer, bool trackChanges)
        {
            var entity = _manager.customer.GetOneCustomerById(id, trackChanges);

            if (entity is null)
                throw new Exception($"Customer with id:{id} could not found.");

            if (customer is null)
                throw new ArgumentNullException(nameof(customer));

            entity.Name = customer.Name;
            entity.Surname = customer.Surname;

            _manager.customer.UpdateOneCustomer(entity);
            _manager.Save();

        }
    }
}
