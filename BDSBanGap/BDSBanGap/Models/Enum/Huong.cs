using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BDSBanGap.Helpers;

namespace BDSBanGap.Models.Enum
{
    public class huong
    {
        public static string GetHuong(HuongEnum huong)
        {
            return GetHuong((int)huong);
        }
        public static string GetHuong(int huong)
        {
            return GetListHuong().Where(s => s.ItemValue == huong).Select(s => s.DisplayValue).FirstOrDefault();
        }

        public static List<ComboItem> GetListHuong()
        {
            List<ComboItem> result = new List<ComboItem>();
            result.Add(new ComboItem()
            {
                DisplayValue = "Hướng Bắc",
                ItemValue = (int)HuongEnum.Huong_Bac
            });

            result.Add(new ComboItem()
            {
                DisplayValue = "Hướng Đông",
                ItemValue = (int)HuongEnum.Huong_Dong
            });


            result.Add(new ComboItem()
            {
                DisplayValue = "Hướng Đông Bắc",
                ItemValue = (int)HuongEnum.Huong_Dong_Bac
            });


            result.Add(new ComboItem()
            {
                DisplayValue = "Hướng Đông Nam",
                ItemValue = (int)HuongEnum.Huong_Dong_Nam
            });


            result.Add(new ComboItem()
            {
                DisplayValue = "Hướng Nam",
                ItemValue = (int)HuongEnum.Huong_Nam
            });


            result.Add(new ComboItem()
            {
                DisplayValue = "Hướng Tây",
                ItemValue = (int)HuongEnum.Huong_Tay
            });


            result.Add(new ComboItem()
            {
                DisplayValue = "Hướng Tây Bắc",
                ItemValue = (int)HuongEnum.Huong_Tay_Bac
            });


            result.Add(new ComboItem()
            {
                DisplayValue = "Hướng Tây Nam",
                ItemValue = (int)HuongEnum.Huong_Tay_Nam
            });

            return result;
        }

    }
    public enum HuongEnum
    {
        Huong_Dong = 1,
        Huong_Dong_Nam = 2,
        Huong_Nam = 3,
        Huong_Tay_Nam = 4,
        Huong_Tay = 5,
        Huong_Tay_Bac = 6,
        Huong_Bac = 7,
        Huong_Dong_Bac =8,
    }
}