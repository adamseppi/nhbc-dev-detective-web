using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WMP.NHBC.DevDetective.CFEntityFramework.Models;

namespace WMP.NHBC.DevDetective.WebApi.Controllers
{
    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    [Route("api/FacilityInventoryItemType")]
    [Authorize(ActiveAuthenticationSchemes = "Bearer")]
    public class FacilityInventoryItemTypeController : Controller
    {
        private DevDetectiveContext _context;

        public FacilityInventoryItemTypeController(DevDetectiveContext context)
        {
            _context = context;
        }

        // GET: api/FacilityInventoryItemType/facility/{facilityId}/
        [HttpGet("facility/{facilityId}")]
        public IEnumerable<FacilityInventoryItemTypes> GetItemsForFacilty(int facilityId)
        {
            return _context.FacilityInventoryItemTypes.Where(x => x.FacilityId == facilityId).ToList();
        }

        // GET: api/FacilityInventoryItemType/5
        [HttpGet("{id}")]
        public FacilityInventoryItemTypes Get(int id)
        {
            return _context.FacilityInventoryItemTypes.FirstOrDefault(x => x.Id == id);
        }


        [HttpGet("")]
        public IActionResult Get()
        {
            return Ok(_context.FacilityInventoryItemTypes.ToList());
        }

        // POST: api/FacilityInventoryItemType
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        //        
        //        // PUT: api/FacilityInventoryItemType/5
        //        [HttpPut("{id}")]
        //        public void Put(int id, [FromBody]string value)
        //        {
        //        }
        //        
        //        // DELETE: api/ApiWithActions/5
        //        [HttpDelete("{id}")]
        //        public void Delete(int id)
        //        {
        //        }
    }
}
