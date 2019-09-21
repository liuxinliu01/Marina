using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
// make sure to include this namespace
using System.Data;

namespace Ch09Cart
{
    public partial class Order : System.Web.UI.Page
    {
        private Slip selectedSlip;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            //SlipGridView.DataSource = 
            //bind dropdown on first load; get and show product data on every load   
            //if (!IsPostBack) ddlDocks.DataBind();
            //selectedSlip = this.GetSelectedSlip();
            //SlipIDTextBox.Text = selectedSlip.ID.ToString();

        }

        //private Product GetSelectedProduct()
        //{
        //    //get row from AccessDataSource based on value in dropdownlist
        //    DataView productsTable = (DataView)
        //        //SqlDataSource1.Select(DataSourceSelectArguments.Empty);
        //    productsTable.RowFilter =
        //        "ProductID = '" + ddlDocks.SelectedValue + "'";
        //    DataRowView row = productsTable[0];

        //    //create a new product object and load with data from row
        //    Product p = new Product();
        //    p.ProductID = row["ProductID"].ToString();
        //    p.Name = row["Name"].ToString();
        //    p.ShortDescription = row["ShortDescription"].ToString();
        //    p.LongDescription = row["LongDescription"].ToString();
        //    p.UnitPrice = (decimal)row["UnitPrice"];
        //    p.ImageFile = row["ImageFile"].ToString();
        //    return p;
        //}

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            //    if (Page.IsValid)
            //    {
            //        //get cart from session and selected item from cart
            //        CartItemList cart = CartItemList.GetCart();
            //        CartItem cartItem = cart[selectedProduct.ProductID];

            //        //if item isn’t in cart, add it; otherwise, increase its quantity
            //        if (cartItem == null)
            //        {
            //            //cart.AddItem(selectedProduct,
            //            //             Convert.ToInt32(txtQuantity.Text));
            //        }
            //        else
            //        {
            //            //cartItem.AddQuantity(Convert.ToInt32(txtQuantity.Text));
            //        }
            //        Response.Redirect("Cart.aspx");
            //    }
        }

        protected void SlipGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedSlip = this.GetSelectedSlip();
         
            SlipIDTextBox.Text = selectedSlip.Width.ToString();

        }

        private Slip GetSelectedSlip()
        {
            Slip s= new Slip();
            GridViewRow gr = SlipGridView.SelectedRow;
            int slipID = Convert.ToInt32( gr.Cells[1].Text);
            using (SlipDataContext dbContext = new SlipDataContext())
            {
                s = (from p in dbContext.Slips
                         where p.ID == slipID
                         select p).Single();
            }
            return s;
        }

        protected void LeaseBtn_Click(object sender, EventArgs e)
        {
            List<Slip> sls = new List<Slip>();
            //Slip sl = new Slip();
            Lease l = new Lease();
            using(SlipDataContext dbContent = new SlipDataContext())
            {
                var selectedSlips = from ls in dbContent.Leases
                                    join c in dbContent.Customers on ls.CustomerID equals c.ID
                                    join s in dbContent.Slips on ls.SlipID equals s.ID
                                    join d in dbContent.Docks on s.DockID equals d.ID
                                    select new
                                    {
                                        s.ID,
                                        s.Width,
                                        s.Length,
                                        d.Name,
                                        c.LastName
                                    };
                LeaseStatusGridView.DataSource = selectedSlips;
                LeaseStatusGridView.DataBind();
                LeaseStatusLabel.Visible = true;
                LeaseStatusGridView.Visible = true;
            }
        }
    }
}