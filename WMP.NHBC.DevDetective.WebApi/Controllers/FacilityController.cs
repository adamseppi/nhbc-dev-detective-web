using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WMP.NHBC.DevDetective.CFEntityFramework.Models;
using WMP.NHBC.DevDetective.WebApi.Security.Data;
using WMP.NHBC.DevDetective.WebApi.Security.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WMP.NHBC.DevDetective.WebApi.Controllers
{
    [Produces("application/json")]
    [Authorize(ActiveAuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    public class FacilityController : BaserContoller
    {
        // GET: api/values
        public FacilityController(DevDetectiveContext context, ApplicationDbContext authContext) : base(context, authContext)
        {
        }

        [HttpGet("user/")]
        public IActionResult GetFacilitiesForUser()
        {
            if (ApplicationUser == null)
            {
                NotFound("User Does Not Exist");
            }
            var usersFacilities = GetUserFacilities(true).ToList();
            return Ok(usersFacilities);
        }

        [HttpPost("{id}/order")]
        public IActionResult CreateOrder([FromBody]ICollection<FacilityOrderItem> facilityOrderItems)
        {
            if (ApplicationUser == null)
            {
                NotFound("User Does Not Exist");
            }

            foreach (var orderItem in facilityOrderItems)
            {
                var inventoryItem = Context.FacilityInventoryItemTypes.FirstOrDefault(x => x.Id == orderItem.ProductId);
                if (inventoryItem != null)
                {
                    inventoryItem.QuantityOnOrder += orderItem.Quantity;
                }
            }
            Context.SaveChanges();

            return Ok();
        }


        [HttpPost("{id}/checkin")]
        public IActionResult CheckInInventory([FromBody]ICollection<FacilityOrderItem> facilityOrderItems)
        {
            if (ApplicationUser == null)
            {
                NotFound("User Does Not Exist");
            }

            foreach (var orderItem in facilityOrderItems)
            {
                var inventoryItem = Context.FacilityInventoryItemTypes.FirstOrDefault(x => x.Id == orderItem.ProductId);
                if (inventoryItem != null)
                {
                    inventoryItem.QuantityOnOrder -= orderItem.Quantity;//todo this is a bug for going negative if you check in stuff
                    inventoryItem.QuantityOnHand += orderItem.Quantity;
                }
            }
            Context.SaveChanges();

            return Ok();
        }

        [HttpGet("{id}/sale/new/")]
        public IActionResult GetNewSaleForFacility(int id)
        {
            if (ApplicationUser == null)
            {
                return NotFound("User Does Not Exist");
            }

            var userFacilities = GetUserFacilities();
            if (!userFacilities.Any(x => x.Id == id))
            {
                return BadRequest("User does not have access to the facility");
            }
            var sale = new FacilitySale()
            {
                FacilityId = id,
                CreatedDate = DateTime.Now
            };
            Context.FacilitySales.Add(sale);
            Context.SaveChanges();
            return Created($"/api/facilitiySale/{sale.Id}",sale);
        }

    }
}
