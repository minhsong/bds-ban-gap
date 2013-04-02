using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BDSBanGap.Helpers;

namespace NhaChoThue.Models.Enum
{
    public class Prices
    {
        public static List<ComboItem> GetPriceFrom()
        {
            List<ComboItem> result = new List<ComboItem>();

            result.Add(new ComboItem()
            {
                DisplayValue = "1 triệu",
                ItemValue = 1
            });

            result.Add(new ComboItem()
            {
                DisplayValue = "5 triệu",
                ItemValue = 5
            });

            result.Add(new ComboItem()
            {
                DisplayValue = "10 triệu",
                ItemValue = 10
            });

            result.Add(new ComboItem()
            {
                DisplayValue = "15 triệu",
                ItemValue = 15
            });


            result.Add(new ComboItem()
            {
                DisplayValue = "20 triệu",
                ItemValue = 20
            });


            result.Add(new ComboItem()
            {
                DisplayValue = "30 triệu",
                ItemValue = 30
            });

            result.Add(new ComboItem()
            {
                DisplayValue = "40 triệu",
                ItemValue = 40
            });

            result.Add(new ComboItem()
            {
                DisplayValue = "50 triệu",
                ItemValue = 50
            });
            return result;
        }

        public static List<ComboItem> GetPriceTo()
        {
            List<ComboItem> result = new List<ComboItem>();

            result.Add(new ComboItem()
            {
                DisplayValue = "5 triệu",
                ItemValue = 5
            });

            result.Add(new ComboItem()
            {
                DisplayValue = "10 triệu",
                ItemValue = 10
            });

            result.Add(new ComboItem()
            {
                DisplayValue = "15 triệu",
                ItemValue = 15
            });


            result.Add(new ComboItem()
            {
                DisplayValue = "20 triệu",
                ItemValue = 20
            });


            result.Add(new ComboItem()
            {
                DisplayValue = "30 triệu",
                ItemValue = 30
            });

            result.Add(new ComboItem()
            {
                DisplayValue = "40 triệu",
                ItemValue = 40
            });

            result.Add(new ComboItem()
            {
                DisplayValue = "50 triệu",
                ItemValue = 50
            });

            result.Add(new ComboItem()
            {
                DisplayValue = "60 triệu",
                ItemValue = 60
            });

            result.Add(new ComboItem()
            {
                DisplayValue = "80 triệu",
                ItemValue = 80
            });

            return result;
        }
    }
}