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
    public class PackagesController : ControllerBase
    {
        public IPackageRepo PackageRepo;
        public IMapper mapper;


        public PackagesController(IPackageRepo pRepo, IMapper pMapper)
        {
            PackageRepo = pRepo;
            mapper = pMapper;
        }



        [HttpGet]
        public ActionResult<IEnumerable<PackageReadDTO>> GetPackages()
        {
            var Packages = PackageRepo.GetPackages();
            return Ok(mapper.Map<IEnumerable<PackageReadDTO>>(Packages));
        }
        [HttpGet("{code}",Name ="GetPackage")]
        public ActionResult<PackageReadDTO> GetPackage(int code)
        {
            var Package = PackageRepo.GetPackage(code);
            if (Package != null)
                return Ok(mapper.Map<PackageReadDTO>(Package));
            else
                return NotFound();

        }

        [HttpPost]

        public ActionResult<PackageCreateDTO> CreatePackage(PackageCreateDTO Package)
        {
            var modelPackage = mapper.Map<Package>(Package);
            PackageRepo.CreatePackage(modelPackage);
            PackageRepo.Save();
            var newPackage = mapper.Map<PackageReadDTO>(modelPackage);
            return CreatedAtRoute(nameof(GetPackage),
                new {code = newPackage.ID}, newPackage);
        }


        [HttpPut("{code}")]

        public ActionResult Update(int code,PackageCreateDTO Package)
        {
            var PackageToUpdate = mapper.Map<Package>(Package);
            PackageToUpdate.ID = code;
            if(PackageRepo.Update(PackageToUpdate))
                return Ok();
            else
                return NotFound();
        }

        [HttpDelete("{code}")]

        public ActionResult Delete(int code)
        {
            var PackageToDelete = PackageRepo.GetPackage(code);

            if (PackageToDelete != null)
        {  
            PackageRepo.Delete(PackageToDelete);
            return Ok();
        }
        else
            return NotFound();
        }
    }
}
