using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary1;

namespace WMP.NHBC.DevDetective.WebForms.Admin
{
    public partial class ManageTenants : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        protected void SubmitForm(object sender, EventArgs e)
        {
            var tenant = new Tenant {Name = TenantName.Text, CreatedDate = DateTime.Now, UpdateDate = DateTime.Now, IsActive = true};
            var dataContext = new DevDetectiveEntities1();
            dataContext.Tenants.Add(tenant);
            
            dataContext.SaveChanges();

        
            TenantName.Text = string.Empty;
            TenantGridView.DataBind();

        }

        public IEnumerable<Tenant> SelectTenant()
        {
            var context = new DevDetectiveEntities1();
            return context.Tenants;
        }
        
        protected void TenantGridView_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            var selectedId = e.CommandArgument;
            if (e.CommandName == "ManageTenant")
            {
               Response.Redirect($"ManageTenant.aspx?id={selectedId}");
            }

        }
    }
}