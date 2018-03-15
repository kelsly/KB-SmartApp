﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace NMCT.Resto.CoreM.Model
{
    public class Restaurant
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Cuisines { get; set; }
        public int PriceRange { get; set; }
        
        public string PriceRangeString {  get
            {
                int lengte = PriceRange.ToString().Length;
                string dollarSigns = "";
                for (int i = 0; i < lengte;i++)
                {
                    dollarSigns = dollarSigns + '$';
                }
                return dollarSigns;
            }
        }

        public string ImageUrl { get; set; }
        public string ThumbUrl { get; set; }

        public Location Location { get; set; }

        public List<Review> Reviews { get; set; }
        public double Score {
            get { return Reviews == null ? double.NaN : Math.Round(Reviews.Average(rev => rev.Score), 1); }
        }
    }
}
