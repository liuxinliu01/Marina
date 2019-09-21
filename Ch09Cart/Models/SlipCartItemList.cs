using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ch09Cart.Models
{
    public class SlipCartItemList
    {
        private List<SlipCartItem> slipcartItems;

        public SlipCartItemList()
        {
            slipcartItems = new List<SlipCartItem>();
        }

        public int Count
        {
            get { return slipcartItems.Count; }
        }

        public SlipCartItem this[int index]
        {
            get { return slipcartItems[index]; }
            set { slipcartItems[index] = value; }
        }

        public SlipCartItem this[string id]
        {
            
            get
            {
                foreach (SlipCartItem c in slipcartItems)

                    if (c.Slip.SlipID == Convert.ToInt32( id)) return c;

                return null;
            }
        }

        public static SlipCartItemList GetCart()
        {
            SlipCartItemList cart = (SlipCartItemList)HttpContext.Current.Session["Cart"];
            if (cart == null)
                HttpContext.Current.Session["Cart"] = new CartItemList();
            return (SlipCartItemList)HttpContext.Current.Session["Cart"];
        }

        public void AddItem(Slip Slip, int quantity)
        {
            SlipCartItem c = new SlipCartItem(Slip, quantity);
            slipcartItems.Add(c);
        }

        public void RemoveAt(int index)
        {
            slipcartItems.RemoveAt(index);
        }

        public void Clear()
        {
            slipcartItems.Clear();
        }
    }
}