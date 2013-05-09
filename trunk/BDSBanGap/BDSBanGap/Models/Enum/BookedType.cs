using BDSBanGap.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BDSBanGap.Models.Enum
{
    public class BookedType
    {
        public static string GetBookedType(BookedTypeEnum type)
        {
            return GetBookedType((int)type);
        }
        public static string GetBookedType(int type)
        {
            return GetListBookedType().Where(s => s.ItemValue == type).Select(s => s.DisplayValue).FirstOrDefault();
        }

        public static List<ComboItem> GetListBookedType()
        {
            List<ComboItem> result = new List<ComboItem>();

            result.Add(new ComboItem()
            {
                DisplayValue = "Kinh doanh",
                ItemValue = (int)BookedTypeEnum.Kinh_Doanh
            });

            result.Add(new ComboItem()
            {
                DisplayValue = "Mua bán lại",
                ItemValue = (int)BookedTypeEnum.Mua_Ban_lai
            });

            result.Add(new ComboItem()
            {
                DisplayValue = "Mua ở",
                ItemValue = (int)BookedTypeEnum.Mua_O
            });
            return result;
        }

    }
    public enum BookedTypeEnum
    {
        Kinh_Doanh = 1,
        Mua_Ban_lai = 2,
        Mua_O = 3,
    }
}