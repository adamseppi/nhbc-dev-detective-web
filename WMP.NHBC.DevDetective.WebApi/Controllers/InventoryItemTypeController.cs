using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WMP.NHBC.DevDetective.CFEntityFramework.Models;

namespace WMP.NHBC.DevDetective.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/InventoryItemType")]
    [Authorize(ActiveAuthenticationSchemes = "Bearer")]
    public class InventoryItemTypeController : Controller
    {
        private DevDetectiveContext _context;

        public InventoryItemTypeController(DevDetectiveContext context)
        {
            _context = context;
        }



        // GET: api/InventoryItemType
        [HttpGet]
        public IEnumerable<InventoryItemTypes> Get()
        {
            return _context.InventoryItemTypes;

        }

        // GET: api/InventoryItemType/5
        [HttpGet("{id}")]
        public InventoryItemTypes Get(int id)
        {
            return _context.InventoryItemTypes.First(x => x.Id == id);
        }


        // POST: api/InventoryItemType
        [HttpPost]
        [Route("Many")]
        public void Post([FromBody]IList<InventoryItemTypes> value)
        {

            _context.InventoryItemTypes.AddRange(value);
            _context.SaveChanges();

        }


        // POST: api/InventoryItemType
        [HttpPost]
        public void Post([FromBody]InventoryItemTypes value)
        {
            _context.InventoryItemTypes.Add(value);
            _context.SaveChanges();
        }

        // PUT: api/InventoryItemType/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
