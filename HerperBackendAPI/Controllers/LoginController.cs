using System.Net;
using AutoMapper;
using HelperBackendAPI.Entity.Entity;
using HelperBackendAPI.Repository.Repository;
using HerperBackendAPI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HerperBackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class LoginController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILoginRepository _loginRepository;
        public LoginController(IMapper mapper, ILoginRepository loginRepository)
        {
            _mapper = mapper;
            _loginRepository = loginRepository;
        }

        [HttpPost]
        public ResponseModel UserLogin(UserLoginModel userLoginModel)
        {
            var response = new ResponseModel();
            var post = _mapper.Map<User>(userLoginModel);
            var result = _loginRepository.UserAuthenticate(post).Result;
            if (result != null)
            {
                response.Status = (int)HttpStatusCode.OK;
                response.Message = "Login successfully";
                response.Data = result;
                return response;
            }
            response.Status = (int)HttpStatusCode.Unauthorized;
            response.Message = "Username or password does not match";
            response.Data = result;
            return response;
        }
         
    }
}
