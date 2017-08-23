using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WMP.NHBC.DevDetective.CFEntityFramework.Models;
using WMP.NHBC.DevDetective.WebApi.Security.Data;
using WMP.NHBC.DevDetective.WebApi.Security.Models;

namespace WMP.NHBC.DevDetective.WebApi.Controllers
{
    public class BaserContoller : Controller
    {
        private readonly ApplicationDbContext _authContext;
        private ApplicationUser _applicationUser;
        protected DevDetectiveContext Context { get; }

        public BaserContoller(DevDetectiveContext context, ApplicationDbContext authContext)
        {
            _authContext = authContext;
            Context = context;
        }

        protected IQueryable<Facilities> GetUserFacilities(bool getRevenue = false)
        {
            var facilities = Context.FacilityUsers.Where(x => x.UserId == ApplicationUser.UserName)
                .Select(x => x.Facility);

            if (getRevenue)
            {
                foreach (var facility in facilities)
                {
                    IEnumerable<FacilitySale> facilitySales =
                        Context.FacilitySales.Where(x => x.FacilityId == facility.Id || x.Facility.ParentFacilityId == facility.Id).Include(x => x.FacilitySaleItems)
                            .ThenInclude(x => x.FacilityInventoryItemType);
                    decimal revenue = facilitySales.Where(x=>x.Completed).SelectMany(facilitySale => facilitySale.FacilitySaleItems)
                        .Sum(facilitySaleFacilitySaleItem => facilitySaleFacilitySaleItem.Price);
                    facility.TotalRevenue = revenue;
                }
            }
            return facilities;
        }

        protected ApplicationUser ApplicationUser
        {
            get
            {
                _applicationUser = _applicationUser ?? _authContext.Users.FirstOrDefault(x => x.UserName == User.Claims.First().Value);
                return _applicationUser;
            }
        }
    }
}