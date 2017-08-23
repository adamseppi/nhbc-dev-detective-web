using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using ClassLibrary1;

namespace WMP.NHBC.DevDetective.WebForms.Admin
{
    public partial class ManageFacility : System.Web.UI.Page
    {
        private int _id;
        private Facility _facility;

        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request.QueryString["id"], out _id);

            var context = new DevDetectiveEntities1();

            _facility = context.Facilities.FirstOrDefault(x => x.Id == _id);

            if (_facility != null)
            {
                FacilityName.Text = _facility.Name;
            }
        }

        protected void SubmitForm(object sender, EventArgs e)
        {
            var context = new DevDetectiveEntities1();

            var facilityInvItem = new FacilityInventoryItemType
            {
                CreatedDate = DateTime.Now,
                FacilityId = _id,
                IsActive = true,
                Name = FacilityProductItemName.Text
            };


            context.FacilityInventoryItemTypes.Add(facilityInvItem);
            context.SaveChanges();

        }

        protected void FacilityInventoryItemGridView_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        public IEnumerable<FacilityInventoryItemType> SelectFacilityInventoryItems()
        {
            var context = new DevDetectiveEntities1();

            return context.FacilityInventoryItemTypes.Where(x => x.FacilityId == _id).ToList();

        }

        protected void SaveFacilityItems(object sender, EventArgs e)
        {
            var context = new DevDetectiveEntities1();

            var items = context.FacilityInventoryItemTypes.Where(x => x.FacilityId == _id).ToList();




            foreach (GridViewRow gridViewRow in FacilityInventoryItemGridView.Rows)
            {
                var quantityOnOrderTextBox = (TextBox) gridViewRow.FindControl("QuantityOnOrder");
                var quantityOnHandTextBox = (TextBox) gridViewRow.FindControl("QuantityOnHand");
                var priceTextBox = (TextBox) gridViewRow.FindControl("Price");
                var idLabel = (HiddenField) gridViewRow.FindControl("HiddenId");

                var id = int.Parse(idLabel.Value);

                var item = items.FirstOrDefault(x => x.Id == id);

                if (item != null)
                {

                    int quantityOnOder;
                    int quantityOnHand;
                    decimal price;

                    var qohsuccess = int.TryParse(quantityOnOrderTextBox.Text, out quantityOnHand);
                    var qoosuccess = int.TryParse(quantityOnHandTextBox.Text, out quantityOnOder);
                    var psuccess = decimal.TryParse(priceTextBox.Text, out price);

                    if (qoosuccess)
                    {
                        item.QuantityOnOrder = quantityOnOder;
                    }
                    if (qohsuccess)
                    {
                        item.QuantityOnHand = quantityOnHand;
                    }
                    if (psuccess)
                    {
                        item.Price = price;
                    }
                }
            }
            context.SaveChanges();
        }
    }
}