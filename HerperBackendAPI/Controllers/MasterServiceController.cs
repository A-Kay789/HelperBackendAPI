using System.Net;
using AutoMapper;
using HelperBackendAPI.Entity.Entity;
using HelperBackendAPI.Repository.Repository;
using HerperBackendAPI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HerperBackendAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MasterServiceController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMasterService _masterService;
        public MasterServiceController(IMapper mapper, IMasterService masterService)
        {
            _mapper = mapper;
            _masterService = masterService;
        }

        [HttpGet]
        public ResponseModel GetServices()
        {
            var response = new ResponseModel();
            var result = _masterService.GetServices().Result;
            if (result != null)
            {
                response.Status = (int)HttpStatusCode.OK;
                response.Message = "Services fetched successfully";
                response.Data = _mapper.Map<List<MasterServiceModel>>(result);
                return response;
            }
            response.Status = (int)HttpStatusCode.BadRequest;
            response.Message = "Something went wrong";
            response.Data = null;
            return response;
        }


        [HttpGet("{id}")]
        public ResponseModel GetService(int id)
        {
            var response = new ResponseModel();
            var result = _masterService.GetService(id).Result;
            if (result != null)
            {
                response.Status = (int)HttpStatusCode.OK;
                response.Message = "Service fetched successfully";
                response.Data = _mapper.Map<MasterServiceModel>(result);
                return response;
            }
            response.Status = (int)HttpStatusCode.BadRequest;
            response.Message = "Something went wrong";
            response.Data = null;
            return response;
        }

        [HttpPost]
        public ResponseModel PostService(MasterServiceModel masterServiceModel)
        {
            var response = new ResponseModel();
            var service = _mapper.Map<MasterService>(masterServiceModel);
            var result = _masterService.CreateService(service).Result;
            if (result != null)
            {
                response.Status = (int)HttpStatusCode.Created;
                response.Message = "Service created successfully";
                response.Data = _mapper.Map<MasterServiceModel>(result);
                return response;
            }
            response.Status = (int)HttpStatusCode.BadRequest;
            response.Message = "Something wrong, please check your request";
            response.Data = result;
            return response;
        }

        [HttpPut]
        public ResponseModel PutService(MasterServiceModel masterServiceModel)
        {
            var response = new ResponseModel();
            var service = _mapper.Map<MasterService>(masterServiceModel);
            var result = _masterService.UpdateService(service).Result;
            if (result != null)
            {
                response.Status = (int)HttpStatusCode.Created;
                response.Message = "Service updated successfully";
                response.Data = _mapper.Map<MasterServiceModel>(result);
                return response;
            }
            response.Status = (int)HttpStatusCode.BadRequest;
            response.Message = "Something wrong, please check your request";
            response.Data = result;
            return response;
        }

        [HttpDelete("{id}")]
        public ResponseModel DeleteService(int id)
        {
            var response = new ResponseModel();
            var result = _masterService.DeleteService(id).Result;
            if (result)
            {
                response.Status = (int)HttpStatusCode.OK;
                response.Message = "Service deleted successfully";
            }
            response.Status = (int)HttpStatusCode.BadRequest;
            response.Message = "Something worng, please check your id";
            response.Data = null;
            return response;
        }
    }
}
