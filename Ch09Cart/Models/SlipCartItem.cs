using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ch09Cart.Models
{
    public class SlipCartItem
    {
        public SlipCartItem() { }

        public SlipCartItem(Slip slip, int quantity)
        {
            this.Slip = slip;
            this.Quantity = quantity;
        }

        public Slip Slip { get; set; }
        public int Quantity { get; set; }

        public void AddQuantity(int quantity)
        {
            this.Quantity += quantity;
        }

        public string Display()
        {
            string displayString = string.Format("{0} ({1})",
               Slip.DockID,
                Quantity.ToString()
               
            );
            return displayString;
        }
    }
}