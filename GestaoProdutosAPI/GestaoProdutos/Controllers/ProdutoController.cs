using Domain.Dtos;
using Domain.Dtos.Produto;
using Domain.Interfaces.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace GestaoProdutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private IProdutoService _service;
        private IFornecedorService _fornecedorService;
        public ProdutoController(IProdutoService service, IFornecedorService fornecedorService)
        {
            _service = service;
            _fornecedorService = fornecedorService;
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

        [HttpGet]
        [Route("skip/{skip}/take/{take}")]
        public async Task<ActionResult> GetWithPaginate([FromQuery] ProdutoFilterRequestDto dto, [FromRoute] int skip = 0, [FromRoute]  int take = 30 )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var registrostotais = await _service.GetAll();
                var total = registrostotais.Count();
                var registros = await _service.GetWithPaginate(dto, skip, take);


                return Ok(new { total,skip, take, data = registros });
                //return Ok(await _service.GetWithPaginate(dto, skip, take));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] ProdutoRequestDto dto)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }

            try
            {

                var fornecedor = await _fornecedorService.Get(dto.FornecedorId);
                if (fornecedor == null)
                {
                    return BadRequest("Fornecedor inexistente");
                } else
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

               
            }
            catch (ArgumentException e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProdutoRequestDto dto)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }

            try
            {
                var fornecedor = await _fornecedorService.Get(dto.FornecedorId);
                if (fornecedor == null)
                {
                    return BadRequest("Fornecedor inexistente");
                }
                else
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
            }
            catch (ArgumentException e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }
            try
            {
                ProdutoResponseDto produtoInativado;
                var produto = await _service.Get(id);
                if (produto == null)
                {
                    return BadRequest("Este produto não existe");
                } else
                {
                    produtoInativado = await _service.Inactivate(id);
                }
                

                if (produtoInativado != null)
                {

                    return Ok(produtoInativado);
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
    }
}
