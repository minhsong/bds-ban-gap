using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDSBanGap.Helpers
{
    /// <summary>
    /// The class is a helper class to do type-safe conversion
    /// We should avoid to use any direct type conversion, instead to collect it
    /// in one place for easier to do code maintenance in the future.
    /// </summary>
    public static class DataConvertHelper
    {
        /// <summary>
        /// Function to convert an object type to Boolean.
        /// </summary>
        /// <param name="objInputconverString">object type, indicate converString to be parsed.</param>
        /// <returns>boolean return converString</returns>
        public static Boolean ToBoolean(object objInputconverString)
        {
            //null input supposed to be false.
            Boolean blnReturnconverString = default(Boolean);
            if (objInputconverString != null)
            {
                Boolean.TryParse(objInputconverString.ToString(), out blnReturnconverString);
            }
            return blnReturnconverString;
        }

        /// <summary>
        /// Function to convert an object type to Byte.
        /// </summary>
        /// <param name="objInputconverString">object type, indicate converString to be parsed.</param>
        /// <returns>byte return converString</returns>
        public static byte ToByte(object objInputconverString)
        {
            byte bytReturnconverString = default(byte);
            if (objInputconverString != null)
            {
                byte.TryParse(objInputconverString.ToString(), out bytReturnconverString);
            }
            return bytReturnconverString;
        }

        /// <summary>
        /// Function to convert an object type to Signed Byte.
        /// </summary>
        /// <param name="objInputconverString">object type, indicate converString to be parsed.</param>
        /// <returns>SByte return converString</returns>
        public static sbyte ToSByte(object objInputconverString)
        {
            sbyte sbytReturnconverString = default(sbyte);
            if (objInputconverString != null)
            {
                sbyte.TryParse(objInputconverString.ToString(), out sbytReturnconverString);
            }
            return sbytReturnconverString;
        }

        /// <summary>
        /// Function to convert an object type to Integer.
        /// </summary>
        /// <param name="objInputconverString">object type, indicate converString to be parsed.</param>
        /// <returns>Int16 return converString</returns>
        public static short ToInt16(object objInputconverString)
        {
            short shrReturnconverString = default(short);
            if (objInputconverString != null)
            {
                short.TryParse(objInputconverString.ToString(), out shrReturnconverString);
            }
            return shrReturnconverString;
        }

        /// <summary>
        /// Function to convert an object type to Unsigned Integer.
        /// </summary>
        /// <param name="objInputconverString">object type, indicate converString to be parsed.</param>
        /// <returns>UInt16 return converString</returns>
        public static ushort ToUInt16(object objInputconverString)
        {
            ushort ushrReturnconverString = default(ushort);
            if (objInputconverString != null)
            {
                ushort.TryParse(objInputconverString.ToString(), out ushrReturnconverString);
            }
            return ushrReturnconverString;
        }

        /// <summary>
        /// Function to convert an object type to Integer.
        /// </summary>
        /// <param name="objInputconverString">object type, indicate converString to be parsed.</param>
        /// <returns>Int32 return converString</returns>
        public static int ToInt32(object objInputconverString)
        {
            int intReturnconverString = default(int);
            if (objInputconverString != null)
            {
                int.TryParse(objInputconverString.ToString(), out intReturnconverString);
            }
            return intReturnconverString;
        }

        /// <summary>
        /// Function to convert an object type to Integer.
        /// </summary>
        /// <param name="objInputconverString">object type, indicate converString to be parsed.</param>
        /// <returns>Int return converString</returns>
        public static int ToInt(object objInputconverString)
        {
            return ToInt32(objInputconverString);
        }
        /// <summary>
        /// Function to convert an object type to Short.
        /// </summary>
        /// <param name="objInputconverString">object type, indicate converString to be parsed.</param>
        /// <returns>Short return converString</returns>
        public static short ToShort(object objInputconverString)
        {
            return ToInt16(objInputconverString);
        }
        ///// <summary>
        ///// Function to convert an object type to Long.
        ///// </summary>
        ///// <param name="objInputconverString">object type, indicate converString to be parsed.</param>
        ///// <returns>Long return converString</returns>
        //public static int ToLong(object objInputconverString)
        //{
        //    return ToInt64(objInputconverString);
        //}
        /// <summary>
        /// Function to convert an object type to String.
        /// </summary>
        /// <param name="objInputconverString">object type, indicate converString to be parsed.</param>
        /// <returns>String return converString</returns>
        //public static int ToString(object objInputconverString)
        //{
        //    string stringReturnconverString = default(string);
        //    if (objInputconverString != null)
        //    {
        //        stringReturnconverString = objInputconverString.ToString();
        //    }
        //    return stringReturnconverString;
        //}
        /// <summary>
        /// Function to convert an object type to Unsigned Integer.
        /// </summary>
        /// <param name="objInputconverString">object type, indicate converString to be parsed.</param>
        /// <returns>UInt32 return converString</returns>
        public static uint ToUInt32(object objInputconverString)
        {
            uint uintReturnconverString = default(uint);
            if (objInputconverString != null)
            {
                uint.TryParse(objInputconverString.ToString(), out uintReturnconverString);
            }
            return uintReturnconverString;
        }

        /// <summary>
        /// Function to convert an object type to Long Integer.
        /// </summary>
        /// <param name="objInputconverString">object type, indicate converString to be parsed.</param>
        /// <returns>Int64 return converString</returns>
        public static long ToInt64(object objInputconverString)
        {
            long lngReturnconverString = default(long);
            if (objInputconverString != null)
            {
                long.TryParse(objInputconverString.ToString(), out lngReturnconverString);
            }
            return lngReturnconverString;
        }


        /// <summary>
        /// Function to convert an object type to Unsigned Long Integer.
        /// </summary>
        /// <param name="objInputconverString">object type, indicate converString to be parsed.</param>
        /// <returns>UInt64 return converString</returns>
        public static ulong ToUInt64(object objInputconverString)
        {
            ulong ulngReturnconverString = default(ulong);
            if (objInputconverString != null)
            {
                ulong.TryParse(objInputconverString.ToString(), out ulngReturnconverString);
            }
            return ulngReturnconverString;
        }


        /// <summary>
        /// Function to convert an object type to Single-Precision Floating-Point.
        /// </summary>
        /// <param name="objInputconverString">object type, indicate converString to be parsed.</param>
        /// <returns>float return converString</returns>
        public static float ToFloat(object objInputconverString)
        {
            float fltReturnconverString = default(float);
            if (objInputconverString != null)
            {
                float.TryParse(objInputconverString.ToString(), out fltReturnconverString);
            }
            return fltReturnconverString;
        }

        /// <summary>
        /// Function to convert an object type to Double-Precision Floating-Point.
        /// </summary>
        /// <param name="objInputconverString">object type, indicate converString to be parsed.</param>
        /// <returns>double return converString</returns>
        public static double ToDouble(object objInputconverString)
        {
            double dblReturnconverString = default(double);
            if (objInputconverString != null)
            {
                double.TryParse(objInputconverString.ToString(), out dblReturnconverString);
            }
            return dblReturnconverString;
        }


        /// <summary>
        /// Function to convert an object type to Decimal.
        /// </summary>
        /// <param name="objInputconverString">object type, indicate converString to be parsed.</param>
        /// <returns>decimal return converString</returns>
        public static decimal ToDecimal(object objInputconverString)
        {
            decimal decReturnconverString = default(decimal);
            if (objInputconverString != null)
            {
                //decimal.TryParse(objInputconverString.ToString(),System.Globalization.NumberStyles.Float, CultureInfo.InvariantCulture, out decReturnconverString);
                decimal.TryParse(objInputconverString.ToString(), out decReturnconverString);
            }
            return decReturnconverString;
        }

        /// <summary>
        /// Function to convert an object type to DateTime.
        /// </summary>
        /// <param name="objInputconverString">object type, indicate converString to be parsed.</param>
        /// <returns>DateTime return converString</returns>
        public static DateTime ToDateTime(object objInputconverString)
        {
            DateTime dtmReturnconverString = default(DateTime);
            if (objInputconverString != null)
            {
                DateTime.TryParse(objInputconverString.ToString(), out dtmReturnconverString);
            }
            return dtmReturnconverString;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objInputconverString"></param>
        /// <returns>If the input converString is null then the current time will be returned</returns>
        public static DateTime ToDateTimeFromOADate(object objInputconverString)
        {
            DateTime dtmReturnconverString = default(DateTime);
            if (objInputconverString != null)
            {
                if (objInputconverString is double)
                {
                    dtmReturnconverString = DateTime.FromOADate((double)objInputconverString);
                }
                else
                {
                    DateTime.TryParse((string)objInputconverString, out dtmReturnconverString);
                }
            }
            else
            {
                dtmReturnconverString = DateTime.Now;
            }

            return dtmReturnconverString;
        }

        /// <summary>
        /// Function to convert an object type to string.
        /// </summary>
        /// <param name="objInputconverString">object type, indicate converString to be parsed.</param>
        /// <returns>string return converString</returns>
        public static string ToString(object objInputconverString)
        {
            string dtmReturnconverString = string.Empty;
            if (objInputconverString != null)
            {
                dtmReturnconverString = objInputconverString.ToString();
            }
            return dtmReturnconverString;
        }

        public static int getWeek(DateTime date)
        {
            System.Globalization.CultureInfo cult_info = System.Globalization.CultureInfo.CreateSpecificCulture("no");
            System.Globalization.Calendar cal = cult_info.Calendar;
            int weekCount = cal.GetWeekOfYear(date, cult_info.DateTimeFormat.CalendarWeekRule, cult_info.DateTimeFormat.FirstDayOfWeek);
            return weekCount;

        }

        public static bool IsContaintIgnoreCulture(string StringValue, string containValue)
        {
            StringValue = VietHoaKhongDau(StringValue).ToLower();
            containValue = VietHoaKhongDau(containValue).ToLower();
            bool result = StringValue.Contains(containValue);
            return result;
        }

        public static string VietHoaKhongDau(string converString)
        {
            converString = ToString(converString);  

            //---------------------------------a^ 
            converString = converString.Replace("ấ", "a");
            converString = converString.Replace("ầ", "a");
            converString = converString.Replace("ẩ", "a");
            converString = converString.Replace("ẫ", "a");
            converString = converString.Replace("ậ", "a");
            //---------------------------------A^ 
            converString = converString.Replace("Ấ", "A");
            converString = converString.Replace("Ầ", "A");
            converString = converString.Replace("Ẩ", "A");
            converString = converString.Replace("Ẫ", "A");
            converString = converString.Replace("Ậ", "A");
            //---------------------------------a( 
            converString = converString.Replace("ắ", "a");
            converString = converString.Replace("ằ", "a");
            converString = converString.Replace("ẳ", "a");
            converString = converString.Replace("ẵ", "a");
            converString = converString.Replace("ặ", "a");
            //---------------------------------A( 
            converString = converString.Replace("Ắ", "A");
            converString = converString.Replace("Ằ", "A");
            converString = converString.Replace("Ẳ", "A");
            converString = converString.Replace("Ẵ", "A");
            converString = converString.Replace("Ặ", "A");
            //---------------------------------a 
            converString = converString.Replace("á", "a");
            converString = converString.Replace("à", "a");
            converString = converString.Replace("ả", "a");
            converString = converString.Replace("ã", "a");
            converString = converString.Replace("ạ", "a");
            converString = converString.Replace("â", "a");
            converString = converString.Replace("ă", "a");
            //---------------------------------A 
            converString = converString.Replace("Á", "A");
            converString = converString.Replace("À", "A");
            converString = converString.Replace("Ả", "A");
            converString = converString.Replace("Ã", "A");
            converString = converString.Replace("Ạ", "A");
            converString = converString.Replace("Â", "A");
            converString = converString.Replace("Ă", "A");
            //---------------------------------e^ 
            converString = converString.Replace("ế", "e");
            converString = converString.Replace("ề", "e");
            converString = converString.Replace("ể", "e");
            converString = converString.Replace("ễ", "e");
            converString = converString.Replace("ệ", "e");
            //---------------------------------E^ 
            converString = converString.Replace("Ế", "E");
            converString = converString.Replace("Ề", "E");
            converString = converString.Replace("Ể", "E");
            converString = converString.Replace("Ễ", "E");
            converString = converString.Replace("Ệ", "E");
            //---------------------------------e 
            converString = converString.Replace("é", "e");
            converString = converString.Replace("è", "e");
            converString = converString.Replace("ẻ", "e");
            converString = converString.Replace("ẽ", "e");
            converString = converString.Replace("ẹ", "e");
            converString = converString.Replace("ê", "e");
            //---------------------------------E 
            converString = converString.Replace("É", "E");
            converString = converString.Replace("È", "E");
            converString = converString.Replace("Ẻ", "E");
            converString = converString.Replace("Ẽ", "E");
            converString = converString.Replace("Ẹ", "E");
            converString = converString.Replace("Ê", "E");
            //---------------------------------i 
            converString = converString.Replace("í", "i");
            converString = converString.Replace("ì", "i");
            converString = converString.Replace("ỉ", "i");
            converString = converString.Replace("ĩ", "i");
            converString = converString.Replace("ị", "i");
            //---------------------------------I 
            converString = converString.Replace("Í", "I");
            converString = converString.Replace("Ì", "I");
            converString = converString.Replace("Ỉ", "I");
            converString = converString.Replace("Ĩ", "I");
            converString = converString.Replace("Ị", "I");
            //---------------------------------o^ 
            converString = converString.Replace("ố", "o");
            converString = converString.Replace("ồ", "o");
            converString = converString.Replace("ổ", "o");
            converString = converString.Replace("ỗ", "o");
            converString = converString.Replace("ộ", "o");
            //---------------------------------O^ 
            converString = converString.Replace("Ố", "O");
            converString = converString.Replace("Ồ", "O");
            converString = converString.Replace("Ổ", "O");
            converString = converString.Replace("Ô", "O");
            converString = converString.Replace("Ộ", "O");
            //---------------------------------o* 
            converString = converString.Replace("ớ", "o");
            converString = converString.Replace("ờ", "o");
            converString = converString.Replace("ở", "o");
            converString = converString.Replace("ỡ", "o");
            converString = converString.Replace("ợ", "o");
            //---------------------------------O* 
            converString = converString.Replace("Ớ", "O");
            converString = converString.Replace("Ờ", "O");
            converString = converString.Replace("Ở", "O");
            converString = converString.Replace("Ỡ", "O");
            converString = converString.Replace("Ợ", "O");
            //---------------------------------u* 
            converString = converString.Replace("ứ", "u");
            converString = converString.Replace("ừ", "u");
            converString = converString.Replace("ử", "u");
            converString = converString.Replace("ữ", "u");
            converString = converString.Replace("ự", "u");
            //---------------------------------U* 
            converString = converString.Replace("Ứ", "U");
            converString = converString.Replace("Ừ", "U");
            converString = converString.Replace("Ử", "U");
            converString = converString.Replace("Ữ", "U");
            converString = converString.Replace("Ự", "U");
            //---------------------------------y 
            converString = converString.Replace("ý", "y");
            converString = converString.Replace("ỳ", "y");
            converString = converString.Replace("ỷ", "y");
            converString = converString.Replace("ỹ", "y");
            converString = converString.Replace("ỵ", "y");
            //---------------------------------Y 
            converString = converString.Replace("Ý", "Y");
            converString = converString.Replace("Ỳ", "Y");
            converString = converString.Replace("Ỷ", "Y");
            converString = converString.Replace("Ỹ", "Y");
            converString = converString.Replace("Ỵ", "Y");
            //---------------------------------DD 
            converString = converString.Replace("Đ", "D");
            converString = converString.Replace("Đ", "D");
            converString = converString.Replace("đ", "d");
            //---------------------------------o 
            converString = converString.Replace("ó", "o");
            converString = converString.Replace("ò", "o");
            converString = converString.Replace("ỏ", "o");
            converString = converString.Replace("õ", "o");
            converString = converString.Replace("ọ", "o");
            converString = converString.Replace("ô", "o");
            converString = converString.Replace("ơ", "o");
            //---------------------------------O 
            converString = converString.Replace("Ó", "O");
            converString = converString.Replace("Ò", "O");
            converString = converString.Replace("Ỏ", "O");
            converString = converString.Replace("Õ", "O");
            converString = converString.Replace("Ọ", "O");
            converString = converString.Replace("Ô", "O");
            converString = converString.Replace("Ơ", "O");
            //---------------------------------u 
            converString = converString.Replace("ú", "u");
            converString = converString.Replace("ù", "u");
            converString = converString.Replace("ủ", "u");
            converString = converString.Replace("ũ", "u");
            converString = converString.Replace("ụ", "u");
            converString = converString.Replace("ư", "u");
            //---------------------------------U 
            converString = converString.Replace("Ú", "U");
            converString = converString.Replace("Ù", "U");
            converString = converString.Replace("Ủ", "U");
            converString = converString.Replace("Ũ", "U");
            converString = converString.Replace("Ụ", "U");
            converString = converString.Replace("Ư", "U");
            //--------------------------------- 
            return converString;
        }
    }
}
