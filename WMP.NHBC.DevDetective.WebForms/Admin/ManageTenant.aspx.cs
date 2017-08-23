using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary1;

namespace WMP.NHBC.DevDetective.WebForms.Admin
{
    public partial class ManageTenant : System.Web.UI.Page
    {
        private int _tenantId;

        protected void Page_Load(object sender, EventArgs e)
        {
           var id = Request.QueryString["id"];
           int.TryParse(id, out _tenantId);
        }

       

        public IEnumerable<Facility> GetFacilities()
        {
            var dataContext = new DevDetectiveEntities1();
            return dataContext.Facilities.Where(x => x.TenantId == _tenantId).ToList();
        }



        protected void CreateFacility(object sender, EventArgs e)
        {
            var dataContext = new DevDetectiveEntities1();
            int parentFacilityId = -1;
            int.TryParse(ParentFacilityId.Text, out parentFacilityId);

            var faciliy = new Facility()
            {
                TenantId = _tenantId,
                CreatedDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                Name = FacilityName.Text,
               
            };

            if (parentFacilityId != -1 && parentFacilityId != 0)
            {
                faciliy.ParentFacilityId = parentFacilityId;
            }
            else
            {
                faciliy.ParentFacilityId = null;
            }

            
            dataContext.Facilities.Add(faciliy);
            dataContext.SaveChanges();

            if (InitializeDataCheckBox.Checked)
            {
                var inventoryItemTypes = dataContext.InventoryItemTypes.Where(x => x.IsActive).ToList();

                var facilityInventoryItemTypes = inventoryItemTypes.Select(inventoryItemType =>
                    new FacilityInventoryItemType()
                    {
                        FacilityId = faciliy.Id,
                        CreatedDate = DateTime.Now,
                        UpdateDate = DateTime.Now,
                        InventoryItemTypeId = inventoryItemType.Id,
                        IsActive = true,
                        Name = inventoryItemType.Name,
                        SKU = inventoryItemType.SKU,
                        QuantityOnHand = 0,
                        QuantityOnOrder = 0
                    }).ToList();

                dataContext.FacilityInventoryItemTypes.AddRange(facilityInventoryItemTypes);
                dataContext.SaveChanges();
            }
            

            FacilityGridView.DataBind();
        }

        protected void TenantsGridView_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            var selectedId = e.CommandArgument;
            if (e.CommandName == "ManageFacility")
            {
                Response.Redirect($"ManageFacility.aspx?id={selectedId}");
            }

        }

        public IEnumerable<AspNetUser> GetUsers()
        {
            var context2 = new DevDetective2Entities();
            var context1 = new DevDetectiveEntities1();

            var usersIds = context1.FacilityUsers.Where(x => x.Facility.TenantId == _tenantId).Select(x=>x.UserId).ToList();
            var users = context2.AspNetUsers.Where(x => !usersIds.Contains(x.Email));

            return users;
        }

        protected void CreateFacilityUser(object sender, EventArgs e)
        {
            var context2 = new DevDetective2Entities();
            var context1 = new DevDetectiveEntities1();

            var userEmail = UserIdTextBox.Text;

            var user = context2.AspNetUsers.FirstOrDefault(x => x.Email == userEmail);
            if (user == null)
            {
                throw new Exception("Todo add an error message");
            }

            int facilityId = -100000;
            int.TryParse(FacilityIdTextBox.Text, out facilityId);

            var facilities = context1.Facilities.Where(x => x.TenantId == _tenantId).ToList();
            var matchingFacility = facilities.FirstOrDefault(x => x.Id == facilityId);

            if (matchingFacility != null)
            {
                var fu = new FacilityUser();
                fu.UserId = userEmail;
                fu.FacilityId = matchingFacility.Id;
                matchingFacility.FacilityUsers.Add(fu);
                var childFacilities = matchingFacility.Facilities1;
                foreach (var child in childFacilities)
                {
                    var childFu = new FacilityUser();
                    childFu.UserId = userEmail;
                    matchingFacility.ParentFacilityId = _tenantId;
                    childFu.FacilityId = child.Id;
                    child.FacilityUsers.Add(childFu);
                }

            }
            else
            {
                foreach (var facility in facilities)
                {
                    var fu = new FacilityUser();
                    fu.UserId = userEmail;
                    fu.FacilityId = facility.Id;
                    facility.FacilityUsers.Add(fu);
                }
            }
            context1.SaveChanges();
        }
    }
}