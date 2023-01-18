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
    public class YienEmployeesController : ControllerBase
    {
        public IYienEmployeeRepo yienEmployeeRepo;
        public IMapper mapper;


        public YienEmployeesController(IYienEmployeeRepo yRepo, IMapper yMapper)
        {
            yienEmployeeRepo = yRepo;
            mapper = yMapper;
        }



        [HttpGet]
        public ActionResult<IEnumerable<YienEmployeeReadDTO>> GetYienEmployee()
        {
            var yienEmployees = yienEmployeeRepo.GetYienEmployees();
            return Ok(mapper.Map<IEnumerable<YienEmployeeReadDTO>>(yienEmployees));
        }
        [HttpGet("{code}", Name = "GetYienEmployee")]
        public ActionResult<YienEmployeeReadDTO> GetYienEmployee(int code)
        {
            var yienEmployee = yienEmployeeRepo.GetYienEmployee(code);
            if (yienEmployee != null)
                return Ok(mapper.Map<YienEmployeeReadDTO>(yienEmployee));
            else
                return NotFound();

        }

        [HttpPost]

        public ActionResult<YienEmployeeCreateDTO> CreateYienEmployee(YienEmployeeCreateDTO yienEmployee)
        {
            var modelYienEmployee = mapper.Map<YienEmployee>(yienEmployee);
            yienEmployeeRepo.CreateYienEmployee(modelYienEmployee);
            yienEmployeeRepo.Save();
            var newYienEmployee = mapper.Map<YienEmployeeReadDTO>(modelYienEmployee);
            return CreatedAtRoute(nameof(GetYienEmployee),
                new { code = newYienEmployee.ID }, newYienEmployee);
        }


        [HttpPut("{code}")]

        public ActionResult Update(int code, YienEmployeeCreateDTO yienEmployee)
        {
            var yienEmployeeToUpdate = mapper.Map<YienEmployee>(yienEmployee);
            yienEmployeeToUpdate.ID = code;
            if (yienEmployeeRepo.Update(yienEmployeeToUpdate))
                return Ok();
            else
                return NotFound();
        }

        [HttpDelete("{code}")]

        public ActionResult Delete(int code)
        {
            var yienEmployeeToDelete = yienEmployeeRepo.GetYienEmployee(code);

            if (yienEmployeeToDelete != null)
            {
                yienEmployeeRepo.Delete(yienEmployeeToDelete);
                return Ok();
            }
            else
                return NotFound();
        }
    }
}
