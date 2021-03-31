﻿
using AutoMapper;
using Lib.Common;
using Lib.Common.Helpers;
using Lib.Data.Entity;
using Lib.Service.Dtos;
using Lib.Service.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YDManagement.Authorization;

namespace YDManagement.APIControllers
{
    [Route("api/role")]
    [ApiController]
    [Permission(Roles.Administrator)]
    [Authorize] // The request must be contains jwt
    public class RoleController : BaseController
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        public RoleController(IRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }

        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            var data = _roleService.GetAll();
            return Ok(data);
        }

        // GET api/<RoleController>/5
        [HttpGet("get-by-id/{id}")]
        public IActionResult GetById(int id)
        {
            var data = _roleService.GetById(id);
            var dataDto = _mapper.Map<RoleDto>(data);
            return Ok(dataDto);
        }

        // POST api/<RoleController>
        [HttpPost("create")]
        public IActionResult Create([FromBody] RoleDto model)
        {
            // map dto to entity
            var data = _mapper.Map<RoleDto, Role>(model);
            try
            {
                // save 
                _roleService.Create(data);
                var dataDto = _mapper.Map<RoleDto>(data);
                return Ok(dataDto);
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        // PUT api/<RoleController>/5
        [HttpPut("update/{id}")]
        public IActionResult Update(int id, [FromBody] RoleDto model)
        {
            // map dto to entity and set id
            var data = _mapper.Map<Role>(model);

            try
            {
                _roleService.Update(data);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        // DELETE api/<RoleController>/5
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            _roleService.Delete(id);
            return Ok();
        }
    }
}
