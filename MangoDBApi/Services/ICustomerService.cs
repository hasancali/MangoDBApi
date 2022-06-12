using System.Collections.Generic;
using System.Threading.Tasks;
using MangoDBApi.Models;

namespace MangoDBApi.Services
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetAllAsync();
        Task<Customer> GetByIdAsync(string id);
        Task<Customer> CreateAsync(Customer customer);
        Task UpdateAsync(string id, Customer customer);
        Task DeleteAsync(string id);
    }
}
