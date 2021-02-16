using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        IBrandServis _brandServis;
        public BrandsController(IBrandServis brandServis)
        {
            _brandServis = brandServis;
        }
        [HttpPost("add")]
        public IActionResult Add(Brand brand)
        {
            var result = _brandServis.Add(brand);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(Brand brand)
        {
            var result = _brandServis.Delete(brand);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult Update(Brand brand)
        {
            var result = _brandServis.Update(brand);
            if (result.Success)
            {
                return Ok(result);
  
            }
            return BadRequest(result);
        }       

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _brandServis.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int brandId)
        {
            var result = _brandServis.GetById(brandId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}