using ChistesAPIRest.Models;
using ChistesAPIRest.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ChistesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChistesController : ControllerBase
    {
        private readonly ChisteService _chisteService;

        public ChistesController(ChisteService chisteService)
        {
            _chisteService = chisteService;
        }

        [HttpGet]
        public ActionResult<List<Chiste>> Get() =>
            _chisteService.Get();

        [Route("random")]
        [HttpGet]
        public ActionResult<Chiste> GetRandom() =>
            _chisteService.GetRandom();

        [HttpGet("{id:length(24)}", Name = "GetChiste")]
        public ActionResult<Chiste> Get(string id)
        {
            var chiste = _chisteService.Get(id);

            if (chiste == null)
            {
                return NotFound();
            }

            return chiste;
        }

        [HttpPost]
        public ActionResult<Chiste> Create(Chiste chiste)
        {
            if(chiste.Name == null || chiste.Author == null ) return BadRequest();
            _chisteService.Create(chiste);

            return CreatedAtRoute("GetChiste", new { id = chiste.Id.ToString() }, chiste);
        }

        [Route("like")]
        [HttpPatch]
        public ActionResult Like(string id)
        {
            if(id == null) return NotFound();
            _chisteService.Like(id);
            return Ok("Liked!");
        }

        [Route("unlike")]
        [HttpPatch]
        public ActionResult Unlike(string id)
        {
            if(id == null) return NotFound();
            _chisteService.Unlike(id);
            return Ok("Unliked!");
        }        
    }
}