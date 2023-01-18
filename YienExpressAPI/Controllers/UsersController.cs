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
    public class UsersController : ControllerBase
    {
        public IUserRepo userRepo;
        public IMapper mapper;


        public UsersController(IUserRepo uRepo, IMapper uMapper)
        {
            userRepo = uRepo;
            mapper = uMapper;
        }



        [HttpGet]
        public ActionResult<IEnumerable<UserReadDTO>> GetUser()
        {
            var users = userRepo.GetUsers();
            return Ok(mapper.Map<IEnumerable<UserReadDTO>>(users));
        }
        [HttpGet("{code}", Name = "GetUser")]
        public ActionResult<UserReadDTO> GetUser(int code)
        {
            var user = userRepo.GetUser(code);
            if (user != null)
                return Ok(mapper.Map<UserReadDTO>(user));
            else
                return NotFound();

        }

        [HttpPost]

        public ActionResult<UserCreateDTO> CreateUser(UserCreateDTO user)
        {
            var modelUser = mapper.Map<User>(user);
            userRepo.CreateUser(modelUser);
            userRepo.Save();
            var newUser = mapper.Map<UserReadDTO>(modelUser);
            return CreatedAtRoute(nameof(GetUser),
                new { code = newUser.Id }, newUser);
        }


        [HttpPut("{code}")]

        public ActionResult Update(int code, UserCreateDTO user)
        {
            var userToUpdate = mapper.Map<User>(user);
            userToUpdate.Id = code;
            if (userRepo.Update(userToUpdate))
                return Ok();
            else
                return NotFound();
        }

        [HttpDelete("{code}")]

        public ActionResult Delete(int code)
        {
            var userToDelete = userRepo.GetUser(code);

            if (userToDelete != null)
            {
                userRepo.Delete(userToDelete);
                return Ok();
            }
            else
                return NotFound();
        }
    }
}
