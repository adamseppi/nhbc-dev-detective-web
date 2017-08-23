using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using WMP.NHBC.DevDetective.CFEntityFramework.Models;
using WMP.NHBC.DevDetective.WebApi.Security.Data;

namespace WMP.NHBC.DevDetective.WebApi.Controllers
{
    [Produces("application/json")]
    [Authorize(ActiveAuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    public class FacilitySaleController : BaserContoller
    {
        public FacilitySaleController(DevDetectiveContext context, ApplicationDbContext authContext) : base(context, authContext)
        {
        }

        [HttpGet("facility/{id}")]
        public IActionResult Get(int id, [FromQuery]bool inProgressOnly)
        {

            var alwaysGetInProgressOnly = Startup.Configuration.GetValue<bool>("inProgress"); 

            if (ApplicationUser == null)
            {
                return NotFound("User Does Not Exist");
            }

            var userFacilities = GetUserFacilities();
            if (!userFacilities.Any(x => x.Id == id))
            {
                return BadRequest("User does not have access to the facility");
            }

            IEnumerable<FacilitySale> facilitySales = Context.FacilitySales.Where(x => x.FacilityId == id).Include(x=>x.FacilitySaleItems).ThenInclude(x=>x.FacilityInventoryItemType).ToList();

            if (inProgressOnly || alwaysGetInProgressOnly)
            {
                facilitySales = facilitySales.Where(x => !x.Completed);
            }
          
            return Ok(facilitySales);
        }

        [HttpGet("{id}")]
        public IActionResult GetSale(Guid id)
        {
            FacilitySale facilitySale = Context.FacilitySales.Include(x=>x.FacilitySaleItems).ThenInclude(x=>x.FacilityInventoryItemType).FirstOrDefault(x => x.Id == id);

            if (facilitySale == null)
            {
                return NotFound();
            }
            return Ok(facilitySale);
        }

        [HttpPost("{saleId}/sale")]
        public IActionResult CreateSaleItem(Guid saleId, [FromBody]FacilitySaleItem saleItem)
        {
            var sale = Context.FacilitySales.FirstOrDefault(x => x.Id == saleId);
            if (sale == null)
            {
                return NotFound("Sale does not exist");
            }

            sale.FacilitySaleItems.Add(saleItem);
            Context.SaveChanges();


            var saleItemForReturn = Context.FacilitySaleItems.Include(x => x.FacilityInventoryItemType)
                .First(x => x.Id == saleItem.Id);


            return Created($"/FacilitySale/{saleId}/sale/{saleItem.Id}", saleItem);
        }

        [HttpPut("{id}/sale")]
        public IActionResult UpdateSaleItem(Guid id, [FromBody]FacilitySaleItem saleItem)
        {

            var existingSaleItem = Context.FacilitySaleItems.FirstOrDefault(x=>x.Id == saleItem.Id);
            if (existingSaleItem == null)
            {
                return NotFound("Sale does not exist");
            }

            if (existingSaleItem.FacilitySaleId != id)
            {
                return BadRequest("Item Posted to the Wrong Sale");
            }

            existingSaleItem.Quantity = saleItem.Quantity;
            existingSaleItem.Notes = saleItem.Notes;
            existingSaleItem.FacilityInventoryItemTypeId = saleItem.FacilityInventoryItemTypeId;

            Context.FacilitySaleItems.Update(existingSaleItem);
            Context.SaveChanges();

            return Ok();
        }

        [HttpPut("{id}/complete")]
        public IActionResult CompleteSaleItem(Guid id)
        {

            var existingSale = Context.FacilitySales.Include(x=>x.FacilitySaleItems).ThenInclude(x=>x.FacilityInventoryItemType).FirstOrDefault(x => x.Id == id);
            if (existingSale == null)
            {
                return NotFound("Sale does not exist");
            }


            foreach (var item in existingSale.FacilitySaleItems)
            {
                item.Price = item.FacilityInventoryItemType.Price;
            }

            existingSale.Price = existingSale.FacilitySaleItems.Sum(x => x.Price);
            existingSale.Completed = true;
            Context.SaveChanges();
            return Ok();
        }

        [HttpGet("{facilityId}/totalRevenue")]
        public IActionResult GetTotalRevenueForFacility(int facilityId)
        {
            var userFacilities = GetUserFacilities();
            if (!userFacilities.Any(x => x.Id == facilityId))
            {
                return BadRequest("User does not have access to the facility");
            }

            IEnumerable<FacilitySale> facilitySales = Context.FacilitySales.Where(x => x.FacilityId == facilityId).Include(x => x.FacilitySaleItems).ThenInclude(x => x.FacilityInventoryItemType).ToList();

            decimal revenue = facilitySales.SelectMany(facilitySale => facilitySale.FacilitySaleItems).Sum(facilitySaleFacilitySaleItem => facilitySaleFacilitySaleItem.FacilityInventoryItemType.Price);
            return Ok(revenue);
        }
    }
}