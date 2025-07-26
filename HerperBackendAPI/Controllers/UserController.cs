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
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        public UserController(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        [HttpGet]
        [Authorize]
        public ResponseModel GetUsers()
        {
            var response = new ResponseModel();
            var result = _userRepository.GetUsers().Result;
            if (result != null)
            {
                response.Status = (int)HttpStatusCode.OK;
                response.Message = "Login successfully";
                response.Data = _mapper.Map<UserListModel>(result);
                return response;
            }
            response.Status = (int)HttpStatusCode.NotFound;
            response.Message = "Data not found";
            response.Data = result;
            return response;
        }

        [HttpGet("{id}")]
        [Authorize]
        public ResponseModel GetUser(int id)
        {
            var response = new ResponseModel();
            var result = _userRepository.GetUser(id).Result;
            if (result != null)
            {
                response.Status = (int)HttpStatusCode.OK;
                response.Message = "Login successfully";
                response.Data = _mapper.Map<UserListModel>(result);
                return response;
            }
            response.Status = (int)HttpStatusCode.NotFound;
            response.Message = "Data not found";
            response.Data = result;
            return response;
        }

        [HttpPost]
        [AllowAnonymous]
        public ResponseModel PostUser(UserModel userModel)
        {
            var response = new ResponseModel();
            var user = _mapper.Map<User>(userModel);
            var result = _userRepository.CreateUser(user).Result;
            if (result != null)
            {
                response.Status = (int)HttpStatusCode.Created;
                response.Message = "User created successfully";
                response.Data = _mapper.Map<User>(result);
                return response;
            }
            response.Status = (int)HttpStatusCode.BadRequest;
            response.Message = "Something wrong, please check your request";
            response.Data = result;
            return response;
        }

        [HttpPut]
        [Authorize]
        public ResponseModel PutUser(UserModel userModel)
        {
            var response = new ResponseModel();
            var user = _mapper.Map<User>(userModel);
            var result = _userRepository.UpdateUser(user).Result;
            if (result != null)
            {
                response.Status = (int)HttpStatusCode.Created;
                response.Message = "User updated successfully";
                response.Data = _mapper.Map<User>(result);
                return response;
            }
            response.Status = (int)HttpStatusCode.BadRequest;
            response.Message = "Something wrong, please check your request";
            response.Data = result;
            return response;
        }
    }
}
