using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YienExpressAPI.Data;
using YienExpressAPI.DTO;
using YienExpressAPI.Model;
using System.Runtime.InteropServices;

namespace YienExpressAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        public ICustomerRepo customerRepo;
        public IMapper mapper;


        public CustomersController(ICustomerRepo cRepo, IMapper cMapper)
        {
            customerRepo = cRepo;
            mapper = cMapper;
        }



        [HttpGet]
        public ActionResult<IEnumerable<CustomerReadDTO>> GetCustomer()
        {
            var customers = customerRepo.GetCustomers();
            return Ok(mapper.Map<IEnumerable<CustomerReadDTO>>(customers));
        }
        [HttpGet("{code}", Name = "GetCustomer")]
        public ActionResult<CustomerReadDTO> GetCustomer(int code)
        {
            var customer = customerRepo.GetCustomer(code);
            if (customer != null)
                return Ok(mapper.Map<CustomerReadDTO>(customer));
            else
                return NotFound();

        }

        [HttpPost]

        public ActionResult<CustomerCreateDTO> CreateCustomer(CustomerCreateDTO customer)
        {
            var modelCustomer = mapper.Map<Customer>(customer);
            customerRepo.CreateCustomer(modelCustomer);
            customerRepo.Save();
            var newCustomer = mapper.Map<CustomerReadDTO>(modelCustomer);
            return CreatedAtRoute(nameof(GetCustomer),
                new { code = newCustomer.ID }, newCustomer);
        }


        [HttpPut("{code}")]

        public ActionResult Update(int code, CustomerCreateDTO customer)
        {
            var customerToUpdate = mapper.Map<Customer>(customer);
            customerToUpdate.ID = code;
            if (customerRepo.Update(customerToUpdate))
                return Ok();
            else
                return NotFound();
        }

        [HttpDelete("{code}")]

        public ActionResult Delete(int code)
        {
            var customerToDelete = customerRepo.GetCustomer(code);

            if (customerToDelete != null)
            {
                customerRepo.Delete(customerToDelete);
                return Ok();
            }
            else
                return NotFound();
        }
    }
}
