using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MangoDBApi.Models;
using MangoDBApi.Services;

namespace MangoDBApi.Controllers
{
    [ApiController]
    [Route("api/v1/MangoDBApi/[Controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _customerService.CreateAsync(customer).ConfigureAwait(false);
            return Ok(customer.Id);
        }

        [HttpPut("Update/{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Customer customerIn)
        {
            var customer = await _customerService.GetByIdAsync(id).ConfigureAwait(false);
            if (customer == null)
            {
                return NotFound();
            }
            await _customerService.UpdateAsync(id, customerIn).ConfigureAwait(false);
            return NoContent();
        }

        [HttpDelete("Delete/{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var customer = await _customerService.GetByIdAsync(id).ConfigureAwait(false);
            if (customer == null)
            {
                return NotFound();
            }
            await _customerService.DeleteAsync(customer.Id).ConfigureAwait(false);
            return NoContent();
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _customerService.GetAllAsync().ConfigureAwait(false));
        }

        [HttpGet("Get/{id:length(24)}")]
        public async Task<IActionResult> Get(string id)
        {
            var customer = await _customerService.GetByIdAsync(id).ConfigureAwait(false);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
    }
}
