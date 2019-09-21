using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ch09Cart
{
    public partial class AvailableSlips : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Slip> sls = new List<Slip>();
            //Slip sl = new Slip();
            //Lease l = new Lease();
            using (SlipDataContext dbContent = new SlipDataContext())
            {
                var selectedSlips = from sl in dbContent.Slips
                                    join d in dbContent.Docks
                                    on sl.DockID equals d.ID
                                    join ls in dbContent.Leases
                                    on sl.ID equals ls.SlipID
                                    
                                    
                                    //join s in dbContent.Slips on ls.SlipID equals s.ID
                                    //join d in dbContent.Docks on s.DockID equals d.ID 
                                    into empLeases
                                    from cu in empLeases.DefaultIfEmpty()
                                    select new

                                    {
                                        sl.ID,
                                        sl.Width,
                                        sl.Length,
                                        d.Name,
                                        Slip_Status = cu == null?"Available":("Occupy")
                                    };
                availableSlipsGridView.DataSource = selectedSlips;
                availableSlipsGridView.DataBind();
                
            }
        }
    }
}