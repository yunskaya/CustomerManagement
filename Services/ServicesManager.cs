using Repositories.Contracts;
using Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServicesManager : IServicesManager
    {
        private readonly Lazy<ICustomerServices> _customerService;
        public ServicesManager(IRepositoryManager repositoryManager)
        {
            _customerService = new Lazy<ICustomerServices>(() => new CustomerManager(repositoryManager));
        }

        public ICustomerServices customerServices => _customerService.Value;
    }
}
