using AutoMapper;
using HelperBackendAPI.Entity.Entity;
using HelperBackendAPI.Repository.Repository;
using HerperBackendAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace HerperBackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILoginRepository _loginRepository;
        public LoginController(IMapper mapper,ILoginRepository loginRepository)
        {
            _mapper = mapper;
            _loginRepository = loginRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            Console.WriteLine("API was hit!");
            return Ok("Test");
        }

        [HttpPost]
        public UserModel UserLogin(UserLoginModel userLoginModel)
        {
            var post = _mapper.Map<User>(userLoginModel);
            var result = _loginRepository.UserAuthenticate(post).Result;
            return _mapper.Map<UserModel>(result);
        }
    }
}
