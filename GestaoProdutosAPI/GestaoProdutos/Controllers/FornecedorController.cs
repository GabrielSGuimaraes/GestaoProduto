using Domain.Dtos.Fornecedor;
using Domain.Interfaces.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace GestaoProdutos.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private IFornecedorService _service;
        public FornecedorController(IFornecedorService service)
        {
            _service = service;
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                return Ok(await _service.GetAll());
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                return Ok(await _service.Get(id));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] FornecedorDto dto)
        {
            if (!ModelState.IsValid)
            {
                
                return BadRequest(ModelState);
            }   

            try
            {
                var result = await _service.Put(dto);
                if (result != null)
                {
                    
                    return Ok(result);
                }
                else
                {
                    
                    return BadRequest();
                }
            }
            catch (ArgumentException e)
            {
                
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] FornecedorDto dto)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.Post(dto);
                if (result != null)
                {
                    
                    return Ok(result);
                }
                else
                {
                    
                    return BadRequest();
                }
            }
            catch (ArgumentException e)
            {
                
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        
        //[HttpDelete("{id}")]
        //public async Task<ActionResult> Delete(int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
                
        //        return BadRequest(ModelState);
        //    }
        //    try
        //    {
        //        var result = await _service.Delete(id);
                
        //        return Ok(result);
        //    }
        //    catch (ArgumentException e)
        //    {
                
        //        return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
        //    }
        //}
    }
}
