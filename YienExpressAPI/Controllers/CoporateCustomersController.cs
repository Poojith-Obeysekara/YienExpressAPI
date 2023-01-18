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
    public class CoporateCustomersController : ControllerBase
    {
        public ICoporateCustomerRepo coporateCustomerRepo;
        public IMapper mapper;


        public CoporateCustomersController(ICoporateCustomerRepo sRepo, IMapper sMapper)
        {
            coporateCustomerRepo = sRepo;
            mapper = sMapper;
        }



        [HttpGet]
        public ActionResult<IEnumerable<CoporateCustomerReadDTO>> GetCoporateCustomer()
        {
            var coporateCustomers = coporateCustomerRepo.GetCoporateCustomers();
            return Ok(mapper.Map<IEnumerable<CoporateCustomerReadDTO>>(coporateCustomers));
        }
        [HttpGet("{code}", Name = "GetCoporateCustomer")]
        public ActionResult<CoporateCustomerReadDTO> GetCoporateCustomer(int code)
        {
            var coporateCustomer = coporateCustomerRepo.GetCoporateCustomer(code);
            if (coporateCustomer != null)
                return Ok(mapper.Map<CoporateCustomerReadDTO>(coporateCustomer));
            else
                return NotFound();

        }

        [HttpPost]

        public ActionResult<CoporateCustomerCreateDTO> CreateCoporateCustomer(CoporateCustomerCreateDTO coporateCustomer)
        {
            var modelCoporateCustomer = mapper.Map<CoporateCustomer>(coporateCustomer);
            coporateCustomerRepo.CreateCoporateCustomer(modelCoporateCustomer);
            coporateCustomerRepo.Save();
            var newCoporateCustomer = mapper.Map<CoporateCustomerReadDTO>(modelCoporateCustomer);
            return CreatedAtRoute(nameof(GetCoporateCustomer),
                new { code = newCoporateCustomer.ID }, newCoporateCustomer);
        }


        [HttpPut("{code}")]

        public ActionResult Update(int code, CoporateCustomerCreateDTO coporateCustomer)
        {
            var coporateCustomerToUpdate = mapper.Map<CoporateCustomer>(coporateCustomer);
            coporateCustomerToUpdate.ID = code;
            if (coporateCustomerRepo.Update(coporateCustomerToUpdate))
                return Ok();
            else
                return NotFound();
        }

        [HttpDelete("{code}")]

        public ActionResult Delete(int code)
        {
            var coporateCustomerToDelete = coporateCustomerRepo.GetCoporateCustomer(code);

            if (coporateCustomerToDelete != null)
            {
                coporateCustomerRepo.Delete(coporateCustomerToDelete);
                return Ok();
            }
            else
                return NotFound();
        }
    }
}
