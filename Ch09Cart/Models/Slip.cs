﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ch09Cart.Models
{
    public class Slip
    {
        public int SlipID { get; set; }
        public int Width { get; set; }

        public int Length { get; set; }

        public int DockID { get; set; }
    }
}