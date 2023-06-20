using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly Lazy<ICustomerRepository> _customerRepository;

        public RepositoryManager(RepositoryContext context)
        {
            _context = context; 
            _customerRepository = new  Lazy<ICustomerRepository>(() => new CustomerRepository(_context));
        }

        public ICustomerRepository customer => _customerRepository.Value;

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
