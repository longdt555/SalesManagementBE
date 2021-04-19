﻿using AutoMapper;
using Lib.Common;
using Lib.Service.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using Lib.Data.Entity;
using Lib.Common.Helpers;
using Lib.Service.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using YDManagement.Authorization;

namespace YDManagement.APIControllers
{    
    [Route("api/[controller]")]
    [ApiController]
    public class BackendUserController : BaseController
    {
        private readonly IBackendUserService _backendUserService;
        private readonly IMapper _mapper;
        public BackendUserController(IBackendUserService backendUserService, IMapper mapper)
        {
            _backendUserService = backendUserService;
            _mapper = mapper;
        }
        [Permission(Roles.Administrator)]
        [HttpPost]
        public IActionResult Create([FromBody] BackendUserDto model)
        {
            var data = _mapper.Map<BackendUser>(model);
            try
            {
                data.CreatedDate = DateTime.Now;
                data.CreatedBy = AdminCurrentUser.Id;
                _backendUserService.Create(data);
                var dataDto = _mapper.Map<BackendUserDto>(data);
                return Ok(dataDto);
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            var data = _backendUserService.GetAll();
            return Ok(data);
        }

        [HttpGet("get-by-id/{id}")]
        public IActionResult GetById(int id)
        {
            var data = _backendUserService.GetFirstOrDefault();
            var dataDto = _mapper.Map<BackendUserDto>(data);
            return Ok(dataDto);
        }
        [HttpPut("update/{id}")]
        public IActionResult Update([FromBody] BackendUserDto model)
        {
            // map dataDto to entity and set id
            var data = _mapper.Map<BackendUser>(model);
            try
            {
                data.UpdatedDate = DateTime.Now;
                data.UpdatedBy = AdminCurrentUser.Id;
                _backendUserService.Update(data);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(ex.Message);
            }
        }
        
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            _backendUserService.Delete(id);
            return Ok();
        }

    }
}
