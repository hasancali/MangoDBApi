using System.Collections.Generic;
using System.Threading.Tasks;
using MangoDBApi.Models;

namespace MangoDBApi.Repository
{
    public interface ICustomerRepository
    {
        Task<Customer> CreateAsync(Customer customer);
        Task UpdateAsync(string id, Customer customer);
        Task DeleteAsync(string id);
        Task<List<Customer>> GetAllAsync();
        Task<Customer> GetByIdAsync(string id);
    }
}
